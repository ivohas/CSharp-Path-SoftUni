 SELECT 
  COUNT(*) AS [Count]
  FROM [Employees]
  GROUP BY [ManagerID]
  HAVING [ManagerID] IS NULL