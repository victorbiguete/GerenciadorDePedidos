import React from "react";
import CustomerList from "./components/CustomerList";
import ProductList from "./components/ProductList";
import OrderForm from "./components/OrderForm";
import OrderList from "./components/OrderList";

function App() {
  return (
    <div>
      <h1>Gerenciador de Pedidos</h1>
      <CustomerList />
      <ProductList />
      <OrderForm />
      <OrderList />
    </div>
  );
}

export default App;
