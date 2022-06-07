--Challenge 1
	--1
	SELECT c.CompanyName, o.SalesOrderID, o.TotalDue
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[SalesOrderHeader] o
		ON c.CustomerID = o.CustomerID

	--2
	SELECT c.CompanyName
	, o.SalesOrderID
	, o.TotalDue
	, a.AddressLine1 + CASE WHEN AddressLine2 IS NOT NULL THEN ' ' + AddressLine2 ELSE '' END AS FullStreetAddress
	, City
	, StateProvince
	, PostalCode
	, CountryRegion
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[SalesOrderHeader] o
			ON c.CustomerID = o.CustomerID
		INNER JOIN [SalesLT].[CustomerAddress] ca
			ON c.CustomerID = ca.CustomerID
			AND ca.AddressType = 'Main Office'
		INNER JOIN [SalesLT].[Address] a
			ON a.AddressID = ca.AddressID

--Challenge 2
	--1
	SELECT c.CustomerID
	, c.CompanyName
	, FirstName
	, LastName
	, o.SalesOrderID
	, o.TotalDue
	FROM SalesLT.Customer c
	LEFT JOIN SalesLT.SalesOrderHeader o
		ON c.CustomerID = o.CustomerID
		ORDER BY c.CompanyName;

	--2
	SELECT c.CustomerID 
	, c.CompanyName
	, FirstName
	, LastName
	, Phone
	FROM SalesLT.Customer c	
	LEFT JOIN SalesLT.CustomerAddress ca
		ON ca.CustomerID = c.CustomerID
		WHERE ca.CustomerID IS NULL;
