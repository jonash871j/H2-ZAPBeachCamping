CREATE OR ALTER PROCEDURE GetCustomer
	@Email VARCHAR(100)
AS
	SELECT * 
	FROM Customers
	WHERE Customers.Email = @Email
GO
