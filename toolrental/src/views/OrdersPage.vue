<template>
  <section>
    <b-table :data="orders" :columns="columns"></b-table>
  </section>
</template>

<script lang="ts">
import rentalOrderService from "@/services/RentalOrderService";
import RentalOrder from "@/store/models/RentalOrder";
import Vue from "vue";

export default Vue.extend({
  data() {
    return {
      isLoading: false,
      orders: [] as RentalOrder[],
      columns: [
        {
          field: "id",
          label: "ID",
          width: "40",
          numeric: true,
        },
        {
          field: "userName",
          label: "Имя клиента",
        },
        {
          field: "productName",
          label: "Наименование товара",
        },
        {
          field: "orderDate",
          label: "Дата начала заказа",
        },
        {
          field: "orderEndDate",
          label: "Дата окончания аренды",
        },
        {
          field: "orderEndDate",
          label: "Дата окончания аренды",
        },
        {
          field: "rentalPrice",
          label: "Стоимость аренды",
        },
        {
          field: "orderStatus",
          label: "Статус",
        },
      ],
    };
  },
  mounted: async function () {
    try {
      this.isLoading = true;
      const user = this.$store.state.user;
      const requestOrders = await rentalOrderService.getRentalOrders(user.id);
      this.orders = requestOrders.data.map((x) => new RentalOrder(x));
    } finally {
      this.isLoading = false;
    }
  },
});
</script>

<style scoped>
.b-table {
  margin: 0 100px;
}
</style>
