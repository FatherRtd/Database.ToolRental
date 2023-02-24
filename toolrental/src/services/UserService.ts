import UserResponse from "@/store/models/UserResponse";
import axios, { AxiosResponse } from "axios";
import md5 from "md5";

export default {
  async logIn(
    login: string,
    password: string
  ): Promise<AxiosResponse<UserResponse>> {
    const url = "https://localhost:7068/api/Auth/LogIn";
    const passwordHash = md5(password);
    return await axios.post<UserResponse>(url, {
      login: login,
      password: passwordHash,
      name: "",
      surName: "",
    });
  },

  async signUp(
    login: string,
    password: string,
    name: string,
    surName: string
  ): Promise<AxiosResponse<string>> {
    const url = "https://localhost:7068/api/Auth/CreateUser";
    const passwordHash = md5(password);

    return await axios.post<string>(url, {
      login: login,
      password: passwordHash,
      firstName: name,
      lastName: surName,
    });
  },
};
