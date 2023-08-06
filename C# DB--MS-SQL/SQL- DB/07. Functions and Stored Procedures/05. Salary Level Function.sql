CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4)) 
RETURNS NVARCHAR(20) AS
BEGIN
	DECLARE @CurrentSalary NVARCHAR(25)
	SET @CurrentSalary = 
	CASE
		WHEN @Salary < 30000 THEN 'Low'
		WHEN @Salary <= 50000 THEN 'Average'
		ELSE 'High'		
	END
		RETURN @CurrentSalary
END