CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(100) NULL, 
    [PasswordHash] NVARCHAR(255) NULL, 
    [userName] NCHAR(50) NULL, 
    [CreatedAt] DATETIME NULL, 
    [RoleUser] NCHAR(20) NULL
)
