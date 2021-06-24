--Select all additions from additions table
CREATE OR ALTER PROCEDURE GetAllAdditions
AS
	SELECT * FROM Additions
GO



--Used to get customer by email
CREATE OR ALTER PROCEDURE GetCustomer
	@Email VARCHAR(100)
AS
	SELECT * 
	FROM Customers
	WHERE Customers.Email = @Email
GO
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
--Used to create reservations additions
CREATE OR ALTER PROCEDURE CreateReservationAdditions
	@OrderNumber INT,
	@AdditionName VARCHAR(50)
AS
	INSERT INTO ReservationsAdditions(AdditionName, OrderNumber) 
	VALUES(@AdditionName, @OrderNumber)
GO

--Used to get reservation additions by order number
CREATE OR ALTER PROCEDURE GetReservationAdditions  
	@OrderNumber INT 
AS
	SELECT Additions.Name, Additions.Price, Additions.IsDailyPayment FROM ReservationsAdditions
	JOIN Additions 
	ON ReservationsAdditions.AdditionName = Additions.Name
	WHERE OrderNumber = @OrderNumber
GO


--Used to create reservation.
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

	--If customer email already exists inserts CustomerEmail from customer
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

	--If customer not exists inserts customer values
	ELSE
	BEGIN 
		INSERT INTO Customers(Email, FirstName, LastName, City, Address, PhoneNumber) 
		VALUES (@Email, @Firstname, @LastName, @City, @Address, @PhoneNumber);
	END

	--If reservations.customerEmail does not exists insert customer.email as reservations.CustomerEmail
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

--Used to check if invoice is sent
CREATE OR ALTER PROCEDURE GetAllReservationsWithMissingInvoice 
AS
	SELECT * 
	FROM Reservations 
	WHERE Reservations.IsInvoiceSent = 0
GO

--Used to mark invoice is sent
CREATE OR ALTER PROCEDURE MarkInvoiceAsSent
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

--Used to search for site with IsGoodView
CREATE OR ALTER PROCEDURE GetSiteBySearch
	@IsGoodView BIT
AS
	SELECT * 
	FROM Spots
	WHERE IsGoodView = @IsGoodView
GO	

--Used to get campingSite where IsGoodView and CampingType is true
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

--Used to get HutSite Where Isgoodview and HutType is true
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

--Used to get all spots between dates
CREATE OR ALTER PROCEDURE GetAllSpotNumbersBetweenDate
	@StartDate Date,
	@EndDate Date
AS
	SELECT Reservations.SpotNumber 
	FROM Reservations
	WHERE (StartDate BETWEEN @StartDate AND @EndDate) OR (EndDate BETWEEN @StartDate AND @EndDate) 
GO	


--Used to get tent site by number
CREATE OR ALTER PROCEDURE GetSite
	@Number VARCHAR(8)
AS
	SELECT * 
	FROM Spots
	WHERE Number = @Number
GO	
--Used to get camping site by number
CREATE OR ALTER PROCEDURE GetCampingSite
	@Number VARCHAR(8)
AS
	SELECT * 
	FROM CampingSpots
	JOIN Spots
	ON Spots.Number = CampingSpots.Number
	WHERE CampingSpots.Number = @Number
GO

--Used to get hut site by number
CREATE OR ALTER PROCEDURE GetHutSite
	@Number VARCHAR(8)
AS
	SELECT * 
	FROM HutSpots
	JOIN Spots
	ON Spots.Number = HutSpots.Number
	WHERE HutSpots.Number = @Number
GO	

--Used to get spot status
CREATE OR ALTER PROCEDURE GetSpotStatus
	@SpotNumber VARCHAR(8)
AS

--Gets unorder reservations
IF NOT EXISTS (
	SELECT * 
	FROM Reservations
	WHERE SpotNumber = @SpotNumber)
BEGIN
	RETURN 1
END
ELSE
BEGIN
	--Gets reservations where start date equal System datetime
	IF EXISTS (
	SELECT * 
	FROM Reservations
	WHERE SpotNumber = @SpotNumber AND StartDate = CONVERT(DATE, SYSDATETIME()))
	BEGIN
		RETURN 3
	END
	--Gets reservations where end date equal System datetime
	ELSE IF EXISTS (
	SELECT * 
	FROM Reservations
	WHERE SpotNumber = @SpotNumber AND EndDate = CONVERT(DATE, SYSDATETIME()))
	BEGIN
		RETURN 4
	END
	ELSE
	BEGIN
	--Gets ordered reservations 
		RETURN 2
	END
END
GO


