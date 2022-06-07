-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1

DECLARE @SalesOrderID int = 7200

	DELETE FROM SalesLT.SalesOrderDetail WHERE SalesOrderID = @SalesOrderID;
	DELETE FROM SalesLT.SalesOrderHeader WHERE SalesOrderID = @SalesOrderID;

IF @@ROWCOUNT < 1
	THROW 50001, 'The ORDER was not found - no ORDER have been deleted', 0;


-----------------------------------
--STEP 2

DECLARE @SalesOrderID int = 7200

	DELETE FROM SalesLT.SalesOrderDetail WHERE SalesOrderID = @SalesOrderID;
	DELETE FROM SalesLT.SalesOrderHeader WHERE SalesOrderID = @SalesOrderID;

IF @@ROWCOUNT < 1
	THROW 50001, 'The ORDER was not found - no ORDER have been deleted', 0;
	print error_message();
	