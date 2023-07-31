	SELECT
	TOP (5)
	[E].[EmployeeID],
	[E].[FirstName],
	[P].[Name] AS [ProjectName]
	FROM Employees 
	AS [E]
  LEFT JOIN [EmployeesProjects]
	AS [EP]
    ON [E].[EmployeeID]=[EP].[EmployeeID]
  LEFT JOIN [Projects] AS [P]
	ON [P].[ProjectID]= [EP].[ProjectID]
	WHERE convert(datetime, convert(varchar(10), [P].[StartDate], 102))  >= convert(datetime,'2002-08-13')
	AND [P].[EndDate] IS NULL
	ORDER BY [E].[EmployeeID]