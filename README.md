# HR Onboarding API

## 📌 Overview
This project is an ASP.NET Core Web API built for the DEV Weekend Challenge (Community Edition).

The application allows HR teams and small organizations to upload employee details in bulk using an Excel file and store them in SQL Server.

---

## 🚀 Features

- Upload employees via Excel file
- Parse Excel using ClosedXML
- Store data in SQL Server
- Retrieve all employees via REST API
- Retrieve employee by ID

---

## 🛠 Technologies Used

- ASP.NET Core Web API
- SQL Server
- Dapper
- ClosedXML
- Postman (for API testing)

---

## 📂 API Endpoints

### Upload Employees
POST `/api/Employee/upload`

Upload an Excel file containing employee details.

---

### Get All Employees
GET `/api/Employee`

Returns the list of all employees.

---

### Get Employee By ID
GET `/api/Employee/{id}`

Returns a single employee by ID.

---

## ⚙ How to Run the Project

1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Ensure SQL Server is running
4. Run the application
5. Use Postman to test the endpoints

---

## 🏢 Community Use Case

This project is designed for small HR teams and startup communities that manage employee onboarding through Excel files and need a simple backend system to automate data storage.

---

## 👩‍💻 Author

Rama Pratheeba R S
