import IRentalOrder from "@/store/models/RentalOrder";
import axios, { AxiosResponse } from "axios";

export default {
  async getRentalOrders(
    userId: number
  ): Promise<AxiosResponse<IRentalOrder[]>> {
    const url = "https://localhost:7068/api/RentalOrder/GetRentalOrders";
    const token = localStorage.getItem("toolrentaltoken");
    return await axios.get<IRentalOrder[]>(url, {
      params: { userId: userId },
      headers: { Authorization: `Bearer ${token}` },
    });
  },
};
