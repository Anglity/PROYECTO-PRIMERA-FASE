--CREATE DATABASE proyecto

USE [proyecto]
GO
/****** Object:  UserDefinedTableType [dbo].[EDetalle_Compra]    Script Date: 22/08/2023 02:41:06 p. m. ******/
CREATE TYPE [dbo].[EDetalle_Compra] AS TABLE(
	[IdProducto] [int] NULL,
	[PrecioCompra] [decimal](18, 2) NULL,
	[PrecioVenta] [decimal](18, 2) NULL,
	[Cantidad] [int] NULL,
	[MontoTotal] [decimal](18, 2) NULL,
	[UnidadMedida] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[EDetalle_Venta]    Script Date: 22/08/2023 02:41:06 p. m. ******/
CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE(
	[IdProducto] [int] NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[SubTotal] [decimal](10, 2) NULL,
	[itbis] [decimal](10, 2) NULL,
	[Valortotal] [decimal](10, 2) NULL,
	[UnidadesMedida] [varchar](50) NULL,
	[Galones_a_Litro] [decimal](10, 4) NULL,
	[Bloque_a_Libra] [decimal](10, 4) NULL
)
GO
/****** Object:  Table [dbo].[AlertasInventario]    Script Date: 22/08/2023 02:41:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlertasInventario](
	[Id] [int] NOT NULL,
	[IdProducto] [int] NULL,
	[TipoAlerta] [varchar](50) NULL,
	[Fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlertasVencimiento]    Script Date: 22/08/2023 02:41:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlertasVencimiento](
	[Id] [int] NOT NULL,
	[IdProducto] [int] NULL,
	[LoteId] [int] NULL,
	[FechaAlerta] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnalisisDatos]    Script Date: 22/08/2023 02:41:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnalisisDatos](
	[Id] [int] NOT NULL,
	[FechaAnalisis] [date] NULL,
	[VentasRendimientoComercial] [decimal](10, 2) NULL,
	[InformesFinancieros] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnalisisVentas]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnalisisVentas](
	[Id] [int] NOT NULL,
	[IdVenta] [int] NULL,
	[Fecha] [date] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[Ganancia] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[NombreCompleto] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
	[IdDireccion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMPRA]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMPRA](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdProveedor] [int] NULL,
	[TipoDocumento] [varchar](50) NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComprasOrdenes]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprasOrdenes](
	[Id] [int] NOT NULL,
	[IdProveedor] [int] NULL,
	[FechaOrden] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlCalidad]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlCalidad](
	[Id] [int] NOT NULL,
	[IdProducto] [int] NULL,
	[Fecha] [date] NULL,
	[Observaciones] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlPagos]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlPagos](
	[Id] [int] NOT NULL,
	[IdVenta] [int] NULL,
	[MontoPagado] [decimal](10, 2) NULL,
	[FechaPago] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlProduccion]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlProduccion](
	[Id] [int] NOT NULL,
	[OrdenProduccionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Id] [int] NOT NULL,
	[IdCliente] [int] NULL,
	[Saldo] [decimal](10, 2) NULL,
	[FechaApertura] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_COMPRA]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_COMPRA](
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NULL,
	[IdProducto] [int] NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
	[UnidadMedida] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_VENTA]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_VENTA](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdProducto] [int] NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[UnidadesMedida] [varchar](50) NULL,
	[SubTotal] [decimal](10, 2) NULL,
	[itbis] [decimal](10, 2) NULL,
	[Valortotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
	[Galones_a_Litro] [decimal](10, 2) NULL,
	[Bloque_a_Libra] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedidos]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedidos](
	[Id] [int] NOT NULL,
	[PedidoId] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevolucionesClientes]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevolucionesClientes](
	[Id] [int] NOT NULL,
	[IdCliente] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[FechaDevolucion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevolucionesClientesProcesadas]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevolucionesClientesProcesadas](
	[Id] [int] NOT NULL,
	[IdCliente] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[FechaProcesamiento] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevolucionesProveedores]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevolucionesProveedores](
	[Id] [int] NOT NULL,
	[IdProveedor] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIRECCION]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIRECCION](
	[IdDireccion] [int] IDENTITY(1,1) NOT NULL,
	[Pais] [varchar](100) NULL,
	[Provincia] [varchar](100) NULL,
	[Ciudad] [varchar](100) NULL,
	[Sector] [varchar](100) NULL,
	[Calle] [varchar](100) NULL,
	[CodigoPostal] [varchar](10) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Cargo] [varchar](100) NULL,
	[Salario] [decimal](10, 2) NULL,
	[IdDireccion] [int] NULL,
	[Documento] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entregas]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entregas](
	[Id] [int] NOT NULL,
	[PedidoId] [int] NULL,
	[FechaEntrega] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EtiquetadoEmpaque]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EtiquetadoEmpaque](
	[Id] [int] NOT NULL,
	[OrdenProduccionId] [int] NULL,
	[FechaEtiquetado] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturacion]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturacion](
	[Id] [int] NOT NULL,
	[IdVenta] [int] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaFacturacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Finanzas]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Finanzas](
	[Id] [int] NOT NULL,
	[IdCompra] [int] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GestionComercial]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GestionComercial](
	[Id] [int] NOT NULL,
	[IdVenta] [int] NULL,
	[FechaGestion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historial_Cambios]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial_Cambios](
	[IdHistorial] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[TablaModificada] [varchar](100) NULL,
	[CambiosRealizados] [varchar](500) NULL,
	[Fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHistorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impuestos]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impuestos](
	[Id] [int] NOT NULL,
	[IdCompra] [int] NULL,
	[Monto] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incentivos]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incentivos](
	[Id] [int] NOT NULL,
	[EmpleadoId] [int] NULL,
	[Tipo] [varchar](100) NULL,
	[Monto] [decimal](10, 2) NULL,
	[Fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InformacionEmpleados]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformacionEmpleados](
	[Id] [int] NOT NULL,
	[EmpleadoId] [int] NULL,
	[FechaNacimiento] [date] NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[Id] [int] NOT NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[FechaInventario] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventarioLotes]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventarioLotes](
	[Id] [int] NOT NULL,
	[IdProducto] [int] NULL,
	[Lote] [varchar](50) NULL,
	[FechaVencimiento] [date] NULL,
	[Stock] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lotes]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lotes](
	[Id] [int] NOT NULL,
	[IdProducto] [int] NULL,
	[Lote] [varchar](50) NULL,
	[FechaVencimiento] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NEGOCIO]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NEGOCIO](
	[IdNegocio] [int] NOT NULL,
	[Nombre] [varchar](60) NULL,
	[RUC] [varchar](60) NULL,
	[Direccion] [varchar](60) NULL,
	[Logo] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nomina]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomina](
	[Id] [int] NOT NULL,
	[RecursosHumanosId] [int] NULL,
	[FechaNomina] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesProduccion]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesProduccion](
	[Id] [int] NOT NULL,
	[ProduccionId] [int] NULL,
	[FechaOrden] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoDetalles]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoDetalles](
	[id_pedido] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[precio_unitario] [money] NOT NULL,
	[cantidad] [int] NOT NULL,
	[descuento] [numeric](5, 2) NOT NULL,
 CONSTRAINT [PK_PedidoDetalles] PRIMARY KEY CLUSTERED 
(
	[id_pedido] ASC,
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Id] [int] NOT NULL,
	[IdCliente] [int] NULL,
	[FechaPedido] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERMISO]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISO](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[NombreMenu] [varchar](100) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produccion]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produccion](
	[Id] [int] NOT NULL,
	[FechaProduccion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProduccionQueso]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProduccionQueso](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FechaProduccion] [date] NULL,
	[CantidadCheddar] [int] NULL,
	[CantidadDanes] [int] NULL,
	[UnidadMedidaGenerica] [varchar](50) NULL,
	[CantidadTotal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[IdCategoria] [int] NULL,
	[Stock] [int] NOT NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
	[UnidadMedida] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promociones]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promociones](
	[Id] [int] NOT NULL,
	[IdProducto] [int] NULL,
	[Descuento] [decimal](5, 2) NULL,
	[FechaInicio] [date] NULL,
	[FechaFin] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVEEDOR]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVEEDOR](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[RazonSocial] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
	[IdDireccion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO









/****** Object:  Table [dbo].[RecursosHumanos]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecursosHumanos](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Cargo] [varchar](100) NULL,
	[Salario] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguridad]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguridad](
	[Id] [int] NOT NULL,
	[Usuario] [varchar](100) NULL,
	[Contrasena] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[NombreCompleto] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Clave] [varchar](50) NULL,
	[IdRol] [int] NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTA]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTA](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Idcliente] [int] NULL,
	[TipoDocumento] [varchar](50) NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[DocumentoCliente] [varchar](50) NULL,
	[NombreCliente] [varchar](100) NULL,
	[MontoPago] [decimal](10, 2) NULL,
	[MontoCambio] [decimal](10, 2) NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]



GO



ALTER TABLE [dbo].[CATEGORIA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[CLIENTE] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[COMPRA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[DETALLE_COMPRA] ADD  DEFAULT ((0)) FOR [PrecioCompra]
GO
ALTER TABLE [dbo].[DETALLE_COMPRA] ADD  DEFAULT ((0)) FOR [PrecioVenta]
GO
ALTER TABLE [dbo].[DETALLE_COMPRA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[DETALLE_VENTA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[PedidoDetalles] ADD  CONSTRAINT [DF_PedidoDetalles_descuento]  DEFAULT ((0)) FOR [descuento]
GO
ALTER TABLE [dbo].[PERMISO] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((0)) FOR [PrecioCompra]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((0)) FOR [PrecioVenta]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[PROVEEDOR] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
TABLE [dbo].[ROL] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[USUARIO] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[VENTA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[AlertasInventario]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[AlertasVencimiento]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[AlertasVencimiento]  WITH CHECK ADD FOREIGN KEY([LoteId])
REFERENCES [dbo].[InventarioLotes] ([Id])
GO
ALTER TABLE [dbo].[AnalisisVentas]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[VENTA] ([IdVenta])
GO
ALTER TABLE [dbo].[CLIENTE]  WITH CHECK ADD FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[DIRECCION] ([IdDireccion])
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[PROVEEDOR] ([IdProveedor])
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([IdUsuario])
GO
ALTER TABLE [dbo].[ComprasOrdenes]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[PROVEEDOR] ([IdProveedor])
GO
ALTER TABLE [dbo].[ControlCalidad]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[ControlPagos]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[VENTA] ([IdVenta])
GO
ALTER TABLE [dbo].[ControlProduccion]  WITH CHECK ADD FOREIGN KEY([OrdenProduccionId])
REFERENCES [dbo].[OrdenesProduccion] ([Id])
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[CLIENTE] ([IdCliente])
GO
ALTER TABLE [dbo].[DETALLE_COMPRA]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[COMPRA] ([IdCompra])
GO
ALTER TABLE [dbo].[DETALLE_COMPRA]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[VENTA] ([IdVenta])
GO
ALTER TABLE [dbo].[DetallePedidos]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DetallePedidos]  WITH CHECK ADD FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([Id])
GO
ALTER TABLE [dbo].[DevolucionesClientes]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[CLIENTE] ([IdCliente])
GO
ALTER TABLE [dbo].[DevolucionesClientes]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DevolucionesClientesProcesadas]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[CLIENTE] ([IdCliente])
GO
ALTER TABLE [dbo].[DevolucionesClientesProcesadas]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DevolucionesProveedores]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[PROVEEDOR] ([IdProveedor])
GO
ALTER TABLE [dbo].[DevolucionesProveedores]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[DIRECCION] ([IdDireccion])
GO
ALTER TABLE [dbo].[Entregas]  WITH CHECK ADD FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([Id])
GO
ALTER TABLE [dbo].[EtiquetadoEmpaque]  WITH CHECK ADD FOREIGN KEY([OrdenProduccionId])
REFERENCES [dbo].[OrdenesProduccion] ([Id])
GO
ALTER TABLE [dbo].[Facturacion]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[VENTA] ([IdVenta])
GO
ALTER TABLE [dbo].[Finanzas]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[COMPRA] ([IdCompra])
GO
ALTER TABLE [dbo].[GestionComercial]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[VENTA] ([IdVenta])
GO
ALTER TABLE [dbo].[Historial_Cambios]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([IdUsuario])
GO
ALTER TABLE [dbo].[Impuestos]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[COMPRA] ([IdCompra])
GO
ALTER TABLE [dbo].[Incentivos]  WITH CHECK ADD FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleados] ([Id])
GO
ALTER TABLE [dbo].[InformacionEmpleados]  WITH CHECK ADD FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleados] ([Id])
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[InventarioLotes]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[Lotes]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD FOREIGN KEY([RecursosHumanosId])
REFERENCES [dbo].[RecursosHumanos] ([Id])
GO
ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD FOREIGN KEY([ProduccionId])
REFERENCES [dbo].[Produccion] ([Id])
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[CLIENTE] ([IdCliente])
GO
ALTER TABLE [dbo].[PERMISO]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[ROL] ([IdRol])
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CATEGORIA] ([IdCategoria])
GO
ALTER TABLE [dbo].[Promociones]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[PROVEEDOR]  WITH CHECK ADD FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[DIRECCION] ([IdDireccion])
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[ROL] ([IdRol])
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD FOREIGN KEY([Idcliente])
REFERENCES [dbo].[CLIENTE] ([IdCliente])
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([IdUsuario])
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProduccionMensual]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerProduccionMensual]
AS
BEGIN
    SELECT
        YEAR(FechaRegistro) AS Anio,
        MONTH(FechaRegistro) AS Mes,
        SUM(Cantidad) AS CantidadTotal
    FROM
        DETALLE_VENTA DV
    GROUP BY
        YEAR(FechaRegistro),
        MONTH(FechaRegistro)
    ORDER BY
        Anio, Mes;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProductosMasVendidos]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerProductosMasVendidos]
AS
BEGIN
    SELECT TOP 5
        P.Nombre,
        SUM(DV.Cantidad) AS CantidadVendida
    FROM
        DETALLE_VENTA DV
    INNER JOIN
        PRODUCTO P ON DV.IdProducto = P.IdProducto
    GROUP BY
        P.Nombre
    ORDER BY
        CantidadVendida DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarCategoria]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[sp_EditarCategoria](
@IdCategoria int,
@Descripcion varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion =@Descripcion and IdCategoria != @IdCategoria)
		update CATEGORIA set
		Descripcion = @Descripcion,
		Estado = @Estado
		where IdCategoria = @IdCategoria
	ELSE
	begin
		SET @Resultado = 0
		set @Mensaje = 'No se puede repetir la descripcion de una categoria'
	end

end

GO
/****** Object:  StoredProcedure [dbo].[sp_EditarDireccion]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_EditarDireccion](
	@IdDireccion int OUTPUT,
	@Pais varchar(100),
	@Provincia varchar(100),
	@Ciudad varchar(100),
	@Sector varchar(100),
	@Calle varchar(100),
	@CodigoPostal varchar(100),
    @Estado bit,    
	@DireccionActualizada BIT OUTPUT, -- Agregamos un parámetro de salida para indicar si se actualizó la dirección
	@Resultado int output,
	@Mensaje varchar(500) output
)
as
begin

    SET @DireccionActualizada = 0;
    -- Verificar si la dirección necesita actualización
    IF EXISTS (
        SELECT 1 FROM DIRECCION
        WHERE IdDireccion = @IdDireccion AND
            (Pais <> @Pais OR Provincia <> @Provincia OR Ciudad <> @Ciudad OR Sector <> @Sector OR Calle <> @Calle
            OR CodigoPostal <> @CodigoPostal OR Estado <> @Estado)
    )
    BEGIN

		update DIRECCION set
		Pais = @Pais,
		Provincia = @Provincia,
		Ciudad = @Ciudad,
		Sector = @Sector,
		Calle = @Calle,
		CodigoPostal = @CodigoPostal,
		Estado = @Estado
		where IdDireccion = @IdDireccion
		SET @DireccionActualizada = 1;
        SET @Mensaje = 'Dirección actualizada correctamente.';
    END
    ELSE
    BEGIN
        SET @DireccionActualizada = 0;
        SET @Mensaje = 'No se realizaron cambios en la dirección.';
    END;

end

GO
/****** Object:  StoredProcedure [dbo].[SP_EDITARUSUARIO]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[SP_EDITARUSUARIO](
@IdUsuario int,
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(100),
@Clave varchar(100),
@IdRol int,
@Estado bit,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''


	if not exists(select * from USUARIO where Documento = @Documento and idusuario != @IdUsuario)
	begin
		update  usuario set
		Documento = @Documento,
		NombreCompleto = @NombreCompleto,
		Correo = @Correo,
		Clave = @Clave,
		IdRol = @IdRol,
		Estado = @Estado
		where IdUsuario = @IdUsuario

		set @Respuesta = 1
		
	end
	else
		set @Mensaje = 'No se puede repetir el documento para más de un usuario'


end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_EliminarCategoria](
@IdCategoria int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (
	 select *  from CATEGORIA c
	 inner join PRODUCTO p on p.IdCategoria = c.IdCategoria
	 where c.IdCategoria = @IdCategoria
	)
	begin
	 delete top(1) from CATEGORIA where IdCategoria = @IdCategoria
	end
	ELSE
	begin
		SET @Resultado = 0
		set @Mensaje = 'La categoria se encuentara relacionada a un producto'
	end

end

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCliente]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarCliente](
    @IdCliente INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1

    -- Verificar si el cliente tiene ventas asociadas
    IF NOT EXISTS (
        SELECT 1 FROM VENTA WHERE IdCliente = @IdCliente
    )
    BEGIN
        DECLARE @IdDireccion INT

        -- Obtener la IdDireccion del cliente
        SELECT @IdDireccion = IdDireccion FROM CLIENTE WHERE IdCliente = @IdCliente

        -- Eliminar el cliente
        DELETE FROM CLIENTE WHERE IdCliente = @IdCliente

        -- Eliminar la dirección si existe
        IF @IdDireccion IS NOT NULL
        BEGIN
            DELETE FROM DIRECCION WHERE IdDireccion = @IdDireccion
        END
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'El cliente se encuentra relacionado a una venta'
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarDireccion]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_EliminarDireccion](
@IdDireccion int
)
as
begin

	 delete top(1) from DIRECCION where IdDireccion = @IdDireccion

end

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarEmpleado]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_EliminarEmpleado](
    @IdEmpleado INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1

    BEGIN
        DECLARE @IdDireccion INT

        -- Obtener la IdDireccion del proveedor
        SELECT @IdDireccion = IdDireccion FROM Empleados WHERE Id = @IdEmpleado

        -- Eliminar el proveedor
        DELETE FROM Empleados WHERE Id = @IdEmpleado

        -- Eliminar la dirección si existe
        IF @IdDireccion IS NOT NULL
        BEGIN
            DELETE FROM DIRECCION WHERE IdDireccion = @IdDireccion
        END
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarProducto]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_EliminarProducto](
@IdProducto int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''
	declare @pasoreglas bit = 1

	IF EXISTS (SELECT * FROM DETALLE_COMPRA dc 
	INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto
	WHERE p.IdProducto = @IdProducto
	)
	BEGIN
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una COMPRA\n' 
	END

	IF EXISTS (SELECT * FROM DETALLE_VENTA dv
	INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
	WHERE p.IdProducto = @IdProducto
	)
	BEGIN
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una VENTA\n' 
	END

	if(@pasoreglas = 1)
	begin
		delete from PRODUCTO where IdProducto = @IdProducto
		set @Respuesta = 1 
	end

end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarProveedor]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EliminarProveedor](
    @IdProveedor INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1

    -- Verificar si el PROVEEDOR tiene compras asociadas
    IF NOT EXISTS (
        SELECT 1 FROM COMPRA WHERE IdProveedor = @IdProveedor
    )
    BEGIN
        DECLARE @IdDireccion INT

        -- Obtener la IdDireccion del proveedor
        SELECT @IdDireccion = IdDireccion FROM PROVEEDOR WHERE IdProveedor = @IdProveedor

        -- Eliminar el proveedor
        DELETE FROM PROVEEDOR WHERE IdProveedor = @IdProveedor

        -- Eliminar la dirección si existe
        IF @IdDireccion IS NOT NULL
        BEGIN
            DELETE FROM DIRECCION WHERE IdDireccion = @IdDireccion
        END
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'El proveedor se encuentra relacionado a una compra'
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINARUSUARIO]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[SP_ELIMINARUSUARIO](
@IdUsuario int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''
	declare @pasoreglas bit = 1

	IF EXISTS (SELECT * FROM COMPRA C 
	INNER JOIN USUARIO U ON U.IdUsuario = C.IdUsuario
	WHERE U.IDUSUARIO = @IdUsuario
	)
	BEGIN
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una COMPRA\n' 
	END

	IF EXISTS (SELECT * FROM VENTA V
	INNER JOIN USUARIO U ON U.IdUsuario = V.IdUsuario
	WHERE U.IDUSUARIO = @IdUsuario
	)
	BEGIN
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una VENTA\n' 
	END

	if(@pasoreglas = 1)
	begin
		delete from USUARIO where IdUsuario = @IdUsuario
		set @Respuesta = 1 
	end

end

GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarCliente]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_ModificarCliente](
    @IdCliente INT,
    @Documento VARCHAR(50),
    @NombreCompleto VARCHAR(50),
    @Correo VARCHAR(50),
    @Telefono VARCHAR(50),
    @Estado BIT,
    @IdDireccion INT,
    @Pais VARCHAR(100),
    @Provincia VARCHAR(100),
    @Ciudad VARCHAR(100),
    @Sector VARCHAR(100),
    @Calle VARCHAR(100),
    @CodigoPostal VARCHAR(100),
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1
    DECLARE @IDPERSONA INT 

    IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento AND IdCliente != @IdCliente)
    BEGIN
        UPDATE CLIENTE SET
            Documento = @Documento,
            NombreCompleto = @NombreCompleto,
            Correo = @Correo,
            Telefono = @Telefono,
            Estado = @Estado
        WHERE IdCliente = @IdCliente


		    update Direccion set
            Pais = @Pais,
            Provincia = @Provincia,
            Ciudad = @Ciudad,
            Sector = @Sector,
            Calle = @Calle,
            CodigoPostal = @CodigoPostal,
            Estado = @Estado
			where IdDireccion = @IdDireccion
	END
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'El número de documento ya existe'
    END
    SET @Mensaje = 'Cliente actualizado'

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarEmpleado]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ModificarEmpleado](
@IdEmpleado int,
@Documento varchar(50),
@Nombre varchar(100),
@Correo varchar(50),
@Telefono varchar(50),
@Cargo varchar(100),
@Salario decimal(10,2),
@Estado bit,
@IdDireccion INT,
@Pais VARCHAR(100),
@Provincia VARCHAR(100), 
@Ciudad VARCHAR(100),
@Sector VARCHAR(100),
@Calle VARCHAR(100),
@CodigoPostal VARCHAR(100),
@Resultado bit output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 1
	DECLARE @IDPERSONA INT 
	IF NOT EXISTS (SELECT * FROM Empleados WHERE Documento = @Documento and Id != @IdEmpleado)
	begin
		update Empleados set
		Nombre = @Nombre,
		Documento = @Documento,
		Correo = @Correo,
		Telefono = @Telefono,
		Cargo = @Cargo,
		Salario = @Salario,
		Estado = @Estado
		where Id = @IdEmpleado

		    update Direccion set
            Pais = @Pais,
            Provincia = @Provincia,
            Ciudad = @Ciudad,
            Sector = @Sector,
            Calle = @Calle,
            CodigoPostal = @CodigoPostal,
            Estado = @Estado
			where IdDireccion = @IdDireccion
        
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'El número de documento ya existe'
    END
    SET @Mensaje = 'Empleado actualizado'

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarProducto]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_ModificarProducto](
@IdProducto int,
@Codigo varchar(20),
@Nombre varchar(30),
@Descripcion varchar(30),
@IdCategoria int,
@Estado bit,
@UnidadMedida varchar (50),
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE codigo = @Codigo and IdProducto != @IdProducto)
		
		update PRODUCTO set
		codigo = @Codigo,
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		IdCategoria = @IdCategoria,
		Estado = @Estado,
		UnidadMedida= @UnidadMedida
		where IdProducto = @IdProducto
	ELSE
	begin
		SET @Resultado = 0
		SET @Mensaje = 'Ya existe un producto con el mismo codigo' 
	end
end


GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarProveedor]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ModificarProveedor](
    @IdProveedor int,
    @Documento varchar(50),
    @RazonSocial varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @IdDireccion INT,
    @Pais VARCHAR(100),
    @Provincia VARCHAR(100), 
    @Ciudad VARCHAR(100),
    @Sector VARCHAR(100),
    @Calle VARCHAR(100),
    @CodigoPostal VARCHAR(100),
    @DiasEntrega int, -- Nuevo parámetro agregado
    @Resultado bit output,
    @Mensaje varchar(500) output
) as
begin
    SET @Resultado = 1
    IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento and IdProveedor != @IdProveedor)
    begin
        update PROVEEDOR set
            Documento = @Documento,
            RazonSocial = @RazonSocial,
            Correo = @Correo,
            Telefono = @Telefono,
            Estado = @Estado,
            DiasEntrega = @DiasEntrega -- Actualizar DiasEntrega
        where IdProveedor = @IdProveedor

        update Direccion set
            Pais = @Pais,
            Provincia = @Provincia,
            Ciudad = @Ciudad,
            Sector = @Sector,
            Calle = @Calle,
            CodigoPostal = @CodigoPostal,
            Estado = @Estado
        where IdDireccion = @IdDireccion
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'El número de documento ya existe'
    END
END
GO

/* ---------- PROCEDIMIENTOS PARA CATEGORIA -----------------*/

create PROC [dbo].[SP_RegistrarCategoria](
@Descripcion varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
	begin
		insert into CATEGORIA(Descripcion,Estado) values (@Descripcion,@Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	ELSE
		set @Mensaje = 'No se puede repetir la descripcion de una categoria'
	
end


GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarCliente]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* ---------- PROCEDIMIENTOS PARA CLIENTE -----------------*/

CREATE PROC [dbo].[sp_RegistrarCliente](
@Documento varchar(50),
@NombreCompleto varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Estado bit,
@Pais varchar(100),
@Provincia varchar(100),
@Ciudad varchar(100),
@Sector varchar(100),
@Calle varchar(100),
@CodigoPostal varchar(100),
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	DECLARE @IDPERSONA INT, @IdDireccion int;
	IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento)
	begin

		exec [dbo].[SP_RegistrarDireccion] @Pais, @Provincia, @Ciudad, @Sector, @Calle, @CodigoPostal, @Estado,  @IdDireccion OUTPUT
		
		insert into CLIENTE(Documento,NombreCompleto,Correo,Telefono,Estado, IdDireccion) values (
		@Documento,@NombreCompleto,@Correo,@Telefono,@Estado, @IdDireccion)

		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'El numero de documento ya existe'
	set @Mensaje = 'Cliente registrado'
end

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarCompra]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_RegistrarCompra](
@IdUsuario int,
@IdProveedor int,
@TipoDocumento varchar(500),
@NumeroDocumento varchar(500),
@MontoTotal decimal(18,2),
@DetalleCompra [EDetalle_Compra] READONLY,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	
	begin try

		declare @idcompra int = 0
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction registro

		insert into COMPRA(IdUsuario,IdProveedor,TipoDocumento,NumeroDocumento,MontoTotal)
		values(@IdUsuario,@IdProveedor,@TipoDocumento,@NumeroDocumento,@MontoTotal)

		set @idcompra = SCOPE_IDENTITY()

		insert into DETALLE_COMPRA(IdCompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal,UnidadMedida)
		select @idcompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal,UnidadMedida from @DetalleCompra


		update p set p.Stock = p.Stock + dc.Cantidad, 
		p.PrecioCompra = dc.PrecioCompra,
		p.PrecioVenta = dc.PrecioVenta
		from PRODUCTO p
		inner join @DetalleCompra dc on dc.IdProducto= p.IdProducto

		commit transaction registro


	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch

end


GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarDireccion]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_RegistrarDireccion](
	@Pais varchar(100),
	@Provincia varchar(100),
	@Ciudad varchar(100),
	@Sector varchar(100),
	@Calle varchar(100),
	@CodigoPostal varchar(100),
    @Estado bit,
	@IdDireccion INT OUTPUT

)
as
begin

	insert into DIRECCION(Pais, Provincia, Ciudad, Sector, Calle, CodigoPostal, Estado)
	values (@Pais, @Provincia, @Ciudad, @Sector, @Calle, @CodigoPostal, @estado)
	
	-- Obtener el ID de la dirección insertada
    SET @IdDireccion = SCOPE_IDENTITY();

end
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarEmpleado]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* ---------- PROCEDIMIENTOS PARA EMPLEADO -----------------*/

CREATE PROC [dbo].[sp_RegistrarEmpleado](
@Nombre varchar(50),
@Cargo varchar(50),
@Salario varchar(50),
@Documento varchar(50),
@Telefono varchar(50),
@Correo varchar(50),
@Estado bit,
@Pais varchar(100),
@Provincia varchar(100),
@Ciudad varchar(100),
@Sector varchar(100),
@Calle varchar(100),
@CodigoPostal varchar(100),
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	DECLARE @IDPERSONA INT,  @IdDireccion int;
	IF NOT EXISTS (SELECT * FROM Empleados WHERE Documento = @Documento)
	begin

		exec [dbo].[SP_RegistrarDireccion] @Pais, @Provincia, @Ciudad, @Sector, @Calle, @CodigoPostal, @Estado,  @IdDireccion OUTPUT

		INSERT INTO Empleados (Nombre, Cargo, Salario, IdDireccion, Documento, Telefono, Correo, Estado)
		VALUES (@Nombre, @Cargo, @Salario, @IdDireccion, @Documento, @Telefono, @Correo, @Estado);

		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'El numero de documento ya existe'
	set @Mensaje = 'Empleado registrado'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProduccion]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Crea el procedimiento almacenado para obtener produccion 

CREATE PROCEDURE [dbo].[sp_RegistrarProduccion]
    @FechaProduccion DATE,
    @CantidadCheddar INT,
    @CantidadDanes INT,
    @UnidadMedidaGenerica VARCHAR(50),
    @CantidadTotal INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    BEGIN TRY

        DECLARE @idProduccion INT = 0;
        SET @Resultado = 1;
        SET @Mensaje = '';

        BEGIN TRANSACTION Produccion;

        -- Inserta la producción general en la tabla ProduccionQueso
        INSERT INTO ProduccionQueso (FechaProduccion, CantidadCheddar, CantidadDanes, UnidadMedidaGenerica, CantidadTotal)
        VALUES (@FechaProduccion, @CantidadCheddar, @CantidadDanes, @UnidadMedidaGenerica, @CantidadTotal);

        SET @idProduccion = SCOPE_IDENTITY();

        -- Aquí podrías añadir más lógica si lo necesitas. 
        -- Por ejemplo, actualizar alguna otra tabla relacionada con los tipos de queso

        COMMIT TRANSACTION Produccion;

    END TRY
    BEGIN CATCH
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
        ROLLBACK TRANSACTION Produccion;
    END CATCH
END;


GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProducto]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_RegistrarProducto](
@Codigo varchar(20),
@Nombre varchar(30),
@Descripcion varchar(30),
@IdCategoria int,
@Estado bit,
@UnidadMedida varchar (50),
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM producto WHERE Codigo = @Codigo)
	begin
		insert into producto(Codigo,Nombre,Descripcion,IdCategoria,Estado,UnidadMedida) values (@Codigo,@Nombre,@Descripcion,@IdCategoria,@Estado,@UnidadMedida)
		set @Resultado = SCOPE_IDENTITY()
	end
	ELSE
	 SET @Mensaje = 'Ya existe un producto con el mismo codigo' 
	
end


GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProveedor]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ---------- PROCEDIMIENTOS PARA PROVEEDOR -----------------*/

CREATE PROC [dbo].[sp_RegistrarProveedor](
    @Documento varchar(50),
    @RazonSocial varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @Pais varchar(100),
    @Provincia varchar(100),
    @Ciudad varchar(100),
    @Sector varchar(100),
    @Calle varchar(100),
    @CodigoPostal varchar(100),
    @DiasEntrega int, -- Nuevo parámetro agregado
    @Resultado int output,
    @Mensaje varchar(500) output
) as
begin
    SET @Resultado = 0
    DECLARE @IDPERSONA INT, @IdDireccion int;
    IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento)
    begin
        exec [dbo].[SP_RegistrarDireccion] @Pais, @Provincia, @Ciudad, @Sector, @Calle, @CodigoPostal, @Estado, @IdDireccion OUTPUT

        insert into PROVEEDOR(Documento, RazonSocial, Correo, Telefono, Estado, IdDireccion, DiasEntrega) values (
        @Documento, @RazonSocial, @Correo, @Telefono, @Estado, @IdDireccion, @DiasEntrega) -- Incluyendo DiasEntrega

        set @Resultado = SCOPE_IDENTITY()
    end
    else
        set @Mensaje = 'El numero de documento ya existe'
    set @Mensaje = 'Proveedor registrado'
end
GO





create PROC [dbo].[SP_REGISTRARUSUARIO](
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(100),
@Clave varchar(100),
@IdRol int,
@Estado bit,
@IdUsuarioResultado int output,
@Mensaje varchar(500) output
)
as
begin
	set @IdUsuarioResultado = 0
	set @Mensaje = ''


	if not exists(select * from USUARIO where Documento = @Documento)
	begin
		insert into usuario(Documento,NombreCompleto,Correo,Clave,IdRol,Estado) values
		(@Documento,@NombreCompleto,@Correo,@Clave,@IdRol,@Estado)

		set @IdUsuarioResultado = SCOPE_IDENTITY()
		
	end
	else
		set @Mensaje = 'No se puede repetir el documento para más de un usuario'


end

GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteCompras]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_ReporteCompras] (
    @fechainicio VARCHAR(10),
    @fechafin VARCHAR(10),
    @idproveedor INT
)
AS
BEGIN
    SET DATEFORMAT dmy;

    SELECT 
        CONVERT(CHAR(10), c.FechaRegistro, 103) AS [FechaRegistro],
        c.TipoDocumento,
        c.NumeroDocumento,
        c.MontoTotal,
        u.NombreCompleto AS [UsuarioRegistro],
        pr.Documento AS [DocumentoProveedor],
        pr.RazonSocial,
        p.Codigo AS [CodigoProducto],
        p.Nombre AS [NombreProducto],
        ca.Descripcion AS [Categoria],
        dc.PrecioCompra,
        dc.PrecioVenta,
        dc.Cantidad,
        dc.MontoTotal AS [SubTotal],
		dc.UnidadMedida
    FROM COMPRA c
    INNER JOIN USUARIO u ON u.IdUsuario = c.IdUsuario
    INNER JOIN PROVEEDOR pr ON pr.IdProveedor = c.IdProveedor
    INNER JOIN DETALLE_COMPRA dc ON dc.IdCompra = c.IdCompra
    INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto
    INNER JOIN CATEGORIA ca ON ca.IdCategoria = p.IdCategoria
    WHERE CONVERT(DATE, c.FechaRegistro) BETWEEN @fechainicio AND @fechafin
        AND (pr.IdProveedor = @idproveedor OR @idproveedor = 0);
END;

 

 exec  sp_ReporteProduccion '22/8/2023','22/8/2023'



GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteProduccion]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- reporte produccion 
CREATE PROC [dbo].[sp_ReporteProduccion](
    @fechainicio VARCHAR(10),
    @fechafin VARCHAR(10)
)
AS
BEGIN
    SET DATEFORMAT dmy;
    
    SELECT 
        CONVERT(CHAR(10), pq.FechaProduccion, 103) AS [FechaProduccion],
        p.Nombre AS [Nombre],
        p.Stock AS [Stock],
        pq.CantidadCheddar,
        pq.CantidadDanes,
        pq.UnidadMedidaGenerica,
        pq.CantidadTotal
    FROM ProduccionQueso pq
    INNER JOIN PRODUCTO p ON pq.ID = p.IdProducto
    WHERE CONVERT(DATE, pq.FechaProduccion) BETWEEN @fechainicio AND @fechafin;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteVentas]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


 CREATE PROC [dbo].[sp_ReporteVentas](
 @fechainicio varchar(10),
 @fechafin varchar(10)
 )
 as
 begin
 SET DATEFORMAT dmy;  
 select 
 convert(char(10),v.FechaRegistro,103)[FechaRegistro],v.TipoDocumento,v.NumeroDocumento,v.MontoTotal,
 u.NombreCompleto[UsuarioRegistro],
 v.DocumentoCliente,v.NombreCliente,
 p.Codigo[CodigoProducto],p.Nombre[NombreProducto],ca.Descripcion[Categoria],dv.PrecioVenta,dv.Cantidad,dv.SubTotal, dv.itbis,dv.Valortotal,dv.UnidadesMedida,dv.Galones_a_Litro,dv.Bloque_a_Libra
 from VENTA v
 inner join USUARIO u on u.IdUsuario = v.IdUsuario
 inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
 inner join PRODUCTO p on p.IdProducto = dv.IdProducto
 inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
 where CONVERT(date,v.FechaRegistro) between @fechainicio and @fechafin
end
GO
/****** Object:  StoredProcedure [dbo].[usp_RegistrarVenta]    Script Date: 22/08/2023 02:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_RegistrarVenta](
    @IdUsuario int,
    @TipoDocumento varchar(500),
    @NumeroDocumento varchar(500),
    @DocumentoCliente varchar(500),
    @NombreCliente varchar(500),
    @MontoPago decimal(18,2),
    @MontoCambio decimal(18,2),
    @MontoTotal decimal(18,2),
    @DetalleVenta [EDetalle_Venta] READONLY, 
    @Resultado bit OUTPUT,
    @Mensaje varchar(500) OUTPUT
)
AS
BEGIN
	
    BEGIN TRY

        DECLARE @idventa int = 0
        SET @Resultado = 1
        SET @Mensaje = ''

        BEGIN TRANSACTION registro

        INSERT INTO VENTA(IdUsuario, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente, MontoPago, MontoCambio, MontoTotal)
        VALUES(@IdUsuario, @TipoDocumento, @NumeroDocumento, @DocumentoCliente, @NombreCliente, @MontoPago, @MontoCambio, @MontoTotal)

        SET @idventa = SCOPE_IDENTITY()

        INSERT INTO DETALLE_VENTA(IdVenta, IdProducto, PrecioVenta, Cantidad,   SubTotal, itbis, Valortotal ,UnidadesMedida,Galones_a_Litro, Bloque_a_Libra )
        SELECT @idventa, IdProducto, PrecioVenta, Cantidad , SubTotal, itbis, Valortotal , UnidadesMedida,Galones_a_Litro, Bloque_a_Libra  FROM  @DetalleVenta

        COMMIT TRANSACTION registro

    END TRY
    BEGIN CATCH
        SET @Resultado = 0
        SET @Mensaje = ERROR_MESSAGE()
        ROLLBACK TRANSACTION registro
    END CATCH

END

GO




/****************** INSERTAMOS REGISTROS A LAS TABLAS ******************/
/*---------------------------------------------------------------------*/

GO

 insert into rol (Descripcion)
 values('ADMINISTRADOR')

 GO

  insert into rol (Descripcion)
 values('EMPLEADO')

 GO

 insert into USUARIO(Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
 values 
 ('101010','ADMIN','@GMAIL.COM','123',1,1)

 GO




 insert into USUARIO(Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
 values 
 ('0210','ANGEL','@GMAIL.COM','0210',1,1)

 GO

 
 TRUNCATE TABLE permiso;
insert into PERMISO(IdRol,NombreMenu) values
  (1,'mnegocio'),
  (1,'menuinicio'),
  (1,'menusuario'),
  (1,'menucategoria'),
  (1,'menuproducto'),
  (1,'menuinventario'),
  (1,'menuventa'),
  (1,'menucompra'),
  (1,'menucliente'),
  (1,'menuproveedores'),
  (1,'menureporte'),
  (1,'menuempleado'),
  (1,'menugrafica'),
  (1,'menusacercade'),
  (1,'menusalir'),
  (1,'menuproduccion')

  GO

  insert into PERMISO(IdRol,NombreMenu) values
  (2,'menuinicio'),
  (2,'menuventa'),
  (2,'menucategoria'),
  (2,'menuproducto'),
  (2,'control'),
  (2,'menureporte'),
  (2,'menugrafica'),
  (2,'menusacercade'),
  (2,'menusalir'),
  (2,'menuproduccion'),
  (2,'menuinventario')
  GO



  insert into categoria (Descripcion,Estado) values ('Lacteos',1)
  insert into categoria (Descripcion,Estado) values ('Producción',1)

  

  insert into NEGOCIO(IdNegocio,Nombre,RUC,Direccion,Logo) values
  (1,'Codigo Estudiante','20202020','av. codigo estudiante 123',null)


  INSERT INTO [dbo].[PRODUCTO] (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioCompra, PrecioVenta, Estado, FechaRegistro, UnidadMedida) VALUES
('1010', 'Leche', 'leche para producir y vender', 1, 436, 20.00, 28.00, 1, '2023-08-22 16:09:05.180', 'Litro'),
('1011', 'Cuajo', 'producir queso', 2, 78, 40.00, 40.00, 1, '2023-08-22 16:11:08.717', 'Libra'),
('1012', 'Cultivo', 'producir queso', 2, 69, 40.00, 40.00, 1, '2023-08-22 16:12:46.757', 'Saco'),
('1013', 'Calcio', 'producir queso', 2, 68, 40.00, 40.00, 1, '2023-08-22 16:13:12.197', 'Cubeta'),
('1014', 'Catalza', 'producir queso', 2, 67, 40.00, 40.00, 1, '2023-08-22 16:13:25.863', 'Cubeta'),
('1015', 'Catibar', 'producir queso', 1, 69, 40.00, 40.00, 1, '2023-08-22 16:14:29.610', 'Cubeta'),
('1016', 'Sal', 'producir queso', 2, 77, 250.00, 250.00, 1, '2023-08-22 16:14:54.583', 'Saco'),
('1017', 'Colorante', 'producir queso', 2, 68, 40.00, 40.00, 1, '2023-08-22 16:15:24.533', 'Litro'),
('1018', 'Peroxido', 'producir queso', 2, 77, 40.00, 40.00, 1, '2023-08-22 16:15:54.870', 'Litro'),
('1021', 'Queso Danés', 'queso', 1, 4, 140.00, 160.00, 1, '2023-08-22 16:30:49.860', 'Libra');



DECLARE @Resultado INT
DECLARE @Mensaje VARCHAR(500)
EXEC [dbo].[sp_RegistrarCliente]
    @Documento = '123456779',               
    @NombreCompleto = 'Juan Pérez',        
    @Correo = 'juan@example.com',           
    @Telefono = '555-123-4567',             
    @Estado = 1,                            
    @Pais = 'República Dominicana',                       
    @Provincia = 'Santiago',               
    @Ciudad = 'Santiago de los caballeros',                  
    @Sector = 'Villa verde',                 
    @Calle = 'Calle 10',           
    @CodigoPostal = '51000',                
    @Resultado = @Resultado OUTPUT,
    @Mensaje = @Mensaje OUTPUT

	
select * from recetas

CREATE TABLE Recetas (
    Id INT PRIMARY KEY IDENTITY,
    NombreReceta NVARCHAR(255),
    Productos NVARCHAR(MAX),
    Preparacion NVARCHAR(MAX),
    Tiempo NVARCHAR(50),
    Imagen VARBINARY(MAX)
);



CREATE PROCEDURE GuardarReceta
    @NombreReceta VARCHAR(255),
    @Productos VARCHAR(MAX),
    @Preparacion TEXT,
    @Tiempo VARCHAR(50),
    @Imagen VARBINARY(MAX),
    @CantidadProduccion INT -- Agregar este nuevo parámetro
AS
BEGIN
    IF EXISTS (SELECT * FROM Recetas WHERE NombreReceta = @NombreReceta)
    BEGIN
        -- Actualiza la receta existente
        UPDATE Recetas
        SET Productos = @Productos,
            Preparacion = @Preparacion,
            Tiempo = @Tiempo,
            Imagen = @Imagen,
            CantidadProduccion = @CantidadProduccion -- Incluir en la actualización
        WHERE NombreReceta = @NombreReceta;
    END
    ELSE
    BEGIN
        -- Inserta una nueva receta
        INSERT INTO Recetas (NombreReceta, Productos, Preparacion, Tiempo, Imagen, CantidadProduccion)
        VALUES (@NombreReceta, @Productos, @Preparacion, @Tiempo, @Imagen, @CantidadProduccion); -- Incluir en el insert
    END
END;




CREATE TABLE ProduccionesAplazadas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreReceta NVARCHAR(100),
    Cantidad INT,
    FechaHoraProgramada DATETIME,
    FueManejada BIT
);
CREATE PROCEDURE sp_InsertarProduccionAplazada
    @NombreReceta NVARCHAR(100),
    @Cantidad INT,
    @FechaHoraProgramada DATETIME
AS
BEGIN
    INSERT INTO ProduccionesAplazadas (NombreReceta, Cantidad, FechaHoraProgramada, FueManejada)
    VALUES (@NombreReceta, @Cantidad, @FechaHoraProgramada, 0)
END

drop table ProduccionesAplazadas

CREATE PROCEDURE sp_ActualizarProduccionAplazada
    @Id INT,
    @Cantidad INT = NULL,
    @FechaHoraProgramada DATETIME = NULL,
    @FueManejada BIT = NULL
AS
BEGIN
    UPDATE ProduccionesAplazadas
    SET 
        Cantidad = ISNULL(@Cantidad, Cantidad),
        FechaHoraProgramada = ISNULL(@FechaHoraProgramada, FechaHoraProgramada),
        FueManejada = ISNULL(@FueManejada, FueManejada)
    WHERE Id = @Id
END




CREATE PROCEDURE sp_ListarProduccionesAplazadas
AS
BEGIN
    SELECT * FROM ProduccionesAplazadas
    WHERE FueManejada = 0
    ORDER BY FechaHoraProgramada
END


CREATE TABLE PedidosAplazados (
    IdPedidoAplazado INT PRIMARY KEY IDENTITY(1,1),
    NombreReceta NVARCHAR(100),
    Cantidad INT,
    FechaHoraProgramada DATETIME,
    FueManejada BIT
);
CREATE PROCEDURE spAgregarPedidoAplazado
    @NombreReceta NVARCHAR(100),
    @Cantidad INT,
    @FechaHoraProgramada DATETIME,
    @FueManejada BIT
AS
BEGIN
    INSERT INTO PedidosAplazados (NombreReceta, Cantidad, FechaHoraProgramada, FueManejada)
    VALUES (@NombreReceta, @Cantidad, @FechaHoraProgramada, @FueManejada);
END;
CREATE PROCEDURE spActualizarPedidoAplazado
    @IdPedidoAplazado INT,
    @NombreReceta NVARCHAR(100),
    @Cantidad INT,
    @FechaHoraProgramada DATETIME,
    @FueManejada BIT
AS
BEGIN
    UPDATE PedidosAplazados
    SET NombreReceta = @NombreReceta,
        Cantidad = @Cantidad,
        FechaHoraProgramada = @FechaHoraProgramada,
        FueManejada = @FueManejada
    WHERE IdPedidoAplazado = @IdPedidoAplazado;
END;
CREATE PROCEDURE spListarPedidosAplazados
AS
BEGIN
    SELECT * FROM PedidosAplazados;
END;




CREATE PROCEDURE sp_ActualizarPedidoAplazado
    @IdPedidoAplazado INT,
    @NombreReceta NVARCHAR(100) = NULL,
    @Cantidad INT = NULL,
    @FechaHoraProgramada DATETIME = NULL,
    @FueManejada BIT = NULL
AS
BEGIN
    UPDATE PedidosAplazados
    SET 
        NombreReceta = ISNULL(@NombreReceta, NombreReceta),
        Cantidad = ISNULL(@Cantidad, Cantidad),
        FechaHoraProgramada = ISNULL(@FechaHoraProgramada, FechaHoraProgramada),
        FueManejada = ISNULL(@FueManejada, FueManejada)
    WHERE IdPedidoAplazado = @IdPedidoAplazado
END




UPDATE PedidosAplazados
SET FueManejada = 1
