import ICategory from "@/store/models/Category";
import axios, { AxiosResponse } from "axios";

export default {
  async getCategories(): Promise<AxiosResponse<ICategory[]>> {
    const url = "https://localhost:7068/api/Category/GetCategories";
    return await axios.get<ICategory[]>(url);
  },
};
