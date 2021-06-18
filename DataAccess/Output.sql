CREATE OR ALTER PROCEDURE GetAllAddtion
AS
	SELECT * FROM Additions
GO

CREATE OR ALTER PROCEDURE GetCustomer
	@Email VARCHAR(100)
AS
	SELECT * 
	FROM Customers
	WHERE Customers.Email = @Email
GO
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
CREATE OR ALTER PROCEDURE CreateReservationAdditions
	@OrderNumber INT,
	@AdditionName VARCHAR(50)
AS
	INSERT INTO ReservationsAdditions(AdditionName, OrderNumber) 
	VALUES(@AdditionName, @OrderNumber)
GO

CREATE OR ALTER PROCEDURE GetReservationAdditions  
	@OrderNumber INT 
AS
	SELECT Additions.Name, Additions.Price, Additions.IsDailyPayment FROM ReservationsAdditions
	JOIN Additions 
	ON ReservationsAdditions.AdditionName = Additions.Name
	WHERE OrderNumber = @OrderNumber
GO


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
--CREATE OR ALTER PROCEDURE GetSpotsBySearch
--	@SpotType INT,
--	@IsGoodView BIT
--AS
--BEGIN
--	SELECT * 
--	FROM Spots
--	WHERE SpotType = @SpotType
--	AND IsGoodView = @IsGoodView
--END
--GO	

CREATE OR ALTER PROCEDURE GetSiteBySearch
	@IsGoodView BIT
AS
	SELECT * 
	FROM Spots
	WHERE IsGoodView = @IsGoodView
GO	

CREATE OR ALTER PROCEDURE GetCampingSiteBySearch
	@IsGoodView BIT
AS
	SELECT * 
	FROM CampingSpots
	JOIN Spots
	ON Spots.Number = CampingSpots.Number
	WHERE IsGoodView = @IsGoodView
GO

CREATE OR ALTER PROCEDURE GetHutSiteBySearch
	@IsGoodView BIT
AS
	SELECT * 
	FROM HutSpots
	JOIN Spots
	ON Spots.Number = HutSpots.Number
	WHERE IsGoodView = @IsGoodView
GO	

CREATE OR ALTER PROCEDURE GetAllSpotNumbersBetweenDate
	@StartDate Date,
	@EndDate Date
AS
	SELECT Reservations.SpotNumber 
	FROM Reservations
	WHERE (StartDate BETWEEN @StartDate AND @EndDate) OR (EndDate BETWEEN @StartDate AND @EndDate) 
GO	



CREATE OR ALTER PROCEDURE GetSite
	@Number VARCHAR(8)
AS
	SELECT * 
	FROM Spots
	WHERE Number = @Number
GO	

CREATE OR ALTER PROCEDURE GetCampingSite
	@Number VARCHAR(8)
AS
	SELECT * 
	FROM CampingSpots
	JOIN Spots
	ON Spots.Number = CampingSpots.Number
	WHERE CampingSpots.Number = @Number
GO

CREATE OR ALTER PROCEDURE GetHutSite
	@Number VARCHAR(8)
AS
	SELECT * 
	FROM HutSpots
	JOIN Spots
	ON Spots.Number = HutSpots.Number
	WHERE HutSpots.Number = @Number
GO	
