USE [GymTEC]
GO
/****** Object:  Database [GymTECSQL]    Script Date: 1/6/2021 21:30:49 ******/
CREATE DATABASE [GymTEC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GymTECSQL', FILENAME = N'D:\Bases de Datos\MSSQL15.MSSQLSERVER\MSSQL\DATA\GymTECSQL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GymTECSQL_log', FILENAME = N'D:\Bases de Datos\MSSQL15.MSSQLSERVER\MSSQL\DATA\GymTECSQL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GymTEC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GymTEC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GymTEC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GymTEC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GymTEC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GymTEC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GymTEC] SET ARITHABORT OFF 
GO
ALTER DATABASE [GymTEC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GymTEC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GymTEC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GymTEC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GymTEC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GymTEC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GymTEC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GymTEC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GymTEC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GymTEC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GymTEC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GymTEC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GymTEC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GymTEC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GymTEC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GymTEC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GymTEC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GymTEC] SET RECOVERY FULL 
GO
ALTER DATABASE [GymTEC] SET  MULTI_USER 
GO
ALTER DATABASE [GymTEC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GymTEC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GymTEC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GymTEC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GymTEC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GymTEC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GymTECSQL', N'ON'
GO
ALTER DATABASE [GymTEC] SET QUERY_STORE = OFF
GO
USE [GymTEC]
GO
/****** Object:  Table [dbo].[Clase]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[ID] [varchar](30) NOT NULL,
	[ID_sucursal] [varchar](20) NOT NULL,
	[Tipo] [varchar](30) NOT NULL,
	[Modalidad] [varchar](30) NOT NULL,
	[Instructor] [int] NOT NULL,
	[Hora_inicio] [time](7) NOT NULL,
	[Hora_fin] [time](7) NOT NULL,
	[Fecha] [date] NOT NULL,
 CONSTRAINT [PK_Clase_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clases_de_clientes]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clases_de_clientes](
	[Cedula] [int] NOT NULL,
	[ID_clase] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Clases_de_clientes] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC,
	[ID_clase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Cedula] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Cedula] [int] NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Salario] [int] NOT NULL,
	[Provincia] [varchar](20) NOT NULL,
	[Distrito] [varchar](20) NOT NULL,
	[Canton] [varchar](20) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Apellido1] [varchar](30) NOT NULL,
	[Apellido2] [varchar](30) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados_admin]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados_admin](
	[Cedula] [int] NOT NULL,
	[ID_sucursal] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Empleados_admin] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC,
	[ID_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maquina]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquina](
	[Serie] [varchar](30) NOT NULL,
	[ID_sucursal] [varchar](20) ,
	[Costo] [int] NOT NULL,
	[Marca] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Maquina] PRIMARY KEY CLUSTERED 
(
	[Serie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maquinas_tipos]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquinas_tipos](
	[Serie] [varchar](30) NOT NULL,
	[ID] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Maquinas_tipos] PRIMARY KEY CLUSTERED 
(
	[Serie] ASC,
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Numeros_sucursal]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Numeros_sucursal](
	[ID_sucursal] [varchar](20) NOT NULL,
	[Numero] [int] NOT NULL,
 CONSTRAINT [PK_Numeros_sucursal] PRIMARY KEY CLUSTERED 
(
	[ID_sucursal] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Bar_code] [varchar](30) NOT NULL,
	[ID_servicio] [varchar](30),
	[Nombre] [varchar](30) NOT NULL,
	[Costo] [int] NOT NULL,
	[Descripcion] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Bar_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[ID] [varchar](30) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Puesto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puestos_empleados]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos_empleados](
	[Cedula] [int] NOT NULL,
	[ID_puesto] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Puestos_empleados] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC,
	[ID_puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[ID] [varchar](30) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles_empleados]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles_empleados](
	[Cedula] [int] NOT NULL,
	[ID_rol] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Roles_empleados] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC,
	[ID_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[ID] [varchar](30) NOT NULL,
	[ID_sucursal] [varchar](20) NOT NULL,
	[Descripcion] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Activo]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activo] (
	[ID] [varchar](30) NOT NULL,
	[Spa] [varchar](20) NOT NULL,
	[Tienda] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Activo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[ID] [varchar](20) NOT NULL,
	[Max_capacidad] [int] NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Provincia] [varchar](20) NOT NULL,
	[Distrito] [varchar](20) NOT NULL,
	[Canton] [varchar](20) NOT NULL,
	[Fecha_apertura] [datetime] NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_equipo]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_equipo](
	[ID] [varchar](30) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Tipo_equipo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_planilla]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_planilla](
	[ID] [varchar](30) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipo_planilla] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_planillas_empleados]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_planillas_empleados](
	[Cedula] [int] NOT NULL,
	[ID_tipo_planilla] [varchar](30) NOT NULL,
	[Clases] [int] NULL,
	[Horas] [int] NULL,
 CONSTRAINT [PK_Tipos_planillas_empleados] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC,
	[ID_tipo_planilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tratamiento]    Script Date: 1/6/2021 21:30:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tratamiento](
	[ID] [varchar](30) NOT NULL,
	[ID_servicio] [varchar](30),
	[Nombre] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Tratamiento_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_Clase_Empleado] FOREIGN KEY([Instructor])
REFERENCES [dbo].[Empleado] ([Cedula])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_Clase_Empleado]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_Clase_Sucursal] FOREIGN KEY([ID_sucursal])
REFERENCES [dbo].[Sucursal] ([ID])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_Clase_Sucursal]
GO
ALTER TABLE [dbo].[Clases_de_clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clases_de_clientes_Clase] FOREIGN KEY([ID_clase])
REFERENCES [dbo].[Clase] ([ID])
GO
ALTER TABLE [dbo].[Clases_de_clientes] CHECK CONSTRAINT [FK_Clases_de_clientes_Clase]
GO
ALTER TABLE [dbo].[Clases_de_clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clases_de_clientes_Cliente] FOREIGN KEY([Cedula])
REFERENCES [dbo].[Cliente] ([Cedula])
GO
ALTER TABLE [dbo].[Clases_de_clientes] CHECK CONSTRAINT [FK_Clases_de_clientes_Cliente]
GO
ALTER TABLE [dbo].[Empleados_admin]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_admin_Empleado] FOREIGN KEY([Cedula])
REFERENCES [dbo].[Empleado] ([Cedula])
GO
ALTER TABLE [dbo].[Empleados_admin] CHECK CONSTRAINT [FK_Empleados_admin_Empleado]
GO
ALTER TABLE [dbo].[Empleados_admin]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_admin_Sucursal] FOREIGN KEY([ID_sucursal])
REFERENCES [dbo].[Sucursal] ([ID])
GO
ALTER TABLE [dbo].[Empleados_admin] CHECK CONSTRAINT [FK_Empleados_admin_Sucursal]
GO
ALTER TABLE [dbo].[Maquinas_tipos]  WITH CHECK ADD  CONSTRAINT [FK_Maquinas_tipos_Maquina] FOREIGN KEY([Serie])
REFERENCES [dbo].[Maquina] ([Serie])
GO
ALTER TABLE [dbo].[Maquinas_tipos] CHECK CONSTRAINT [FK_Maquinas_tipos_Maquina]
GO
ALTER TABLE [dbo].[Maquinas_tipos]  WITH CHECK ADD  CONSTRAINT [FK_Maquinas_tipos_Tipo_equipo] FOREIGN KEY([ID])
REFERENCES [dbo].[Tipo_equipo] ([ID])
GO
ALTER TABLE [dbo].[Maquinas_tipos] CHECK CONSTRAINT [FK_Maquinas_tipos_Tipo_equipo]
GO
ALTER TABLE [dbo].[Numeros_sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Numeros_sucursal_Sucursal] FOREIGN KEY([ID_sucursal])
REFERENCES [dbo].[Sucursal] ([ID])
GO
ALTER TABLE [dbo].[Numeros_sucursal] CHECK CONSTRAINT [FK_Numeros_sucursal_Sucursal]
GO
ALTER TABLE [dbo].[Puestos_empleados]  WITH CHECK ADD  CONSTRAINT [FK_Puestos_empleados_Empleado] FOREIGN KEY([Cedula])
REFERENCES [dbo].[Empleado] ([Cedula])
GO
ALTER TABLE [dbo].[Puestos_empleados] CHECK CONSTRAINT [FK_Puestos_empleados_Empleado]
GO
ALTER TABLE [dbo].[Puestos_empleados]  WITH CHECK ADD  CONSTRAINT [FK_Puestos_empleados_Puesto] FOREIGN KEY([ID_puesto])
REFERENCES [dbo].[Puesto] ([ID])
GO
ALTER TABLE [dbo].[Puestos_empleados] CHECK CONSTRAINT [FK_Puestos_empleados_Puesto]
GO
ALTER TABLE [dbo].[Roles_empleados]  WITH CHECK ADD  CONSTRAINT [FK_Roles_empleados_Empleado] FOREIGN KEY([Cedula])
REFERENCES [dbo].[Empleado] ([Cedula])
GO
ALTER TABLE [dbo].[Roles_empleados] CHECK CONSTRAINT [FK_Roles_empleados_Empleado]
GO
ALTER TABLE [dbo].[Roles_empleados]  WITH CHECK ADD  CONSTRAINT [FK_Roles_empleados_Roles_empleados] FOREIGN KEY([ID_rol])
REFERENCES [dbo].[Rol] ([ID])
GO
ALTER TABLE [dbo].[Roles_empleados] CHECK CONSTRAINT [FK_Roles_empleados_Roles_empleados]
GO
ALTER TABLE [dbo].[Servicio]  WITH CHECK ADD  CONSTRAINT [FK_Servicio_Sucursal1] FOREIGN KEY([ID_sucursal])
REFERENCES [dbo].[Sucursal] ([ID])
GO
ALTER TABLE [dbo].[Servicio] CHECK CONSTRAINT [FK_Servicio_Sucursal1]
GO
ALTER TABLE [dbo].[Tipos_planillas_empleados]  WITH CHECK ADD  CONSTRAINT [FK_Tipos_planillas_empleados_Empleado] FOREIGN KEY([Cedula])
REFERENCES [dbo].[Empleado] ([Cedula])
GO
ALTER TABLE [dbo].[Tipos_planillas_empleados] CHECK CONSTRAINT [FK_Tipos_planillas_empleados_Empleado]
GO
ALTER TABLE [dbo].[Tipos_planillas_empleados]  WITH CHECK ADD  CONSTRAINT [FK_Tipos_planillas_empleados_Tipo_planilla] FOREIGN KEY([ID_tipo_planilla])
REFERENCES [dbo].[Tipo_planilla] ([ID])
GO
ALTER TABLE [dbo].[Tipos_planillas_empleados] CHECK CONSTRAINT [FK_Tipos_planillas_empleados_Tipo_planilla]
GO
ALTER TABLE [dbo].[Activo]  WITH CHECK ADD  CONSTRAINT [PK_Activo] FOREIGN KEY([ID])
REFERENCES [dbo].[Sucursal] ([ID])
GO
USE [GymTEC]
GO
ALTER DATABASE [GymTEC] SET  READ_WRITE 
GO
