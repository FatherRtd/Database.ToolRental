import IProduct from "@/store/models/Product";
import axios, { AxiosResponse } from "axios";

export default {
  async getAllProducts(): Promise<AxiosResponse<IProduct[]>> {
    const url = "https://localhost:7068/api/Product/GetProducts";
    return await axios.get<IProduct[]>(url);
  },

  async getProductsByCategory(id: string): Promise<AxiosResponse<IProduct[]>> {
    const url = "https://localhost:7068/api/Product/GetProductsByCategoryId";
    return await axios.get<IProduct[]>(url, { params: { id: id } });
  },

  async getProductById(id: number): Promise<AxiosResponse<IProduct>> {
    const url = "https://localhost:7068/api/Product/GetProductById";
    return await axios.get<IProduct>(url, { params: { id: id } });
  },

  async addProduct(
    name: string,
    shortDescription: string,
    longDescription: string,
    rentalPrice: number,
    image: File,
    categoryId: number
  ): Promise<AxiosResponse<string>> {
    const url = "https://localhost:7068/api/Product/AddProduct";
    const formData = new FormData();
    formData.append("name", name);
    formData.append("shortDescription", shortDescription);
    formData.append("longDescription", longDescription);
    formData.append("rentalPrice", rentalPrice.toString());
    formData.append("image", image);
    formData.append("categoryId", categoryId.toString());
    return await axios.post<string>(url, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  },
};
