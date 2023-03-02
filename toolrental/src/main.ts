import Vue from "vue";
import App from "./App.vue";
import "mdi/css/materialdesignicons.css";
import buefy from "buefy";
import Vuex from "vuex";
import "./styles.sass";
import router from "./router/router";
import store from "./store/store";

Vue.use(buefy, {
  defaultClockpickerHoursLabel: "Часы",
  defaultClockpickerMinutesLabel: "Мин.",
  defaultTimeFormatter: "HH:mm",
  defaultTimeParser: "HH:mm",
  defaultModalScroll: "keep",
  defaultFirstDayOfWeek: 1,
});

Vue.use(Vuex);

Vue.config.productionTip = false;

new Vue({
  render: (h) => h(App),
  router,
  store,
}).$mount("#app");
