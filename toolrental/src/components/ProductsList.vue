<template>
  <section class="container">
    <div v-for="product in products" :key="product.id">
      <product-card :product="product"></product-card>
    </div>
  </section>
</template>

<script lang="ts">
import Product from "@/store/models/Product";
import Vue from "vue";
import ProductCard from "./ProductCard.vue";

export default Vue.extend({
  components: {
    ProductCard,
  },
  props: {
    products: { type: Array as () => Array<Product> },
  },
});
</script>

<style>
.container {
  display: grid;
  grid-template-columns: repeat(auto-fit, 300px);
  row-gap: 10px;
  column-gap: 10px;
  justify-content: center;
}
</style>
