<template>
  <section class="is-flex">
    <categories class="categories mr-2" :categories="categories"></categories>
    <products-list :products="products"></products-list>
  </section>
</template>

<script lang="ts">
import Categories from "@/components/Categories.vue";
import ProductsList from "@/components/ProductsList.vue";
import productService from "@/services/ProductService";
import categoryService from "@/services/CategoryService";
import Category from "@/store/models/Category";
import Product from "@/store/models/Product";
import Vue from "vue";

export default Vue.extend({
  components: { ProductsList, Categories },
  data() {
    return {
      products: [] as Product[],
      categories: [] as Category[],
    };
  },
  mounted: async function () {
    const requestProducts = await productService.getAllProducts();
    this.products = requestProducts.data.map((x) => new Product(x));
    const requestCategories = await categoryService.getCategories();
    this.categories = requestCategories.data.map((x) => new Category(x));
  },
});
</script>

<style></style>
