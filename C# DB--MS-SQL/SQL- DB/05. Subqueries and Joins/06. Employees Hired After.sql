	SELECT [E].[FirstName], 
	[E].[LastName],
	[E].[HireDate],
	[D].[Name] AS [DeptName] 
	FROM Employees 
	AS [E]
	LEFT JOIN [Departments]
	AS [D]
	ON [E].DepartmentID=[D].[DepartmentID]
	WHERE convert(datetime, convert(varchar(10), [E].[HireDate], 102))  >= convert(datetime,'1999-01-01') 
	AND [D].[Name] in ('Sales','Finance')
	ORDER BY [E].[HireDate]
	-- HIRE CHECK
