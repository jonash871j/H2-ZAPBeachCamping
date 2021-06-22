CREATE OR ALTER TRIGGER trgAfterInsert ON Reservations
FOR INSERT
AS
BEGIN
    DECLARE @OrderNumber INT,
            @CustomerEmail VARCHAR(100),
            @SpotNumber VARCHAR(8),
            @StartDate DATE,
            @EndDate DATE,
            @IsInvoiceSent BIT,
            @IsPayForCleaning BIT,
            @SeasonType INTEGER

    SELECT @OrderNumber = inserted.OrderNumber FROM inserted;
    SELECT @CustomerEmail = inserted.CustomerEmail FROM inserted;
    SELECT @SpotNumber = inserted.SpotNumber FROM inserted;
    SELECT @StartDate = inserted.StartDate FROM inserted;
    SELECT @EndDate = inserted.EndDate FROM inserted;
    SELECT @IsInvoiceSent = inserted.IsInvoiceSent FROM inserted;
    SELECT @IsPayForCleaning = inserted.IsPayForCleaning FROM inserted;
    SELECT @SeasonType = inserted.SeasonType FROM inserted;

    INSERT INTO TR_Reservations(OrderNumber, CustomerEmail, SpotNumber, StartDate, EndDate, IsInvoiceSent, IsPayForCleaning,SeasonType, Logtime)
    VALUES(@OrderNumber,@CustomerEmail, @SpotNumber, @StartDate, @EndDate, @IsInvoiceSent, @IsPayForCleaning, @SeasonType, GETDATE());
END