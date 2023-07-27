USE Geography;

SELECT MountainRange,
       PeakName,
       Elevation
FROM Peaks
     JOIN Mountains ON Peaks.MountainId = Mountains.Id
WHERE Peaks.MountainId =
(
    SELECT Id
    FROM Mountains
    WHERE MountainRange = 'Rila'
)
ORDER BY Peaks.Elevation DESC;