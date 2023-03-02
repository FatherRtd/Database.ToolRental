<template>
  <div id="app">
    <NavBar />
    <router-view class="pt-3"></router-view>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import NavBar from "@/components/NavBar.vue";
import User from "./store/models/User";

export default Vue.extend({
  components: {
    NavBar,
  },
  data() {
    return {
      user: null as User | null,
    };
  },
  async mounted() {
    this.$store.dispatch("getUser");
  },
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
