-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1
select * 
from [SalesLT].[Customer];

-----------------------------------
--STEP2

select P.Title, p.FirstName, P.MiddleName, p.LastName, P.Suffix
from [SalesLT].[Customer] P;

-----------------------------------
--STEP3
-----------------------------------
select P.SalesPerson, P.Title + ' ' +  p.LastName, P.Phone
from [SalesLT].[Customer] P;

-----------------------------------
--CHALLENGE 2
-----------------------------------
--STEP 1
select CAST(P.CustomerID AS VARCHAR(5)) + ':' + P.COMPANYNAME
from [SalesLT].[Customer] P;


-----------------------------------
--STEP 2
-----------------------------------
SELECT SalesOrderNumber +'('+ CAST(RevisionNumber AS VARCHAR(4)) + ')' AS ORDER_NUMBER
	, CONVERT(VARCHAR, ORDERDATE,23) AS  DATE_ORDER
FROM [SalesLT].SalesOrderHeader;

-----------------------------------
--CHALLENGE 3
-----------------------------------
--STEP 1

select  CASE WHEN P.MiddleName IS NULL 
			THEN 
				p.FirstName+ ' ' + p.LastName
			ELSE 
				p.FirstName + ' ' +  P.MiddleName + ' '+  p.LastName
			END NAME
from [SalesLT].[Customer] P;

-----------------------------------
--STEP2
select CustomerID, 
	CASE WHEN [EmailAddress] IS NULL 
	  THEN [Phone]
	  ELSE [EmailAddress]
	  END AS primaryContact
from [SalesLT].[Customer] P;


-----------------------------------
--STEP3
select [SalesOrderID]
	, CASE WHEN [ShipDate] IS NULL 
			THEN 'Awaiting Shipment'
			ELSE 'Shipped'
			END ShippingStatus
from [SalesLT].SalesOrderHeader P;