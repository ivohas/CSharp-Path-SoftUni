CREATE DATABASE Airport
 USE Airport

 CREATE TABLE Passengers(
Id INT IDENTITY PRIMARY KEY,
FullName VARCHAR(100) UNIQUE NOT NULL,
Email VARCHAR(50) UNIQUE NOT NULL
) 

CREATE TABLE Pilots(
Id INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(30) UNIQUE NOT NULL,
LastName VARCHAR(30) UNIQUE NOT NULL,
Age TINYINT NOT NULL
CHECK (Age >= 21 AND Age <= 62),
Rating FLOAT
CHECK (Rating>=0 AND Rating<= 10)
)  

CREATE TABLE AircraftTypes(
Id INT IDENTITY PRIMARY KEY,
TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft(
Id INT IDENTITY PRIMARY KEY,
Manufacturer VARCHAR(25) NOT NULL,
Model VARCHAR(30) NOT NULL,
Year INT NOT NULL,
FlightHours INT,
Condition CHAR NOT NULL,
TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft(
AircraftId INT NOT NULL REFERENCES Aircraft(Id),
PilotId INT NOT NULL REFERENCES Pilots(Id)
PRIMARY KEY (AircraftId,PilotId)
)

CREATE TABLE Airports(
Id INT IDENTITY PRIMARY KEY,
AirportName VARCHAR(70) UNIQUE NOT NULL,
Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations(
Id INT IDENTITY PRIMARY KEY,
AirportId INT NOT NULL REFERENCES Airports(Id),
Start DateTime NOT NULL,
AircraftId INT NOT NULL REFERENCES Aircraft(Id),
PassengerId INT NOT NULL REFERENCES Passengers(Id),
TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)

-- PROBLEM 2

INSERT INTO Passengers (FullName, Email)
SELECT FirstName + ' ' + LastName AS FullName, 
       REPLACE(FirstName + LastName, ' ', '') + '@gmail.com' AS Email
FROM Pilots
WHERE Id BETWEEN 5 AND 15;

-- PROBLEM 3

UPDATE Aircraft
SET Condition = 'A'
WHERE (Condition = 'B'  OR Condition = 'C')
AND (FlightHours IS NULL OR FlightHours<=100)
AND Year >= 2013

-- PROBLEM 4 

DELETE FROM Passengers
WHERE LEN(FullName) <=10 

-- PROBELM 5 

SELECT Manufacturer, Model, FlightHours, Condition FROM Aircraft
ORDER BY FlightHours DESC

-- PROBLEM 6

SELECT FirstName, LastName, Manufacturer, Model, FlightHours FROM Pilots AS [P]
LEFT JOIN PilotsAircraft AS [PA]
ON [P].[Id]= [PA].PilotId
LEFT JOIN Aircraft AS [A]
ON [A].Id=[PA].AircraftId
WHERE FlightHours IS NOT NULL AND FlightHours<=304
ORDER BY FlightHours DESC,FirstName

-- PROBLEM 7 

SELECT TOP(20)
  FD.Id AS DestinationId, 
  FD.Start, 
  Passengers.FullName, 
  Airports.AirportName, 
  FD.TicketPrice 
FROM 
  FlightDestinations AS [FD]
  INNER JOIN Passengers ON FD.PassengerId = Passengers.Id 
  INNER JOIN Airports ON FD.AirportId = Airports.Id 
WHERE 
  DAY(Start) % 2 = 0 
ORDER BY 
  TicketPrice DESC, 
  AirportName 

 -- PROBLEM 8 

 SELECT 
   [A].[Id] AS AircraftId,
   [Manufacturer],
   AVG(FlightHours) AS FlightHours,
   COUNT(*) AS FlightDestinationsCount,
   ROUND(AVG(TicketPrice),2)AS AvgPrice
 FROM Aircraft AS [A]
   LEFT JOIN FlightDestinations AS [FD] ON [FD].[AircraftId] = [A].[Id]
 GROUP BY 
  [A].[Id],
  [Manufacturer] 
 HAVING COUNT(*) >= 2
 ORDER BY FlightDestinationsCount DESC, [A].[Id],FlightHours

 -- PROBLEM 9 

 SELECT 
   FullName,
   COUNT(*) AS [CountOfAircraft],
--   SUM() AS TotalPayed
 FROM Passengers AS [P]
    LEFT JOIN PilotsAircraft AS [PA] ON [PA].PilotId = [P].Id
    LEFT JOIN Aircraft AS [A] ON  [A].Id = [PA].AircraftId
 GROUP BY FullName
 HAVING SUBSTRING(FullName,2,1) = 'a'
 ORDER BY FullName
