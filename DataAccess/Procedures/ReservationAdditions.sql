CREATE OR ALTER PROCEDURE [dbo].[CreateReservationAdditions] 
	@OrderNumber INT,
	@AdditionName VARCHAR(50)
AS
BEGIN
	INSERT INTO ReservationsAdditions(AdditionName, OrderNumber) 
	VALUES(@AdditionName, @OrderNumber)
END
