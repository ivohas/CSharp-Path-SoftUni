CREATE or alter PROC usp_GetHoldersWithBalanceHigherThan(@TotalMoney MONEY) AS 

	SELECT ah.FirstName, ah.LastName FROM Accounts AS a
	JOIN AccountHolders AS ah
	ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @totalMoney