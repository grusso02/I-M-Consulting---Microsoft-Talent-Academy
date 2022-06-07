-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1

select p.ProductID
	, p.Name
	, v.Name as modelName
	, v.Summary
  from [SalesLT].[Product] p
  inner join [SalesLT].[vProductModelCatalogDescription] v
    on v.ProductModelID=p.ProductModelID;
	
	
---------------------------------
--STEP 2

-- Temporary table
CREATE TABLE #Colors
(Color varchar(15) collate SQL_Latin1_General_CP1_CI_AS);

INSERT INTO #Colors
SELECT DISTINCT Color FROM SalesLT.Product;

select ProductID, Name, Color
  from SalesLT.Product
  where color in (select color from #Colors);

  	
---------------------------------
--STEP 3

SELECT *
  FROM [SalesLT].[Product] P
  INNER JOIN [dbo].[ufnGetAllCategories]() F
    ON F.[ProductCategoryID]=P.ProductCategoryID;

-----------------------------------
--CHALLENGE 2
-----------------------------------
--STEP 1

WITH retrieveForCustomer (CustomerID, LineTotal)
as  (SELECT SO.CustomerID, SOD.LineTotal
	FROM [SalesLT].[SalesOrderHeader]SO
		INNER JOIN [SalesLT].[SalesOrderDetail]SOD
		  ON SOD.SalesOrderID=SO.SalesOrderID)  

select c.CompanyName + '(' + c.FirstName + ' ' + c.LastName +')', sum(LineTotal) as total
from [SalesLT].[Customer] c
  inner join retrieveForCustomer r
    on c.CustomerID=r.CustomerID
group by c.CompanyName , c.FirstName , c.LastName 
order by c.CompanyName
