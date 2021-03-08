CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [ModelYear] DATETIME2 NOT NULL, 
    [DailyPrice] FLOAT NULL, 
    [Description] TEXT NULL
)
