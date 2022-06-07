-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1

SELECT a.CountryRegion, a.StateProvince, SUM(soh.TotalDue) AS Revenue
FROM SalesLT.Address AS a
	JOIN SalesLT.CustomerAddress AS ca 
		ON a.AddressID = ca.AddressID
	JOIN SalesLT.Customer AS c 
		ON ca.CustomerID = c.CustomerID
	JOIN SalesLT.SalesOrderHeader as soh 
		ON c.CustomerID = soh.CustomerID
GROUP BY ROLLUP  (a.CountryRegion, a.StateProvince)

ORDER BY a.CountryRegion, a.StateProvince;

-----------------------------------
--STEP 2

SELECT 
	CASE WHEN GROUPING_ID(a.CountryRegion) = 1 AND GROUPING_ID(a.StateProvince) = 1
		THEN 'Total'
	   WHEN GROUPING_ID(a.CountryRegion) = 0 AND GROUPING_ID(a.StateProvince) = 1
	    THEN a.CountryRegion + ' sub total'
	   WHEN GROUPING_ID(a.CountryRegion) = 0 AND GROUPING_ID(a.StateProvince) = 0
	    THEN a.StateProvince + ' sub total'
	   END	   
	, a.CountryRegion
	, a.StateProvince
	, SUM(soh.TotalDue) AS Revenue
FROM SalesLT.Address AS a
	JOIN SalesLT.CustomerAddress AS ca 
		ON a.AddressID = ca.AddressID
	JOIN SalesLT.Customer AS c 
		ON ca.CustomerID = c.CustomerID
	JOIN SalesLT.SalesOrderHeader as soh 
		ON c.CustomerID = soh.CustomerID
GROUP BY ROLLUP  (a.CountryRegion, a.StateProvince)
ORDER BY a.CountryRegion, a.StateProvince;


-----------------------------------
--STEP 3

SELECT 
	CASE WHEN GROUPING_ID(a.CountryRegion) = 1 AND GROUPING_ID(a.StateProvince)=1 and GROUPING_ID(a.City) = 1 
		THEN 'Total'
	   WHEN GROUPING_ID(a.CountryRegion)=0 AND GROUPING_ID(a.StateProvince)=1 and GROUPING_ID(a.City) = 1 
	    THEN a.CountryRegion + ' sub total'
	   WHEN GROUPING_ID(a.CountryRegion)=0 AND GROUPING_ID(a.StateProvince)=0 and GROUPING_ID(a.City) = 1 
	    THEN a.StateProvince + ' sub total'
	   WHEN GROUPING_ID(a.CountryRegion)=0 AND GROUPING_ID(a.StateProvince)=0 and GROUPING_ID(a.City) = 0 
	    THEN a.City + ' sub total'
	   END	   
	, a.CountryRegion
	, a.StateProvince
	, a.City
	, SUM(soh.TotalDue) AS Revenue
FROM SalesLT.Address AS a
	JOIN SalesLT.CustomerAddress AS ca 
		ON a.AddressID = ca.AddressID
	JOIN SalesLT.Customer AS c 
		ON ca.CustomerID = c.CustomerID
	JOIN SalesLT.SalesOrderHeader as soh 
		ON c.CustomerID = soh.CustomerID
GROUP BY ROLLUP  (a.CountryRegion, a.StateProvince, a.City)
ORDER BY a.CountryRegion, a.StateProvince, a.City;

-----------------------------------
--CHALLENGE 2
-----------------------------------
--STEP 1

SELECT * FROM
(SELECT c.CompanyName, f.[ParentProductCategoryName], sod.LineTotal
 FROM saleslt.Customer AS c
	inner join [SalesLT].[SalesOrderHeader] so
	  on c.CustomerID=so.CustomerID
	inner join [SalesLT].[SalesOrderDetail] sod
	  on so.SalesOrderID=sod.SalesOrderID
	inner join [SalesLT].[Product] p
	  on sod.ProductID=p.ProductID
	inner JOIN [dbo].[ufnGetAllCategories]() AS f
 ON f.[ProductCategoryID]=p.ProductCategoryID
 ) AS PPC
PIVOT(sum(LineTotal) FOR [ParentProductCategoryName] IN (Accessories, Bikes, Clothing, Components)) as pvt
ORDER BY CompanyName;