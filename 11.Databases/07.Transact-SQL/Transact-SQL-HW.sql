-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
-- Insert few records for testing. Write a stored procedure that selects the full names of all persons.
CREATE DATABASE Bank

USE Bank
GO

CREATE TABLE Persons (
	PersonID int IDENTITY PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN nvarchar(50) NOT NULL,
)

CREATE TABLE Accounts (
	AccountID int IDENTITY PRIMARY KEY,
	PersonID int NOT NULL,
	Balance money NOT NULL
	CONSTRAINT FK_Persons_Accounts
		FOREIGN KEY (PersonID)
		REFERENCES Persons(PersonID)
)
GO

DECLARE @counter int = 1
WHILE(@counter < 21)
BEGIN
	INSERT INTO Persons(FirstName, LastName, SSN)
	VALUES ('userFn' + CONVERT(varchar, @counter), 'userLn' + CONVERT(varchar, @counter), @counter * 1234)
	SET @counter = @counter + 1
END
GO

DECLARE @counter int = 1
WHILE(@counter < 21)
BEGIN
	INSERT INTO Accounts(PersonID, Balance)
	VALUES (@counter, @counter * 1000)
	SET @counter = @counter + 1
END
GO

CREATE PROC usp_personsFullNames
AS
	SELECT FirstName + ' ' + LastName AS [FullName]
	FROM Persons
GO

EXEC usp_personsFullNames
GO

-- 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_peopleWithHigherBalance(@minMoney int)
AS
	SELECT FirstName + ' ' + LastName AS [FullName],
			a.Balance
	FROM Persons p
	INNER JOIN Accounts a
		ON p.PersonID = a.PersonID
	WHERE a.Balance > @minMoney
GO

EXEC usp_peopleWithHigherBalance 8000
GO

-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. It should calculate and return the new sum.
-- Write a SELECT to test whether the function works as expected.
CREATE FUNCTION ufn_sumWithInterest(@sum money, @interest float, @months int)
RETURNS money
AS
BEGIN
	RETURN @sum + (@sum * @interest) * (CONVERT(float, @months) / 12)
END
GO

SELECT dbo.ufn_sumWithInterest(1000, 0.3, 6)
GO

-- 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.
CREATE PROC usp_oneMonthInterestSumCalculator (@accountID int, @interest float)
AS
BEGIN
	DECLARE @balance money
	SELECT @balance = Balance FROM Accounts WHERE AccountID = @accountID
	SELECT dbo.ufn_sumWithInterest(@balance, @interest, 1)
END
GO

EXEC usp_oneMonthInterestSumCalculator 9, 0.5
GO

-- 5. Add two more stored procedures WithdrawMoney (AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
CREATE PROC usp_withdraw (@accountID int, @amount money)
AS
BEGIN
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @amount
		WHERE AccountID = @accountID AND Balance - @amount >= 0
	COMMIT TRAN
END
GO

CREATE PROC usp_deposit (@accountID int, @amount money)
AS
BEGIN
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @amount
		WHERE AccountID = @accountID
	COMMIT TRAN
END
GO

EXEC usp_withdraw 1, 10
EXEC usp_withdraw 1, 20
EXEC usp_deposit 1, 200
GO

-- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes. 
CREATE TABLE Logs (
	LogID int IDENTITY PRIMARY KEY,
	AccountID int NOT NULL,
	OldSum money,
	NewSum money,
	CONSTRAINT FK_Accounts_Logs
		FOREIGN KEY (AccountID)
		REFERENCES Accounts(AccountID)
)
GO

CREATE TRIGGER tr_balanceChanges ON Accounts FOR UPDATE
AS
	INSERT INTO Logs (AccountID, OldSum, NewSum)
	SELECT n.AccountID, o.Balance, n.Balance
	FROM inserted n, deleted o
	WHERE n.AccountID = o.AccountID
GO

UPDATE Accounts
SET Balance = 20
WHERE AccountID = 2
GO

-- 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
USE TelerikAcademy
GO

CREATE FUNCTION ufn_isComposed (@setOfLetters varchar(50), @name varchar(50))
RETURNS BIT
AS
BEGIN
	DECLARE @lenOfName int = LEN(@name),
			@currentIndex int = 1,
			@currentChar char,
			@isComposed bit = 1

	WHILE (@currentIndex <= @lenOfName)
	BEGIN
		SET @currentChar = LOWER(SUBSTRING(@name, @currentIndex, 1))

		IF (CHARINDEX(@currentChar, LOWER(@setOfLetters)) = 0)
		BEGIN
			SET @isComposed = 0
			BREAK
		END

		SET @currentIndex = @currentIndex + 1
	END
	
	RETURN @isComposed
END
GO

CREATE FUNCTION ufn_comprisedNamesFromEmployeesAndTowns (@setOfLetters varchar(50))
RETURNS TABLE
AS
	RETURN (
		SELECT f.FirstName AS Name
			FROM Employees f
			WHERE dbo.ufn_isComposed(@setOfLetters, f.FirstName) = 1
		UNION
		SELECT l.LastName AS Name
			FROM Employees l
			WHERE dbo.ufn_isComposed(@setOfLetters, l.LastName) = 1
		UNION
		SELECT m.MiddleName AS Name
			FROM Employees m
			WHERE dbo.ufn_isComposed(@setOfLetters, m.MiddleName) = 1 AND m.MiddleName IS NOT NULL
		UNION
		SELECT t.Name
			FROM Towns t
			WHERE dbo.ufn_isComposed(@setOfLetters, t.Name) = 1) 
GO

SELECT * FROM dbo.ufn_comprisedNamesFromEmployeesAndTowns('oistmiahf')
GO

-- 8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT e1.FirstName + ' ' + e1.LastName AS Employee1Name, e2.FirstName + ' ' + e2.LastName AS Employee2Name, t1.Name AS TownName
	FROM Employees e1, Employees e2, Addresses a1, Addresses a2, Towns t1, Towns t2
	WHERE e1.AddressID = a1.AddressID AND a1.TownID = t1.TownID AND
			e2.AddressID = a2.AddressID AND a2.TownID = t2.TownID AND
			t1.TownID = t2.TownID AND e1.EmployeeID <> e2.EmployeeID

	OPEN empCursor
	DECLARE @firstEmpName char(50), @secondEmpName char(50), @townName char(50)
	FETCH NEXT FROM empCursor INTO @firstEmpName, @secondEmpName, @townName

	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @firstEmpName + ' ' + @secondEmpName + ' => ' + @townName
		FETCH NEXT FROM empCursor INTO @firstEmpName, @secondEmpName, @townName
	END

	CLOSE empCursor
	DEALLOCATE empCursor

-- 9. * Write a T-SQL script that shows for each town a list of all employees that live in it.
-- Sample output: 
--		Sofia -> Svetlin Nakov, Martin Kulov, George Denchev 
--		Ottawa -> Jose Saraiva …


-- 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','.
-- For example the following SQL statement should return a single string:   SELECT StrConcat(FirstName + ' ' + LastName) FROM Employees