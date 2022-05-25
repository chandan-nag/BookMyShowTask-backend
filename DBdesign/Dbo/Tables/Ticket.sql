CREATE TABLE [dbo].[Ticket]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MovieId] INT NOT NULL, 
    [TheatreId] INT NOT NULL, 
    [NoOfSeats] INT NOT NULL, 
    [ShowId] INT NOT NULL
)
