use RestaurantDB;

-- customers
insert into dbo.Customers values ('Filipe Pinheiro');
insert into dbo.Customers values ('Barbara Pinheiro');
insert into dbo.Customers values ('Maria Pinheiro');
insert into dbo.Customers values ('Sarah Pinheiro');

-- food item
insert into dbo.FoodItems values ('Chichen Tender', CAST(3.50 as decimal(5,2)));
insert into dbo.FoodItems values ('Chichen Tender w/ Fries', CAST(4.99 as decimal(5,2)));
insert into dbo.FoodItems values ('Chichen Tender w/ Onion', CAST(5.99 as decimal(5,2)));
insert into dbo.FoodItems values ('Grilled Cheese Sandwich', CAST(2.50 as decimal(5,2)));
insert into dbo.FoodItems values ('Grilled Cheese Sandwich w/ Fries', CAST(3.99 as decimal(5,2)));
insert into dbo.FoodItems values ('Grilled Cheese Sandwich w/ Onion', CAST(4.99 as decimal(5,2)));
insert into dbo.FoodItems values ('Lettuce and Tomato Burger', CAST(1.99 as decimal(5,2)));
insert into dbo.FoodItems values ('Soup', CAST(2.50 as decimal(5,2)));
insert into dbo.FoodItems values ('Onion Rings', CAST(2.99 as decimal(5,2)));
insert into dbo.FoodItems values ('Fries', CAST(1.99 as decimal(5,2)));
insert into dbo.FoodItems values ('Sweet Potato Fries', CAST(2.49 as decimal(5,2)));
insert into dbo.FoodItems values ('Sweet Tea', CAST(1.79 as decimal(5,2)));
insert into dbo.FoodItems values ('Bottle Water', CAST(1.00 as decimal(5,2)));
insert into dbo.FoodItems values ('Canned Drinks', CAST(1.00 as decimal(5,2)));
