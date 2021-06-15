CREATE OR ALTER PROCEDURE [dbo].[CreateReservationAdditions] 
	@OrderNumber INT,
	@AdditionName VARCHAR(50)
AS
BEGIN
	INSERT INTO ReservationsAdditions(AdditionName, OrderNumber) 
	VALUES(@AdditionName, @OrderNumber)
END
GO

CREATE OR ALTER PROCEDURE GetReservationAdditions  
	@OrderNumber INT 
AS
BEGIN
	SELECT Additions.Name, Additions.Price, Additions.IsDailyPayment FROM ReservationsAdditions
		JOIN Additions 
		ON ReservationsAdditions.AdditionName = Additions.Name
		WHERE OrderNumber = @OrderNumber
END
GO


