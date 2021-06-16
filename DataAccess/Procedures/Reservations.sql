CREATE OR ALTER PROCEDURE CreateReservation 
						@Email VARCHAR(100), 
						@Firstname VARCHAR(25), 
						@LastName VARCHAR(25), 
						@City VARCHAR(50), 
						@Address VARCHAR(128), 
						@PhoneNumber VARCHAR(20), 
						@SpotNumber VARCHAR(8), 
						@TotalPrice FLOAT, 
						@StartDate DATE, 
						@EndDate DATE
AS
	IF EXISTS (
	SELECT Customers.Email 
	FROM Customers 
	WHERE Customers.Email = @Email)
	BEGIN
		INSERT INTO Reservations(CustomerEmail, SpotNumber, TotalPrice, StartDate, EndDate, IsInvoiceSent) 
		VALUES(@Email, @SpotNumber, @TotalPrice, @StartDate, @EndDate, 0); 
	END

	ELSE
	BEGIN 
		INSERT INTO Customers(Email, FirstName, LastName, City, Address, PhoneNumber) 
		VALUES (@Email, @Firstname, @LastName, @City, @Address, @PhoneNumber);
	END

	IF NOT EXISTS (
	SELECT Reservations.CustomerEmail 
	FROM Reservations 
	WHERE Reservations.CustomerEmail = @Email)
	BEGIN
		INSERT INTO Reservations(CustomerEmail, SpotNumber, TotalPrice, StartDate, EndDate, IsInvoiceSent) 
		VALUES (@Email, @SpotNumber, @TotalPrice, @StartDate, @EndDate, 0);
	END
GO

CREATE OR ALTER PROCEDURE GetAllReservationsWithMissingInvoice 
AS
	SELECT * 
	FROM Reservations 
	WHERE Reservations.IsInvoiceSent = 0
GO

CREATE OR ALTER PROCEDURE MarkReservationAsSent
	@OrderNumber INT
AS
	UPDATE Reservations
	SET IsInvoiceSent = 1
	WHERE OrderNumber = @OrderNumber;
GO

CREATE OR ALTER PROCEDURE GetReservation
	@OrderNumber INT
AS
	SELECT *
	FROM Reservations
	WHERE Reservations.OrderNumber = @OrderNumber
GO
