using System.Net;
using Microsoft.EntityFrameworkCore;
using ToolRental.API.Models;
using ToolRental.API.Models.Request;
using Product = ToolRental.API.Models.Response.Product;
using Amazon.S3;
using Amazon.S3.Model;

namespace ToolRental.API.Services
{
	public class ProductService: IProductService
	{
		private readonly ToolrentalContext _dbContext;
		private readonly IConfiguration _config;

		public ProductService(ToolrentalContext dbContext, IConfiguration config)
		{
			_dbContext = dbContext;
			_config = config;
		}

		public async Task<IEnumerable<Models.Response.Product>> GetProducts()
		{
			var response =  await _dbContext.Products.Include(pc => pc.Category.Parent).ToListAsync();
			return ToProductResponse(response);
		}

		public async Task<IEnumerable<Models.Response.Product>> GetProductsByCategoryId(int id)
		{
			var response = await _dbContext.Products.Where(p => p.CategoryId == id).Include(pc => pc.Category.Parent)
				.ToListAsync();
			return ToProductResponse(response);
		}

		public async Task<Models.Response.Product> GetProductById(int id)
		{
			var response = await _dbContext.Products.Where(x => x.Id == id).Include(pc => pc.Category.Parent)
				.ToListAsync();
			return ToProductResponse(response).FirstOrDefault();
		}

		public async Task<string> AddProduct(ProductRequest request)
		{
			var path = "./.tmp" + request.Image.FileName;
			await using (var fileStream = new FileStream(path, FileMode.Create))
				await request.Image.CopyToAsync(fileStream);

			var accessKey = _config["S3Storage:S3_KEY"];
			var secretKey = _config["S3Storage:S3_SECRET"];
			var bucketName = _config["S3Storage:S3_BUCKET"];
			var region = _config["S3Storage:S3_REGION"];
			var endpoint = _config["S3Storage:S3_ENDPOINT"];
			try
			{
				var s3Config = new AmazonS3Config
				{
					ServiceURL = endpoint,
					AuthenticationRegion = region,
				};
				var s3Client = new AmazonS3Client(accessKey, secretKey, s3Config);

				var objectRequest = new PutObjectRequest
				{
					BucketName = bucketName,
					Key = request.Image.FileName,
					FilePath = path
				};

				var response = await s3Client.PutObjectAsync(objectRequest);

				if (response.HttpStatusCode != HttpStatusCode.OK)
				{
					throw new Exception();
				}
			}
			catch(Exception ex)
			{
				throw new Exception();
			}
			finally
			{
				File.Delete(path);
			}


			var imageSrc = endpoint + $"/{bucketName}" + $"/{request.Image.FileName}";


			var category = await _dbContext.Categories.Where(x => x.Id == request.CategoryId).FirstOrDefaultAsync();
			var query = await _dbContext.Products.AddAsync(new Models.Product
			{
				Name = request.Name,
				LongDescription = request.LongDescription,
				ShortDescription = request.ShortDescription,
				RentalPrice = request.RentalPrice,
				Image = imageSrc,
				IsInStock = true,
				Category = category
			});

			_dbContext.SaveChanges();

			return "Товар успешно добавлен.";
		}

		private IEnumerable<Models.Response.Product> ToProductResponse(IEnumerable<Models.Product> products)
		{
			List<Models.Response.Product> response = new List<Models.Response.Product>();

			foreach (var product in products)
			{
				response.Add(new Models.Response.Product
				{
					Id = product.Id,
					Name = product.Name,
					ShortDescription = product.ShortDescription,
					LongDescription = product.LongDescription,
					RentalPrice = product.RentalPrice,
					IsInStock = product.IsInStock,
					ImageSrc = product.Image,
					Category = new Models.Response.Category
					{
						Id = product.Category.Id,
						Name = product.Category.Name,
						ParentCategory = product.Category.Parent == null ? null : new Models.Response.Category
						{
							Id = product.Category.Parent.Id,
							Name = product.Category.Parent.Name,
							ParentCategory = null
						}
					}
				});
			}

			return response;
		}
	}
}
