namespace NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Seed
{
    public static class ProductSeed
    {
        public static string GetSeed()
        {
            var sql = @"
                USE [SimpleDapperVsDapperQueryMultiple_Db];                

                IF OBJECT_ID(N'dbo.ProductDetails', N'U') IS NOT NULL  
                   DROP TABLE [dbo].[ProductDetails];  
                
                IF OBJECT_ID(N'dbo.Products', N'U') IS NOT NULL  
                   DROP TABLE [dbo].[Products];
                
                IF OBJECT_ID(N'dbo.Categories', N'U') IS NOT NULL  
                   DROP TABLE [dbo].[Categories];
                
                CREATE TABLE Categories (
                  Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
                  [Name] VARCHAR(100) NOT NULL
                );

                CREATE TABLE Products (
                  Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
                  [Name] VARCHAR(100) NOT NULL,
                  [CategoryId] INT NOT NULL
  	                CONSTRAINT FK_CATEGORY_ID
                        REFERENCES Categories(Id)
                );

                CREATE TABLE ProductDetails (
                  Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
                  [Name] VARCHAR(100) NOT NULL,
                  [ProductId] INT NOT NULL
  	                CONSTRAINT FK_PRODUCT_ID
                        REFERENCES Products(Id)
                );

                INSERT INTO Categories([Name]) 
                VALUES ('Category 1'),('Category 2'),('Category 3'),('Category 4');

                INSERT INTO Products([Name],[CategoryId]) 
                VALUES ('Product 1', 1),('Product 2', 1),('Product 3', 2),('Product 4', 3);

                INSERT INTO ProductDetails([Name], ProductId)
                VALUES('Detail 1', 1),('Detail 2', 1),('Detail 3', 1),('Detail 4', 1),
                ('Detail 5', 2),('Detail 6', 2),('Detail 7', 2),('Detail 8', 2),
                ('Detail 9', 3),('Detail 10', 3),('Detail 11', 3),('Detail 12', 3),
                ('Detail 13', 4),('Detail 14', 4),('Detail 15', 4),('Detail 16', 4);
            ";

            return sql;
        }
    }
}
