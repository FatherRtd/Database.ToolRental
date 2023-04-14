import Vue from "vue";
import VueRouter from "vue-router";
import { RouteConfig } from "vue-router/types/router";
import store from "@/store/store";

Vue.use(VueRouter);

const routeNames = {
  signUp: "signup",
  login: "login",
  main: "main",
  orders: "orders",
  category: "category",
  product: "product",
  admin: "admin",
};

const urls = {
  main: "/:categoryId?",
  signUp: `/${routeNames.signUp}`,
  login: `/${routeNames.login}`,
  orders: `/${routeNames.orders}`,
  product: `/${routeNames.product}/:productId`,
  admin: `/${routeNames.admin}`,
};

export { urls };

const Main = () => import("@/views/MainPage.vue");
const Login = () => import("@/views/LoginPage.vue");
const SignUp = () => import("@/views/SignUpPage.vue");
const Orders = () => import("@/views/OrdersPage.vue");
const Product = () => import("@/views/ProductPage.vue");
const Admin = () => import("@/views/AdminPage.vue");

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
  {
    name: routeNames.product,
    path: urls.product,
    component: Product,
  },
  {
    name: routeNames.admin,
    path: urls.admin,
    component: Admin,
  },
];

const router = new VueRouter({
  mode: "history",
  routes: routes,
});

router.beforeEach((to, from, next) => {
  const loggedIn = store.state.user != null;

  if (
    loggedIn == false &&
    to.name != routeNames.login &&
    to.name != routeNames.signUp &&
    to.name != routeNames.main &&
    to.name != routeNames.product &&
    to.name != routeNames.admin
  ) {
    next({ name: routeNames.main });
    return false;
  }
  next();
});

export default router;
