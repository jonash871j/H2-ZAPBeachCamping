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


