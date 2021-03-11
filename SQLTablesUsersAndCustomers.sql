CREATE TABLE Users(
	UserId int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(25),
	LastName nvarchar(25),
	Email nvarchar(15),
	Passwords nvarchar(25)
)

CREATE TABLE Customers(
	CustomerId int PRIMARY KEY IDENTITY (1,1),
	UserId int ,
	CompanyName nvarchar(35),
	FOREIGN KEY (UserId) REFERENCES Users(UserId)
)

CREATE TABLE Rentals(
	RentalId int PRIMARY KEY IDENTITY (1,1),
	CarId int,
	CustomerId int,
	RentDate DateTime,
	ReturnDate DateTime,
	FOREIGN KEY (CarId) REFERENCES Cars(Id),
	FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

