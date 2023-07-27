USE SoftUni
CREATE TABLE [Manufacturers](
	[ManufacturerID] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(10) Not NULL,
	[EstablishedOn] nvarchar(10)
	
)
CREATE TABLE [Models](
	[ModelID] int PRIMARY KEY  NOT NULL ,
	[Name] nvarchar(100),
	[ManufacturerID] int
	
    FOREIGN KEY([ManufacturerID]) REFERENCES Manufacturers([ManufacturerID])
)






