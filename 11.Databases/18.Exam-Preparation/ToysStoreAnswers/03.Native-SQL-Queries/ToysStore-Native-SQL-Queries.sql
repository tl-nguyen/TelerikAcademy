-- Problem 3. SQL Queries (15 points)
-- Write three queries in native SQL:
USE [ToysStore]

-- 1. Get all toys’s name and price having type of “puzzle” and price above $10.00 ordering them by price
SELECT Name, Price
FROM Toys
WHERE Type = 'puzzle' AND Price > 10.00
ORDER BY Price

-- 2. Get all manufacturers’ name and how many toys they have in the age range of 5 to 10 years, inclusive
-- My Query
SELECT m.Name AS ManufactorName, COUNT(*) [ToysCount]
FROM Manufacturers m
	INNER JOIN Toys t
	ON m.Id = t.ManufacturerId
	INNER JOIN AgeRanges a
	ON a.Id = t.AgeRangeId
WHERE 5 <= a.MinAge AND a.MaxAge <= 10
GROUP BY m.Name
ORDER BY m.Name

-- Ivo's Query
SELECT m.Name,
(SELECT COUNT(*)
FROM Toys t
INNER JOIN AgeRanges a
	ON t.AgeRangeId = a.Id
WHERE a.MinAge >= 5 AND a.MaxAge <= 10 AND m.Id = t.ManufacturerId) AS [Count]
FROM Manufacturers m
ORDER BY m.Name

-- 3. Get all toys’ name, price and color from category “boys” 
SELECT t.Name, t.Price, t.Color
FROM Toys t
	INNER JOIN Toys_Categories tc
	ON t.Id = tc.ToyId
	INNER JOIN Categories c
	ON c.Id = tc.CategoryId
WHERE c.Name = 'boys'