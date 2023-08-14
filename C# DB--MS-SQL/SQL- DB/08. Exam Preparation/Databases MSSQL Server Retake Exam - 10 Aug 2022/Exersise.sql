CREATE DATABASE NationalTouristSitesOfBulgaria

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Locations](
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[Municipality] VARCHAR(50),
	[Province] VARCHAR(50)
)

CREATE TABLE [Sites](
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[LocationId] INT NOT NULL FOREIGN KEY REFERENCES [Locations](Id),
	[CategoryId] INT NOT NULL  FOREIGN KEY REFERENCES [Categories](Id),
	[Establishment] VARCHAR(15)
)
-- mid
CREATE TABLE [Tourists](
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
	   CHECK(Age >= 0 AND Age <= 120),
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[Nationality] VARCHAR(30) NOT NULL,
	[Reward] VARCHAR(20) 
)

CREATE TABLE [SitesTourists](
	[TouristId] INT NOT NULL FOREIGN KEY REFERENCES [Tourists](Id),
	[SiteId] INT NOT NULL FOREIGN KEY REFERENCES [Sites](Id)
	PRIMARY KEY ([TouristId],[SiteId])
)

CREATE TABLE [BonusPrizes](
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [TouristsBonusPrizes](
	[TouristId] INT NOT NULL FOREIGN KEY REFERENCES [Tourists](Id),
	[BonusPrizeId] INT NOT NULL FOREIGN KEY REFERENCES [BonusPrizes](Id) 
	PRIMARY KEY([TouristId],[BonusPrizeId])
)
-- 24/30 
-- PROBLEM 2

SET IDENTITY_INSERT Tourists ON

INSERT INTO Tourists(Name, Age, PhoneNumber, Nationality, Reward) VALUES
 ('Borislava Kazakova', 52 , '+359896354244', 'Bulgaria', NULL ),
 ('Peter Bosh', 48, '+447911844141', 'UK', NULL),
 ('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge' ),
 ('Svilen Dobrev', 49 , '+359986584786', 'Bulgaria', 'Silver badge'),
 ('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL )

SET IDENTITY_INSERT Sites ON

 INSERT INTO Sites(Name, LocationId, CategoryId, Establishment) VALUES 
 ('Ustra fortress', 90 , 7, 'X'),
 ('Karlanovo Pyramids', 65, 7, NULL),
 ('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
 ('Sinite Kamani Natural Park', 17 , 1 , NULL),
 ('St. Petka of Bulgaria – Rupite', 92 , 6, '1994') 
 -- 3/3 
 -- PROBLEM 3

 UPDATE Sites 
 SET Establishment ='not defined'
 WHERE Establishment IS NULL

 -- 3/3 
 -- PROBLEM 4

 DELETE FROM TouristsBonusPrizes
 WHERE BonusPrizeId = 5

 SELECT * FROM BonusPrizes
 DELETE FROM BonusPrizes
 WHERE Id = 5 

 -- 4/4
 -- PROBLEM 5

 SELECT [Name], [Age], [PhoneNumber], [Nationality] FROM Tourists
 ORDER BY [Nationality], [Age] DESC, [Name] 

 -- 2/2
 -- PROBLEM  6

 SELECT 
 [S].[Name] AS [Site],
 [L].[Name] AS [Location],
 [S].[Establishment],
 [C].[Name] AS [Location]
 FROM Sites AS [S]
  LEFT JOIN Locations AS [L]
  ON [S].[LocationId]= [L].[Id]
  LEFT JOIN Categories AS [C]
  ON [C].[Id] = [S].[CategoryId]
  ORDER BY [C].[Name] DESC, [L].[Name], [S].[Name]
  
  -- 4/4 
  -- PROBLEM 7

  SELECT Province FROM Locations GROUP BY (Province) 