	SELECT 
	[E].[EmployeeID],
	[E].[FirstName],
	CASE 
	WHEN YEAR([P].[StartDate]) >= 2005 
	THEN NULL
	ELSE [P].[Name]
	END  AS [ProjectName]
	FROM [Employees] 
	AS [E]
 LEFT JOIN [EmployeesProjects] 
	AS [EP]
    ON [E].[EmployeeID] = [EP].[EmployeeID]
 LEFT JOIN [Projects] 
	AS [P]
	ON [P].[ProjectID]=[EP].[ProjectID]
	WHERE [E].[EmployeeID] = 24
