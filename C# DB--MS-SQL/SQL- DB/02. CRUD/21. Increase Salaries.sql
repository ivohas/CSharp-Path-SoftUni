
 SELECT DepartmentID FROM Departments
 WHERE Name IN ('Engineering', 'Tool Design','Marketing', 'Information Services')

 UPDATE Employees
    SET Salary += Salary*0.12
	WHERE DepartmentID in (1,2,4,11)

SELECT Salary FROM Employees