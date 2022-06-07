-----------------------------------
--CHALLENGE 1
-----------------------------------
--STEP 1

DECLARE @orderDate datetime
	, @dueDate datetime
	, @customerid int
	, @orderId int

set @orderDate=getdate()
set @dueDate=dateadd(dd, 7, getdate())
set @customerid=1

INSERT INTO [SalesLT].[SalesOrderHeader]
     VALUES
           (default
           ,@orderDate
           ,@dueDate
           ,null
           ,default
           ,default
           ,null
           ,null
           ,@customerid
           ,null
           ,null
           ,'CARGO TRANSPORT 5'
           ,null
           ,default
           ,default
           ,default
           ,null
           ,default
           ,default);

select @orderId=SCOPE_IDENTITY

-----------------------------------
--STEP 2
DECLARE  @productId int
  , @qty smallint
  , @unitPrice money


set @productId=760
set @qty=1
set @unitPrice=782.99

SELECT SalesOrderID
  FROM [SalesLT].[SalesOrderHeader]
WHERE SalesOrderID=@orderId

IF @@ROWCOUNT < 1
	PRINT 'The order does not exist'
ELSE
   INSERT INTO [SalesLT].[SalesOrderDetail]
     VALUES
           (@orderId
           ,@qty
           ,@productId
           ,@unitPrice
           ,DEFAULT
           ,DEFAULT
           ,DEFAULT)
GO