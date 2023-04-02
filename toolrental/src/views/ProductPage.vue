<template>
  <div class="productPage">
    <b-loading :is-full-page="true" v-model="isLoading"></b-loading>
    <div v-if="!isLoading">
      <b>{{ product.name }}</b>
      <b-image class="image" :src="product.imageSrc"></b-image>
      <div class="mt-3">
        <h2>{{ product.longDescription }}</h2>
      </div>
      <div class="is-flex is-align-items-center">
        <b-button class="mt-3 mr-3" type="is-info" @click="createOrder"
          >Оформить заказ</b-button
        >
        <p>за {{ product.rentalPrice }} р в день</p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Product from "@/store/models/Product";
import productService from "@/services/ProductService";
import rentalOrderService from "@/services/RentalOrderService";
import RentalOrder from "@/store/models/RentalOrder";
import User from "@/store/models/User";
import Vue from "vue";

export default Vue.extend({
  data() {
    return {
      product: null as Product | null,
      isLoading: false,
    };
  },
  methods: {
    async createOrder() {
      const user = this.$store.state.user as User | null;
      const order = new RentalOrder({
        id: 0,
        user,
        product: this.product,
        orderDate: null,
        orderEndDate: null,
        rentalPrice: 0,
        isDone: false,
      });

      await rentalOrderService.add(order);
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
