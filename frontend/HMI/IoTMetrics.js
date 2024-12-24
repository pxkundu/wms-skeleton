import React, { useState, useEffect } from "react";
import { Line } from "react-chartjs-2";
import axios from "axios";

const IoTMetrics = () => {
  const [metrics, setMetrics] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5000/api/iot")
      .then((response) => setMetrics(response.data))
      .catch((error) => console.error(error));
  }, []);

  const chartData = {
    labels: metrics.map((data) => new Date(data.timestamp).toLocaleTimeString()),
    datasets: [
      {
        label: "Metric Value",
        data: metrics.map((data) => data.metricValue),
        borderColor: "rgba(75, 192, 192, 1)",
        backgroundColor: "rgba(75, 192, 192, 0.2)",
        fill: true,
      },
    ],
  };

  return (
    <div>
      <h2>IoT Metrics</h2>
      <Line data={chartData} />
    </div>
  );
};

export default IoTMetrics;
