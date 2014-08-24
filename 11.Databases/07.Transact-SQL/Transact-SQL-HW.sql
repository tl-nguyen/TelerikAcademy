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
	DECLARE @oldSum money, @newSum money, @accountId int
	SELECT @oldSum = Balance FROM deleted WHERE Balance IS NOT NULL
	SELECT @newSum = Balance FROM inserted WHERE Balance IS NOT NULL
	SELECT @accountId = AccountID FROM inserted

	INSERT INTO Logs (AccountID, OldSum, NewSum)
	VALUES (@accountId, @oldSum, @newSum)
GO

UPDATE Accounts
SET Balance = 20
WHERE AccountID = 1
GO

-- 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.


-- 8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.

-- 9. * Write a T-SQL script that shows for each town a list of all employees that live in it.
-- Sample output: 
--		Sofia -> Svetlin Nakov, Martin Kulov, George Denchev 
--		Ottawa -> Jose Saraiva …

-- 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','.
-- For example the following SQL statement should return a single string:   SELECT StrConcat(FirstName + ' ' + LastName) FROM Employees