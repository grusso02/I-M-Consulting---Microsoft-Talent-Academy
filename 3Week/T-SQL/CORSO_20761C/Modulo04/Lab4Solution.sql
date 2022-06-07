-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1
SELECT C.CompanyName
	, A.AddressLine1 
	, A.[City]
	, CASE WHEN CA.[AddressType]='Main Office' THEN 'Billing' ELSE '' ENd AddressType
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[CustomerAddress] CA
	  ON C.[CustomerID]=CA.[CustomerID]
	INNER JOIN [SalesLT].[Address] A
	  ON A.AddressID=CA.AddressID

-----------------------------------
--STEP 2
SELECT C.CompanyName
	, A.AddressLine1 
	, A.[City]
	, CASE WHEN CA.[AddressType]='Shipping' THEN 'Shipping' ELSE '' ENd AddressType
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[CustomerAddress] CA
	  ON C.[CustomerID]=CA.[CustomerID]
	INNER JOIN [SalesLT].[Address] A
	  ON A.AddressID=CA.AddressID
-----------------------------------
--STEP 3

SELECT C.CompanyName
	, A.AddressLine1 
	, A.[City]
	, 'Billing'  AS AddressType
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[CustomerAddress] CA
	  ON C.[CustomerID]=CA.[CustomerID]
	INNER JOIN [SalesLT].[Address] A
	  ON A.AddressID=CA.AddressID
  WHERE CA.[AddressType]='Main Office'
UNION 

SELECT C.CompanyName
	, A.AddressLine1 
	, A.[City]
	, 'Shipping' AS AddressType
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[CustomerAddress] CA
	  ON C.[CustomerID]=CA.[CustomerID]
	INNER JOIN [SalesLT].[Address] A
	  ON A.AddressID=CA.AddressID
  WHERE CA.[AddressType]='Shipping'
ORDER BY C.CompanyName, AddressType

-----------------------------------
--CHALLENGE 2
-----------------------------------
--STEP 1
SELECT C.CompanyName
	, A.[City]
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[CustomerAddress] CA
	  ON C.[CustomerID]=CA.[CustomerID]
	INNER JOIN [SalesLT].[Address] A
	  ON A.AddressID=CA.AddressID
  WHERE CA.[AddressType]='Main Office'
EXCEPT 

SELECT C.CompanyName
	, A.[City]
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[CustomerAddress] CA
	  ON C.[CustomerID]=CA.[CustomerID]
	INNER JOIN [SalesLT].[Address] A
	  ON A.AddressID=CA.AddressID
  WHERE CA.[AddressType]='Shipping'

  -----------------------------------
--STEP 2
SELECT C.CompanyName
	, A.[City]
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[CustomerAddress] CA
	  ON C.[CustomerID]=CA.[CustomerID]
	INNER JOIN [SalesLT].[Address] A
	  ON A.AddressID=CA.AddressID
  WHERE CA.[AddressType]='Main Office'
INTERSECT 

SELECT C.CompanyName
	, A.[City]
  FROM [SalesLT].[Customer] c
	INNER JOIN [SalesLT].[CustomerAddress] CA
	  ON C.[CustomerID]=CA.[CustomerID]
	INNER JOIN [SalesLT].[Address] A
	  ON A.AddressID=CA.AddressID
  WHERE CA.[AddressType]='Shipping'