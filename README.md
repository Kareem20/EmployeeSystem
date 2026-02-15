# Employee Management System

A full-stack Employee Management System built using:

- Microsoft SQL Server (Database Layer)
- .NET Web API (Backend Layer)
- Angular (Frontend Layer)

This project demonstrates full-stack development with proper separation of concerns, stored procedures, API integration, and UI implementation.

---

## 📌 Project Overview

The system allows:

- Adding new employees with job details
- Retrieving all employees with their job information
- Calculating the total salaries of all employees

The application follows a 3-layer architecture:

Database → API → Frontend

---

## 🗄 Database Layer (SQL Server)

### Tables

- **Employees**
  - Id
  - Name
  - Address
  - GenderId

- **EmployeeJobs**
  - Id
  - EmployeeId (FK)
  - JobTitle
  - DepartmentId
  - Salary

### Stored Procedures

1. **CreateEmployeeWithJob**
   - Uses TRANSACTION.
   - Inserts into Employees and EmployeeJobs.
   - Ensures data integrity.

2. **GetAllEmployees**
   - Uses JOIN between Employees and EmployeeJobs.

3. **GetTotalSalaries**
   - Calculates the sum of salaries for all employees.
   
4. **GetEmployeeById**
   - Uses JOIN to get the details of a specific employee.
   
5. **UpdateEmployee**
   - Update the date of a specific Employee.
   
4. **DeleteEmployee**
   - Update the date of a specific Employee and related EmployeeJob.
---

## 🚀 Backend (.NET Web API)

### Features

- Uses SqlClient to call stored procedures
- Implements Data Access Layer
- Handles parameters for insert operations
- Provides RESTful endpoints

### API Endpoints

#### POST /employees
Creates a new employee with job details.

#### GET /employees
Returns all employees with job details.

#### GET /employees/salaries/total
Returns total salary amount.

---

## 💻 Frontend (Angular)

### Components

1. **Employee Form**
   - Add new employee
   - Update existing employee
   - Sends POST request to API

2. **Employee List**
   - Displays all employees
   - Fetches data from API

3. **Salary Summary**
   - Displays total salary amount

### Angular Service

- addEmployee()
- getEmployees()
- getEmployeeById()
- getTotalSalaries()
- updateEmployee()
- deleteEmployee()
- getGenders()
- getDepartments()

---

## 🏗 Project Structure

    EmployeeSystem/
    │
    ├── backend/
    │ └── EmployeeManagement.API
    │
    ├── frontend/
    │ └── employee-management
    │
    ├── database/
    │ ├── Tables.sql
    │ └── StoredProcedures.sql
    │
    └── README.md

-----

## 🖼 Application Screens
Employee Form
<img width="1360" height="644" alt="image" src="https://github.com/user-attachments/assets/98526fa0-3bbc-4573-8eb9-fb29ecace139" />

Employee List
<img width="1366" height="643" alt="image" src="https://github.com/user-attachments/assets/9ca9c06b-9295-4d9a-baa8-199fd1005ff0" />

Salary Summary
<img width="1366" height="646" alt="image" src="https://github.com/user-attachments/assets/e5cdbc1d-ab3b-45d5-bd70-d4922381463e" />

-----
🧠 Technical Highlights

- Transaction handling in SQL Server

- Stored procedure integration with .NET

- Clean separation between layers

- RESTful API design

- Angular service-based architecture


