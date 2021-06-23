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

CREATE OR ALTER PROCEDURE GetSpotStatus
	@SpotNumber VARCHAR(8)
AS
	
IF NOT EXISTS (
	SELECT * 
	FROM Reservations
	WHERE SpotNumber = @SpotNumber)
BEGIN
	RETURN 1
END
ELSE
BEGIN
	IF EXISTS (
	SELECT * 
	FROM Reservations
	WHERE SpotNumber = @SpotNumber AND StartDate = CONVERT(DATE, SYSDATETIME()))
	BEGIN
		RETURN 3
	END
	ELSE IF EXISTS (
	SELECT * 
	FROM Reservations
	WHERE SpotNumber = @SpotNumber AND EndDate = CONVERT(DATE, SYSDATETIME()))
	BEGIN
		RETURN 4
	END
	ELSE
	BEGIN
		RETURN 2
	END
END
GO


