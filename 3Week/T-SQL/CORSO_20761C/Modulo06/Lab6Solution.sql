-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1

SELECT P.ProductID, P.Name, P.ListPrice
FROM [SalesLT].[Product] P
WHERE P.ListPrice> (SELECT AVG([UnitPrice]) FROM [SalesLT].[SalesOrderDetail])


-----------------------------------
--STEP 2

SELECT P.ProductID, P.Name, P.ListPrice
FROM [SalesLT].[Product] P
WHERE P.ProductID IN (SELECT S.ProductID FROM [SalesLT].[SalesOrderDetail] S WHERE S.UnitPrice<100)
  AND P.ListPrice>=100
  
-----------------------------------
--STEP 3

SELECT P.ProductID
	, P.Name
	, P.ListPrice
	, P.StandardCost
	, (SELECT avg(s.[UnitPrice]) FROM [SalesLT].[SalesOrderDetail] S WHERE S.ProductID=P.ProductID) AS Avgsold
FROM [SalesLT].[Product] P


  
-----------------------------------
--STEP 4

SELECT P.ProductID
	, P.Name
	, P.ListPrice
	, P.StandardCost
	, (SELECT avg(s.[UnitPrice]) FROM [SalesLT].[SalesOrderDetail] S WHERE S.ProductID=P.ProductID) AS Avgsold
FROM [SalesLT].[Product] P
where (SELECT avg(s.[UnitPrice]) FROM [SalesLT].[SalesOrderDetail] S WHERE S.ProductID=P.ProductID) is not null
	and P.StandardCost>(SELECT avg(s.[UnitPrice]) FROM [SalesLT].[SalesOrderDetail] S WHERE S.ProductID=P.ProductID)

-----------------------------------
--CHALLENGE 2
-----------------------------------
--STEP 1

SELECT c.CustomerID, f.FirstName, f.LastName, c.TotalDue
  FROM [SalesLT].[SalesOrderHeader] C
  CROSS APPLY [dbo].[ufnGetCustomerInformation](C.CustomerID) F
  
-----------------------------------
--STEP 2

SELECT c.CustomerID, f.FirstName, f.LastName, a.AddressLine1, a.City
  FROM [SalesLT].[CustomerAddress] C
	inner join [SalesLT].[Address] a
		on c.AddressID=a.AddressID
  CROSS APPLY [dbo].[ufnGetCustomerInformation](C.CustomerID) F