

CREATE TABLE [dbo].[Product]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProdName] [nvarchar](max) NULL,
	[ProdDesc] [nvarchar](max) NULL,
	[ProdPrice] [int] NULL,
	[UpdatedAt] [DateTime] NULL
)
GO


