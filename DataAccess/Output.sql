CREATE OR ALTER PROCEDURE CreateCustomerTypes 
	@OrderNumber INT,
	@Value INT
AS
BEGIN
	INSERT INTO CustomerTypes(OrderNumber, Value)
	VALUES (@OrderNumber, @Value)
END
GO
﻿CREATE OR ALTER PROCEDURE CreateReservationAdditions 
	@OrderNumber INT,
	@AdditionName VARCHAR(50)
AS
	INSERT INTO ReservationsAdditions(AdditionName, OrderNumber) 
	VALUES(@AdditionName, @OrderNumber)
GO﻿CREATE OR ALTER PROCEDURE GetAllAddtions 
AS
BEGIN
	SELECT * FROM Additions
END
GOCREATE OR ALTER PROCEDURE DropAllTables
AS
	DROP TABLE CustomerTypes;
	DROP TABLE ReservationsAdditions;
	DROP TABLE Additions;
	DROP TABLE Reservations;
	DROP TABLE CampingSpots;
	DROP TABLE HutSpots;
	DROP TABLE Spots;
	DROP TABLE Customers;
GO
﻿CREATE OR ALTER PROCEDURE CreateReservation 
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