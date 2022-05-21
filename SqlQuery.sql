
DROP TABLE IF EXISTS ProductCategory;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Categories;


CREATE TABLE Products (
  ProductId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ProductId PRIMARY KEY,
  ProductName nvarchar(20) NOT NULL
);


INSERT INTO Products(ProductName) VALUES ('Product-1');
INSERT INTO Products(ProductName) VALUES ('Product-2');
INSERT INTO Products(ProductName) VALUES ('Product-3');
INSERT INTO Products(ProductName) VALUES ('Product-4');

GO


CREATE TABLE Categories (
  CategoryId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CategoryId PRIMARY KEY,
  CategoryName nvarchar(20) NOT NULL
);


INSERT INTO Categories(CategoryName) VALUES ('Category-1');
INSERT INTO Categories(CategoryName) VALUES ('Category-2');
INSERT INTO Categories(CategoryName) VALUES ('Category-3');

GO


CREATE TABLE ProductCategory (
  ProductId INT NOT NULL CONSTRAINT FK_Product FOREIGN KEY REFERENCES Products(ProductId),
  CategoryId INT NULL CONSTRAINT FK_Category FOREIGN KEY REFERENCES Categories(CategoryId),
);


INSERT INTO ProductCategory(ProductId,CategoryId) VALUES (1, 1);
INSERT INTO ProductCategory(ProductId,CategoryId) VALUES (1, 2);
INSERT INTO ProductCategory(ProductId,CategoryId) VALUES (1, 3);
INSERT INTO ProductCategory(ProductId,CategoryId) VALUES (2, 2);
INSERT INTO ProductCategory(ProductId,CategoryId) VALUES (2, 3);
INSERT INTO ProductCategory(ProductId,CategoryId) VALUES (3, 1);
INSERT INTO ProductCategory(ProductId,CategoryId) VALUES (3, 3);
INSERT INTO ProductCategory(ProductId,CategoryId) VALUES (4, NULL);

GO


SELECT ProductName, CategoryName FROM Products
JOIN ProductCategory
ON Products.ProductId = ProductCategory.ProductId
LEFT JOIN Categories
ON ProductCategory.CategoryId = Categories.CategoryId
-- optional, can be safely removed
ORDER BY ProductName, CategoryName 
