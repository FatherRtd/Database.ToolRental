<template>
  <div class="p-3" style="width: 400px">
    <b-field label="Название">
      <b-input v-model="newProduct.name"></b-input>
    </b-field>
    <b-field label="Краткое описание">
      <b-input v-model="newProduct.shortDescription"></b-input>
    </b-field>
    <b-field label="Описание">
      <b-input v-model="newProduct.longDescription"></b-input>
    </b-field>
    <b-field label="Цена">
      <b-input v-model="newProduct.rentalPrice" type="number"></b-input>
    </b-field>
    <b-field label="Изображение">
      <b-upload v-model="newProduct.image" class="file-label">
        <span class="file-cta">
          <b-icon class="file-icon" icon="upload"></b-icon>
          <span class="file-label">Загрузить</span>
        </span>
        <span class="file-name" v-if="newProduct.image">
          {{ newProduct.image.name }}
        </span>
      </b-upload>
    </b-field>
    <b-field label="Категория">
      <b-select v-model="newProduct.categoryId">
        <option
          v-for="category in categories"
          :key="category.id"
          :value="category.id"
        >
          {{ category.name }}
        </option>
      </b-select>
    </b-field>
    <b-button @click="addProduct">Добавить</b-button>
  </div>
</template>

<script lang="ts">
import Category from "@/store/models/Category";
import categoryService from "@/services/CategoryService";
import Vue from "vue";
export default Vue.extend({
  data() {
    return {
      file: File,
      categories: [] as Category[],
      newProduct: {
        name: "",
        shortDescription: "",
        longDescription: "",
        rentalPrice: 0,
        image: null as File | null,
        categoryId: "",
      },
    };
  },
  methods: {
    async addProduct() {
      console.log("add");
    },
  },
  mounted: async function () {
    const requestCategories = await categoryService.getCategories();
    this.categories = requestCategories.data.map((x) => new Category(x));
  },
});
</script>

<style></style>
