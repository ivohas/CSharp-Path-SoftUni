USE [MINI]

CREATE TABLE [Cities](
	[CityID] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(100) NOT NULL

)

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Birthday] NVARCHAR(100) NOT NULL,
	[CityID] Int FOREIGN KEY REFERENCES [Cities]([CityID])
)

CREATE TABLE [Orders](
	[OrderID] INT PRIMARY KEY NOT NULL,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(100)
)

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY NOT NULL, 
	[Name] NVARCHAR(100) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) 
)

CREATE TABLE [OrderItems](
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID])  NOT NULL,
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]) NOT NULL,
	PRIMARY KEY ([OrderID],[ItemID])
)
