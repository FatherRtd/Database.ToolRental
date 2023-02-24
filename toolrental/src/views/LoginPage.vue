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
      <b-button type="is-info" @click="logIn()">Войти</b-button>
    </div>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
import userService from "@/services/UserService";
import router from "@/router/router";

export default Vue.extend({
  data() {
    return {
      login: "",
      password: "",
    };
  },
  methods: {
    logIn: async function (): Promise<void> {
      const result = await userService.logIn(this.login, this.password);

      localStorage.setItem("toolrentaltoken", result.data.token);
      console.log(result.data);
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
