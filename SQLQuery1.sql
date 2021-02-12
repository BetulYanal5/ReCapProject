CREATE TABLE Cars(
    CarId int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice money,
	Descriptions nvarchar(25),
	FOREIGN KEY (ColorID) REFERENCES Colors(ColorID),
	FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
)
CREATE TABLE Colors(
    ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25)
)
CREATE TABLE Brands(
    BrandId int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25)
)

INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
VALUES (1,1,2010,89,"Manuel Benzin"),
       (2,2,2014,100,"Otomatik Vites"),
	   (3,3,2015,120,"Manuel Dizel"),
	   (4,4,2013,110,"Otomatik Vites"),
	   (5,5,2002,65,"Manuel Benzin");

INSERT INTO Colors(ColorName)
VALUES ("Siyah"),("Lacivert"),("Beyaz"),("Beyaz"),("Kırmızı");

INSERT INTO Brands(BrandName)
VALUES ("Toyota"),("Renault"),("BMW"),("Fiat"),("Volvo");
         