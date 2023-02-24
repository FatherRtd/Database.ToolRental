<template>
  <b-navbar
    class="navbar"
    :shadow="true"
    :fixed-top="true"
    :transparent="true"
    :mobile-burger="true"
  >
    <template #brand>
      <b-navbar-item tag="router-link" :to="{ name: 'main' }">
        <img src="../assets/toolrental.png" alt="ToolRental" />
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
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  mounted: function () {
    console.log(localStorage.getItem("toolrentaltoken"));
  },
});
</script>

<style></style>
