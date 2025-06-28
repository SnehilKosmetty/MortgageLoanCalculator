**Mortgage Loan Calculator**
------------------------
A web-based application to calculate monthly mortgage payments and generate amortization schedules, built as a portfolio project to demonstrate ASP.NET MVC and unit testing skills.

**Overview**
-----------
This project provides a user-friendly interface to:

* Calculate monthly mortgage payments based on loan amount, interest rate, and term.
* Display a detailed amortization schedule.
* Save calculations for authenticated users.


**Features**
------------
* Loan Calculation: Computes monthly payments using the standard amortization formula.
* Amortization Schedule: Generates a month-by-month breakdown of principal, interest, and balance.
* User Authentication: Allows registration and login to save calculations securely.
* Data Persistence: Saves calculations to a SQL Server database.
* Unit Testing: Includes comprehensive tests for the business logic using MSTest.

**Technologies**
----------------
* Framework: .NET Framework 4.8
* Web Framework: ASP.NET MVC 5
* Database: Entity Framework 6 with SQL Server
* Authentication: ASP.NET Identity with OWIN
* Frontend: Bootstrap 4.5.2, jQuery 3.6.0
* Testing: MSTest
* IDE: Visual Studio 2019

**Architectural Pattern**
-------------------------
The project follows the Model-View-Controller (MVC) pattern:

* Model: Business logic and data models (e.g., LoanService, AmortizationEntry, LoanCalculation).
* View: Razor views for UI (e.g., Index.cshtml, Result.cshtml).
* Controller: Manages flow and user input (e.g., LoanController, AccountController).
* Supporting Patterns: Basic Dependency Injection (via ILoanService), implicit Unit of Work (via DbContext), and a partial Repository approach (via LoanCalculations context).
  
**Setup Instructions**
----------------------
Prerequisites

* Visual Studio 2019
* SQL Server (e.g., SQL Server Express)
* .NET Framework 4.8 SDK
