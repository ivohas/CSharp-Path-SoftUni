CREATE DATABASE Zoo

USE Zoo

CREATE TABLE Owners(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
Address VARCHAR(50)
)

CREATE TABLE AnimalTypes(
Id INT IDENTITY PRIMARY KEY,
AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
Id INT IDENTITY PRIMARY KEY,
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id),
)

CREATE TABLE Animals(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages(
CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id),
PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
Id INT IDENTITY PRIMARY KEY,
DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
Address VARCHAR(50),
AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

-- PROBLEM 2
INSERT INTO Animals([Name],BirthDate,OwnerId,AnimalTypeId) VALUES
('Giraffe', '2018-09-21' ,21,1 ),
('Harpy Eagle','2015-04-17',15 ,3),
('Hamadryas Baboon','2017-11-02' ,NULL , 1),
('Tuatara','2021-06-30' ,2 , 4)

INSERT INTO Volunteers (Name,PhoneNumber, Address, AnimalId, DepartmentId) VALUES 
('Anita Kostova','0896365412','Sofia, 5 Rosa str.',15,1),
('Dimitur Stoev','0877564223',null,42,4),
('Kalina Evtimova','0896321112','Silistra, 21 Breza str.',9,7),
('Stoyan Tomov','0898564100','Montana, 1 Bor str.',18,8),
('Boryana Mileva','0888112233',NULL,31,5)


-- PROBELM 3
SELECT * FROM Owners

UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

-- PROBLEM 4
SELECT * FROM Volunteers
DELETE FROM Volunteers
WHERE DepartmentId =2

SELECT * FROM VolunteersDepartments
DELETE FROM VolunteersDepartments
WHERE DepartmentName='Education program assistant'

-- PROBLEM 5
SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId FROM Volunteers
ORDER BY Name,AnimalId,DepartmentId
-- 2/2

-- PROBLEM 6
SELECT [A].[Name], [T].AnimalType, FORMAT(BirthDate,'dd.MM.yyyy') FROM Animals AS [A]
LEFT JOIN AnimalTypes AS [T]
ON [T].Id= [A].AnimalTypeId
ORDER BY [A].[Name]

-- PROBLEM 7
SELECT TOP(5)
[O].[Name] AS Owner,
COUNT([A].[Id]) 
AS CountOfAnimals 
FROM Owners AS [O]
LEFT JOIN Animals AS [A]
ON [O].Id= [A].OwnerId
GROUP BY [O].Name
ORDER BY CountOfAnimals DESC , Owner
-- PROBLEM 8 

 SELECT CONCAT([O].[Name], '-', [A].[Name]) AS [OwnersAnimals],
 [O].PhoneNumber
 ,CageId
 FROM Owners AS [O]
 LEFT JOIN Animals AS [A]
 ON [O].[Id]= [A].[OwnerId]
 LEFT JOIN AnimalTypes AS [T] 
 ON [T].[Id] = [A].[AnimalTypeId]
 LEFT JOIN AnimalsCages AS [AC]
 ON [AC].[AnimalId]=[A].[Id]
 WHERE AnimalType ='Mammals' AND CageId IS NOT NULL 
 ORDER BY [O].[Name], [A].[Name] DESC


 -- PROBLEM 9 

 SELECT [V].[Name], PhoneNumber,TRIM(REPLACE(REPLACE (Address, 'Sofia' ,''),',','')) AS Address FROM Volunteers AS [V]
 LEFT JOIN VolunteersDepartments [VS]
 ON [VS].[Id] = [V].[DepartmentId]
 WHERE [VS].DepartmentName ='Education program assistant'
 AND [V].[Address] LIKE '%Sofia%'
 ORDER BY [V].[Name]

 -- PROBLEM 10 
 SELECT [A].[Name], DATEPART(YEAR,BirthDate) AS BirthYear, AnimalType  FROM Animals AS [A]
 INNER JOIN AnimalTypes AS [AT]
 ON [AT].[Id] = [A].AnimalTypeId
 WHERE DATEDIFF(YEAR,BirthDate,'01/01/2022') < 5
 AND [AT].AnimalType <> 'Birds'
 AND OwnerId IS NULL
 ORDER BY Name
 -- PROBLEM 11 

 GO
 CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30) ) 
     RETURNS INT 
     AS 
     BEGIN


							DECLARE @DEPARMENTID  INT;
							SET @DEPARMENTID =(
										SELECT COUNT(*) 
										FROM Volunteers
									    WHERE DepartmentId = (
									    SELECT [Id] 
										FROM VolunteersDepartments
										WHERE DepartmentName =  @VolunteersDepartment
									    ));
 RETURN @DEPARMENTID
 END;

 -- PROBLEM 12 
 GO
 CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
  AS
  BEGIN 
 
    SELECT [A].[Name],ISNULL( [OW].Name, 'For adoption') AS OwnersName FROM Owners AS [OW]
	RIGHT JOIN Animals AS [A]
	ON [A].OwnerId = OW.Id
   WHERE [A].[Name] = @AnimalName
  END;