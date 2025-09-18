CREATE TABLE [dbo].[Ghiseu]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Cod] NCHAR(10) NULL, 
    [Denumire] NVARCHAR(50) NULL, 
    [Descriere] NVARCHAR(50) NULL, 
    [Icon] NCHAR(10) NULL, 
    [Activ] BIT NULL
)
