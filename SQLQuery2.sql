CREATE TABLE Colors(
	ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(20),
)

INSERT INTO Colors(ColorName)
VALUES
	('Beyaz'),
	('Siyah'),
	('Kırmızı');


CREATE TABLE Brands(
	BrandId int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)

INSERT INTO Brands(BrandName)
VALUES
	('Alfa Romeo'),
	('Audi'),
	('Volvo'),
	('Isuzu'),
	('Toyota');


CREATE TABLE Cars(
	Id int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelYear nvarchar(25),
	DailyPrice decimal,
	Descriptions nvarchar(75),
	FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
	FOREIGN KEY (BrandId) REFERENCES Brands(BrandId)
)

INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
VALUES
	(1, 1,'2015', 100000, '2015 model, automatic, gasoline-powered vehicle'),
	(2, 2,'2016', 110000,'2016 model, manuel, diesel-powered vehicle '),
	(3, 3,'2017', 200000,'2017 model, manuel, gasoline-powered vehicle'),
	(4, 1,'2018', 255000,'2018 model, automatic, gasoline-powered vehicle'),
	(5, 2,'2019', 350000,'2019 model, automatic, diesel-powered vehicle ');