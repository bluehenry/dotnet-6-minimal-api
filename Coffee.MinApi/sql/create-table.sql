DROP TABLE [dbo].[Orders];
CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[OrderNumber] INT NOT NULL,
	[Created] DATETIME,
	[Description] VARCHAR(MAX),
	[PromoCode] VARCHAR(MAX),
	[Total] MONEY,
);

INSERT INTO [dbo].[Orders] VALUES(1, 100, GETDATE(), 'Flat White', 'Openning', 5.00);
