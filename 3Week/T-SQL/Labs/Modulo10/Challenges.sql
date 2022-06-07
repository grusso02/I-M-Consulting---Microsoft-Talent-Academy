--Challenge 1
	--1
	DECLARE @orderDate datetime
		, @dueDate datetime
		, @customerid int
		, @orderId int

	set @orderDate = getdate()
	set @dueDate = dateadd(dd, 7, getdate())
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

	select @orderId = SCOPE_IDENTITY()