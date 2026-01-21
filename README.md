# JobBdAPP – Job Portal Backend API

JobBdAPP is a **backend-oriented ASP.NET Core Web API** project developed for a Job Portal system using **N-Tier Architecture**.
The project demonstrates **enterprise-level backend design**, clean separation of concerns, and real-world features commonly found in modern job platforms.

---

## 🚀 Features Overview

### 🔐 Authentication & Authorization

* User Login & Logout
* OTP-based password reset
* Secure email-based OTP verification
* Role-based user management

### 👤 User Management

* Create, update, delete users
* Search users
* Filter users by role
* Count users by role

### 🏢 Company Management

* Company CRUD operations
* Search companies
* Fetch companies with jobs
* Companies with open jobs / closed jobs
* Company with highest job posted
* Open vs Closed job count per company

### 💼 Job Management

* Job CRUD operations
* Job search (title, description, location)
* Filter by salary range
* Get open & closed jobs
* Recent jobs
* Highest & lowest salary jobs
* Jobs by company
* Most popular jobs
* Job application count
* **Job recommendation system (premium feature)**

### 📝 Application Management

* Apply for jobs
* Update application status
* Applications by job
* Applications by user
* Application statistics by status
* Pending, shortlisted, hired & rejected applications
* Most applied jobs

---

## 🧱 Architecture

The project follows **N-Tier Architecture**:

```
Controller (API Layer)
   ↓
Service / BLL (Business Logic)
   ↓
Repository / DAL (Data Access)

```

### Layer Responsibilities

* **Controllers** → Handle HTTP requests & responses
* **Services (BLL)** → Business rules, validations, workflows
* **Repositories (DAL)** → Database operations using EF Core
* **DTOs** → Data transfer between layers
* **AutoMapper** → Entity ↔ DTO mapping

---

## 🛠️ Technology Stack

* ASP.NET Core Web API
* Entity Framework Core (Code First)
* SQL Server
* AutoMapper
* Swagger (OpenAPI)
* N-Tier Architecture
* SOLID Principles

---

## 📂 Project Structure

```
JobBdAPP
│
├── Controllers
│   ├── AuthController
│   ├── UserController
│   ├── CompanyController
│   ├── JobController
│   ├── ApplicationController
│   
│
├── BLL
│   ├── Services
│         ├── AuthService
│         ├── UserService
│         ├── CompanyService
│         ├── JobService
│         ├── ApplicationService
│   ├── DTOs
│   └── MapperConfig
│
├── DAL
│   ├── EF
│   │   ├── Models
│            ├── User
│            ├── Company
│            ├── Job
│            ├── Application
│   │   └── JobBdContext
│   ├── Interfaces
│   ├── Repositories
             ├── AuthRepository
             ├── UserRepository
│            ├── CompanyRepository
│            ├── JobRepository
│            ├── ApplicationRepository
│   └── DataAccessFactory

```

---

## 🔄 API Documentation (Swagger)

Swagger is fully integrated for API testing and documentation.

* **Swagger UI**
<img width="1920" height="4647" alt="screencapture-localhost-7263-swagger-index-html-2026-01-22-00_43_54" src="https://github.com/user-attachments/assets/50b90ad1-97b6-488d-ab0f-82550fa64dbe" />


---

## 📌 Key Highlights

* Clean N-Tier architecture
* AutoMapper used consistently
* Real-world backend workflows
* Swagger documented APIs
* Scalable and maintainable design

---

## ▶️ How to Run the Project

1. Clone the repository

```bash
git clone https://github.com/your-username/JobBdAPP.git
```

2. Update database connection string in `appsettings.json`

3. Run database migration and update databases

```bash
dotnet ef migrations add initDB --project DAL --startup-project JobBdAPP
dotnet ef database update --project DAL --startup-project JobBdAPP
```

4. Start the project


5. Open Swagger in browser

```
https://localhost:{port}/swagger
```

---

## 👨‍💻 Author

**Md Sabbir Khan Oni**
Backend Developer (ASP.NET Core)

---

## 📄 License

This project is developed for **educational and learning purposes**.
