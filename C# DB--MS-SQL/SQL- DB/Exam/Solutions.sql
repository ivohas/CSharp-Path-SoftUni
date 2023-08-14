CREATE DATABASE Boardgames

USE Boardgames

CREATE TABLE Categories (
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
Id INT IDENTITY PRIMARY KEY,
StreetName NVARCHAR(100) NOT NULL,
StreetNumber INT NOT NULL,
Town VARCHAR(30) NOT NULL,
Country VARCHAR(50) NOT NULL,
ZIP INT NOT NULL
)

CREATE TABLE Publishers(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(30) UNIQUE NOT NULL,
AddressId INT NOT NULL REFERENCES Addresses(Id),
Website NVARCHAR(40),
Phone NVARCHAR(20)
)

CREATE TABLE PlayersRanges (
Id INT IDENTITY PRIMARY KEY,
PlayersMin INT NOT NULL,
PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(30) NOT NULL,
YearPublished INT NOT NULL,
Rating DECIMAL(20,2) NOT NULL,
CategoryId INT NOT NULL REFERENCES Categories(Id),
PublisherId INT NOT NULL REFERENCES Publishers(Id),
PlayersRangeId INT NOT NULL REFERENCES PlayersRanges(Id)
)

CREATE TABLE Creators(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames(
CreatorId INT NOT NULL REFERENCES Creators(Id),
BoardgameId INT NOT NULL REFERENCES Boardgames(Id)
PRIMARY KEY (CreatorId,BoardgameId)
)

-- PROBLEM 2

INSERT INTO Boardgames (Name,YearPublished,Rating,CategoryId,PublisherId,PlayersRangeId)
VALUES 
('Deep Blue',2019 ,5.67 ,1,15,7),
('Paris', 2016, 9.78,7 ,1 ,5),
('Catan: Starfarers',2021 ,9.87 ,7 ,13 ,6),
('Bleeding Kansas',2020 ,3.25 , 3, 7,4),
('One Small Step', 2019,5.75 ,5 ,9 ,2)

INSERT INTO Publishers(Name,AddressId,Website,Phone) VALUES 
('Agman Games', 5,'www.agmangames.com','+16546135542'),
('Amethyst Games',7 ,'www.amethystgames.com','+15558889992'),
('BattleBooks', 13,'www.battlebooks.com','+12345678907')

-- PROBLEM 3

UPDATE PlayersRanges
SET PlayersMax = PlayersMax + 1
WHERE PlayersMin = 2 AND PlayersMax = 2;

UPDATE Boardgames
SET Name = CONCAT(Name, 'V2')
WHERE YearPublished >= 2020;


-- PROBLEM 4
DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN (
SELECT Id FROM Boardgames
WHERE PublisherId IN (
SELECT Id
FROM Publishers
WHERE AddressId IN (
SELECT Id
FROM Addresses
WHERE Town LIKE 'L%'
))
)

DELETE FROM Boardgames
WHERE PublisherId IN (
SELECT Id
FROM Publishers
WHERE AddressId IN (
SELECT Id
FROM Addresses
WHERE Town LIKE 'L%'
))

DELETE FROM Publishers
WHERE AddressId IN (
SELECT Id
FROM Addresses
WHERE Town LIKE 'L%'
)

DELETE FROM Addresses
WHERE Town LIKE 'L%'
-- PROBLEM 5

SELECT Name,Rating FROM Boardgames
ORDER BY YearPublished,Name DESC

-- PROBLEM 6

SELECT BG.Id,BG.Name,YearPublished, C.Name FROM Boardgames AS [BG]
LEFT JOIN Categories AS [C] ON C.Id= BG.CategoryId
WHERE C.Name = 'Strategy Games' OR C.Name ='Wargames'
ORDER BY YearPublished DESC 

-- PROBLEM 7 

SELECT C.Id, CONCAT(C.FirstName,' ',C.LastName) AS CreatorName,
Email
FROM Creators AS C
FULL OUTER JOIN CreatorsBoardgames AS CB ON C.Id= CB.CreatorId
FULL OUTER JOIN Boardgames AS BG ON BG.Id= CB.CreatorId
WHERE BG.Name IS NULL

-- PROBLEM 8 
SELECT TOP(5) BG.Name, BG.Rating, CA.Name AS CategoryName
FROM Boardgames AS [BG]
LEFT JOIN Categories AS [CA] ON CA.Id = BG.CategoryId
LEFT JOIN PlayersRanges AS PG ON BG.PlayersRangeId = PG.Id
WHERE (BG.Rating > 7.00 AND BG.Name LIKE '%a%')
   OR (BG.Rating > 7.50 AND PG.PlayersMin = 2 AND PG.PlayersMax = 5)
ORDER BY BG.Name ASC, BG.Rating DESC;

-- PROBLEM 9

SELECT CONCAT(FirstName, ' ', LastName) AS FullName,Email, MAX(Rating) AS Rating FROM Creators AS C
INNER JOIN CreatorsBoardgames AS CB ON CB.CreatorId= C.Id
INNER JOIN Boardgames AS BG ON BG.Id = CB.BoardgameId
WHERE C.Email LIKE '%.com'
GROUP BY C.FirstName,C.LastName, Email
ORDER BY FullName 

-- PROBLEM 10 


SELECT 
	C.LastName,
	CEILING(AVG(BG.Rating)) AS AverageRating,
	P.Name AS PublisherName
FROM Creators AS C
	INNER JOIN CreatorsBoardgames AS CB ON C.Id = CB.CreatorId
	INNER JOIN Boardgames AS BG ON CB.BoardgameId = BG.Id
	INNER JOIN Publishers AS P ON BG.PublisherId = P.Id
WHERE P.Name = 'Stonemaier Games'
GROUP BY C.Id, C.LastName, P.Name
ORDER BY AVG(BG.Rating) DESC;


-- PROBLEM 11 

GO 
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN 
   RETURN(
   SELECT  COUNT(BG.Id) FROM Creators AS C
   LEFT JOIN CreatorsBoardgames AS CB ON CB.CreatorId = C.Id
   LEFT JOIN Boardgames AS BG ON BG.Id = CB.BoardgameId
   WHERE FirstName =@name
   )
END



--  PROBLEM 12 
GO 
CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
AS
BEGIN
  SELECT BG.Name, BG.YearPublished,
  BG.Rating, 
  C.Name AS CategoryName, 
  P.Name AS PublisherName, 
  CONCAT(PG.PlayersMin, ' people') AS MinPlayers,
  CONCAT(PG.PlayersMax, ' people') AS MaxPlayers
    FROM Boardgames AS BG
    INNER JOIN Categories AS C ON BG.CategoryId = C.Id
    INNER JOIN Publishers AS P ON BG.PublisherId = P.Id
    INNER JOIN PlayersRanges AS PG ON BG.PlayersRangeId = PG.Id
    WHERE C.Name = @category
    ORDER BY PublisherName ASC, YearPublished DESC;
END

EXEC usp_SearchByCategory 'Wargames'