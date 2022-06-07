-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1
select distinct City, StateProvince 
from [SalesLT].Address;

-----------------------------------
--STEP 2
select top 10 productid, name, Weight
from [SalesLT].[Product]
order by Weight desc

-----------------------------------
--STEP 3
-Display the first ten products by product number
SELECT Name, Weight 
FROM SalesLT.Product 
ORDER BY Weight desc OFFSET 10 ROWS FETCH NEXT 100 ROWS ONLY; 

-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1
select [Name], [Color], [Size]
from [SalesLT].[Product]
where ProductModelID=1;


-----------------------------------
--STEP 2
select [ProductNumber], [Name], color, size
from [SalesLT].[Product]
where [Color] in ('black', 'red', 'white')
 and size in ('S', 'M');

 -----------------------------------
--STEP 3
select [ProductNumber], [Name], ListPrice
from [SalesLT].[Product]
where [ProductNumber] like 'BK-%'

-----------------------------------
--STEP 4
select [ProductNumber], [Name], ListPrice
from [SalesLT].[Product]
where [ProductNumber] like 'BK-[^R]___-[0-9][0-9]'

