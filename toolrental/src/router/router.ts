import Vue from "vue";
import VueRouter from "vue-router";
import { RouteConfig } from "vue-router/types/router";

Vue.use(VueRouter);

const routeNames = {
  signUp: "signup",
  login: "login",
  main: "main",
  orders: "orders",
};

const urls = {
  main: "/",
  signUp: `/${routeNames.signUp}`,
  login: `/${routeNames.login}`,
  orders: `/${routeNames.orders}`,
};

export { urls };

const Main = () => import("@/views/MainPage.vue");
const Login = () => import("@/views/LoginPage.vue");
const SignUp = () => import("@/views/SignUpPage.vue");
const Orders = () => import("@/views/OrdersPage.vue");

const routes: Array<RouteConfig> = [
  {
    name: routeNames.login,
    path: urls.login,
    component: Login,
  },
  {
    name: routeNames.signUp,
    path: urls.signUp,
    component: SignUp,
  },
  {
    name: routeNames.main,
    path: urls.main,
    component: Main,
  },
  {
    name: routeNames.orders,
    path: urls.orders,
    component: Orders,
  },
];

const router = new VueRouter({
  mode: "history",
  routes: routes,
});

export default router;
