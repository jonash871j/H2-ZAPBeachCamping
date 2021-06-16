CREATE OR ALTER PROCEDURE CreateCustomerType
	@OrderNumber INT,
	@Value INT
AS
	INSERT INTO CustomerTypes(OrderNumber, Value)
	VALUES (@OrderNumber, @Value)
GO

CREATE OR ALTER PROCEDURE GetCustomerType 
	@OrderNumber INT
AS
	SELECT CustomerTypes.Value
	FROM CustomerTypes
	WHERE @OrderNumber = OrderNumber;
GO
