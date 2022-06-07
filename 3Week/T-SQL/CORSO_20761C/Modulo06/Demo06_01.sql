--------------------------------------------------
--1 - Scalar Subquery
--------------------------------------------------
--Display a list of products whose list price is higher than the highest unit price of items that have sold


SELECT * 
  from SalesLT.Product
WHERE ListPrice >
  (SELECT MAX(UnitPrice) FROM SalesLT.SalesOrderDetail)


--List products that have an order quantity greater than 20

SELECT Name 
  FROM SalesLT.Product
WHERE ProductID IN  (SELECT ProductID 
						from SalesLT.SalesOrderDetail
						WHERE OrderQty>20);

SELECT Name 
	, OrderQty
  FROM SalesLT.Product P
	INNER JOIN SalesLT.SalesOrderDetail SOD
		ON P.ProductID=SOD.ProductID
WHERE OrderQty>20

