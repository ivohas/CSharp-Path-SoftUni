 SELECT 
 TOP(5)
 [E].[EmployeeID],
 [E].[FirstName],
 [E].[Salary],
 [D].[Name] AS [DepartmentName]
 FROM Employees
 AS [E]
 LEFT JOIN [Departments] AS [D]
 ON [E].[DepartmentID]= [D].[DepartmentID]
 WHERE [E].[Salary] >15000
 ORDER BY [E].[DepartmentID]
   