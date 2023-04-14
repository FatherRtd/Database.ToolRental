<template>
  <section>
    <b-table :data="orders">
      <b-table-column label="ID" field="id" v-slot="props" sortable>
        {{ props.row.id }}
      </b-table-column>
      <b-table-column label="Заказчик" field="userName" v-slot="props">
        {{ props.row.userName }}
      </b-table-column>
      <b-table-column label="Товар" field="productName" v-slot="props">
        {{ props.row.productName }}
      </b-table-column>
      <b-table-column label="Начало заказа" field="orderDate" v-slot="props">
        {{ props.row.orderDate }}
      </b-table-column>
      <b-table-column
        label="Окончание заказа"
        field="orderEndDate"
        v-slot="props"
      >
        {{ props.row.orderEndDate }}
      </b-table-column>
      <b-table-column label="Цена" field="rentalPrice" v-slot="props">
        {{ props.row.rentalPrice }}
      </b-table-column>
      <b-table-column label="Статус" field="orderStatus" v-slot="props">
        {{ props.row.orderStatus }}
      </b-table-column>
      <b-table-column v-if="isAdmin" label="Действие" v-slot="props">
        <b-button
          v-if="props.row.orderDate == null"
          @click="acceptOrder(props.row)"
          >Подтвердить</b-button
        >
        <b-button
          v-else
          :disabled="props.row.orderEndDate != null"
          @click="completeOrder(props.row)"
          >Завершить</b-button
        >
      </b-table-column>
    </b-table>
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
    };
  },
  methods: {
    async acceptOrder(order: RentalOrder) {
      try {
        this.isLoading = true;
        const result = await rentalOrderService.acceptRentalOrder(order.id);
        this.orders[this.orders.findIndex((x) => x.id == order.id)] =
          new RentalOrder(result.data);
      } finally {
        this.isLoading = false;
      }
    },

    async completeOrder(order: RentalOrder) {
      console.log(order);

      try {
        this.isLoading = true;
        const result = await rentalOrderService.completeRentalOrder(order.id);
        this.orders[this.orders.findIndex((x) => x.id == order.id)] =
          new RentalOrder(result.data);
      } finally {
        this.isLoading = false;
      }
    },
  },
  computed: {
    isAdmin(): boolean {
      return this.$store.state.user.isAdmin;
    },
  },
  mounted: async function () {
    try {
      this.isLoading = true;
      const user = this.$store.state.user;
      if (user.isAdmin) {
        const requestOrders = await rentalOrderService.getAllRentalOrders();
        this.orders = requestOrders.data.map((x) => new RentalOrder(x));
      } else {
        const requestOrders = await rentalOrderService.getRentalOrders(user.id);
        this.orders = requestOrders.data.map((x) => new RentalOrder(x));
      }
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
