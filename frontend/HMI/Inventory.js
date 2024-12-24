import React, { useState, useEffect } from "react";
import axios from "axios";

const Inventory = () => {
  const [inventory, setInventory] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5000/api/inventory")
      .then((response) => setInventory(response.data))
      .catch((error) => console.error(error));
  }, []);

  return (
    <div>
      <h2>Inventory</h2>
      <ul>
        {inventory.map((item) => (
          <li key={item.id}>
            {item.name} - {item.quantity} units
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Inventory;
