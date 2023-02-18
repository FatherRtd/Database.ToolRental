<template>
  <section>
    <div class="login">
      <b-field label="Логин">
        <b-input placeholder="Введите логин"></b-input>
      </b-field>
      <b-field label="Пароль">
        <b-input type="password" placeholder="Введите пароль"></b-input>
      </b-field>
      <b-button type="is-info">Войти</b-button>
    </div>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({});
</script>

<style>
.login {
  width: 500px;
  height: 400px;
  margin: 0 auto;
}
</style>
