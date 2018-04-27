CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nchar](50) NOT NULL,
	[telefone] [nchar](20) NULL,
	[ativo] [bit] NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED ([id])
)
GO