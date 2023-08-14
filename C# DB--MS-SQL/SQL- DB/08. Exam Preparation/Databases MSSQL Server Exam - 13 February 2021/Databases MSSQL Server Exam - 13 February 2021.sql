 CREATE DATABASE Bitbucket

 GO

 USE [Bitbucket]

 GO
  
-- PROBLEM 1

CREATE TABLE Users (
Id INT IDENTITY PRIMARY KEY,
Username VARCHAR(30) NOT NULL,
Password VARCHAR(30) NOT NULL,
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues(
Id INT IDENTITY PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
IssueStatus VARCHAR(6) NOT NULL,
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(ID)
)

CREATE TABLE Commits(
Id INT IDENTITY PRIMARY KEY,
Message VARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Files(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
Size DECIMAL(15 , 2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)
-- 30/30
-- PROBLEM 2

INSERT INTO Files(Name,Size,ParentId,CommitId) VALUES
('Trade.idk',2598.0,1,1),
('menu.net',9238.31, 2,2 ),
('Administrate.soshy',1246.93,3,3),
('Controller.php',7353.15, 4,4),
('Find.java',9957.86,5,5),
('Controller.json',14034.87,3,6),
('Operate.xix', 7662.92, 7,7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file','open', 1 ,4),
('Typo fix in Judge.html','open',4,3),
('Implement documentation for UsersService.cs','closed',8,2),
('Unreachable code in Index.cs','open', 9, 8)
-- 3/3
 -- PROBLEM 3

 SELECT * FROM Issues

 UPDATE  Issues
 SET IssueStatus='closed'
 WHERE AssigneeId=6
 -- 3/3

 -- PROBLEM 4
SELECT [Id] FROM Repositories
WHERE [Name] ='Softuni-Teamwork'

DELETE FROM RepositoriesContributors 
  WHERE RepositoryId =
		(SELECT [Id] FROM Repositories
		WHERE [Name] ='Softuni-Teamwork')

SELECT Id FROM Issues
 WHERE RepositoryId =
		(SELECT [Id] FROM Repositories
		WHERE [Name] ='Softuni-Teamwork')
	

DELETE FROM Commits
 WHERE IssueId IN (
        SELECT Id FROM Issues
		WHERE RepositoryId =
			(SELECT [Id] FROM Repositories
			WHERE [Name] ='Softuni-Teamwork'))

DELETE FROM Issues 
 WHERE RepositoryId = (SELECT [Id] FROM Repositories
WHERE [Name] ='Softuni-Teamwork') 
-- 4/4 


-- PROBLEM 5

SELECT [Id],
	   [Message], 
	   RepositoryId, 
	   ContributorId FROM Commits
	   ORDER BY Id, Message, RepositoryId, ContributorId
-- 2/2 

-- PROBLEM 6
 
 SELECT Id, Name, Size FROM Files
 WHERE Size >1000
 AND Name LIKE '%html%'
 ORDER BY Size DESC,
 Id, Name
 -- 4/4 

 --PROBLEM 7 
	SELECT [I].[Id],
	CONCAT([U].[Username],' : ', [I].[Title])
    AS [IssueAssignee] 
	FROM Issues AS [I]
 LEFT JOIN Users 
	AS [U]
	ON [I].[AssigneeId] = [U].[Id]
	ORDER BY Id DESC ,Title
-- 8/8

-- PROBLEM 8

	SELECT 
	[FP].Id,
	[FP].[Name],
	CONCAT ([FP].[Size],'KB')
	FROM Files 
	AS [FCH]
	FULL OUTER JOIN Files 
	AS [FP]
	ON FCH.ParentId= FP.Id
	WHERE [FCH].[Id] IS NULL
	-- 8/8

	-- PROBLEM 9
		SELECT 
		TOP(5)
		[R].[Id], 
		[R].[Name], 
		COUNT ([C].[Id]) 
		AS [Commits]
		FROM Repositories 
		AS [R]
     LEFT JOIN Commits 
	    AS [C]
		ON [C].[RepositoryId]= [R].[Id]
	 LEFT JOIN [RepositoriesContributors]
	    AS [RC]
		ON [RC].[RepositoryId]=[R].[Id]
		GROUP BY [R].[Id],[R].[Name] 
		ORDER BY [Commits] DESC, [R].[Id], [R].[Name]

-- 10/10
 -- PROBLEM 10

   SELECT  [U].[Username], AVG([F].[Size]) AS [Size]
    FROM [Users] AS [U]
  INNER JOIN [Commits] AS [C]
   ON [C].[ContributorId] = [U].[Id]
  INNER JOIN Files AS [F]
   ON [F].[CommitId]= [C].[Id]
   GROUP BY [U].[Username]
   ORDER BY [Size] DESC, Username

-- 8/8
  -- PROBLEM 11
  GO
  CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30)) 
  RETURNS INT
  AS 
  BEGIN 
	DECLARE @userId INT=(
	 SELECT [Id] FROM Users
	 WHERE Username = @username
  )
  DECLARE @commitsCnt INT = (
				SELECT COUNT([Id]) FROM [Commits]
				WHERE [ContributorId] =@userId
				)

  RETURN @commitsCnt
  END
  -- 10/10
  -- PROBLEM 12
  GO
  CREATE PROC usp_SearchForFiles @fileExtension VARCHAR(98) 
   AS 
   BEGIN
    SELECT [F].[Id], [F].[Name],CONCAT( [F].[Size],'KB') AS Size FROM Files AS [F]
	WHERE NAME LIKE CONCAT ('%[.]', @fileExtension)
	ORDER BY [F].[Id], [F].Name,[F].Size DESC
   END
   -- 10/10