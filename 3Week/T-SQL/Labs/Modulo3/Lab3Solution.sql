-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1
SELECT C.CompanyName
	, O.SalesOrderID
	, O.TotalDue
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[SalesOrderHeader] O
	  ON C.CustomerID=O.CustomerID;

   
-----------------------------------
--STEP 2
SELECT C.CompanyName
	, O.SalesOrderID
	, O.TotalDue
	, A.AddressLine1 + CASE WHEN [AddressLine2] IS NOT NULL THEN ' ' + [AddressLine2] ELSE '' END AS fullStretAddress
	, [City]
	, [StateProvince]
	, [PostalCode]
	, [CountryRegion]
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[SalesOrderHeader] O
	  ON C.CustomerID=O.CustomerID
	INNER JOIN [SalesLT].[CustomerAddress] CA
	  ON CA.CustomerID=C.CustomerID
		AND CA.AddressType='Main Office'
	INNER JOIN [SalesLT].[Address] A
	  ON A.AddressID=CA.AddressID
	    
-----------------------------------
--CHALLENGE 2
-----------------------------------
--STEP 1

SELECT C.CustomerID
	, C.CompanyName
	, [FirstName]
	, [LastName]
	, O.SalesOrderID
	, O.TotalDue
  FROM [SalesLT].[Customer] c
	LEFT JOIN [SalesLT].[SalesOrderHeader] O
	  ON C.CustomerID=O.CustomerID
ORDER BY C.CompanyName;

-----------------------------------
--STEP 2

SELECT c.CustomerID 
	, C.CompanyName
	, [FirstName]
	, [LastName]
	, [Phone]
  FROM [SalesLT].[Customer] c	
	LEFT JOIN [SalesLT].[CustomerAddress] CA
	  ON CA.CustomerID=C.CustomerID
WHERE CA.CustomerID IS NULL;

