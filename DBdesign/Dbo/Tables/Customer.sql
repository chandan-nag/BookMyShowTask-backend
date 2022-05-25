CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [Gender] NCHAR(10) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Password] VARBINARY(50) NOT NULL

)
