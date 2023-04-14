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
    const url = "https://localhost:7068/api/Product/GetProductById";
    return await axios.post<string>(url, {
      name: name,
      shortDescription: shortDescription,
      longDescription: longDescription,
      rentalPrice: rentalPrice,
      image: image,
      categoryId: categoryId,
    });
  },
};
