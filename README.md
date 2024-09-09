# **LibraryManagementApp.NET**

A .NET-based library management system that helps librarians manage books, track borrowing history, and maintain member records. The system is built using C# and SQL Server for efficient database management.


## **Project Overview**
This Library Management System is designed to automate the manual process of managing books in a library. It provides a user-friendly interface for librarians to track book checkouts, returns, and manage the book inventory. The system uses a SQL Server database to store book details, member information, and transaction records.

## **Features**
- Manage library books (add, update, delete)
- Track book lending and returns
- Member registration and record-keeping
- Search for books by title, author, or ISBN
- Generate reports on borrowed and available books

## **Technologies Used**
- **.NET Core 6.0**: Backend framework for building the application.
- **C#**: Main programming language for the project.
- **SQL Server**: Database for storing books, members, and transaction records.
- **Entity Framework Core**: For object-relational mapping (ORM) to the SQL database.
- **ASP.NET MVC**: To build the web application with a Model-View-Controller pattern.
- **Bootstrap**: For responsive UI design.
- **Visual Studio**: Integrated development environment (IDE) used for coding and testing.

## **Installation**
1. **Clone the repository**:
   ```bash
   git clone https://github.com/ahmedmaged6/LibraryManagementApp.NET.git
   cd LibraryManagementApp.NET
   ```

2. **Set up the SQL Server database**:
   - Create a new SQL Server database named `LibraryManagementDB`.
   - Update the contion string in `appsettings.json` to point to your SQL Server instance.
   - Run the database migrations:
     ```bash
     dotnet ef database update
     ```

3. **Run the project**:
   - Open the project in Visual Studio.
   - Build the solution.
   - Run the application by pressing `F5` or using the command:
     ```bash
     dotnet run
     ```

## **Usage**
1. Access the system via the browser at `http://localhost:5000`.
2. Navigate to the dashboard to manage books, members, and transactions.
3. Use the search functionality to find books by title, author, or ISBN.
4. Add new members and keep track of their borrowing history.

