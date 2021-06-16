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


