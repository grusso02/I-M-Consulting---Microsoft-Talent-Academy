--------------------------------------------------
-- Logical functions
--------------------------------------------------

SELECT Name
	, Size AS NumericSize
  FROM SalesLT.Product
WHERE ISNUMERIC(Size) = 1;

SELECT Name
	, IIF(ProductCategoryID IN (5,6,7), 'Bike', 'Other') ProductType
  FROM SalesLT.Product;

SELECT Name, IIF(ISNUMERIC(Size) = 1, 'Numeric', 'Non-Numeric') SizeType
  FROM SalesLT.Product;

SELECT prd.Name AS ProductName
	, cat.Name AS Category,
      CHOOSE (cat.ParentProductCategoryID, 'Bikes','Components','Clothing','Accessories') AS ProductType
  FROM SalesLT.Product AS prd
	JOIN SalesLT.ProductCategory AS cat
	  ON prd.ProductCategoryID = cat.ProductCategoryID;