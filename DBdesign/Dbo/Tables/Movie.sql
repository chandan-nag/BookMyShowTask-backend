﻿CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Genre] VARCHAR(50) NOT NULL, 
    [Rating] NCHAR(10) NOT NULL, 
    [ReleasedDate] DATETIME NOT NULL
)
