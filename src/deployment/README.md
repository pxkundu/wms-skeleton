These files are essential for the deployment process.

1. **Dockerfile**:
   - Builds the application container for deployment.
2. **docker-compose.yml**:
   - Sets up local development or multi-container deployment environments.
3. **aws-cdk-config.json**:
   - Automates AWS infrastructure provisioning for the project.

---

- **Test the Docker Configuration**:
  1. Build the container locally:
     ```bash
     docker build -t wms-backend -f ./deployment/Dockerfile .
     ```
  2. Run the container:
     ```bash
     docker run -p 5000:80 wms-backend
     ```

- **Deploy Using Docker Compose**:
  ```bash
  docker-compose -f ./deployment/docker-compose.yml up --build
  ```

- **Provision AWS Infrastructure**:
  Use AWS CDK with the `aws-cdk-config.json` file:
  ```bash
  cdk deploy
  ```

### **AWS Configuration for CI/CD Deployment**

#### **Overview**
To successfully deploy the backend application using the CI/CD pipeline, the AWS environment must be configured. This section outlines the necessary AWS configurations, including setting up an S3 bucket for artifacts, configuring an EC2 instance for hosting the application, and managing permissions.

---

#### **AWS S3 Configuration**

1. **Create an S3 Bucket**:
   - Log in to the [AWS Management Console](https://aws.amazon.com/console/).
   - Navigate to the **S3** service and click **Create Bucket**.
   - Configure the bucket:
     - Name: `your-s3-bucket-name`
     - Region: Select the same region as your EC2 instance.
     - Enable public access (optional, only for demo purposes).
   - Save the bucket name for later use.

2. **Upload Static Files (Optional)**:
   - The CI/CD pipeline can upload static assets to this bucket. Update the `ci-cd-pipeline.yml` to include:
     ```yaml
     aws s3 sync ./publish s3://your-s3-bucket-name --acl public-read
     ```

3. **Set Permissions**:
   - Attach a policy to your IAM user or role that allows `s3:PutObject` and `s3:ListBucket` actions for the bucket.

---

#### **AWS EC2 Configuration**

1. **Launch an EC2 Instance**:
   - Navigate to **EC2** in the AWS Management Console.
   - Click **Launch Instance** and configure:
     - AMI: Amazon Linux 2 or Ubuntu (depending on preference).
     - Instance Type: t2.micro (for demo purposes).
     - Key Pair: Create or select an existing key pair for SSH access.
     - Security Group: Allow inbound rules for:
       - SSH (port 22) from your IP.
       - HTTP/HTTPS (ports 80/443) for public API access.
       - Custom port 5000 for backend API.

2. **Install .NET Core Runtime**:
   - Connect to the instance via SSH:
     ```bash
     ssh -i your-key.pem ec2-user@<ec2-public-ip>
     ```
   - Update packages and install .NET Core:
     ```bash
     sudo apt update
     sudo apt install -y dotnet-runtime-6.0
     ```

3. **Create Application Directory**:
   - Prepare the directory for the backend application:
     ```bash
     mkdir -p /var/www/wms-backend
     ```

4. **Set Up a Systemd Service**:
   - Create a service file for managing the application:
     ```bash
     sudo nano /etc/systemd/system/wms-backend.service
     ```
   - Add the following configuration:
     ```plaintext
     [Unit]
     Description=WMS Backend API
     After=network.target

     [Service]
     ExecStart=/usr/bin/dotnet /var/www/wms-backend/backend.dll
     Restart=always
     User=www-data
     Group=www-data
     Environment=ASPNETCORE_ENVIRONMENT=Production

     [Install]
     WantedBy=multi-user.target
     ```

   - Reload systemd and enable the service:
     ```bash
     sudo systemctl daemon-reload
     sudo systemctl enable wms-backend.service
     sudo systemctl start wms-backend.service
     ```

---

#### **IAM Role and Permissions**

1. **Create an IAM Role**:
   - Navigate to **IAM Roles** in the AWS Management Console.
   - Attach a policy allowing:
     - EC2: `ec2:StartInstances`, `ec2:StopInstances`, and `ec2:DescribeInstances`.
     - S3: `s3:PutObject`, `s3:GetObject`, and `s3:ListBucket`.

2. **Assign the Role to EC2**:
   - Edit the EC2 instance settings and attach the newly created IAM role.

---

#### **Secrets Management**

1. **GitHub Secrets**:
   - Add AWS credentials as GitHub secrets for secure access:
     - `AWS_ACCESS_KEY_ID`: Your IAM user access key.
     - `AWS_SECRET_ACCESS_KEY`: Your IAM user secret key.

2. **Environment Variables**:
   - Update the application to load sensitive configurations (e.g., database connection strings) from environment variables.

---

#### **Pipeline Testing**

- Verify that:
  1. Artifacts are uploaded to the S3 bucket.
  2. The application is copied to `/var/www/wms-backend` on the EC2 instance.
  3. The systemd service runs the backend application.

---