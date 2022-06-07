--Challenge 1
	--1
	SELECT ProductID
		, UPPER(Name)
		, ROUND(Weight, 0) AS ApproxWeight
	FROM [SalesLT].[Product]

	--2
	SELECT ProductID, UPPER(Name)
		, ROUND(Weight, 0) AS ApproxWeight
		, YEAR(SellStartDate) AS SellStartYear
		, DATENAME(mm, SellStartDate) AS SellStartMonth
	FROM [SalesLT].[Product]

	--3
	SELECT ProductID, UPPER(Name)
		, ROUND(Weight, 0) AS ApproxWeight
		, YEAR(SellStartDate) AS SellStartYear
		, DATENAME(mm, SellStartDate) AS SellStartMonth
		, LEFT(ProductNumber, 2)
	FROM [SalesLT].[Product]

	--4
	SELECT ProductID, UPPER(Name)
		, ROUND(Weight, 0) AS ApproxWeight
		, YEAR(SellStartDate) AS SellStartYear
		, DATENAME(mm, SellStartDate) AS SellStartMonth
		, LEFT(ProductNumber, 2)
	FROM [SalesLT].[Product]
	WHERE ISNUMERIC(size) = 1

--Challenge 2
	--1
	SELECT RANK() OVER(ORDER BY oh.TotalDue DESC) AS ROW
		, c.CompanyName
		, oh.TotalDue
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[SalesOrderHeader] oh
		ON c.CustomerID = oh.CustomerID

--Challenge 3
	--1
	SELECT p.Name
		, SUM(od.LineTotal) AS TotLineTotal
	FROM [SalesLT].[Product] p
		INNER JOIN [SalesLT].[SalesOrderDetail] od
		ON p.ProductID = od.ProductID
	GROUP BY p.Name
	ORDER BY TotLineTotal DESC

	--2
	SELECT p.Name
		, SUM(od.LineTotal) AS TotLineTotal
		, SUM(od.OrderQty * od.UnitPrice) AS SalesTotal
	FROM [SalesLT].[Product] p
		INNER JOIN [SalesLT].[SalesOrderDetail] od
		ON p.ProductID = od.ProductID
	WHERE p.ListPrice > 1000
	GROUP BY p.Name
	ORDER BY TotLineTotal DESC

	--3
	SELECT p.Name
		, SUM(od.LineTotal) AS TotLineTotal
		, SUM(od.OrderQty * od.UnitPrice) AS SalesTotal
	FROM [SalesLT].[Product] p
		INNER JOIN [SalesLT].[SalesOrderDetail] od
		ON p.ProductID = od.ProductID
	WHERE p.ListPrice > 1000
	GROUP BY p.Name
	HAVING SUM(od.OrderQty * od.UnitPrice) > 20000
	ORDER BY TotLineTotal DESC