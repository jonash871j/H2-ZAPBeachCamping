CREATE OR ALTER PROCEDURE CreateReservation @Email VARCHAR(100), @Firstname VARCHAR(25), @LastName VARCHAR(25), @City VARCHAR(50), @Address VARCHAR(128), @PhoneNumber VARCHAR(20), @SpotNumber VARCHAR(8), @TotalPrice FLOAT, @StartDate DATE, @EndDate DATE
AS
	INSERT INTO Customers(Email, FirstName, LastName, City, Address, PhoneNumber) VALUES 
	(@Email, @Firstname, @LastName, @City, @Address, @PhoneNumber);
	
	IF NOT EXISTS (SELECT Reservations.CustomerEmail FROM Reservations WHERE Reservations.CustomerEmail = @Email)
	
	INSERT INTO Reservations(CustomerEmail, SpotNumber, TotalPrice, StartDate, EndDate, IsInvoiceSent) VALUES 
	(@Email, @SpotNumber, @TotalPrice, @StartDate, @EndDate, 0);
GO