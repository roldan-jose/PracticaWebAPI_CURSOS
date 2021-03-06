USE [master]
GO
/****** Object:  Database [DB_CURSO]    Script Date: 15/07/2021 07:14:34 p. m. ******/
CREATE DATABASE [DB_CURSO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_CURSO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_CURSO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_CURSO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_CURSO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_CURSO] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_CURSO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_CURSO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_CURSO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_CURSO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_CURSO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_CURSO] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_CURSO] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_CURSO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_CURSO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_CURSO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_CURSO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_CURSO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_CURSO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_CURSO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_CURSO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_CURSO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_CURSO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_CURSO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_CURSO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_CURSO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_CURSO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_CURSO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_CURSO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_CURSO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_CURSO] SET  MULTI_USER 
GO
ALTER DATABASE [DB_CURSO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_CURSO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_CURSO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_CURSO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_CURSO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_CURSO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_CURSO] SET QUERY_STORE = OFF
GO
USE [DB_CURSO]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[IdCurso] [int] NOT NULL,
	[Codigo] [varchar](10) NULL,
	[Descripcion] [varchar](100) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[IdEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[NombreApellido]  AS (concat([Nombre],' ',[Apellido])),
	[FechaNacimiento] [date] NULL,
	[PhotoName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InscripcionCurso]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InscripcionCurso](
	[IdEstudiante] [int] NOT NULL,
	[IdPeriodo] [int] NOT NULL,
	[IdCurso] [int] NOT NULL,
	[Fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC,
	[IdPeriodo] ASC,
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[IdEstudiante] [int] NOT NULL,
	[IdPeriodo] [int] NOT NULL,
	[Fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC,
	[IdPeriodo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periodo]    Script Date: 15/07/2021 07:14:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodo](
	[IdPeriodo] [int] NOT NULL,
	[Anio] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPeriodo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'3af8d70d-9dd5-41f1-9505-e7ed4e6b06ea', 0, N'648197a1-58ed-4cef-87be-4598fb5b7ad4', N'abc@abc.co', 0, 1, NULL, N'ABC@ABC.CO', N'ABC-ABC', N'AQAAAAEAACcQAAAAELEcdGLneinD4KwJVU+vF9MKrJ/hLx2nwPRZwjtd3h64u2Q9GpvZ2iZGEqEJwYYVCw==', NULL, 0, N'QUXO6N35J4RHI5TEUHAU3ZEGYHACNHSS', 0, N'abc-abc')
GO
INSERT [dbo].[Curso] ([IdCurso], [Codigo], [Descripcion], [Estado]) VALUES (2010, N'Iu8Yg54', N'TALLER DE BASE DE DATOS', 1)
INSERT [dbo].[Curso] ([IdCurso], [Codigo], [Descripcion], [Estado]) VALUES (2098, N'Lp85BA2', N'FISICA lll', 1)
INSERT [dbo].[Curso] ([IdCurso], [Codigo], [Descripcion], [Estado]) VALUES (9062, N'jq5x63L', N'PROGRAMACIÓN ORIENTADA A OBJETOS', 0)
GO
SET IDENTITY_INSERT [dbo].[Estudiante] ON 

INSERT [dbo].[Estudiante] ([IdEstudiante], [Codigo], [Nombre], [Apellido], [FechaNacimiento], [PhotoName]) VALUES (43, N'02953384', N'Ragnar', N' Lodbrok L.P', CAST(N'1900-01-15' AS Date), N'mwy5wrec.4by.jpg')
INSERT [dbo].[Estudiante] ([IdEstudiante], [Codigo], [Nombre], [Apellido], [FechaNacimiento], [PhotoName]) VALUES (44, N'02963574', N'Sigurd', N'Ring S.R', CAST(N'1800-12-15' AS Date), N'q04ocnx3.uex.jpg')
SET IDENTITY_INSERT [dbo].[Estudiante] OFF
GO
INSERT [dbo].[InscripcionCurso] ([IdEstudiante], [IdPeriodo], [IdCurso], [Fecha]) VALUES (43, 1020, 2098, CAST(N'2021-07-15T18:36:00.087' AS DateTime))
INSERT [dbo].[InscripcionCurso] ([IdEstudiante], [IdPeriodo], [IdCurso], [Fecha]) VALUES (44, 1014, 2010, CAST(N'2021-07-15T18:48:39.257' AS DateTime))
INSERT [dbo].[InscripcionCurso] ([IdEstudiante], [IdPeriodo], [IdCurso], [Fecha]) VALUES (44, 1014, 9062, CAST(N'2021-07-15T18:47:57.903' AS DateTime))
GO
INSERT [dbo].[Matricula] ([IdEstudiante], [IdPeriodo], [Fecha]) VALUES (43, 1020, CAST(N'2021-07-15T18:34:32.470' AS DateTime))
INSERT [dbo].[Matricula] ([IdEstudiante], [IdPeriodo], [Fecha]) VALUES (44, 1014, CAST(N'2021-07-15T18:42:27.027' AS DateTime))
GO
INSERT [dbo].[Periodo] ([IdPeriodo], [Anio], [Estado]) VALUES (1014, 2025, 1)
INSERT [dbo].[Periodo] ([IdPeriodo], [Anio], [Estado]) VALUES (1015, 2015, 0)
INSERT [dbo].[Periodo] ([IdPeriodo], [Anio], [Estado]) VALUES (1016, 2016, 0)
INSERT [dbo].[Periodo] ([IdPeriodo], [Anio], [Estado]) VALUES (1017, 2017, 0)
INSERT [dbo].[Periodo] ([IdPeriodo], [Anio], [Estado]) VALUES (1018, 2021, 0)
INSERT [dbo].[Periodo] ([IdPeriodo], [Anio], [Estado]) VALUES (1019, 2022, 0)
INSERT [dbo].[Periodo] ([IdPeriodo], [Anio], [Estado]) VALUES (1020, 2020, 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_CODIGO]    Script Date: 15/07/2021 07:14:36 p. m. ******/
ALTER TABLE [dbo].[Estudiante] ADD  CONSTRAINT [UQ_CODIGO] UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[InscripcionCurso]  WITH CHECK ADD FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([IdCurso])
GO
ALTER TABLE [dbo].[InscripcionCurso]  WITH CHECK ADD FOREIGN KEY([IdEstudiante], [IdPeriodo])
REFERENCES [dbo].[Matricula] ([IdEstudiante], [IdPeriodo])
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD FOREIGN KEY([IdPeriodo])
REFERENCES [dbo].[Periodo] ([IdPeriodo])
GO
USE [master]
GO
ALTER DATABASE [DB_CURSO] SET  READ_WRITE 
GO
