CREATE TABLE [dbo].[Seat]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SeatNo] INT NOT NULL, 
    [SeatQuality] VARCHAR(50) NOT NULL, 
    [TicketId] INT NOT NULL
)
