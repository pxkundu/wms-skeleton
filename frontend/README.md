### **Frontend-Specific README File**

**Path**: `/frontend/README.md`

# Warehouse Management System (Frontend)

The frontend application for the Warehouse Management System (WMS) provides a Human-Machine Interface (HMI) for visualizing IoT metrics and managing inventory. Built with React, it integrates seamlessly with the backend APIs to deliver an interactive user experience.

---

## Features

1. **Dashboard**:
   - Displays IoT metrics and inventory data in a user-friendly layout.
2. **IoT Metrics Visualization**:
   - Line charts powered by Chart.js to visualize workplace conditions (e.g., temperature, sound).
3. **Inventory Management**:
   - Lists all inventory items and allows adding new items.
4. **Reusable Components**:
   - Includes modular components like `Header`, `Footer`, and `API` utilities.

---

## Project Structure

```plaintext
/frontend
├── /HMI
│   ├── Dashboard.js      # Main dashboard for IoT and inventory data
│   ├── IoTMetrics.js     # IoT metrics chart component
│   ├── Inventory.js      # Inventory list component
│   ├── AddInventory.js   # Form to add new inventory items
├── /Components
│   ├── Header.js         # Reusable header component
│   ├── Footer.js         # Reusable footer component
│   ├── API.js            # Centralized API utility
│   └── Layout.js         # Page layout component
├── App.js                # Main React app entry
├── index.js              # React DOM rendering
├── package.json          # Project dependencies
├── .env                  # Environment variables
└── README.md             # Frontend-specific instructions
```

---

## How to Run

1. Navigate to the `frontend` directory:
   ```bash
   cd frontend
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Create a `.env` file with the backend API base URL:
   ```plaintext
   REACT_APP_API_BASE_URL=http://localhost:5000/api
   ```

4. Start the development server:
   ```bash
   npm start
   ```

The application will be accessible at `http://localhost:3000`.

---

## API Endpoints Used

1. **IoT Metrics**:
   - `GET /api/iot`: Fetch workplace condition metrics.

2. **Inventory Management**:
   - `GET /api/inventory`: Fetch inventory data.
   - `POST /api/inventory`: Add a new inventory item.

---

## Future Enhancements

1. Real-time IoT data visualization using WebSocket or Server-Sent Events (SSE).
2. Filters and search functionality for inventory management.
3. Enhanced UI design using Material-UI or Bootstrap.

```

---