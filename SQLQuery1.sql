IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HotelDatabase')
CREATE DATABASE HotelDatabase
GO

USE HotelDatabase
GO

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'VacationRequest')
drop table VacationRequest

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'Employee')
drop table Employee

create table Employee
(
EmployeeID int primary key identity(1,1) not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
DateOfBirth Date not null,
Email nvarchar(50) not null,
Username nvarchar(50)  not null,
Password nvarchar(50) not null,
HotelFloor int not null,
Gender nvarchar(1) Check (UPPER(Gender) = 'M' or UPPER(Gender) = 'F' or UPPER(Gender) = 'O' or UPPER(Gender) = 'X'),
Citizenship nvarchar(20),
Responsibility nvarchar(50) Check (UPPER(Responsibility) = 'Cleaning' or UPPER(Responsibility) = 'Cooking' or UPPER(Responsibility) = 'Overseeing' or UPPER(Responsibility) = 'Reporting'),
Paycheck decimal,
WorkExperience int,
ProfesionalQualifications nvarchar(3) Check (UPPER(ProfesionalQualifications) = 'I' or UPPER(ProfesionalQualifications) = 'II' or UPPER(ProfesionalQualifications) = 'III' or UPPER(ProfesionalQualifications) = 'IV' or UPPER(ProfesionalQualifications) = 'V' or UPPER(ProfesionalQualifications) = 'VI' or UPPER(ProfesionalQualifications) = 'VII'),
)

create table VacationRequest
(
RequestID int primary key identity(1,1) not null,
EmployeeID int foreign key references Employee(EmployeeID),
VacationStart Date Check( Day(VacationStart) - Day(GetDate()) > 20 ),
VacationEnd Date,
VacationReason nvarchar(150),
RequestStatus nvarchar(50) Check (UPPER(RequestStatus) = 'Approved' or UPPER(RequestStatus) = 'Rejected' or UPPER(RequestStatus) = 'Deleted' or UPPER(RequestStatus) = 'Pending' ) DEFAULT 'Pending',
RequestDeletedReason nvarchar(150)
)
