-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1

SELECT [ProductID]
	, UPPER([Name]) AS NAME
	, ROUND([Weight], 0) AS WEIGHT
  FROM [SalesLT].[Product]

-----------------------------------
--STEP 2

SELECT [ProductID]
	, UPPER([Name]) AS NAME
	, ROUND([Weight], 0) AS WEIGHT
	, YEAR([SellStartDate]) AS SellStartYear
	, DATENAME(MM, [SellStartDate]) AS SellStartMonth
  FROM [SalesLT].[Product]

-----------------------------------
--STEP 3

SELECT [ProductID]
	, UPPER([Name]) AS NAME
	, ROUND([Weight], 0) AS WEIGHT
	, YEAR([SellStartDate]) AS SellStartYear
	, DATENAME(MM, [SellStartDate]) AS SellStartMonth
	, LEFT([ProductNumber], 2) AS ProductType
  FROM [SalesLT].[Product]

-----------------------------------
--STEP 4

SELECT [ProductID]
	, UPPER([Name]) AS NAME
	, ROUND([Weight], 0) AS WEIGHT
	, YEAR([SellStartDate]) AS SellStartYear
	, DATENAME(MM, [SellStartDate]) AS SellStartMonth
	, LEFT([ProductNumber], 2) AS ProductType
	, Size
  FROM [SalesLT].[Product]
  where isnumeric(Size)=1

-----------------------------------
--CHALLENGE 2
-----------------------------------
--STEP 1

SELECT ROW_NUMBER() OVER(ORDER BY [TotalDue] DESC) AS ROW
	, [CompanyName]
	, [TotalDue]
  FROM [SalesLT].[Customer] C
	INNER JOIN [SalesLT].[SalesOrderHeader] SO
	 ON C.CustomerID=SO.CustomerID

-----------------------------------
--CHALLENGE 3
-----------------------------------
--STEP 1
SELECT P.Name
	, SUM([LineTotal]) AS TotLineTotal
  FROM [SalesLT].[Product] P
	INNER JOIN [SalesLT].[SalesOrderDetail] SD
	 ON P.ProductID=SD.ProductID
GROUP BY P.Name
ORDER BY SUM([LineTotal]) DESC

-----------------------------------
--STEP 2

SELECT P.Name
	, SUM([LineTotal]) AS TotLineTotal
	, SUM([OrderQty]*[UnitPrice]) AS SalesTotal
  FROM [SalesLT].[Product] P
	INNER JOIN [SalesLT].[SalesOrderDetail] SD
	 ON P.ProductID=SD.ProductID
WHERE P.[ListPrice]>1000
GROUP BY P.Name
ORDER BY SUM([LineTotal]) DESC

-----------------------------------
--STEP 3

SELECT P.Name
	, SUM([LineTotal]) AS TotLineTotal
	, SUM([OrderQty]*[UnitPrice]) AS SalesTotal
  FROM [SalesLT].[Product] P
	INNER JOIN [SalesLT].[SalesOrderDetail] SD
	 ON P.ProductID=SD.ProductID
WHERE P.[ListPrice]>1000
GROUP BY P.Name
HAVING SUM([OrderQty]*[UnitPrice])>20000
ORDER BY SUM([LineTotal]) DESC