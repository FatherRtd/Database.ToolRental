<template>
  <section>
    <div class="login">
      <b-field label="Логин">
        <b-input placeholder="Введите логин" v-model="login"></b-input>
      </b-field>
      <b-field label="Пароль">
        <b-input
          type="password"
          placeholder="Введите пароль"
          v-model="password"
        ></b-input>
      </b-field>
      <b-button type="is-info" @click="logIn">Войти</b-button>
    </div>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
import userService from "@/services/UserService";
import router from "@/router/router";
import User from "@/store/models/User";
import jwtDecode from "jwt-decode";
import UserService from "@/services/UserService";

export default Vue.extend({
  data() {
    return {
      login: "",
      password: "",
    };
  },
  methods: {
    logIn: async function () {
      const result = await userService.logIn(this.login, this.password);
      localStorage.setItem("toolrentaltoken", result.data);

      const user = jwtDecode<User>(result.data);
      const responseUser = await UserService.getUser(user.id);
      this.$store.commit("setUser", new User(responseUser.data));

      if (result.status == 200) {
        router.push({ name: "main" });
      }
    },
  },
});
</script>

<style>
.login {
  width: 500px;
  height: 400px;
  margin: 0 auto;
}
</style>
