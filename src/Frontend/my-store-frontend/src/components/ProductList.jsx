import React, { useEffect, useState } from "react";
import { api } from "../api";

export default function ProductList() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    api.getProducts()
      .then(res => setProducts(res.data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div>
      <h2>Produtos</h2>
      <ul>
        {products.map(p => (
          <li key={p.id}>{p.name} - R${p.price}</li>
        ))}
      </ul>
    </div>
  );
}
