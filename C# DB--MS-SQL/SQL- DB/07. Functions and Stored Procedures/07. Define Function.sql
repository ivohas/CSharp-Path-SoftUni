CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(50), @Word NVARCHAR(100)) 
RETURNS BIT AS
BEGIN

	DECLARE @Index INT= 1;	

	WHILE (@Index <= LEN(@Word))
		BEGIN
			--Check if the @setOfLetters contains the current letter 
			IF CHARINDEX(SUBSTRING(@Word, @Index, 1), @SetOfLetters) = 0 
			BEGIN
				RETURN 0
			END 
				SET @Index += 1;
		END

			RETURN 1
END