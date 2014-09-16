-- 1. Get the full name (first name + “ “ + last name)  of every employee and its salary, 
-- for each employee with salary between $100 000 and $150 000, inclusive. 
-- Sort the results by salary in ascending order.
SELECT FirstName + ' ' + LastName AS [FullName], YearSalary
FROM Employees
WHERE YearSalary >= 100000 AND YearSalary <= 150000
ORDER BY YearSalary

-- 2. Get all departments and how many employees there are in each one.
-- Sort the result by the number of employees in descending order.
SELECT d.Name AS [DepartmentName], COUNT(*) AS [EmployeesCount]
FROM Departments d
INNER JOIN Employees e
	ON e.DepartmentId = d.Id
GROUP BY d.Name
ORDER BY EmployeesCount DESC

-- 3. Get each employee’s full name (first name + “ “ + last name), project’s name, 
-- department’s name, starting and ending date for each employee in project. 
-- Additionally get the number of all reports, which time of reporting is between the 
-- start and end date. Sort the results first by the employee id, then by the project id. 
-- (This query is slow, be patient!)
SELECT e.FirstName + ' ' + e.LastName AS [FullName],
		d.Name AS [DepartmentName], 
		p.Name AS [ProjectName], ep.StartingDate, ep.EndingDate,
		r.Time
FROM Employees e
INNER JOIN EmployeesProjects ep
	ON e.Id = ep.EmployeeId
INNER JOIN Projects p
	ON p.Id = ep.ProjectId
INNER JOIN Departments d
	ON d.Id = e.DepartmentId
INNER JOIN Reports r
	ON r.EmployeeId = e.Id
WHERE r.[Time] >= ep.StartingDate AND r.[Time] <= ep.EndingDate

