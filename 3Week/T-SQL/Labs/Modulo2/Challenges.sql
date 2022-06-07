--Challenge 1
	--1
	SELECT DISTINCT City, StateProvince
	FROM [SalesLT].[Address]

	--2
	SELECT TOP 10 PERCENT ProductId, Name, Weight
	FROM [SalesLT].[Product]
	ORDER BY Weight DESC

	--3
	SELECT ProductId, Name, Weight
	FROM [SalesLT].[Product]
	ORDER BY Weight DESC OFFSET 10 ROWS FETCH NEXT 100 ROWS ONLY

--Challenge 2
	--1
	SELECT Name, Color, Size
	FROM [SalesLT].[Product]
	WHERE ProductModelID = 1

	--2
	SELECT ProductNumber, Name, Color, Size
	FROM [SalesLT].[Product]
	WHERE Color in ('black', 'red', 'white')
	and Size in ('S', 'M')

	--3
	SELECT ProductNumber, Name, ListPrice
	FROM [SalesLT].[Product]
	WHERE ProductNumber like 'BK-%'

	--4
	SELECT ProductNumber, Name, ListPrice
	FROM [SalesLT].[Product]
	WHERE ProductNumber like 'BK-[^R][0-9][0-9]_-[0-9][0-9]'