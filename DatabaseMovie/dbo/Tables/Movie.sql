CREATE TABLE [dbo].[Movie]
(
	[MovieId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MovieTitle] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(300) NULL, 
    [Genre] NVARCHAR(50) NULL
)
