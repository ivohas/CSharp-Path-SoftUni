SELECT * FROM Towns
WHERE LEFT([Name],1) IN ('M','B','K','E')
ORDER BY [Name]