--- Creating the Customers Table

CREATE TABLE Customers_174772
(
	CustomerId int identity primary key,
	FullName varchar(50),
	EmailId varchar(30),
	Password varchar(20),
	DeliveryAddress varchar(30)
)



DROP TABLE Customers_174772

ALTER TABLE Customers_174772
ALTER COLUMN DeliveryAddress varchar(200)


SELECT * FROM Customers_174772

--- Creating the Products Table

CREATE TABLE Products_174772
(
	ProductId int primary key,
	CategoryId int foreign key references Categories_174772(CategoryId),
	ModelNumber varchar(50),
	ModelName varchar(50),
	UnitCost int,
	Description varchar(50)
)

DROP TABLE Products_174772

ALTER TABLE Products_174772
ALTER COLUMN Description varchar(200)

SELECT * FROM Products_174772

--- Creating the Categories Table

CREATE TABLE Categories_174772
(
	CategoryId int primary key,
	CategoryName varchar(50),
	Description varchar(50)
)

DROP TABLE Categories_174772

ALTER TABLE Categories_174772
ALTER COLUMN Description varchar(200)

SELECT * FROM Categories_174772


--- Create the Orders Table
 
 CREATE TABLE Orders_174772
 (
	OrderId int primary key,
	CustomerId int foreign key references Customers_174772(CustomerId),
	OrderDate datetime,
	ShipDate datetime
)

DROP TABLE Orders_174772

SELECT * FROM Orders_174772

--- Create the Order Details Table

CREATE TABLE OrderDetails_174772
(
	OrderId int primary key,
	ProductId int foreign key references Products_174772(ProductId),
	Quantity int,
	UnitCost int
)

DROP TABLE OrderDetails_174772

SELECT * FROM OrderDetails_174772

--- Create the Shopping Cart Table

CREATE TABLE ShoppingCart_174772
(
	RecordId int primary key,
	CartId int,
	Quantity int,
	ProductId int foreign key references Products_174772(ProductId),
	DateCreated datetime
)

DROP TABLE ShoppingCart_174772

SELECT * FROM ShoppingCart_174772



