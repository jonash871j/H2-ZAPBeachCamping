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
BEGIN
	SELECT * 
	FROM Spots
	WHERE IsGoodView = @IsGoodView
END
GO	

CREATE OR ALTER PROCEDURE GetCampingSiteBySearch
	@IsGoodView BIT
AS
BEGIN
	SELECT * 
	FROM CampingSpots
	JOIN Spots
	ON Spots.Number = CampingSpots.Number
	WHERE IsGoodView = @IsGoodView
END
GO

CREATE OR ALTER PROCEDURE GetHutSiteBySearch
	@IsGoodView BIT
AS
BEGIN
	SELECT * 
	FROM HutSpots
	JOIN Spots
	ON Spots.Number = HutSpots.Number
	WHERE IsGoodView = @IsGoodView
END
GO	

CREATE OR ALTER PROCEDURE GetAllSpotNumbersBetweenDate
	@StartDate Date,
	@EndDate Date
AS
BEGIN
	SELECT Reservations.SpotNumber 
	FROM Reservations
	WHERE (StartDate BETWEEN @StartDate AND @EndDate) OR (EndDate BETWEEN @StartDate AND @EndDate) 
END
GO	



CREATE OR ALTER PROCEDURE GetSite
	@Number VARCHAR(8)
AS
BEGIN
	SELECT * 
	FROM Spots
	WHERE Number = @Number
END
GO	

CREATE OR ALTER PROCEDURE GetCampingSite
	@Number VARCHAR(8)
AS
BEGIN
	SELECT * 
	FROM CampingSpots
	JOIN Spots
	ON Spots.Number = CampingSpots.Number
	WHERE CampingSpots.Number = @Number
END
GO

CREATE OR ALTER PROCEDURE GetHutSite
	@Number VARCHAR(8)
AS
BEGIN
	SELECT * 
	FROM HutSpots
	JOIN Spots
	ON Spots.Number = HutSpots.Number
	WHERE HutSpots.Number = @Number
END
GO	







