

-- 1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands. 
-- Structured Query Language - SQL - Declarative language for query and manipulation of relational data 
-- Data Manipulation Language - DML - A Part of SQL - used for manipulation of existing data using several methods: SELECT, INSERT, UPDATE, DELETE
-- Data Definition Language - DDL - A Part of SQL - used for Defining or deleting a data object, like tables, databases,... using several methods:
--	CREATE, DROP, ALTER, GRANT, REVOKE

-- 2. What is Transact-SQL (T-SQL)?
-- T-SQL (Transact SQL) is an extension to the standard SQL language
-- T-SQL is the standard language used in MS SQL Server Supports if statements, loops, exceptions
-- Constructions used in the high-level procedural programming languages
-- T-SQL is used for writing stored procedures, functions, triggers, etc. 

-- 3. Start SQL Management Studio and connect to the database TelerikAcademy. 
-- Examine the major tables in the "TelerikAcademy" database.
-- Done

USE TelerikAcademy

-- 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT * FROM Departments

-- 5. Write a SQL query to find all department names.
SELECT Name AS [Department Name] FROM Departments

-- 6. Write a SQL query to find the salary of each employee.
SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name], Salary FROM Employees

-- 7. Write a SQL to find the full name of each employee. 
SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name] FROM Employees

-- 8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
-- Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
-- The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Email Address] FROM Employees

-- 9. Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary FROM Employees

-- 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT * 
	FROM Employees
	WHERE JobTitle = 'Sales Representative'

-- 11. Write a SQL query to find the names of all employees whose first name starts with "SA". 
SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name] 
	FROM Employees
	WHERE FirstName LIKE 'SA%'

-- 12. Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name] 
	FROM Employees
	WHERE LastName LIKE '%ei%'

-- 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT DISTINCT Salary 
	FROM Employees
	WHERE Salary BETWEEN 20000 AND 30000
	ORDER BY Salary

-- 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name], Salary 
	FROM Employees
	WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600
	ORDER BY Salary

-- 15. Write a SQL query to find all employees that do not have manager.
SELECT *
	FROM Employees
	WHERE ManagerID IS NULL

-- 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT *
	FROM Employees
	WHERE Salary > 50000
	ORDER BY Salary DESC

-- 17. Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 *
	FROM Employees
	ORDER BY Salary DESC

-- 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary, a.AddressText AS [Address]
	FROM Employees e
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID

-- 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary, a.AddressText AS [Address]
	FROM Employees e, Addresses a
	WHERE e.AddressID = a.AddressID

-- 20. Write a SQL query to find all employees along with their manager.
SELECT e.*, ISNULL(m.FirstName + ' ' + m.LastName, '') AS Manager
	FROM Employees e, Employees m
	WHERE e.ManagerID = m.EmployeeID

-- 21. Write a SQL query to find all employees, along with their manager and their address.
-- Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT e.*, ISNULL(m.FirstName + ' ' + m.LastName, '') AS Manager, a.AddressText AS [Address]
	FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
		ON e.AddressID = a.AddressID

-- 22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT Name FROM Departments
UNION
SELECT Name FROM Towns

-- 23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
-- Use right outer join. Rewrite the query to use left outer join.
SELECT e.*, ISNULL(m.FirstName + ' ' + m.LastName, '') AS Manager
	FROM Employees m
	RIGHT JOIN Employees e
		ON e.ManagerID = m.EmployeeID

SELECT e.*, ISNULL(m.FirstName + ' ' + m.LastName, '') AS Manager
	FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID

-- 24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.*
	FROM Employees e
	WHERE e.DepartmentID IN (SELECT DISTINCT d.DepartmentID 
								FROM Departments d 
								WHERE d.Name = 'Sales' OR d.Name = 'Finance')
		AND (e.HireDate BETWEEN '1/1/1995' AND '12/31/2005')
	ORDER BY e.HireDate

