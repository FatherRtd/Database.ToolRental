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
    <template v-if="user" #start>
      <b-navbar-item
        v-if="!user.isAdmin"
        tag="router-link"
        :to="{ name: 'orders' }"
      >
        Мои заказы
      </b-navbar-item>
      <b-navbar-item
        v-if="user.isAdmin"
        tag="router-link"
        :to="{ name: 'orders' }"
      >
        Управление заказами
      </b-navbar-item>
      <b-navbar-item
        v-if="user.isAdmin"
        tag="router-link"
        :to="{ name: 'orders' }"
      >
        Управление товарами
      </b-navbar-item>
    </template>

    <template #end>
      <b-navbar-item v-if="!user" tag="div">
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
      <b-navbar-item v-else tag="div">
        <span class="mr-3">{{ user.fullName }}</span>
        <b-button type="is-danger" @click="logOut">Выйти</b-button>
      </b-navbar-item>
    </template>
  </b-navbar>
</template>

<script lang="ts">
import router from "@/router/router";
import User from "@/store/models/User";
import Vue from "vue";

export default Vue.extend({
  methods: {
    logOut() {
      localStorage.removeItem("toolrentaltoken");
      this.$store.commit("setUser", null);
      if (router.currentRoute.name != "main") {
        router.push({ name: "main" });
      }
    },
  },
  computed: {
    user(): User | null {
      return this.$store.state.user;
    },
  },
});
</script>

<style></style>
