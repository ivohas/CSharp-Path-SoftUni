CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(155)) 
RETURNS TABLE AS
	RETURN SELECT SUM(Cash) AS SumCash FROM

		(SELECT ug.Cash, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNumber FROM UsersGames AS ug 
		JOIN Games AS g ON ug.GameId = g.Id
		WHERE g.Name = @GameName
		) AS AllGames
		WHERE RowNumber % 2 = 1