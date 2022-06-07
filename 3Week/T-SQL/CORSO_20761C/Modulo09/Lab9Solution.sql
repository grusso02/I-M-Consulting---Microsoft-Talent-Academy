-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1

DECLARE @PRODUCTID INT;
INSERT INTO [SalesLT].[Product]
     VALUES
           ('LED Lights'
           ,'LT-L123'
           ,null
           ,2.56
           ,12.99
           ,null
           ,null
           ,37
           ,null
           ,getdate()
           ,null
           ,null
           ,null
           ,null
           ,default
           ,default);

SELECT @PRODUCTID=SCOPE_IDENTITY();

SELECT *
FROM [SalesLT].[Product]
WHERE ProductID=SCOPE_IDENTITY();


-----------------------------------
--STEP 2
DECLARE @CATEGORY INT
INSERT INTO [SalesLT].[ProductCategory]
     VALUES
           (4
           ,'Bells and Horns'
           ,default
           ,default)

SELECT @CATEGORY=SCOPE_IDENTITY();

INSERT INTO [SalesLT].[Product]
     VALUES
           ('Bicycle Bell'
           ,'BB-RING'
           ,null
           ,2.47
           ,4.99
           ,null
           ,null
           ,@CATEGORY
           ,null
           ,getdate()
           ,null
           ,null
           ,null
           ,null
           ,default
           ,default);

INSERT INTO [SalesLT].[Product]
     VALUES
           ('Bicycle Horn'
           ,'BB-PARP'
           ,null
           ,1.29
           ,3.75
           ,null
           ,null
           ,@CATEGORY
           ,null
           ,getdate()
           ,null
           ,null
           ,null
           ,null
           ,default
           ,default);

SELECT * 
  FROM [SalesLT].[Product] P
    INNER JOIN [SalesLT].[ProductCategory] PC
	  ON PC.ProductCategoryID=P.ProductCategoryID
WHERE P.ProductCategoryID=@CATEGORY;

-----------------------------------
--CHALLENGE 2
-----------------------------------
--STEP 1

UPDATE [SalesLT].[Product]
  SET ListPrice=ListPrice + ListPrice*10/100
WHERE ProductCategoryID=@CATEGORY;

-----------------------------------
--STEP 2

UPDATE [SalesLT].[Product]
	SET [DiscontinuedDate]=GETDATE()
WHERE ProductCategoryID=@CATEGORY
  AND ProductID<>@PRODUCTID;
  

-----------------------------------
--CHALLENGE 3
-----------------------------------
--STEP 1
DELETE FROM [SalesLT].[Product]
WHERE ProductCategoryID=@CATEGORY

DELETE FROM [SalesLT].[ProductCategory]
WHERE ProductCategoryID=@CATEGORY