CREATE DATABASE CigarShop
 
USE CigarShop

CREATE TABLE Sizes(
Id INT IDENTITY PRIMARY KEY,
Length INT NOT NULL
  CHECK (Length>=10 AND Length<=25),
RingRange DECIMAL(18,2)
 CHECK (RingRange>=1.5 AND RingRange<=7.5)
)

CREATE TABLE Tastes(
Id INT IDENTITY PRIMARY KEY,
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
Id INT IDENTITY PRIMARY KEY,
BrandName  VARCHAR(30) UNIQUE NOT NULL,
BrandDescription VARCHAR(max) 
)

CREATE TABLE Cigars(
Id INT IDENTITY PRIMARY KEY,
CigarName VARCHAR(80) NOT NULL,
BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
PriceForSingleCigar MONEY NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
-- MAY HAVE MORE THAN ONE PK
)

CREATE TABLE Addresses(
Id INT IDENTITY PRIMARY KEY,
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30)  NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(30) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
)

CREATE TABLE ClientsCigars(
ClientId INT FOREIGN KEY REFERENCES Clients(Id),
CigarId INT FOREIGN KEY REFERENCES Cigars(Id)
PRIMARY KEY(CigarId,ClientId)
)

-- 30/30
-- PROBLEM 2

INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
 VALUES
 ('COHIBA ROBUSTO', 9,1 ,5 ,15.50, 'cohiba-robusto-stick_18.jpg'),
 ('COHIBA SIGLO I',9 , 1,10 ,410.00,'cohiba-siglo-i-stick_12.jpg'),
 ('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5,11 ,7.50,'hoyo-du-maire-stick_17.jpg'),
 ('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14 , 4, 15,32.00,'hoyo-de-san-juan-stick_20.jpg'),
 ('TRINIDAD COLONIALES', 2, 3, 8,85.21,' trinidad-coloniales-stick_30.jpg')

 INSERT INTO Addresses(Town, Country, Streat, ZIP) 
   VALUES
   ('Sofia','Bulgaria','18 Bul. Vasil levski',1000),
      ('Athens','Greece','4342 McDonald Avenue',10435),
	     ('Zagreb','Croatia','4333 Lauren Drive',10000)
-- 3/3 
-- PROBLEM 3


UPDATE Cigars
 SET PriceForSingleCigar += PriceForSingleCigar/5
 WHERE TastId = (
    SELECT [Id] FROM Tastes
    WHERE TasteType ='Spicy')

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL
--  3/3 
-- PROBLEM 4
DELETE FROM Clients
WHERE AddressId IN  
    (SELECT [Id] FROM Addresses
	 WHERE  Country LIKE 'C%'
)

SELECT * FROM Addresses
DELETE FROM Addresses
WHERE Country LIKE 'C%'

-- 4/4 

-- PROBLEM 5

SELECT CigarName, PriceForSingleCigar, ImageURL FROM Cigars
ORDER BY PriceForSingleCigar , CigarName DESC 
-- 2/2 

-- PROBLEM 6

SELECT C.Id, C.CigarName, C.PriceForSingleCigar, T.TasteType,
T.TasteStrength
FROM Cigars AS [C]
 LEFT JOIN Tastes AS [T]
 ON T.Id= C.TastId
 WHERE T.TasteType IN ('Earthy', 'Woody')
 ORDER BY PriceForSingleCigar DESC
 -- 4/4 

 -- PROBLEM 7

 SELECT 
 Id, 
 CONCAT (FirstName, ' ', LastName) AS ClientName, 
 Email
 FROM Clients 
 WHERE NOT EXISTS (SELECT 1 FROM ClientsCigars WHERE ClientId= Id)
 ORDER BY ClientName
 -- 8/8

 -- PROBLEM 8

   -- PROBLEM 8

   SELECT TOP (5)
   [C].[CigarName],
   [C].[PriceForSingleCigar],
   [C].[ImageURL]
   FROM Cigars AS [C]
   JOIN Sizes AS [S]
   ON [S].[Id]= [C].[SizeId]
   WHERE [S].[Length] >= 12
   AND ([C].[CigarName] LIKE '%ci%'
   OR [C].[PriceForSingleCigar] >= 50)
   AND [S].[RingRange] >2.55
   ORDER BY [C].[CigarName], [C].[PriceForSingleCigar] DESC
-- 8/8 
-- PROBLEM 9

 SELECT * FROM Addresses AS [A]
 -- LATER 


