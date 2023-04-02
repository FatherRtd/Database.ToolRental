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

  async getAllRentalOrders(): Promise<AxiosResponse<IRentalOrder[]>> {
    const url = "https://localhost:7068/api/RentalOrder/GetAllRentalOrders";
    const token = localStorage.getItem("toolrentaltoken");
    return await axios.get<IRentalOrder[]>(url, {
      headers: { Authorization: `Bearer ${token}` },
    });
  },

  async acceptRentalOrder(
    orderId: number
  ): Promise<AxiosResponse<IRentalOrder>> {
    const url = "https://localhost:7068/api/RentalOrder/AcceptRentalOrder";
    const token = localStorage.getItem("toolrentaltoken");
    return await axios.get<IRentalOrder>(url, {
      params: { orderId: orderId },
      headers: { Authorization: `Bearer ${token}` },
    });
  },

  async completeRentalOrder(
    orderId: number
  ): Promise<AxiosResponse<IRentalOrder>> {
    const url = "https://localhost:7068/api/RentalOrder/CompleteRentalOrder";
    const token = localStorage.getItem("toolrentaltoken");
    return await axios.get<IRentalOrder>(url, {
      params: { orderId: orderId },
      headers: { Authorization: `Bearer ${token}` },
    });
  },

  async add(newOrder: IRentalOrder): Promise<AxiosResponse<string>> {
    const url = "https://localhost:7068/api/RentalOrder/CreateRentalOrder";
    const token = localStorage.getItem("toolrentaltoken");
    return await axios.post<string>(url, newOrder, {
      headers: { Authorization: `Bearer ${token}` },
    });
  },
};
