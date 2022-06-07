--Challenge 1
	--1
	SELECT * FROM [SalesLT].[Customer]

	--2
	SELECT Title + ' '
			+ FirstName + ' '
			+ ISNULL(MiddleName, '') + ' '
			+ LastName + ' '
			+ ISNULL(Suffix, '')
			AS CustomerContactNames
	FROM [SalesLT].[Customer]

	--2
	SELECT SalesPerson, ISNULL(Title, '') + ' ' + COALESCE(LastName, FirstName, MiddleName) AS CustomerName, Phone
	FROM [SalesLT].[Customer]

--Challenge 2
	--1
	SELECT CAST(CustomerID AS varchar(5)) + ':' + CompanyName
	FROM [SalesLT].[Customer]

	--2
	SELECT SalesOrderNumber + ' (' + CAST(RevisionNumber AS varchar(1)) + ')' AS OrderNumber
		, CONVERT(varchar, OrderDate, 23) AS DateOrder
	FROM [SalesLT].[SalesOrderHeader]

--Challenge 3
	--1
	SELECT CASE WHEN MiddleName is null
				THEN
					FirstName + ' ' + LastName
				ELSE
					FirstName + ' ' +  MiddleName + ' '+  LastName
				END CustomerName
	FROM [SalesLT].[Customer]

	--2
	SELECT CustomerID,
		CASE WHEN EmailAddress is null
			THEN Phone
			ELSE EmailAddress
			END PrimaryContact
	FROM [SalesLT].[Customer]

	--3
	SELECT SalesOrderID,
		CASE WHEN ShipDate is null 
			THEN 'Awaiting Shipment'
			ELSE 'Shipped'
			END ShippingStatus
	from [SalesLT].[SalesOrderHeader];