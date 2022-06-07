--------------------------------------------------
--1 INTERSECT
--------------------------------------------------

SELECT FirstName, LastName
FROM SalesLT.Customers
INTERSECT
SELECT FirstName, LastName
FROM SalesLT.Employees;

--------------------------------------------------
--2 EXCEPT
--------------------------------------------------

SELECT FirstName, LastName
FROM SalesLT.Customers
EXCEPT
SELECT FirstName, LastName
FROM SalesLT.Employees;