CREATE OR ALTER PROCEDURE GetAllAddtions
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
						@StartDate DATE, 
						@EndDate DATE,
						@IsPayForCleaning BIT
AS
	DECLARE @OrderNumber INTEGER;

	IF EXISTS (
	SELECT Customers.Email 
	FROM Customers 
	WHERE Customers.Email = @Email)
	BEGIN
		INSERT INTO Reservations(CustomerEmail, SpotNumber, StartDate, EndDate, IsInvoiceSent, IsPayForCleaning) 
		VALUES(@Email, @SpotNumber, @StartDate, @EndDate, 0, @IsPayForCleaning); 
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
		INSERT INTO Reservations(CustomerEmail, SpotNumber, StartDate, EndDate, IsInvoiceSent, IsPayForCleaning) 
		VALUES(@Email, @SpotNumber, @StartDate, @EndDate, 0, @IsPayForCleaning); 
			SET @OrderNumber = SCOPE_IDENTITY()
		RETURN @OrderNumber;
	END
GO
CREATE OR ALTER PROCEDURE GetSiteBySearch
	@IsGoodView BIT
AS
	SELECT * 
	FROM Spots
	WHERE IsGoodView = @IsGoodView
GO	

CREATE OR ALTER PROCEDURE GetCampingSiteBySearch
	@IsGoodView BIT,
	@CampingType INTEGER
AS
	SELECT * 
	FROM CampingSpots
	JOIN Spots
	ON Spots.Number = CampingSpots.Number
	WHERE IsGoodView = @IsGoodView AND CampingSpots.CampingType = @CampingType
GO

CREATE OR ALTER PROCEDURE GetHutSiteBySearch
	@IsGoodView BIT,
	@HutType INTEGER
AS
	SELECT * 
	FROM HutSpots
	JOIN Spots
	ON Spots.Number = HutSpots.Number
	WHERE IsGoodView = @IsGoodView AND HutType = @HutType
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
