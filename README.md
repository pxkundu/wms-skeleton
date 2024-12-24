# wms-skeleton
Warehouse Management System (WMS/WCS) Demonstration

### Detailed README for the WMS/WCS Demo Project

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
│   ├── /backend
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
│   │   └── Program.cs
│   └── /deployment
│       ├── Dockerfile
│       ├── docker-compose.yml
│       ├── aws-cdk-config.json
│       ├── ci-cd-pipeline.yml
│       └── README.md
├── .gitignore
├── README.md
└── LICENSE
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
   git clone https://github.com/your-username/WMS-WCS-Demo.git
   cd WMS-WCS-Demo
   ```

2. Navigate to the backend folder:
   ```bash
   cd src/backend
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

## **Deployment Instructions**

### **Local Deployment Using Docker**
1. Build the Docker image:
   ```bash
   docker build -t wms-wcs-demo .
   ```

2. Run the container:
   ```bash
   docker run -p 5000:5000 wms-wcs-demo
   ```

### **Cloud Deployment to AWS**
1. Use the `aws-cdk-config.json` to configure deployment settings.
2. Run the CI/CD pipeline using GitHub Actions.

---
