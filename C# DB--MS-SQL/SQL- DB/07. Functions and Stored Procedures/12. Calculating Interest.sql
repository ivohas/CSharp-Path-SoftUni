CREATE PROC usp_CalculateFutureValueForAccount (@AccID INT, @InterestRate FLOAT)
AS
SELECT 
	a.Id AS [Account Id], 
	ah.FirstName AS [First Name], 
	ah.LastName AS [Last Name], 
	a.Balance AS [Current Balance], 
	dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years] 
FROM AccountHolders AS ah
JOIN Accounts AS a ON a.AccountHolderId=ah.Id AND a.Id = @AccID