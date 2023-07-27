USE SoftUni

CREATE TABLE Passports(
PassportID int PRIMARY KEY  NOT NULL ,
PassoprtNumber nvarchar(100) NOT NULL,
)

CREATE TABLE  Persons(
    PersonID int PRIMARY KEY NOT NULL,
   FirstName nvarchar(20),
   Salary int,
   PassportID int unique NOT NULL

   FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)
)
