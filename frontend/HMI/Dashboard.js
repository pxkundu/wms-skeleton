import React from "react";
import IoTMetrics from "./IoTMetrics";
import Inventory from "./Inventory";

const Dashboard = () => {
  return (
    <div>
      <h1>Warehouse Management System - Dashboard</h1>
      <IoTMetrics />
      <Inventory />
    </div>
  );
};

export default Dashboard;
