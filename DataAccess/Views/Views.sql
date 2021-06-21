CREATE OR ALTER VIEW GetAllReservations AS
SELECT * FROM Reservations;
GO

CREATE OR ALTER VIEW GetAllCustomers AS
SELECT * FROM Customers;
GO

CREATE OR ALTER VIEW GetALLFurtureCustomers AS
SELECT *
FROM Reservations
WHERE Reservations.StartDate > CONVERT(DATE, SYSDATETIME())
GO

CREATE OR ALTER VIEW GetAllCustomerTodayArrival AS
SELECT *
FROM Reservations
WHERE Reservations.StartDate = CONVERT(DATE, SYSDATETIME())
GO