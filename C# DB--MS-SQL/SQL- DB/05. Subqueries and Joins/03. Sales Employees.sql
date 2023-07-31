	SELECT 
	[E].[EmployeeID],
	[E].[FirstName],
	[E].[LastName], 
	[D].[Name] AS [DepartmentName]
	FROM Employees 
	AS [E]
	LEFT JOIN [Departments] AS [D]
	ON [E].[DepartmentID]= [D].[DepartmentID]
	WHERE [Name]='Sales'
	ORDER BY [E].[EmployeeID]
	