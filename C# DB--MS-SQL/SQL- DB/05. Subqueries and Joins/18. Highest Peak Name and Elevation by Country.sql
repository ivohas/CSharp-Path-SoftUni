SELECT TOP (5) jt.CountryName AS Country,
               ISNULL(jt.PeakName, '(no highest peak)') AS HighestPeakName,
               ISNULL(jt.Elevation, 0) AS HighestPeakElevation,
               ISNULL(jt.MountainRange, '(no mountain)') AS Mountain
FROM
(
    SELECT c.CountryName,
           DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank,
           p.PeakName,
           p.Elevation,
           m.MountainRange
    FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
         LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
         LEFT JOIN Peaks AS p ON m.Id = p.MountainId
) AS jt
WHERE jt.PeakRank = 1
ORDER BY jt.CountryName,
         jt.PeakName;

-- CASE solution

SELECT TOP (5) jt.CountryName AS Country,
               CASE
                   WHEN jt.PeakName IS NULL
                   THEN '(no highest peak)'
                   ELSE jt.PeakName
               END AS HighestPeakName,
               CASE
                   WHEN jt.Elevation IS NULL
                   THEN 0
                   ELSE jt.Elevation
               END AS HighestPeakElevation,
               CASE
                   WHEN jt.MountainRange IS NULL
                   THEN '(no mountain)'
                   ELSE jt.MountainRange
               END AS Mountain
FROM
(
    SELECT c.CountryName,
           DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank,
           p.PeakName,
           p.Elevation,
           m.MountainRange
    FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
         LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
         LEFT JOIN Peaks AS p ON m.Id = p.MountainId
) AS jt
WHERE jt.PeakRank = 1
ORDER BY jt.CountryName,
         jt.PeakName;