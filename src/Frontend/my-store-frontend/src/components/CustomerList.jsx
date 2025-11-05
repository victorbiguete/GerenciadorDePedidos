import React, { useEffect, useState } from "react";
import { api } from "../api";

export default function CustomerList() {
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    api.getCustomers()
      .then(res => setCustomers(res.data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div>
      <h2>Clientes</h2>
      <ul>
        {customers.map(c => (
          <li key={c.id}>{c.name} - {c.email}</li>
        ))}
      </ul>
    </div>
  );
}
