--Challenge 1
	--1
	SELECT c.CompanyName
		, a.AddressLine1
		, a.City
		, CASE WHEN ca.AddressType = 'Main Office'
			THEN 'Billing'
			ELSE ca.AddressType
			END AddressType
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[CustomerAddress] ca
		ON c.CustomerID = ca.CustomerID
			INNER JOIN [SalesLT].[Address] a
			ON ca.AddressID = a.AddressID

	--2
		SELECT c.CompanyName
		, a.AddressLine1
		, a.City
		, CASE WHEN ca.AddressType = 'shipping'
			THEN 'Shipping'
			ELSE ca.AddressType
			END AddressType
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[CustomerAddress] ca
		ON c.CustomerID = ca.CustomerID
			INNER JOIN [SalesLT].[Address] a
			ON ca.AddressID = a.AddressID
	
	--3
	SELECT c.CompanyName
		, a.AddressLine1
		, a.City
		, CASE WHEN ca.AddressType = 'Main Office'
			THEN 'Billing'
			ELSE ca.AddressType
			END AddressType
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[CustomerAddress] ca
		ON c.CustomerID = ca.CustomerID
			INNER JOIN [SalesLT].[Address] a
			ON ca.AddressID = a.AddressID

	UNION

		SELECT c.CompanyName
		, a.AddressLine1
		, a.City
		, CASE WHEN ca.AddressType = 'shipping'
			THEN 'Shipping'
			ELSE ca.AddressType
			END AddressType
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[CustomerAddress] ca
		ON c.CustomerID = ca.CustomerID
			INNER JOIN [SalesLT].[Address] a
			ON ca.AddressID = a.AddressID
			ORDER BY c.CompanyName, AddressType

--Challenge 2
	--1
	SELECT c.CompanyName
		, a.AddressLine1
		, a.City
		, CASE WHEN ca.AddressType = 'Main Office'
			THEN 'Billing'
			ELSE ca.AddressType
			END AddressType
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[CustomerAddress] ca
		ON c.CustomerID = ca.CustomerID
			INNER JOIN [SalesLT].[Address] a
			ON ca.AddressID = a.AddressID

	EXCEPT

		SELECT c.CompanyName
		, a.AddressLine1
		, a.City
		, CASE WHEN ca.AddressType = 'shipping'
			THEN 'Shipping'
			ELSE ca.AddressType
			END AddressType
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[CustomerAddress] ca
		ON c.CustomerID = ca.CustomerID
			INNER JOIN [SalesLT].[Address] a
			ON ca.AddressID = a.AddressID
			ORDER BY c.CompanyName, AddressType

	--2
	SELECT c.CompanyName
		, a.AddressLine1
		, a.City
		, CASE WHEN ca.AddressType = 'Main Office'
			THEN 'Billing'
			ELSE ca.AddressType
			END AddressType
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[CustomerAddress] ca
		ON c.CustomerID = ca.CustomerID
			INNER JOIN [SalesLT].[Address] a
			ON ca.AddressID = a.AddressID

	INTERSECT

		SELECT c.CompanyName
		, a.AddressLine1
		, a.City
		, CASE WHEN ca.AddressType = 'shipping'
			THEN 'Shipping'
			ELSE ca.AddressType
			END AddressType
	FROM [SalesLT].[Customer] c
		INNER JOIN [SalesLT].[CustomerAddress] ca
		ON c.CustomerID = ca.CustomerID
			INNER JOIN [SalesLT].[Address] a
			ON ca.AddressID = a.AddressID
			ORDER BY c.CompanyName, AddressType