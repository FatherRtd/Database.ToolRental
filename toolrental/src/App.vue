<template>
  <div id="app">
    <b-navbar
      class="navbar"
      :shadow="true"
      :fixed-top="true"
      :transparent="true"
      :mobile-burger="true"
    >
      <template #brand>
        <b-navbar-item tag="router-link" :to="{ name: 'main' }">
          <img src="./assets/toolrental.png" alt="ToolRental" />
        </b-navbar-item>
      </template>
      <template #start>
        <b-navbar-item tag="router-link" :to="{ name: 'orders' }">
          Мои заказы
        </b-navbar-item>
      </template>

      <template #end>
        <b-navbar-item tag="div">
          <b-button
            tag="router-link"
            class="mr-2"
            type="is-danger"
            :to="{ name: 'signup' }"
            >Зарегестрироваться</b-button
          >
          <b-button tag="router-link" type="is-info" :to="{ name: 'login' }"
            >Войти</b-button
          >
        </b-navbar-item>
      </template>
    </b-navbar>
    <router-view class="pt-3"></router-view>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  components: {},
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
