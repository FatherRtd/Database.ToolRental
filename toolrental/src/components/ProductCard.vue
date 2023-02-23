<template>
  <div class="card product-card">
    <div class="card-image">
      <figure class="image is-4by3">
        <img src="" alt="Placeholder image" />
      </figure>
    </div>
    <div class="card-content">
      <div class="media">
        <div class="media-content">
          <h2 class="title is-4">{{ product.name }}</h2>
        </div>
      </div>
      <div class="content">
        {{ product.shortDescription }}
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import IProduct from "@/store/models/Product";
import Vue, { PropType } from "vue";
export default Vue.extend({
  props: {
    product: { type: Object as PropType<IProduct> },
  },
});
</script>

<style>
.product-card {
  width: 300px;
  height: 500px;
}
</style>
