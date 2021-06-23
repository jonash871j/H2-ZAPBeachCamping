--Used to create customer type
CREATE OR ALTER PROCEDURE CreateCustomerType
	@OrderNumber INT,
	@Value INT
AS
	INSERT INTO CustomerTypes(OrderNumber, Value)
	VALUES (@OrderNumber, @Value)
GO

--Used to get customer type by order number
CREATE OR ALTER PROCEDURE GetCustomerType 
	@OrderNumber INT
AS
	SELECT CustomerTypes.Value
	FROM CustomerTypes
	WHERE @OrderNumber = OrderNumber;
GO
