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
};
