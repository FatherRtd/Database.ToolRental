<template>
  <section>
    <b-collapse
      class="card"
      animation="slide"
      v-for="(parent, index) in parents()"
      :key="parent.id"
      :open="isOpen == index"
      @open="isOpen = index"
      :aria-id="'contentIdForA11y5-' + index"
    >
      <template #trigger="props">
        <div
          class="card-header"
          role="button"
          :aria-controls="'contentIdForA11y5-' + index"
          :aria-expanded="props.open"
        >
          <p class="card-header-title">
            {{ parent.name }}
          </p>
          <a class="card-header-icon">
            <b-icon :icon="props.open ? 'menu-down' : 'menu-up'"> </b-icon>
          </a>
        </div>
      </template>
      <div class="card-content child">
        <div class="content" v-for="child in childs(parent.id)" :key="child.id">
          <router-link :to="'/' + child.id">{{ child.name }}</router-link>
        </div>
      </div>
    </b-collapse>
  </section>
</template>

<script lang="ts">
import Category from "@/store/models/Category";
import Vue from "vue";

export default Vue.extend({
  props: {
    categories: { type: Array as () => Array<Category> },
  },
  data() {
    return {
      isOpen: 0,
    };
  },
  methods: {
    parents(): (Category | null)[] {
      const parents = this.categories.map((x) => x.parentCategory);
      const filtred: (Category | null)[] = [];
      parents.forEach((x) => {
        if (!filtred.some((z) => z?.id == x?.id)) {
          filtred.push(x);
        }
      });

      return filtred;
    },
    childs(id: number): Category[] {
      return this.categories.filter((x) => x.parentCategory?.id == id);
    },
  },
});
</script>
