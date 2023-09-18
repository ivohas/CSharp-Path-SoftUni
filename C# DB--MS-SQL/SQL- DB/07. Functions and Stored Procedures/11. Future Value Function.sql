CREATE FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(20,2), @YearlyInterest FLOAT, @Years INT)
RETURNS DECIMAL(20,4) AS
BEGIN
	DECLARE @Result DECIMAL(20,4) = @Sum * POWER((1+@YearlyInterest), @Years)
	RETURN @Result
END