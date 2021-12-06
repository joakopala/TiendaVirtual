USE [TiendaVirtual]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Cp] [int] NULL,
	[IdProvincia] [int] NULL,
	[Valor] [int] NULL,
	[Zona] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[IdMenu] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Controlador] [nvarchar](100) NULL,
	[Accion] [nvarchar](100) NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuPermisos]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuPermisos](
	[IdPermiso] [int] NOT NULL,
	[IdMenu] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubMenu]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubMenu](
	[IdSubMenu] [int] IDENTITY(1,1) NOT NULL,
	[IdMenu] [int] NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Controlador] [nvarchar](100) NULL,
	[Accion] [nvarchar](100) NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSubMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellido] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Direccion] [nvarchar](500) NULL,
	[Clave] [nvarchar](100) NULL,
	[IdTipoUsuario] [int] NULL,
	[edad] [int] NULL,
	[Activo] [bit] NULL,
	[IdPermiso] [int] NULL,
	[FechaNacimiento] [datetime] NULL,
	[IdUsuarioLog] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios_Tipos]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios_Tipos](
	[IdTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [IdUsuarioLog]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [IdEstado]
GO
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincias] ([Id])
GO
ALTER TABLE [dbo].[MenuPermisos]  WITH CHECK ADD FOREIGN KEY([IdMenu])
REFERENCES [dbo].[Menu] ([IdMenu])
GO
ALTER TABLE [dbo].[MenuPermisos]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permisos] ([IdPermiso])
GO
ALTER TABLE [dbo].[SubMenu]  WITH CHECK ADD FOREIGN KEY([IdMenu])
REFERENCES [dbo].[Menu] ([IdMenu])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permisos] ([IdPermiso])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permisos] ([IdPermiso])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios_Tipos] FOREIGN KEY([IdTipoUsuario])
REFERENCES [dbo].[Usuarios_Tipos] ([IdTipoUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Usuarios_Tipos]
GO
/****** Object:  StoredProcedure [dbo].[SP_Menu_Listar]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SP_Menu_Listar]
as
select * from Menu
GO
/****** Object:  StoredProcedure [dbo].[SP_Menu_ListarPorUsuario]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Menu_ListarPorUsuario]
(
@IdUsuario int
)
as
begin

select m.* from usuarios u
inner join permisos p on p.idpermiso=u.idpermiso
inner join menupermisos mp on mp.idpermiso=p.idpermiso 
inner join menu m on m.IdMenu=mp.idmenu
where u.idUsuario=@IdUsuario

end
GO
/****** Object:  StoredProcedure [dbo].[SP_SubMenu_Listar]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SP_SubMenu_Listar]
as
select * from SubMenu
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_Actualizar]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_Usuarios_Actualizar](@idUsuario int,@Nombre nvarchar(200),@Apellido nvarchar(200),@Email nvarchar(200),@Direccion nvarchar(1000),@Clave nvarchar(200),@IdTipoUsuario int,@edad int,@Activo bit,@IdPermiso int)asbegin	update Usuarios 	set 	Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Direccion = @Direccion, 	Clave = @Clave, IdTipoUsuario = @IdTipoUsuario, edad = @edad, Activo=@Activo, IdPermiso=@IdPermiso	where IdUsuario = @IdUsuarioend
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_Buscar]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Usuarios_Buscar]
(
@Nombre nvarchar(200)=null,
@Apellido nvarchar(200)=null,
@Email nvarchar(200)=null,
@Direccion nvarchar(1000)=null,
@TipoUsuario nvarchar(1000)=null,
@edad int=null,
@FechaNacimientoDesde datetime='01/01/1900',
@FechaNacimientoHasta datetime='01/01/2300'
)
as
begin
select U.* from usuarios U
INNER JOIN Usuarios_Tipos UT
ON UT.IdTipoUsuario=U.IdTipoUsuario
	Where IdEstado=1
	and
	((@edad is null) OR (edad = @edad )) AND
	((@Apellido is null) OR (@Apellido = '') OR (Apellido LIKE  '%' + @Apellido + '%' )) AND
	((@Nombre is null) OR (@Nombre = '') OR (Nombre LIKE  '%' + @Nombre + '%' )) AND
	((@Direccion is null) OR (@Direccion = '') OR (Direccion LIKE  '%' + @Direccion + '%' )) AND
	((@Email is null) OR (@Email = '') OR (Email LIKE  '%' + @Email + '%' )) AND
	FechaNacimiento between @FechaNacimientoDesde and @FechaNacimientoHasta AND
	((@TipoUsuario is null) OR (@TipoUsuario = '') OR (UT.Descripcion LIKE  '%' + @TipoUsuario + '%' ))
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_CambiarEstado]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Usuarios_CambiarEstado](@Activo bit,@IdUsuario int)asbegin	update usuarios set Activo=@Activo	where IdUsuario = @IdUsuarioend
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_Eliminar]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Usuarios_Eliminar](@IdUsuario int)asbegin	delete Usuarios	where IdUsuario = @IdUsuarioend
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_Insertar]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Usuarios_Insertar]
(
@Nombre nvarchar(200),
@Apellido nvarchar(200),
@Email nvarchar(200),
@Direccion nvarchar(1000),
@Clave nvarchar(200),
@IdTipoUsuario int,
@Edad int,
@Activo bit=1,
@IdPermiso int,
@FechaNacimiento datetime
)
as
begin

insert into Usuarios (Nombre,Apellido,Email,Direccion,Clave,IdTipoUsuario,Edad,Activo,IdPermiso,FechaNacimiento)
values(@Nombre,@Apellido,@Email,@Direccion,@Clave,@IdTipoUsuario,@Edad,@Activo,@IdPermiso,@FechaNacimiento)

select @@IDENTITY

end
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_Listar]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Usuarios_Listar]
as
begin
	SET NOCOUNT ON;

	select * from usuarios
	Where IdEstado=1
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_ModificarEstado]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_Usuarios_ModificarEstado](@IdUsuario int,@IdEstado int)asbegin	update Usuarios	set IdEstado=@IdEstado	where IdUsuario = @IdUsuarioend
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_Obtener]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Usuarios_Obtener]
(
	@Email nvarchar(100),
	@Clave nvarchar(100)
)
as
begin
	SET NOCOUNT ON;

	select * from Usuarios
	where Email=@email and Clave=@clave
	and IdEstado=1
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_ObtenerPorEmail]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Usuarios_ObtenerPorEmail]
(
	@Email nvarchar(100)
)
as
begin
	SET NOCOUNT ON;

	select * from Usuarios
	where Email=@Email 
	and IdEstado=1
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_ObtenerPorId]    Script Date: 25/8/2021 20:29:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Usuarios_ObtenerPorId]
(
	@Id int
	)
as
begin
	SET NOCOUNT ON;

	select * from Usuarios
	where IdUsuario=@id
	and IdEstado=1
end
GO
