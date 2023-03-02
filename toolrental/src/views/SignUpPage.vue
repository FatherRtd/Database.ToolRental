<template>
  <section>
    <div class="signup">
      <b-field label="Имя">
        <b-input placeholder="Введите имя" v-model="firstName"></b-input>
      </b-field>
      <b-field label="Фамилия">
        <b-input placeholder="Введите фамилию" v-model="lastName"></b-input>
      </b-field>
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
      <b-button type="is-info" @click="signUp()">Зарегестрироваться</b-button>
    </div>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
import userService from "@/services/UserService";

export default Vue.extend({
  data() {
    return {
      login: "",
      password: "",
      firstName: "",
      lastName: "",
    };
  },
  methods: {
    signUp: async function (): Promise<void> {
      const result = await userService.signUp(
        this.login,
        this.password,
        this.firstName,
        this.lastName
      );
    },
  },
});
</script>

<style>
.signup {
  width: 500px;
  height: 400px;
  margin: 0 auto;
}
</style>
