﻿CREATE TABLE [dbo].[Theatre]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(50) NOT NULL, 
    [MovieId] INT NOT NULL
)
