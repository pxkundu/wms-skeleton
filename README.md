# wms-skeleton
Warehouse Management System (WMS/WCS) Demonstration

---

# **Warehouse Management System (WMS/WCS) Demo**
A demonstration project showcasing core concepts and functionalities of a Warehouse Management System (WMS) and Warehouse Control System (WCS). The project includes backend development, user authentication, inventory management, IoT data integration, and CI/CD pipelines for deployment in AWS Cloud. This repository serves as a practical example of real-world industrial software solutions while maintaining client confidentiality.

---

## **Assumptions**
1. **Project Scope**: 
   - This project is a skeleton demonstrating key functionalities found in a WMS/WCS system. It is not a complete production-ready application but provides a foundation for building one.
2. **Database**: 
   - A simple in-memory database is used for demonstration purposes. Replace with a production-ready database like SQL Server or PostgreSQL for real-world applications.
3. **IoT Data**: 
   - Mock data is used to simulate IoT device inputs. Replace with live IoT device data in a production scenario.
4. **Authentication**: 
   - Basic JWT-based authentication is implemented. Extend with advanced security measures for production environments.
5. **CI/CD Pipeline**:
   - GitHub Actions is used as the CI/CD tool for deploying the backend. Additional configuration may be required for specific deployment environments.

---

## **Project Features**
1. **Backend Development**:
   - Built using C# with the .NET Core framework.
   - RESTful APIs for authentication, inventory management, and IoT data integration.
2. **Authentication**:
   - JWT-based secure login with role-based access control.
3. **Inventory Management**:
   - CRUD operations for managing warehouse inventory items.
4. **IoT Data Integration**:
   - Mock IoT data ingestion and visualization for workplace condition monitoring.
5. **CI/CD Pipeline**:
   - Automated build, test, and deployment pipeline using GitHub Actions.
6. **Cloud Hosting**:
   - Deployment on AWS EC2 instances with static assets stored on S3.

---

## **Project Structure**

```plaintext
/wms-skeleton
├── /src
│   ├── /Backend
│   │   ├── Controllers
│   │   │   ├── AuthController.cs
│   │   │   ├── InventoryController.cs
│   │   │   └── IoTController.cs
│   │   ├── Models
│   │   │   ├── User.cs
│   │   │   ├── InventoryItem.cs
│   │   │   └── IoTData.cs
│   │   ├── Services
│   │   │   ├── AuthService.cs
│   │   │   ├── InventoryService.cs
│   │   │   └── IoTService.cs
│   │   ├── Utilities
│   │   │   └── JWTGenerator.cs
│   │   ├── appsettings.json
│   │   ├── Program.cs
│   │   └── backend.csproj
│   ├── /deployment
│   │   ├── Dockerfile
│   │   ├── docker-compose.yml
│   │   └── aws-cdk-config.json
|   |   └── ci-cd-pipeline.yml
├── /frontend
│   ├── /HMI
│   │   ├── Dashboard.js
│   │   ├── Inventory.js
│   │   ├── IoTMetrics.js
│   │   └── AddInventory.js
│   ├── /Components
│   │   ├── Header.js
│   │   ├── Footer.js
│   │   ├── API.js
│   │   └── Layout.js
│   ├── App.js
│   ├── index.js
│   ├── package.json
│   ├── .env
│   └── README.md
├── .github
│   └── workflows
│       └── ci-cd-pipeline.yml
├── .gitignore
├── README.md
├── LICENSE

```

---

## **Setup and Installation**

### **Prerequisites**
1. [.NET Core SDK](https://dotnet.microsoft.com/download)
2. [Postman](https://www.postman.com/) (for testing APIs)
3. AWS account (if deploying to AWS)
4. Docker (for containerized deployment)

### **Steps to Run Locally**
1. Clone the repository:
   ```bash
   git clone https://github.com/pxkundu/wms-skeleton.git
   cd wms-skeleton
   ```

2. Navigate to the backend folder:
   ```bash
   cd src/Backend
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Test the APIs using Postman or any other API testing tool.

---

## **API Documentation**

### **Authentication API**

#### **Login**
**Endpoint**: `POST /api/auth/login`  
**Request Body**:
```json
{
  "username": "admin",
  "password": "password"
}
```
**Response**:
```json
{
  "token": "your-jwt-token-here"
}
```

---

### **Inventory Management API**

#### **Get All Inventory Items**
**Endpoint**: `GET /api/inventory`  
**Response**:
```json
[
  {
    "id": 1,
    "name": "Widget A",
    "description": "High-quality widget",
    "quantity": 100,
    "price": 10.99
  },
  {
    "id": 2,
    "name": "Widget B",
    "description": "Economy widget",
    "quantity": 200,
    "price": 5.49
  }
]
```

#### **Add Inventory Item**
**Endpoint**: `POST /api/inventory`  
**Request Body**:
```json
{
  "name": "Widget C",
  "description": "Premium widget",
  "quantity": 50,
  "price": 15.99
}
```

#### **Update Inventory Item**
**Endpoint**: `PUT /api/inventory/{id}`  
**Request Body**:
```json
{
  "name": "Updated Widget",
  "description": "Updated description",
  "quantity": 75,
  "price": 12.99
}
```

#### **Delete Inventory Item**
**Endpoint**: `DELETE /api/inventory/{id}`  

---

### **IoT Data Integration API**

#### **Get All IoT Data**
**Endpoint**: `GET /api/iot`  
**Description**: Retrieves all IoT data collected from sensors, simulating workplace condition metrics.  
**Response**:
```json
[
  {
    "id": 1,
    "deviceId": "Sensor1",
    "metricType": "Temperature",
    "metricValue": 22.5,
    "timestamp": "2024-12-23T12:00:00"
  },
  {
    "id": 2,
    "deviceId": "Sensor2",
    "metricType": "Sound",
    "metricValue": 55.0,
    "timestamp": "2024-12-23T12:05:00"
  }
]
```

---

#### **Add IoT Data**
**Endpoint**: `POST /api/iot`  
**Description**: Adds a new data record from an IoT sensor to the system.  
**Request Body**:
```json
{
  "deviceId": "Sensor3",
  "metricType": "Air Quality",
  "metricValue": 75.5,
  "timestamp": "2024-12-23T12:15:00"
}
```
**Response**:
```json
{
  "id": 3,
  "deviceId": "Sensor3",
  "metricType": "Air Quality",
  "metricValue": 75.5,
  "timestamp": "2024-12-23T12:15:00"
}
```

---

## **Deployment Instructions**

### **Local Deployment Using Docker**
1. Build the Docker image:
   ```bash
   docker build -t wms-skeleton .
   ```

2. Run the container:
   ```bash
   docker run -p 5000:5000 wms-skeleton
   ```

### **Cloud Deployment to AWS**
1. Use the `aws-cdk-config.json` to configure deployment settings.
2. Run the CI/CD pipeline using GitHub Actions.

---

### **CI/CD Pipeline**

#### **Overview**
The CI/CD pipeline automates the process of building, testing, and deploying the WMS/WCS backend application. The pipeline is implemented using **GitHub Actions** and integrates with AWS for deployment. It ensures code integrity through continuous integration and automates deployment to AWS EC2, minimizing manual intervention.

---

#### **Pipeline Workflow**

1. **Trigger**:
   - The pipeline runs on:
     - Every push to the `main` branch.
     - Pull request merges into `main`.

2. **Jobs**:
   - **Build Job**:
     - Restores dependencies, builds the project, and runs unit tests.
   - **Deploy Job**:
     - Uploads build artifacts to an AWS S3 bucket (if applicable).
     - Deploys the application to an AWS EC2 instance.

---

#### **Setup**

1. **AWS Credentials**:
   - Add the following secrets to the repository in GitHub:
     - `AWS_ACCESS_KEY_ID`: Your AWS access key.
     - `AWS_SECRET_ACCESS_KEY`: Your AWS secret key.

2. **Configure EC2 Instance**:
   - Ensure an EC2 instance is running and accessible via SSH.
   - Install the .NET Core runtime on the instance:
     ```bash
     sudo apt update
     sudo apt install -y dotnet-runtime-6.0
     ```
   - Create a directory for the application:
     ```bash
     mkdir -p /var/www/wms-backend
     ```

3. **Systemd Service**:
   - Set up a systemd service file (`/etc/systemd/system/wms-backend.service`) for managing the backend application.

---

#### **Pipeline File**
The pipeline configuration file is located in `src/deployment/ci-cd-pipeline.yml`. Below is an outline of its functionality:

1. **Build Phase**:
   - Restores dependencies with `dotnet restore`.
   - Builds the project with `dotnet build`.
   - Runs unit tests using `dotnet test`.

2. **Deployment Phase**:
   - Uploads static files (if applicable) to an AWS S3 bucket.
   - Deploys the backend application to an AWS EC2 instance via SCP and SSH.

---

#### **Workflow File**
**File Location**: `src/deployment/ci-cd-pipeline.yml`

Key steps in the pipeline:
- **Checkout Code**:
  - Retrieves the latest code from the repository.
- **Build and Test**:
  - Ensures the application builds correctly and passes tests.
- **Deploy**:
  - Copies the build artifacts to an AWS EC2 instance.

---

#### **Testing the Pipeline**
1. Push changes to the `main` branch or create a pull request.
2. Monitor the **Actions** tab in the GitHub repository to observe the pipeline execution.
3. Verify:
   - Build and test jobs complete successfully.
   - Deployment to EC2 is error-free.

---

#### **Example Deployment**
After a successful deployment, you can access the backend API via the public IP address of the EC2 instance. Example:
```plaintext
http://<ec2-public-ip>:5000/api/inventory
```

---

#### **Frontend: Human-Machine Interface (HMI)**

##### **Overview**
The frontend is built using React to simulate real-world Human-Machine Interface (HMI) components for the Warehouse Management System (WMS). It interacts with the backend APIs to:
- Display IoT metrics in real-time.
- Show inventory data and allow CRUD operations.
- Provide an intuitive user interface for data visualization and interaction.

The frontend is located in the `/frontend` directory, separate from the backend (`/src/Backend`), for better separation of concerns and easier deployment.

---

##### **Frontend Features**
1. **Dashboard**:
   - Displays an overview of inventory data and IoT metrics.
2. **IoT Metrics Visualization**:
   - Real-time IoT metrics visualized using a line chart (powered by Chart.js).
   - Fetches data from the `GET /api/iot` endpoint.
3. **Inventory Management**:
   - Lists all inventory items with details.
   - Allows adding new inventory items using the `POST /api/inventory` endpoint.
4. **API Utility**:
   - Centralized utility for API interactions to maintain consistency and reusability.

---

##### **Frontend Structure**
```plaintext
/frontend
├── /HMI
│   ├── Dashboard.js      # Main dashboard displaying IoT and inventory data
│   ├── IoTMetrics.js     # IoT metrics chart component
│   ├── Inventory.js      # Inventory list component
│   ├── AddInventory.js   # Form for adding new inventory items
├── /Components
│   ├── Header.js         # Reusable header component
│   ├── Footer.js         # Reusable footer component
│   ├── API.js            # API utility functions
│   └── Layout.js         # Page layout component
├── App.js                # Main entry point of the React app
├── index.js              # React DOM rendering entry
├── package.json          # Dependencies and scripts for the frontend
├── .env                  # Environment variables for API configuration
└── README.md             # Instructions for the frontend
```

---

##### **How to Run the Frontend**
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

##### **Integration with Backend**
The frontend interacts with the backend using REST APIs:
1. **IoT Metrics**:
   - Fetches data from `GET /api/iot` to visualize workplace conditions like temperature and air quality.
2. **Inventory Management**:
   - Fetches data from `GET /api/inventory` to list inventory items.
   - Submits new items to `POST /api/inventory`.

---

##### **Reasoning for Frontend Location**
The frontend is placed outside the `src` directory to ensure clear separation of concerns between the backend and frontend. This structure:
- Allows independent development and deployment of the frontend and backend.
- Simplifies hosting the frontend on platforms like AWS S3, Netlify, or Vercel, while the backend remains hosted on AWS EC2 or similar services.

---
