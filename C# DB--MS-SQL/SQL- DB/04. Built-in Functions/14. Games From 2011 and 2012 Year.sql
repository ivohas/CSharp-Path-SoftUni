SELECT TOP (50) Name,
                FORMAT(CAST(Start AS DATE), 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, Start) BETWEEN 2011 AND 2012
ORDER BY Start,
         Name;