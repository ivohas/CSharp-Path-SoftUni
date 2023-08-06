CREATE PROC usp_GetTownsStartingWith(@Start NVARCHAR(20)) AS
	SELECT Name AS Town FROM Towns 
	WHERE Name LIKE @Start + '%'