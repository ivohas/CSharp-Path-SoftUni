CREATE DATABASE NationalTouristSitesOfBulgaria1
USE NationalTouristSitesOfBulgaria1

CREATE TABLE Categories(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Locations(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Municipality VARCHAR(50),
Province VARCHAR(50)
)

CREATE TABLE Sites(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
LocationId INT NOT NULL REFERENCES Locations(Id),
CategoryId INT NOT NULL REFERENCES Categories(Id),
Establishment VARCHAR(15)
)

CREATE TABLE Tourists(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Age INT NOT NULL
 CHECK(Age>=0 AND Age<=120),
PhoneNumber VARCHAR(20) NOT NULL,
Nationality VARCHAR(30) NOT NULL,
Reward VARCHAR(20)
)

CREATE TABLE SitesTourists(
TouristId INT NOT NULL REFERENCES Tourists(Id),
SiteId INT NOT NULL REFERENCES Sites(Id)
PRIMARY KEY(TouristId,SiteId)
)

CREATE TABLE BonusPrizes(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes(
TouristId INT NOT NULL REFERENCES Tourists(Id),
BonusPrizeId INT NOT NULL REFERENCES BonusPrizes(Id)
PRIMARY KEY (BonusPrizeId,TouristId)
)
--13
-- PROBLEM 2

INSERT INTO Tourists(Name,Age,PhoneNumber, Nationality, Reward ) VALUES
('Borislava Kazakova',52,'+359896354244','Bulgaria',NULL),
('Peter Bosh',48,'+447911844141','UK',NULL),
('Martin Smith',29,'+353863818592','Ireland','Bronze badge'),
('Svilen Dobrev',49,'+359986584786','Bulgaria','Silver badge'),
('Kremena Popova',38,'+359893298604','Bulgaria',NULL)


INSERT INTO Sites(Name, LocationId, CategoryId, Establishment) VALUES 
('Ustra fortress',90,7,'X'),
('Karlanovo Pyramids',65,7,NULL),
('The Tomb of Tsar Sevt',63,8,'V BC'),
('Sinite Kamani Natural Park',17,1,NULL),
('St. Petka of Bulgaria – Rupite',92,6,'1994')
-- PROBELM 3

UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL 
-- PROBLEM 4
SELECT * FROM BonusPrizes
DELETE FROM BonusPrizes
WHERE Id=5


-- PROBLEM 5
SELECT Name, Age , PhoneNumber, Nationality FROM Tourists
ORDER BY Nationality, Age DESC , Name

-- PROBLEM 6
 

SELECT 
  [S].Name AS Site,
  [L].Name AS [Location],
  [S].Establishment,
  [C].Name AS [Category]
FROM Sites AS [S]
	LEFT JOIN Locations AS [L] ON [S].LocationId = L.Id
	LEFT JOIN Categories AS [C] ON C.Id =S.CategoryId
ORDER BY Category DESC, Location,Site


-- PROBLEM 7

SELECT l.Province, l.Municipality, l.Name AS 'Location', COUNT(s.Name) AS CountOfSites
FROM Locations AS l
JOIN Sites AS s ON s.LocationId = l.Id
WHERE l.Province = 'Sofia'
GROUP BY l.Name, l.Municipality, l.Province
ORDER BY CountOfSites DESC, l.Name

-- PROBLEM 8
SELECT 
	[S].Name AS [Site],
	L.[Name] AS [Location], 
	Municipality, 
	Province, 
	Establishment 
FROM Sites AS [S]
	LEFT JOIN Locations AS [L] ON [L].Id =[S].LocationId
WHERE LEFT(l.Name, 1) NOT LIKE '[B,M,D]'
 AND Establishment LIKE '%BC'
 ORDER BY [S].Name

 -- PROBLEM 9 

 SELECT T.Name, Age , PhoneNumber, Nationality, ISNULL(B.Name,'(no bonus prize)') AS [Reward]
 FROM Tourists AS [T]
 LEFT JOIN TouristsBonusPrizes AS [TB] ON TB.TouristId= T.Id
 LEFT JOIN BonusPrizes AS [B] ON B.Id= TB.BonusPrizeId
 ORDER BY T.Name

 -- PROBELM 10 
 SELECT 
 SUBSTRING(t.Name, CHARINDEX(' ', t.Name) + 1, LEN(t.Name)) AS LastName,
 Nationality,
 Age,
 PhoneNumber
 FROM Tourists AS [T]
 LEFT JOIN SitesTourists AS [ST] ON [ST].TouristId = [T].Id
 LEFT JOIN Sites AS [S] ON [ST].SiteId = [S].Id
 LEFT JOIN Categories AS [C] ON C.Id = S.CategoryId
 WHERE C.Name = 'History and archaeology'
 GROUP BY T.Name, Nationality, Age, PhoneNumber
 ORDER BY LastName

 -- PROBLEM 11 
 GO
CREATE FUNCTION udf_GetTouristsCountOnATouristSite(@Site VARCHAR (100))
RETURNS INT
AS
BEGIN	
	RETURN(SELECT COUNT(t.Id) FROM Tourists AS t
	JOIN SitesTourists AS st ON t.Id = st.TouristId
	JOIN Sites AS s ON s.Id = st.SiteId
	WHERE s.Name = @Site)
END

-- PROBLEM 12
GO
CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 100
	BEGIN 
			UPDATE Tourists
			SET	Reward = 'Gold badge'
			WHERE Name = @TouristName
	END
ELSE IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 50
	BEGIN 
			UPDATE Tourists
			SET	Reward = 'Silver badge'
			WHERE Name = @TouristName
	END
ELSE IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 25
	BEGIN 
			UPDATE Tourists
			SET	Reward = 'Bronze badge'
			WHERE Name = @TouristName
	END
SELECT Name, Reward FROM Tourists
WHERE Name = @TouristName
END


GO
CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 100
	BEGIN 
			UPDATE Tourists
			SET	Reward = 'Gold badge'
			WHERE Name = @TouristName
	END
ELSE IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 50
	BEGIN 
			UPDATE Tourists
			SET	Reward = 'Silver badge'
			WHERE Name = @TouristName
	END
ELSE IF (SELECT COUNT(s.Id) FROM Sites AS s
			JOIN SitesTourists AS st ON s.Id = st.SiteId
			JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE t.Name = @TouristName) >= 25
	BEGIN 
			UPDATE Tourists
			SET	Reward = 'Bronze badge'
			WHERE Name = @TouristName
	END
SELECT Name, Reward FROM Tourists
WHERE Name = @TouristName
END