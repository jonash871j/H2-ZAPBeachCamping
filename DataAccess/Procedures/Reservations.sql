CREATE OR ALTER PROCEDURE CreateReservation 
						@Email VARCHAR(100), 
						@Firstname VARCHAR(25), 
						@LastName VARCHAR(25), 
						@City VARCHAR(50), 
						@Address VARCHAR(128), 
						@PhoneNumber VARCHAR(20), 
						@SpotNumber VARCHAR(8), 
						@StartDate DATE, 
						@EndDate DATE,
						@IsPayForCleaning BIT,
						@SeasonType INTEGER
AS
	DECLARE @OrderNumber INTEGER;

	IF EXISTS (
	SELECT Customers.Email 
	FROM Customers 
	WHERE Customers.Email = @Email)
	BEGIN
		INSERT INTO Reservations(CustomerEmail, SpotNumber, StartDate, EndDate, IsInvoiceSent, IsPayForCleaning, SeasonType) 
		VALUES(@Email, @SpotNumber, @StartDate, @EndDate, 0, @IsPayForCleaning, @SeasonType); 
		SET @OrderNumber = SCOPE_IDENTITY()
		RETURN @OrderNumber;
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
		INSERT INTO Reservations(CustomerEmail, SpotNumber, StartDate, EndDate, IsInvoiceSent, IsPayForCleaning, SeasonType) 
		VALUES(@Email, @SpotNumber, @StartDate, @EndDate, 0, @IsPayForCleaning, @SeasonType); 
			SET @OrderNumber = SCOPE_IDENTITY()
		RETURN @OrderNumber;
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
