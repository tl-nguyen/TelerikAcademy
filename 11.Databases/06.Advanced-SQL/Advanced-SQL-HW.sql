USE TelerikAcademy
GO

-- 1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.
SELECT FirstName, LastName, MiddleName, Salary
	FROM Employees
	WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- 2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, MiddleName, Salary
	FROM Employees
	WHERE Salary <= (SELECT MIN(Salary) FROM Employees) + (SELECT MIN(Salary) FROM Employees) * 0.1
	ORDER BY Salary

-- 3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.
SELECT e.FirstName + ' ' + ISNULL(e.MiddleName + ' ', '') + e.LastName AS [FullName], d.Name AS DepName
	FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary = (SELECT MIN(Salary) FROM Employees)

-- 4. Write a SQL query to find the average salary in the department #1.
SELECT AVG(e.Salary) AS AverageSalary
	FROM Employees e
	WHERE e.DepartmentID = 1

-- 5. Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(e.Salary) AS AverageSalary
	FROM Employees e
	WHERE e.DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')

-- 6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*)
	FROM Employees e
	WHERE e.DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')

-- 7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*)
	FROM Employees
	WHERE ManagerID IS NOT NULL

-- 8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*)
	FROM Employees
	WHERE ManagerID IS NULL

-- 9. Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name AS DepName, AVG(e.Salary) AS AvgSalary
	FROM Departments d, Employees e
	WHERE d.DepartmentID = e.DepartmentID
	GROUP BY d.Name
	ORDER BY AvgSalary DESC

-- 10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name AS TownName, d.Name AS DepName, COUNT(*) AS EmpCount
	FROM Towns t, Departments d, Employees e, Addresses a
	WHERE t.TownID = a.TownID 
			AND e.AddressID = a.AddressID 
			AND d.DepartmentID = e.DepartmentID
	GROUP BY t.Name, d.Name
	ORDER BY TownName

-- 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT FirstName, LastName
	FROM Employees m
	WHERE (SELECT COUNT(*) FROM Employees e WHERE e.ManagerID = m.EmployeeID) = 5

-- 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.*, ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS Manager
	FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID

-- 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function
SELECT FirstName, MiddleName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5

-- 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". 
-- Search in Google to find how to format dates in SQL Server.
SELECT CONVERT(VARCHAR, GETDATE(), 104) + ' ' + RIGHT(CONVERT(VARCHAR, GETDATE(), 113),12) 

-- 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
-- Choose appropriate data types for the table fields.
-- Define a primary key column with a primary key constraint. 
-- Define the primary key column as identity to facilitate inserting records.
-- Define unique constraint to avoid repeating usernames. 
-- Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users (
	UserID int IDENTITY PRIMARY KEY,
	Username nvarchar(50) NOT NULL,
	Password nvarchar(50) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastLogin DateTime,
	CONSTRAINT UK_UserNames UNIQUE(Username),
	CONSTRAINT PK_Password CHECK (LEN(Password) >= 5)
)
GO

-- 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
-- Test if the view works correctly.
INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES ('ivan', 'password', 'Ivan Ivanov', GETDATE())

INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES ('petyr', 'password', 'Petyr Petkov', GETDATE())

INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES ('maria', 'password', 'Maria Lazarova', '2014-1-1')
GO

CREATE VIEW [LoggedInUsers] 
AS
	SELECT * 
	FROM Users
	WHERE DATEDIFF(day, LastLogin, GETDATE()) = 0
GO

-- 17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
-- Define primary key and identity column.
CREATE TABLE Groups (
	GroupID int IDENTITY PRIMARY KEY,
	Name nvarchar(50) NOT NULL,
	CONSTRAINT UK_Name UNIQUE(Name)
)
GO

-- 18. Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column and as well in the Groups table.
-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
INSERT INTO Groups(Name)
VALUES('Dev')

INSERT INTO Groups(Name)
VALUES('Test')
GO

ALTER TABLE Users
	ADD GroupID int
GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupID)
	REFERENCES Groups(GroupID)
GO

UPDATE Users
SET GroupID = 1
GO

UPDATE Users
SET GroupID = 2
WHERE Username = 'maria'
GO

-- 19. Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Groups(Name)
VALUES('Design')

INSERT INTO Groups(Name)
VALUES('Mobile')

INSERT INTO Groups(Name)
VALUES('Desktop')
GO

INSERT INTO Users(Username, Password, FullName, LastLogin, GroupID)
VALUES ('gosho', 'password', 'Grigor Grigorov', GETDATE(), 2)

INSERT INTO Users(Username, Password, FullName, LastLogin, GroupID)
VALUES ('vankata', 'password', 'Ivan Petkov', GETDATE(), 3)

INSERT INTO Users(Username, Password, FullName, LastLogin, GroupID)
VALUES ('dodo', 'password', 'Petyr Dodev', GETDATE(), 4)
GO

-- 20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Password = 'passw'
WHERE Username = 'gosho'

UPDATE Groups
SET Name = 'web dev'
WHERE Name = 'dev'
GO

-- 21. Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE Users
WHERE Username = 'gosho'

DELETE Groups
WHERE Name = 'Desktop'
GO

-- 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
-- Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase).
-- Use the same for the password, and NULL for last login time.
ALTER TABLE Users
DROP CONSTRAINT PK_Password

ALTER TABLE Users
DROP CONSTRAINT UK_UserNames

INSERT INTO Users(Username, Password, FullName, LastLogin)
	SELECT LOWER(LEFT(FirstName, 1) + LastName), 
			LOWER(LEFT(FirstName, 1) + LastName),
			FirstName + ' ' + LastName,
			NULL
	FROM Employees
GO

-- 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES ('svetla', 'password', 'Svetlana', '2010-1-1')
GO

ALTER TABLE Users
ALTER COLUMN Password nvarchar(50) NULL
GO

UPDATE Users
SET Password = NULL
WHERE LastLogin < '2010-03-10'
GO

-- 24. Write a SQL statement that deletes all users without passwords (NULL password).
DELETE Users
WHERE Password IS NULL
GO

-- 25. Write a SQL query to display the average employee salary by department and job title.
SELECT e.JobTitle, d.Name AS DepName, AVG(e.Salary) AS AvgSalary
	FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	GROUP BY e.JobTitle, d.Name

-- 26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT MIN(e.FirstName + ' ' + e.LastName) AS Name, e.JobTitle, d.Name AS DepName, MIN(e.Salary) AS MinSalary
	FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	GROUP BY e.JobTitle, d.Name
	ORDER BY JobTitle

-- 27. Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(*) AS [Count]
	FROM Towns t
	INNER JOIN Addresses a
		ON a.TownID = t.TownID
	INNER JOIN Employees e
		ON e.AddressID = a.AddressID
	GROUP BY t.Name
	ORDER BY [Count] DESC

-- 28. Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(*) AS [ManagerCount]
	FROM Towns t
	INNER JOIN Addresses a
		ON a.TownID = t.TownID
	INNER JOIN Employees e
		ON e.AddressID = a.AddressID
	WHERE e.ManagerID IS NULL
	GROUP BY t.Name
	ORDER BY [ManagerCount] DESC

-- 29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
-- Don't forget to define  identity, primary key and appropriate foreign key.  
--		Issue few SQL statements to insert, update and delete of some data in the table.
--		Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--			For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours(
	WorkHourID int IDENTITY PRIMARY KEY,
    EmployeeID int NOT NULL,
    [Date] DATETIME NOT NULL,
    Task nvarchar(256) NOT NULL,
    [Hours] int NOT NULL,
    Comments nvarchar(256),
    CONSTRAINT FK_Employees_WorkHours 
        FOREIGN KEY (EmployeeID)
        REFERENCES Employees(EmployeeID)
)
GO

INSERT INTO WorkHours(EmployeeId, [Date], Task, [Hours])
    VALUES (1, GETDATE(), 'Have fun', 4),
			(2, GETDATE(), 'Have fun', 6),
			(3, GETDATE(), 'Do stuffs', 8),
			(4, GETDATE(), 'Do stuffs', 8),
			(5, GETDATE(), 'Do stuffs', 8),
			(6, GETDATE(), 'Do stuffs', 12),
			(7, GETDATE(), 'Sleep', 2)
GO

UPDATE WorkHours
	SET Comments = 'Great Job'
	WHERE [Hours] > 8

DELETE WorkHours
	WHERE [Hours] < 4


-- 30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
-- At the end rollback the transaction.
BEGIN TRAN
ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees
GO

ALTER TABLE WorkHours
	DROP CONSTRAINT FK_Employees_WorkHours
GO

DELETE Employees
WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')
GO
ROLLBACK TRAN

-- 31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
BEGIN TRANSACTION
DROP TABLE EmployeesProjects
ROLLBACK TRANSACTION

-- 32. Find how to use temporary tables in SQL Server.
-- Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.