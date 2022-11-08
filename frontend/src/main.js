import { createApp } from 'vue';
import axios from "axios";
import App from './App.vue';
import router from "./router";
import { appAxios } from './utils/appAxios';

const app = createApp(App)

app.use(router);
app.config.globalProperties.$axios = axios;
app.config.globalProperties.$appAxios = appAxios;
app.mount('#app');