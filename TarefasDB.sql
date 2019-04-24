USE [TarefasDB]
GO

/****** Object:  Table [dbo].[Tarefa]    Script Date: 24/04/2019 15:16:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tarefa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Descricao] [varchar](200) NULL,
	[Hora] [varchar](10) NULL,
	[Data] [varchar](10) NULL,
	[Concluida] [bit] NULL,
	[Responsavel] [varchar](100) NULL,
 CONSTRAINT [PK_dbo.Tarefa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


