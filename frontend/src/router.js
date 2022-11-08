import { createRouter, createWebHashHistory } from "vue-router";

const routes = [
    {
        name: "HomePage",
        path: "/",
        component: () => import("./views/HomePage")
    },
    {
        name: "NewAppointment",
        path: "/new",
        component: () => import("./views/NewAppointment")
    },
    {
        name: "PageNotFound",
        path: "/:pathMatch(.*)*",
        component: () => import("./views/PageNotFound")
    }
];

const router = createRouter({
    routes,
    history: createWebHashHistory()
});

export default router;