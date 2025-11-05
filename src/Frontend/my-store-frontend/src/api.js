import axios from "axios";

const API_BASE = "https://localhost:7228"; // Troque para a URL da sua API .NET

export const api ={
getCustomers : () => axios.get(`${API_BASE}/Customer`),
getCustomerById  :(id) => axios.get(`${API_BASE}/Customer/GetById/${id}`),

// Product
getProducts : () => axios.get(`${API_BASE}/Product`),
getProductById : (id) => axios.get(`${API_BASE}/Product/GetById/${id}`),

// Order
getOrders : () => axios.get(`${API_BASE}/Order/GetAllOrder`),
getOrderById : (id) => axios.get(`${API_BASE}/Order/GetById/${id}`),
getOrdersByStatus : (status) => axios.get(`${API_BASE}/Order/GetAllOrderStatus/${status}`),
createOrder : (data) => axios.post(`${API_BASE}/Order/register`, data),
updateOrderStatus : (data) => axios.put(`${API_BASE}/Order/UpdateOrderStatus`, data),
deleteOrder : (id) => axios.delete(`${API_BASE}/Order/DeleteOrder/${id}`),

};
// Customer
