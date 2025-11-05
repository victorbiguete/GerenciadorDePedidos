import React, { useState, useEffect } from "react";
import { api } from "../api";

export default function OrderForm() {
  const [products, setProducts] = useState([]);
  const [orderItems, setOrderItems] = useState([{ productId: "", quantity: 1 }]);

  useEffect(() => {
    api.getProducts()
      .then(res => setProducts(res.data))
      .catch(err => console.error(err));
  }, []);

  const handleAddItem = () => {
    setOrderItems([...orderItems, { productId: "", quantity: 1 }]);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    api.createOrder({
      customerId: 1,
      items: orderItems.map(i => ({ productId: parseInt(i.productId), quantity: i.quantity }))
    })
      .then(res => alert("Pedido criado com sucesso!"))
      .catch(err => console.error(err));
  };

  return (
    <div>
      <h2>Criar Pedido</h2>
      <form onSubmit={handleSubmit}>
        {orderItems.map((item, index) => (
          <div key={index}>
            <select value={item.productId} onChange={e => {
              const newItems = [...orderItems];
              newItems[index].productId = e.target.value;
              setOrderItems(newItems);
            }}>
              <option value="">Selecione um produto</option>
              {products.map(p => (
                <option key={p.id} value={p.id}>{p.name}</option>
              ))}
            </select>
            <input type="number" min="1" value={item.quantity} onChange={e => {
              const newItems = [...orderItems];
              newItems[index].quantity = parseInt(e.target.value);
              setOrderItems(newItems);
            }} />
          </div>
        ))}
        <button type="button" onClick={handleAddItem}>Adicionar Produto</button>
        <button type="submit">Criar Pedido</button>
      </form>
    </div>
  );
}
