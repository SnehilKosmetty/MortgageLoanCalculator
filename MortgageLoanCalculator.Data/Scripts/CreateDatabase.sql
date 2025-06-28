CREATE DATABASE MortgageLoanCalculator;
GO
USE MortgageLoanCalculator;
GO
CREATE TABLE LoanCalculations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    LoanAmount DECIMAL(18,2) NOT NULL,
    InterestRate DECIMAL(5,2) NOT NULL,
    LoanTermYears INT NOT NULL,
    MonthlyPayment DECIMAL(18,2) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UserId NVARCHAR(450) NOT NULL
);
GO