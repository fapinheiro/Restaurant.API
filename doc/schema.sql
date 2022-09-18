create database RestaurantDB;

use RestaurantDB;

-- tables
create table dbo.Customers (
	CustomerId int identity(1,1) primary key,
	CustomerName varchar(100)
);

create table dbo.FoodItems (
	FoodItemId int identity(1,1) primary key,
	FoodItemName varchar(100),
	Price decimal(5,2)
);

create table dbo.OrderMasters (
	OrderMasterId int identity(1,1) primary key,
	OrderNumber varchar(75),
	CustomerId int,
	PMethod varchar(10),
	GTotal decimal(5,2)
);

create table dbo.OrderDetails (
	OrderDetailId int identity(1,1) primary key,
	OrderMasterId int,
	FoodItemId int,
	FoodItemPrice decimal(5,2),
	Quantity int
);


-- constraints
ALTER TABLE dbo.OrderMasters
   ADD CONSTRAINT FK_Customers_OrderMasters FOREIGN KEY (CustomerId)
      REFERENCES dbo.Customers (CustomerId)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE dbo.OrderDetails
   ADD CONSTRAINT FK_OrderMaster_OrderDetails FOREIGN KEY (OrderMasterId)
      REFERENCES dbo.OrderMasters (OrderMasterId)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE dbo.OrderDetails
   ADD CONSTRAINT FK_FoodItem_OrderDetails FOREIGN KEY (FoodItemId)
      REFERENCES dbo.FoodItems (FoodItemId)
      ON DELETE CASCADE -- warning: db migration generates automatically. in some cases might be a problem.
      ON UPDATE CASCADE
;
