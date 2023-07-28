SELECT CountryName AS [Country Name], IsoCode AS [ISO Code] FROM Countries
WHERE LOWER(CountryName)  LIKE '%a%a%a%'
ORDER BY [ISO Code]