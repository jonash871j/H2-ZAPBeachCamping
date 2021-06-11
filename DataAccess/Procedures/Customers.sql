CREATE OR ALTER PROCEDURE GetCustomer
	@Email VARCHAR(100)
AS
BEGIN
	SELECT * 
	FROM Customers
	WHERE Customers.Email = @Email
END
GO
