import axios from "axios";

export const appAxios = axios.create({
    baseURL: "https://localhost:7222/api/v1",
    withCredentials: false,
    headers: {
        "Content-Type": "application/json"
    }
})