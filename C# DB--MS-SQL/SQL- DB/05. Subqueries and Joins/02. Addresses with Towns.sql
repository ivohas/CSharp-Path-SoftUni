	SELECT 
	TOP(50) 
	[E].[FirstName],[E].[LastName],
	[T].[Name] AS [Town],
	[A].[AddressText] 
	FROM [Employees]
	AS [E]
  LEFT JOIN [Addresses] 
  AS [A]
  ON [E].[AddressID]=[A].[AddressID]
  LEFT JOIN[Towns] AS [T]
  ON [T].[TownID]=[A].[TownID]
  ORDER BY [E].[FirstName],[E].[LastName] 