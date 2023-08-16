CREATE PROC usp_EmployeesBySalaryLevel(@LevelOfSalary NVARCHAR (10)) AS
	SELECT FirstName, LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary