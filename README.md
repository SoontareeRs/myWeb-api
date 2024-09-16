# MyWeb-API project is a user management API
This project is a simple **User Management API** built using **ASP.NET Core**. The API allows you to perform **CRUD operations** on users, including creating, reading, updating, and deleting users.

## Features

- Create a new user
- Retrieve user details
- Update user information
- Delete a user


# How to Run the Project
1. Clone this repository.
```
git clone https://github.com/SoontareeRs/myWeb-api.git
```
2. Navigate to the project directory:
```
cd mywebapi
```
3. Install dependencies: Ensure you have .NET installed, then run:
```
dotnet restore
```
4. Run the API:
```
dotnet run
```
5. Navigate to http://localhost:5245/swagger in your browser.


# How to Create This Project
1. Create a new ASP.NET Core Web Application project using Visual Studio or the command line:
```
dotnet new webapi -o mywebapi
```
2. Add the following NuGet packages to the project:
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
3. Create a database named `myweb` in MySQL Workbench or another SQL client of your choice. Create a MySQL database:First, run a MySQL container using Docker:
```
   docker run --name mysqlUser -e MYSQL_ROOT_PASSWORD=password -p 3306:3306 -d mysql
```
4. Update the connection string in `appsettings.json`:
```
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=myweb;Uid=root;Pwd=<PASSWORD>;"}
```
5. Run the following commands to create and seed the database:
```
dotnet ef migrations add <InitialCreate>
```
6.  Run the following command to apply the migrations to the database:
```
dotnet ef database update
```
7. Test the API Navigate to http://localhost:5245/swagger in your browser.