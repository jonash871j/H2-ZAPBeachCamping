CREATE TABLE Customers
(
    Email VARCHAR(100) PRIMARY KEY NOT NULL,
	FirstName VarChar(25) NOT NULL,
	LastName VarChar(50) NOT NULL,
	City VarChar(50) NOT NULL,
	Address VarChar(128) NOT NULL,
	PhoneNumber VarChar(20) NOT NULL,
)

CREATE TABLE Spots
(
	Number VARCHAR(8) PRIMARY KEY NOT NULL,
	SpotType INTEGER NOT NULL,
	IsGoodView BIT NOT NULL,
)
CREATE TABLE HutSpots
(
	Number VARCHAR(8) PRIMARY KEY NOT NULL,
	IsCleaned BIT NOT NULL,
	HutType INTEGER NOT NULL,

	FOREIGN KEY (Number) REFERENCES Spots(Number),
)
CREATE TABLE CampingSpots
(
	Number VARCHAR(8) PRIMARY KEY NOT NULL,
	CampingType INTEGER NOT NULL,

	FOREIGN KEY (Number) REFERENCES Spots(Number),
)

CREATE TABLE Reservations
(
    OrderNumber INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CustomerEmail VarChar(100) NOT NULL,
	SpotNumber VARCHAR(8) NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	IsInvoiceSent BIT NOT NULL,
	IsPayForCleaning BIT NOT NULL,
	SeasonType INTEGER NOT NULL,

	FOREIGN KEY (CustomerEmail) REFERENCES Customers(Email),
	FOREIGN KEY (SpotNumber) REFERENCES Spots(Number),
)

CREATE TABLE Additions
(
	Name VARCHAR(50) PRIMARY KEY NOT NULL,
	Price FLOAT NOT NULL,
	IsDailyPayment BIT NOT NULL,
)

CREATE TABLE ReservationsAdditions
(
	AdditionName VARCHAR(50) NOT NULL,
	OrderNumber INTEGER NOT NULL,

	FOREIGN KEY (AdditionName) REFERENCES Additions(Name),
	FOREIGN KEY (OrderNumber) REFERENCES Reservations(OrderNumber),
)

CREATE TABLE CustomerTypes
(
	ID INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
	OrderNumber INTEGER NOT NULL,
	Value INTEGER NOT NULL,

	FOREIGN KEY (OrderNumber) REFERENCES Reservations(OrderNumber),
)