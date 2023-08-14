CREATE DATABASE Service

USE Service

CREATE TABLE Users(
Id INT IDENTITY PRIMARY KEY,
Username VARCHAR(30) UNIQUE NOT NULL,
Password VARCHAR(50) NOT NULL,
Name VARCHAR(50) NOT NULL,
Birthdate DATE NOT NULL,
Age INT 
  CHECK(Age>=14 AND Age<=110),
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DateTime,
Age INT CHECK(Age>=18 AND Age<=110),
DepartmentId INT REFERENCES Departments(Id) 
)

CREATE TABLE Categories(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
DepartmentId INT NOT NULL REFERENCES Departments(Id)
)

CREATE TABLE Status(
Id INT IDENTITY PRIMARY KEY,
Label VARCHAR(20) NOT NULL
)

CREATE TABLE Reports(
Id INT IDENTITY PRIMARY KEY,
CategoryId INT NOT NULL REFERENCES Categories(Id),
StatusId INT NOT NULL REFERENCES Status(Id),
OpenDate DateTime NOT NULL,
CloseDate DateTime,
Description VARCHAR(200)  NOT NULL,
UserId INT NOT NULL REFERENCES Users(Id),
EmployeeId INT REFERENCES Employees(Id)
)

-- 30/30 
-- PROBLEM 2

INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
 VALUES
 ('Marlo','O''Malley',1958-9-21,1),
 ('Niki','Stanaghan',1969-11-26,4),
  ('Ayrton','Senna',1960-03-21,9),
   ('Ronnie','Peterson',1944-02-14,9),
    ('Giovanna','Amati',1959-07-20,5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId)
 VALUES 
 (1,1,2017-04-13,NULL,'Stuck Road on Str.133',6,2),
 (6,3,2015-09-05,2015-12-06,'Charity trail running',3,5),
 (14,2,2015-09-07,NULL,'Falling bricks on Str.58',5,2),
 (4,3,2017-07-03,2017-07-06,'Cut off streetlight on Str.11',1,1)

 -- 2/2 
 -- PROBLEM 3

 UPDATE Reports
 SET CloseDate = GETDATE()
 WHERE CloseDate IS NULL 
 -- 4/4 

 -- PROBLEM 4
 SELECT * FROM Reports
 DELETE Reports
 WHERE StatusId = 4
 -- 4/4

 -- PROBLEM 5

 SELECT 
 R.Description , FORMAT(R.OpenDate,'dd-MM-yyyy') AS OpenDate
 FROM Reports AS [R]
 WHERE EmployeeId IS NULL
 ORDER BY R.OpenDate, R.Description
 -- 3/3

 -- PROBLEM 6

 SELECT Description, Name AS  CategoryName
 FROM Reports AS [R]
 JOIN Categories AS [C]
 ON C.Id= R.CategoryId
 ORDER BY Description, Name
 -- 5/5
 -- PROBLEM 7

 SELECT TOP (5) Name AS CategoryName, COUNT(*) AS  ReportsNumber FROM  Reports [R]
 LEFT JOIN Categories AS [C]
 ON C.Id = R.CategoryId
 GROUP BY Name
 ORDER BY ReportsNumber DESC , CategoryName 
 -- 6/6
 -- PROBLEM 8

 SELECT Username AS [Username], [C].Name AS [CategoryName] FROM Users AS [U] 
 LEFT JOIN Reports AS R
 ON U.Id= R.UserId
 LEFT JOIN Categories AS [C]
 ON [C].Id= R.CategoryId
 WHERE (FORMAT (U.Birthdate,'dd/MM') =  FORMAT (R.OpenDate,'dd/MM'))
 OR (FORMAT (U.Birthdate,'dd/MM') =  FORMAT (R.CloseDate,'dd/MM'))
 ORDER BY Username, CategoryName
 -- 7/7

 -- PROBLEM 9 

  SELECT CONCAT([E].FirstName, ' ', [E].[LastName]) AS FullName, ISNULL(COUNT(*),0) AS UsersCount FROM [Employees] AS [E]
   JOIN [Reports] AS [R]
  ON [R].[EmployeeId] = [E].[Id]
  LEFT  JOIN  [Users] AS [U]
  ON [U].[Id] = [R].[UserId]
  GROUP BY CONCAT([E].FirstName, ' ', [E].[LastName]) 
  ORDER BY UsersCount DESC, FullName



 -- PROBLEM 10