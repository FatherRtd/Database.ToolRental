<template>
  <div class="productPage">
    <b-loading :is-full-page="true" v-model="isLoading"></b-loading>
    <div v-if="!isLoading">
      <b>{{ product.name }}</b>
      <b-image class="image" :src="product.imageSrc"></b-image>
      <div class="mt-3">
        <h2>{{ product.longDescription }}</h2>
      </div>
      <b-button class="mt-3" type="is-info" @click="openOrderModal"
        >Оформить заказ</b-button
      >
    </div>
  </div>
</template>

<script lang="ts">
import Product from "@/store/models/Product";
import productService from "@/services/ProductService";
import Vue from "vue";

export default Vue.extend({
  data() {
    return {
      product: null as Product | null,
      isLoading: false,
    };
  },
  methods: {
    openOrderModal() {
      console.log("modal open");
    },
  },
  beforeMount: async function () {
    try {
      this.isLoading = true;
      const response = await productService.getProductById(
        Number(this.$route.params.productId)
      );
      this.product = new Product(response.data);
    } finally {
      this.isLoading = false;
    }
  },
});
</script>

<style scoped>
.productPage {
  margin: 0 100px;
  margin-top: 100px;
}
.image {
  width: 400px;
}
</style>
