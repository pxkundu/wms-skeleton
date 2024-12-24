import axios from "axios";

const api = axios.create({
  baseURL: process.env.REACT_APP_API_BASE_URL,
});

export const fetchInventory = () => api.get("/inventory");
export const fetchIoTData = () => api.get("/iot");
export const addInventory = (item) => api.post("/inventory", item);

export default api;
