--Challenge 1
	--1
	SELECT ProductID, Name, ListPrice
	FROM [SalesLT].[Product]
	WHERE ListPrice > (SELECT AVG(UnitPrice) FROM [SalesLT].[SalesOrderDetail])

	--2
	SELECT ProductID, Name, ListPrice
	FROM [SalesLT].[Product]
	WHERE ListPrice >= 100 and ProductID in (SELECT ProductID FROM [SalesLT].[SalesOrderDetail] WHERE UnitPrice < 100)

	--3
	SELECT ProductID
		, Name
		, StandardCost
		, ListPrice
		, (SELECT AVG(so.UnitPrice) FROM [SalesLT].[SalesOrderDetail] so WHERE so.ProductID = p.ProductID) AS Avgsold
	FROM [SalesLT].[Product] p

	--4
	SELECT ProductID
		, Name
		, StandardCost
		, ListPrice
		, (SELECT AVG(so.UnitPrice) FROM [SalesLT].[SalesOrderDetail] so WHERE so.ProductID = p.ProductID) AS Avgsold
	FROM [SalesLT].[Product] p
	WHERE StandardCost > (SELECT AVG(so.UnitPrice) FROM [SalesLT].[SalesOrderDetail] so WHERE so.ProductID = p.ProductID) is not null
	and p.StandardCost > (SELECT AVG(s.[UnitPrice]) FROM [SalesLT].[SalesOrderDetail] s WHERE s.ProductID = p.ProductID)

--Challenge 2
	--1
	SELECT sh.CustomerID, f.FirstName, f.LastName, sh.TotalDue
	FROM [SalesLT].[SalesOrderHeader] sh
	CROSS APPLY [dbo].[ufnGetCustomerInformation](sh.CustomerID) f

	--2
	SELECT c.CustomerID, f.FirstName, f.LastName, a.AddressLine1, a.City
	FROM [SalesLT].[CustomerAddress] c
		INNER JOIN [SalesLT].[Address] a
			on c.AddressID = a.AddressID
	CROSS APPLY [dbo].[ufnGetCustomerInformation](c.CustomerID) f