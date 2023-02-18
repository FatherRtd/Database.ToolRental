<template>
  <section>
    <div class="signup">
      <b-field label="Имя">
        <b-input placeholder="Введите имя"></b-input>
      </b-field>
      <b-field label="Фамилия">
        <b-input placeholder="Введите фамилию"></b-input>
      </b-field>
      <b-field label="Логин">
        <b-input placeholder="Введите логин"></b-input>
      </b-field>
      <b-field label="Пароль">
        <b-input type="password" placeholder="Введите пароль"></b-input>
      </b-field>
      <b-button type="is-info">Зарегестрироваться</b-button>
    </div>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({});
</script>

<style>
.signup {
  width: 500px;
  height: 400px;
  margin: 0 auto;
}
</style>
