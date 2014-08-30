CREATE PROC usp_totalIncomeOfSupplier (@name NVARCHAR(50), @startDate DATE, @endDate DATE)
AS
	SELECT SUM(od.UnitPrice) AS TotalIncome
	FROM [Order Details] od, Products p, Suppliers s, Orders o
	WHERE od.ProductID = p.ProductID AND 
			p.SupplierID = s.SupplierID AND 
			o.OrderID = od.OrderID AND
			s.CompanyName = @name AND
			(o.OrderDate BETWEEN @startDate AND @endDate)
GO