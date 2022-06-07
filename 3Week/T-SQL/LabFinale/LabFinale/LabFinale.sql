--Challenge 1
	ALTER VIEW SalesLT.vCustomerForProductBlu AS
		SELECT c.CompanyName
				+ ' ' + c.FirstName
				+ CASE WHEN c.MiddleName is not null THEN ' ' + c.MiddleName ELSE ' ' END
				+ c.LastName as Customer
				, oh.SalesOrderID
				, COUNT(p.Color) as nSoldBlu
				, c.CustomerID
		FROM [SalesLT].[Customer] c
			INNER JOIN [SalesLT].[SalesOrderHeader] oh
			ON c.CustomerID = oh.CustomerID
			INNER JOIN [SalesLT].[SalesOrderDetail] od
			ON oh.SalesOrderID = od.SalesOrderID
			INNER JOIN [SalesLT].[Product] p
			ON od.ProductID = p.ProductID

			WHERE Color = 'Blue'
			GROUP BY c.CompanyName, c.FirstName, c.MiddleName, c.LastName, oh.SalesOrderID, c.CustomerID
	GO

	SELECT c.CompanyName
			, COUNT(vc.CustomerID) as nCustomerBlu
	FROM SalesLT.vCustomerForProductBlu vc
	INNER JOIN [SalesLT].[Customer] c
	ON c.CustomerID = vc.CustomerID
	GROUP BY c.CustomerID, c.CompanyName

--Challenge 2
	
	SELECT *
	FROM [SalesLT].[SalesOrderDetail] od
	CROSS APPLY SalesLT.ufnAvgProduct(od.ProductID)

	SELECT p.ProductID
		, p.name
		,count(sod.SalesOrderID) as nOrders
		,(select AvgPrice from SalesLT.ufnAvgProduct (p.ProductID)) as AvgPrice
	FROM [SalesLT].[Product] p
	INNER JOIN [SalesLT].[SalesOrderDetail] sod
	on sod.ProductID = p.ProductID
	GROUP BY p.ProductID, p.name

--Challenge 3