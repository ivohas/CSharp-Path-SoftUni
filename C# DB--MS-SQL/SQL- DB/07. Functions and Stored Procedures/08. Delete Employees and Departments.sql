CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT) AS
DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @DepartmentId
						)

 UPDATE Employees
 SET ManagerID = NULL
 WHERE ManagerID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @DepartmentId
		)

ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

UPDATE Departments
	SET ManagerID = NULL 
	WHERE DepartmentID = @DepartmentId

DELETE FROM Employees
	WHERE DepartmentID = @DepartmentId

DELETE FROM Departments
	WHERE DepartmentID = @DepartmentId

SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @DepartmentId