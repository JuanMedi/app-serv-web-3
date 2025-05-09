USE [DBExamen]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 4/20/2025 1:19:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[idEstudiante] [int] NOT NULL,
	[Documento] [varchar](20) NOT NULL,
	[NombreCompleto] [varchar](80) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[Clave] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[idEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 4/20/2025 1:19:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[idMatricula] [int] IDENTITY(1,1) NOT NULL,
	[idEstudiante] [int] NOT NULL,
	[NumeroCreditos] [int] NOT NULL,
	[ValorCredito] [int] NOT NULL,
	[TotalMatricula] [int] NOT NULL,
	[FechaMatricula] [date] NOT NULL,
	[SemestreMatricula] [varchar](6) NOT NULL,
	[MateriasMatriculadas] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Matricula] PRIMARY KEY CLUSTERED 
(
	[idMatricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Estudiante] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Estudiante] ([idEstudiante])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Estudiante]
GO
