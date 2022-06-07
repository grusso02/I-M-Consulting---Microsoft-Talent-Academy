--Challenge 1
	--1
	SELECT p.ProductID
		, p.Name
		, v.Name as modelName
		, v.Summary
	FROM [SalesLT].[Product] p
	INNER JOIN [SalesLT].[vProductModelCatalogDescription] v
		ON v.ProductModelID = p.ProductModelID;

	--2
	CREATE TABLE #Colors
		(Color varchar(15) collate SQL_Latin1_General_CP1_CI_AS);

	INSERT INTO #Colors
	SELECT DISTINCT Color FROM SalesLT.Product;

	SELECT ProductID, Name, Color
	FROM SalesLT.Product
	WHERE color in (SELECT color FROM #Colors);

	--3
	SELECT *
	FROM [SalesLT].[Product] P
	INNER JOIN [dbo].[ufnGetAllCategories]() F
		ON F.[ProductCategoryID] = P.ProductCategoryID;

--Challenge 2
	--1
	WITH retrieveForCustomer (CustomerID, LineTotal)
		AS (SELECT SO.CustomerID, SOD.LineTotal
			FROM [SalesLT].[SalesOrderHeader]SO
			INNER JOIN [SalesLT].[SalesOrderDetail]SOD
				ON SOD.SalesOrderID = SO.SalesOrderID)  

	SELECT c.CompanyName + '(' + c.FirstName + ' ' + c.LastName +')', sum(LineTotal) AS total
	FROM [SalesLT].[Customer] c
	INNER JOIN retrieveForCustomer r
		ON c.CustomerID = r.CustomerID
		GROUP BY c.CompanyName , c.FirstName , c.LastName 
		ORDER BY c.CompanyName
