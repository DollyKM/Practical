CREATE DATABASE [EmployeeDB]
GO

USE [EmployeeDB]
GO

--==========================================================================
-----------------------------EmployeeDetails Table--------------------------
--==========================================================================
CREATE TABLE [EmployeeDetails](
[EmpID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[FirstName] NVARCHAR(56) NOT NULL,
[LastName] NVARCHAR(56),
[Email] NVARCHAR(156) NOT NULL,
[Age] INT,
[Gender] NVARCHAR(12),
[Address] NVARCHAR(256) NOT NULL,
[Country] NVARCHAR(56) NOT NULL,
[State] NVARCHAR(56) NOT NULL,
[City] NVARCHAR(56) NOT NULL,
[TotalExperience] DECIMAL(2,1)
)
GO

INSERT INTO [EmployeeDetails] VALUES('Dolly','Mishra','dolly@gmail.com',23,'Female','K 21, Shilpkala, MG Road','India','Gujarat','Ahmedabad',1.7),
									('Raj','T','raj@gmail.com',22,'Male','11, Karnawati rd','India','Gujarat','Ahmedabad',1)
SELECT *FROM [EmployeeDetails]
--==========================================================================
-----------------------------CompanyRecord Table----------------------------
--==========================================================================
DROP TABLE [CompanyRecord]

CREATE TABLE [CompanyRecord](
[RecordID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
[EmpId] INT FOREIGN KEY REFERENCES [EmployeeDetails]([EmpID]),
[CompanyName] NVARCHAR(156),
[Address] NVARCHAR(256),
[Experience] DECIMAL(2,1),
[Designation] NVARCHAR(56) NOT NULL
)
GO

INSERT INTO [CompanyRecord] VALUES(1,'Gateway Group','Pakwan',1.7,'Software Engineer'),
									(2,'Gateway Group','Pakwan',1,'Software Engineer')


ALTER PROCEDURE [SP_SearchEmpDetails]
@firstName NVARCHAR(56)='',
@lastName NVARCHAR(56)='',
@country NVARCHAR(56)='',
@state NVARCHAR(56)='',
@city NVARCHAR(56)=''
AS
	BEGIN
	SELECT *FROM [EmployeeDetails] ED
	INNER JOIN [CompanyRecord] CR
	ON ED.[EmpID]=CR.EmpId
	WHERE ED.[FirstName]= @firstName OR
		 ED.[LastName]= @lastName OR
		 ED.[Country]= @country OR
		 ED.[State]= @state OR
		 ED.[City]= @city 
	END
GO

EXEC [SP_SearchEmpDetails] @city='Ahmedabad'