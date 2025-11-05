import React, { useEffect, useState } from "react";
import { api } from "../api";

export default function OrderList() {
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    api.getOrders()
      .then(res => setOrders(res.data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div>
      <h2>Pedidos</h2>
      {orders.map(o => (
        <div key={o.id}>
          <h3>Pedido {o.id} - Status: {o.status}</h3>
          <ul>
            {o.orderItems.map(item => (
              <li key={item.id}>
                {item.productName} - Qtd: {item.quantity} - Total: R${item.totalPrice}
              </li>
            ))}
          </ul>
        </div>
      ))}
    </div>
  );
}
