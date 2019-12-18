USE [E:\EROMONITOR\EBOOKSTORESERVICES\EBOOKSTORESERVICES\APP_DATA\EBOOKSTORE.MDF]

CREATE TABLE [dbo].[Books](

    [ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,

    [Title] varchar(50) NULL,

    [Author] varchar(50) NULL,

    [Description] varchar(50) NULL,

    [Publisher] varchar(50) NULL,

    [PublishedYear] [int] NULL,

    [Price] [decimal](18, 0) NULL)

	--DROP TABLE dbo.Books
	--DELETE  FROM Books

	INSERT into dbo.Books
	(
	    --ID - column value is auto-generated
	    Title,
	    Author,
	    Description,
	    Publisher,
	    PublishedYear,
	    Price
	)
	VALUES
	(
	    -- ID - int
	    'Speaking JavaScript', -- Title - varchar
	    'Axel Rauschmayer', -- Author - varchar
	    'An In-Depth Guide for Programmers', -- Description - varchar
	    'O''Reilly Media', -- Publisher - varchar
	    2020, -- PublishedYear - int
	    1 -- Price - decimal
	)

	INSERT into dbo.Books
	(
	    --ID - column value is auto-generated
	    Title,
	    Author,
	    Description,
	    Publisher,
	    PublishedYear,
	    Price
	)
	VALUES
	(
	    -- ID - int
	    'Programming JavaScript Applications', -- Title - varchar
	    'Eric Elliott', -- Author - varchar
	    'Robust Web Architecture ', -- Description - varchar
	    'O''Reilly Media', -- Publisher - varchar
	    2020, -- PublishedYear - int
	    1 -- Price - decimal
	)
	
	

CREATE TABLE [dbo].[Users](

    [ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,

    [FullName] varchar(500),

    [Email] varchar(500),

    [Password] varbinary(500) NULL ,

    [Salt] varbinary(500) NULL,
) 

--DROP TABLE dbo.[Users]

INSERT INTO dbo.Users
(
    --ID - column value is auto-generated
    FullName,
    Email,
    Password,
    Salt
)
VALUES
(
    -- ID - int
    'Nitin Rahane', -- FullName - varchar
    'nitin.rahane11@gmail.com', -- Email - varchar
    null, -- Password - varbinary
    null -- Salt - varbinary
)

INSERT INTO dbo.Users
(
    --ID - column value is auto-generated
    FullName,
    Email,
    Password,
    Salt
)
VALUES
(
    -- ID - int
    'Vivek Rahane', -- FullName - varchar
    'vivek.rahane11@gmail.com', -- Email - varchar
    null, -- Password - varbinary
    null -- Salt - varbinary
)

CREATE TABLE Orders (
    ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,   
    UserID int NOT NULL FOREIGN KEY REFERENCES Users(ID),	
	PurchaseDate datetime NOT NULL DEFAULT getdate(),	
	TotalPrice decimal NOT NULL,
	OrderStatus varchar(50) NOT NULL DEFAULT 'Pending'
);

CREATE TABLE Order_Items (
ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
OrderNumber int NOT NULL FOREIGN KEY REFERENCES Orders(ID),
BookID int NOT NULL FOREIGN KEY REFERENCES Books(ID),
Quantity int NOT NULL DEFAULT 1,
)



  CREATE TABLE Cart (
    ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,   
    UserID int NOT NULL FOREIGN KEY REFERENCES Users(ID),
	BookID int NOT NULL FOREIGN KEY REFERENCES Books(ID),	
	Quantity int NOT NULL DEFAULT 1,
	AddedDate datetime NOT NULL DEFAULT getdate(),
	CartStaus varchar(50) DEFAULT 'AddedToCart'    
);

--DROP TABLE Cart

--DROP TABLE Orders

-- DROP TABLE Order_Items

SELECT * FROM dbo.Books b

SELECT * FROM dbo.Users u

SELECT * FROM books WHERE dbo.Books.ID = 1 

DELETE 
FROM dbo.Books
WHERE dbo.Books.ID = @id



SELECT * FROM cart

DECLARE @userId int  = 1;
DECLARE @bookID int  = 1;

if exists(
	SELECT * from dbo.Cart c 
	where  c.UserID= @userId 
		 AND c.BookID = @bookID
	)            
BEGIN            
 update dbo.Cart  set Quantity =  (Quantity + 1)
 WHERE UserID= @userId 
		 AND BookID = @bookID
End                    
else            
begin  
insert INTO dbo.Cart
(
    --ID - column value is auto-generated
    UserID,
    BookID,
    Quantity,
    AddedDate,
    CartStaus
)
VALUES
(   
    @userId, -- UserID - int
    @bookID, -- BookID - int
    1, -- Quantity - int
    '2019-12-17 21:06:35', -- AddedDate - datetime
    'AddedToCart' -- CartStaus - varchar
)
end 

DECLARE @userId int  = 1;
DECLARE @bookID int  = 1;
DELETE FROM dbo.Cart
WHERE userid = @userID AND bookId = @bookID

SELECT b.*, c.Quantity, c.AddedDate FROM books b
INNER JOIN Cart c
ON b.ID = c.BookID
WHERE c.userid = 1
AND c.CartStaus = 'addedtocart'


INSERT INTO dbo.Orders
(
    --ID - column value is auto-generated
    UserID,
    PurchaseDate,
    TotalPrice,
    OrderStatus
)
VALUES
(
    -- ID - int
    0, -- UserID - int
    '2019-12-17 22:42:21', -- PurchaseDate - datetime
    0, -- TotalPrice - decimal
    '' -- OrderStatus - varchar
)

INSERT INTO dbo.Order_Items
(
    --ID - column value is auto-generated
    OrderNumber,
    BookID,
    Quantity
)
VALUES
(
    -- ID - int
    0, -- OrderNumber - int
    0, -- BookID - int
    0 -- Quantity - int
)




SELECT SCOPE_IDENTITY()

SELECT * FROM dbo.Orders
SELECT * FROM dbo.Order_Items

DELETE FROM Order_items
DELETE FROM Orders


SELECT * FROM dbo.Orders o
WHERE o.UserID = 1

SELECT * FROM order_items o WHERE o.OrderNumber = 6

SELECT b.* FROM Books b 
INNER JOIN 
dbo.Order_Items oi
ON b.ID = oi.BookID
AND oi.OrderNumber = 6