import React, { useState } from "react";
import axios from "axios";

const AddInventory = () => {
  const [item, setItem] = useState({
    name: "",
    description: "",
    quantity: "",
    price: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setItem({ ...item, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    axios.post("http://localhost:5000/api/inventory", item)
      .then(() => alert("Inventory added successfully"))
      .catch((error) => console.error(error));
  };

  return (
    <div>
      <h2>Add Inventory</h2>
      <form onSubmit={handleSubmit}>
        <input type="text" name="name" placeholder="Name" onChange={handleChange} />
        <input type="text" name="description" placeholder="Description" onChange={handleChange} />
        <input type="number" name="quantity" placeholder="Quantity" onChange={handleChange} />
        <input type="number" name="price" placeholder="Price" onChange={handleChange} />
        <button type="submit">Add Item</button>
      </form>
    </div>
  );
};

export default AddInventory;
