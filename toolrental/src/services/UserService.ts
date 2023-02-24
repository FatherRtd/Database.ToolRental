import IUser from "@/store/models/User";
import axios, { AxiosResponse } from "axios";
import md5 from "md5";

export default {
  async logIn(
    login: string,
    password: string
  ): Promise<AxiosResponse<IUser[]>> {
    const url = "https://localhost:7068/api/User/LogIn";
    const passwordHash = md5(password);

    return await axios.post<IUser[]>(url, {
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
  ): Promise<AxiosResponse<IUser[]>> {
    const url = "https://localhost:7068/api/User/CreateUser";
    const passwordHash = md5(password);

    return await axios.post<IUser[]>(url, {
      login: login,
      password: passwordHash,
      firstName: name,
      lastName: surName,
    });
  },
};
