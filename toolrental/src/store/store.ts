import UserService from "@/services/UserService";
import jwtDecode from "jwt-decode";
import Vue from "vue";
import Vuex from "vuex";
import User from "./models/User";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    user: null as User | null,
  },
  getters: {
    getUser(state): User | null {
      return state.user;
    },
  },
  mutations: {
    setUser(state, user: User | null) {
      state.user = user;
    },
  },
  actions: {
    async getUser(context) {
      const token = localStorage.getItem("toolrentaltoken");
      if (token) {
        const user = jwtDecode<User>(token);
        try {
          const response = await UserService.getUser(user.id);
          context.commit("setUser", new User(response.data));
        } catch (e) {
          console.error(e);
          context.commit("setUser", null);
          localStorage.removeItem("toolrentaltoken");
        }
      }
    },
  },
});
