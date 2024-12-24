import React from "react";
import Layout from "./Components/Layout";
import Dashboard from "./HMI/Dashboard";
import AddInventory from "./HMI/AddInventory";

const App = () => {
  return (
    <Layout>
      <Dashboard />
      <AddInventory />
    </Layout>
  );
};

export default App;
