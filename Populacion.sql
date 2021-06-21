USE [GymTEC]
GO
--------------------------------------------------------------------------- Empleados--------------------------------------------------------------
create procedure Insertar_Empleado
	@Cedula int ,
	@Correo varchar(50) ,
	@Salario int ,
	@Provincia varchar(20),
	@Distrito varchar(20) ,
	@Canton varchar(20),
	@Nombre varchar(30),
	@Apellido1 varchar(30),
	@Apellido2 varchar(30),
	@Password varchar(50)
	as
	Begin
		INSERT INTO [dbo].[Empleado]([Cedula],[Correo],[Salario],[Provincia],[Distrito],[Canton],[Nombre],[Apellido1],[Apellido2],[Password])
     VALUES
           (@Cedula,@Correo,@Salario,@Provincia,@Distrito,@Canton,@Nombre,@Apellido1,@Apellido2,@Password)
		
		END
	GO

create procedure Borrar_Empleado
	@Cedula int 
	as
	Begin
		DELETE FROM [dbo].[Empleado] WHERE [dbo].Empleado.Cedula = @Cedula		
		END
	GO

create procedure Actualizar_Empleado
	@Cedula int ,
	@Correo varchar(50) ,
	@Salario int ,
	@Provincia varchar(20),
	@Distrito varchar(20) ,
	@Canton varchar(20),
	@Nombre varchar(30),
	@Apellido1 varchar(30),
	@Apellido2 varchar(30),
	@Password varchar(50)
	as
	Begin
		UPDATE [dbo].[Empleado]
   SET 
       [Correo] = @Correo
      ,[Salario] = @Salario
      ,[Provincia] = @Provincia
      ,[Distrito] = @Distrito
      ,[Canton] = @Canton
      ,[Nombre] = @Nombre
      ,[Apellido1] = @Apellido1
      ,[Apellido2] = @Apellido2
      ,[Password] = @Password
 WHERE [Cedula] = @Cedula
		END
	GO

create procedure Consultar_Empleado
	@Cedula int 
	as
	Begin
		SELECT * FROM [dbo].Empleado WHERE [Cedula] = @Cedula 
		END
	GO

create procedure Consultar_All_Empleados
	as
	Begin
		SELECT * FROM [dbo].Empleado 
		END
	GO

create procedure Consultar_Empleados_Completos
	as
	Begin
		SELECT [dbo].Empleado.Nombre,[dbo].Empleado.Apellido1,[dbo].Empleado.Apellido2,[dbo].Empleado.Canton,[dbo].Empleado.Cedula,[dbo].Empleado.Correo,[dbo].Empleado.Distrito,
		[dbo].Empleado.Password,[dbo].Empleado.Provincia,[dbo].Empleado.Salario, [dbo].Puestos_empleados.ID_puesto,[dbo].Tipos_planillas_empleados.ID_tipo_planilla
		FROM [dbo].Empleado FULL OUTER JOIN [dbo].Puestos_empleados ON [dbo].Puestos_empleados.Cedula = [dbo].Empleado.Cedula
		FULL OUTER JOIN [dbo].Tipos_planillas_empleados ON [dbo].Tipos_planillas_empleados.Cedula = [dbo].Empleado.Cedula;
		END
	GO

-- -----------------------------------------------------------------------------Sucursal----------------------------------------------------------

create procedure Insertar_Sucursal
	@ID varchar(50) ,
	@Max_capacidad int ,
	@Nombre varchar(20),
	@Provincia varchar(20) ,
	@Distrito varchar(20),
	@Canton varchar(30),
	@Fecha_apertura date
	as
	Begin
		INSERT INTO [dbo].[Sucursal]([ID],[Max_capacidad],[Nombre],[Provincia],[Distrito],[Canton],[Fecha_apertura])
     VALUES
           (@ID,@Max_capacidad,@Nombre ,@Provincia ,@Distrito,@Canton ,@Fecha_apertura )
		
		END
	GO

create procedure Borrar_Sucursal
	@ID varchar(30)
	as
	Begin
		DELETE [dbo].[Tratamiento] FROM [dbo].[Servicio] INNER JOIN [dbo].[Tratamiento] ON [dbo].[Servicio].ID = [dbo].[Tratamiento].ID_servicio WHERE [dbo].Servicio.ID_sucursal = @ID ;
		DELETE [dbo].[Producto] FROM [dbo].[Servicio] INNER JOIN [dbo].[Producto] ON [dbo].[Servicio].ID = [dbo].[Producto].ID_servicio WHERE [dbo].Servicio.ID_sucursal = @ID ;
		DELETE [dbo].[Clases_de_clientes]FROM [dbo].[Clase] INNER JOIN [dbo].[Clases_de_clientes]  ON [dbo].[Clase].ID = [dbo].[Clases_de_clientes].[ID_clase] WHERE [dbo].[Clase].[ID_sucursal] = @ID ;
		DELETE FROM [dbo].[Clase] WHERE [dbo].[Clase].[ID_sucursal] = @ID ;
		DELETE FROM [dbo].[Servicio] WHERE [dbo].Servicio.ID_sucursal = @ID ;
		DELETE FROM [dbo].[Maquina] WHERE [dbo].[Maquina].[ID_sucursal] = @ID ;
		DELETE FROM [dbo].[Sucursal] WHERE [dbo].Sucursal.ID = @ID	;	
		END
	GO


create procedure Actualizar_Sucursal
	@ID varchar(50) ,
	@Max_capacidad int ,
	@Nombre varchar(20),
	@Provincia varchar(20) ,
	@Distrito varchar(20),
	@Canton varchar(30),
	@Fecha_apertura date
	as
	Begin
		UPDATE [dbo].[Sucursal]
   SET 
       [Max_capacidad] = @Max_capacidad
      ,[Nombre] = @Nombre
      ,[Provincia] = @Provincia
      ,[Distrito] = @Distrito
      ,[Canton] = @Canton
      ,[Fecha_apertura] = @Fecha_apertura

 WHERE [ID] = @ID
		END
	GO

create procedure Consultar_Sucursal
	@ID varchar(30)
	as
	Begin
		SELECT * FROM [dbo].Sucursal WHERE [ID] = @ID 
		END
	GO

create procedure Consultar_All_Sucursales
	as
	Begin
		SELECT * FROM [dbo].Sucursal
		END
	GO

	--------------------------------------------------------------------------Servicio------------------------------------------------------------

	create procedure Insertar_Servicio
	@ID varchar(30) ,
	@ID_sucursal varchar(20),
	@Descripcion varchar(30) 
	as
	Begin
		INSERT INTO [dbo].[Servicio]([ID],[ID_sucursal],[Descripcion])
     VALUES
           (@ID,@ID_sucursal,@Descripcion)
		
		END
	GO

create procedure Borrar_Servicio
	@ID varchar(30)
	as
	Begin
		DELETE [dbo].[Tratamiento] FROM [dbo].[Servicio] INNER JOIN [dbo].[Tratamiento] ON [dbo].[Servicio].ID = [dbo].[Tratamiento].ID_servicio WHERE [dbo].Servicio.ID = @ID ;
		DELETE FROM [dbo].[Servicio] WHERE [dbo].Servicio.ID = @ID		
		END
	GO

create procedure Actualizar_Servicio
	@ID varchar(30) ,
	@ID_sucursal varchar(20),
	@Descripcion varchar(30) 
	as
	Begin
		UPDATE [dbo].[Servicio]
   SET 
       [ID_sucursal] = @ID_sucursal,
      [Descripcion] = @Descripcion 
 WHERE [ID] = @ID
		END
	GO

create procedure Consultar_Servicio
	@ID varchar(30)
	as
	Begin
		SELECT * FROM [dbo].Servicio WHERE [ID] = @ID 
		END
	GO

create procedure Consultar_All_Servicios
	as
	Begin
		SELECT * FROM [dbo].Servicio
		END
	GO

------------------------------------------------------------------------------Puesto---------------------------------------------------------------

	create procedure Insertar_Puesto
	@ID varchar(30) ,
	@Descripcion varchar(50)
	as
	Begin
		INSERT INTO [dbo].[Puesto]([ID],[Descripcion])
     VALUES
           (@ID,@Descripcion)
		END
	GO

create procedure Borrar_Puesto
	@ID varchar(30)
	as
	Begin
		DELETE FROM [dbo].[Puesto] WHERE [dbo].Puesto.ID = @ID		
		END
	GO

create procedure Actualizar_Puesto
	@ID varchar(30) ,
	@Descripcion varchar(50)
	as
	Begin
		UPDATE [dbo].[Puesto]
   SET 
       [Descripcion] = @Descripcion
 WHERE [ID] = @ID
		END
	GO

create procedure Consultar_Puesto
	@ID varchar(30)
	as
	Begin
		SELECT * FROM [dbo].Puesto WHERE [ID] = @ID 
		END
	GO

create procedure Consultar_All_Puestos
	as
	Begin
		SELECT * FROM [dbo].Puesto
		END
	GO

----------------------------------------------------------------------------Tipo Planilla----------------------------------------------------



	create procedure Insertar_Tipo_Planilla
	@ID varchar(30) ,
	@Descripcion varchar(50)
	as
	Begin
		INSERT INTO [dbo].[Tipo_planilla]([ID],[Descripcion])
     VALUES
           (@ID,@Descripcion)
		END
	GO

create procedure Borrar_Tipo_Planilla
	@ID varchar(30)
	as
	Begin
		DELETE FROM [dbo].[Tipo_planilla] WHERE [dbo].Tipo_Planilla.ID = @ID		
		END
	GO

create procedure Actualizar_Tipo_Planilla
	@ID varchar(30) ,
	@Descripcion varchar(50)
	as
	Begin
		UPDATE [dbo].[Tipo_planilla]
   SET 
       [Descripcion] = @Descripcion
 WHERE [ID] = @ID
		END
	GO

create procedure Consultar_Tipo_Planilla
	@ID varchar(30) 
	as
	Begin
		SELECT * FROM [dbo].Tipo_planilla WHERE [ID] = @ID 
		END
	GO

create procedure Consultar_All_Tipo_Planillas
	as
	Begin
		SELECT * FROM [dbo].Tipo_planilla
		END
	GO

	----------------------------------------------------------------------Tratamiento----------------------------------------------------------
		create procedure Insertar_Tratamiento
	@ID varchar(30) ,
	@ID_servicio varchar(30),
	@Nombre varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Tratamiento]([ID],[ID_servicio],[Nombre])
     VALUES
           (@ID,@ID_servicio,@Nombre)
		END
	GO

create procedure Borrar_Tratamiento
	@ID varchar(30) 
	as
	Begin
		DELETE FROM [dbo].[Tratamiento] WHERE [dbo].[Tratamiento].ID = @ID		
		END
	GO

create procedure Actualizar_Tratamiento
	@ID varchar(30) ,
	@ID_servicio varchar(30),
	@Nombre varchar(30)
	as
	Begin
		UPDATE [dbo].[Tratamiento]
   SET 
       [ID_servicio] = @ID_servicio,
	   [Nombre] = @Nombre
 WHERE [ID] = @ID
		END
	GO

create procedure Consultar_Tratamiento
	@ID varchar(30)
	as
	Begin
		SELECT * FROM [dbo].Tratamiento WHERE [ID] = @ID 
		END
	GO

create procedure Consultar_All_Tratamientos
	as
	Begin
		SELECT * FROM [dbo].Tratamiento
		END
	GO

	------------------------------------------------------------------------Tipo Equipo------------------------------------------------------------

create procedure Insertar_Tipo_equipo
	@ID varchar(30) ,
	@Nombre varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Tipo_equipo]([ID],[Nombre])
     VALUES
           (@ID,@Nombre)
		END
	GO

create procedure Borrar_Tipo_equipo
	@ID varchar(30)
	as
	Begin
		DELETE FROM [dbo].[Tipo_equipo] WHERE [dbo].[Tipo_equipo].ID = @ID		
		END
	GO

create procedure Actualizar_Tipo_equipo
	@ID varchar(30) ,
	@Nombre varchar(30)
	as
	Begin
		UPDATE [dbo].[Tipo_equipo]
   SET 
	   [Nombre] = @Nombre
 WHERE [ID] = @ID
		END
	GO

create procedure Consultar_Tipo_equipo
	@ID varchar(30)
	as
	Begin
		SELECT * FROM [dbo].[Tipo_equipo] WHERE [ID] = @ID 
		END
	GO

create procedure Consultar_All_Tipo_equipos
	as
	Begin
		SELECT * FROM [dbo].[Tipo_equipo]
		END
	GO

---------------------------------------------------------------------------------Maquina-----------------------------------------------------------

create procedure Insertar_Maquina
	@Serie varchar(30) ,
	@ID_sucursal varchar(20),
	@Costo int,
	@Marca varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Maquina]([Serie],[ID_sucursal],[Costo],[Marca])
     VALUES
           (@Serie,@ID_sucursal,@Costo,@Marca)
		END
	GO

create procedure Borrar_Maquina
	@Serie varchar(30) 
	as
	Begin
		DELETE FROM [dbo].[Maquina] WHERE [dbo].[Maquina].Serie = @Serie		
		END
	GO

create procedure Actualizar_Maquina
	@Serie varchar(30) ,
	@ID_sucursal varchar(20),
	@Costo int,
	@Marca varchar(30)
	as
	Begin
		UPDATE [dbo].[Maquina]
   SET 
	   [ID_sucursal] = @ID_sucursal,
	   [Costo] = @Costo,
	   [Marca] = @Marca
 WHERE [Serie] = @Serie
		END
	GO

create procedure Consultar_Maquina
	@Serie varchar(30)
	as
	Begin
		SELECT * FROM [dbo].[Maquina] WHERE [Serie] = @Serie 
		END
	GO

create procedure Consultar_All_Maquinas
	as
	Begin
		SELECT * FROM [dbo].[Maquina]
		END
	GO

--------------------------------------------------------------------------------Rol------------------------------------------------------------

create procedure Insertar_Rol
	@ID varchar(30) ,
	@Descripcion varchar(50)
	as
	Begin
		INSERT INTO [dbo].[Rol]([ID],[Descripcion])
     VALUES
           (@ID,@Descripcion)
		END
	GO

create procedure Borrar_Rol
	@ID varchar(30)
	as
	Begin
		DELETE FROM [dbo].[Rol] WHERE [dbo].[Rol].[ID] = @ID		
		END
	GO

	--------------------------------------------------------------------Numeros de Sucursal-----------------------------------------------------
create procedure Insertar_Numeros_sucursal
	@ID_sucursal varchar(20) ,
	@Numero int
	as
	Begin
		INSERT INTO [dbo].[Numeros_sucursal]([ID_sucursal],[Numero])
     VALUES
           (@ID_sucursal,@Numero)
		END
	GO

create procedure Borrar_Numeros_sucursal
	@ID_sucursal varchar(20) 
	as
	Begin
		DELETE FROM [dbo].[Numeros_sucursal] WHERE [dbo].[Numeros_sucursal].[ID_sucursal] = @ID_sucursal		
		END
	GO

create procedure Actualizar_Numero_Sucursal
	@ID_sucursal varchar(20) ,
	@Numero int
	as
	Begin
		UPDATE [dbo].[Numeros_sucursal]
   SET 
	   
	   [Numero] = @Numero
 WHERE [ID_sucursal] = @ID_sucursal
		END
	GO

	-------------------------------------------------------------------Tipo planilla de empleados---------------------------------------------------

	create procedure Insertar_Tipos_planillas_empleados
	@Cedula int ,
	@ID_tipo_planilla varchar(30),
	@Clases int ,
	@Horas int
	as
	Begin
		INSERT INTO [dbo].[Tipos_planillas_empleados]([Cedula],[ID_tipo_planilla],[Clases],[Horas])
     VALUES
           (@Cedula,@ID_tipo_planilla,@Clases,@Horas)
		END
	GO

create procedure Borrar_Tipos_planillas_empleados
	@Cedula int 
	as
	Begin
		DELETE FROM [dbo].[Tipos_planillas_empleados] WHERE [dbo].[Tipos_planillas_empleados].[Cedula] = @Cedula		
		END
	GO

create procedure Actualizar_Tipos_planillas_empleados
	@Cedula int ,
	@ID_tipo_planilla varchar(30),
	@Clases int ,
	@Horas int
	as
	Begin
		UPDATE [dbo].[Tipos_planillas_empleados]
   SET 
	   [Clases] = @Clases,
	   [Horas] = @Horas
 WHERE [Cedula] = @Cedula
		END
	GO
	--------------------------------------------------------------------Producto-----------------------------------------------------------

	create procedure Insertar_Producto
	@Bar_code varchar(30) ,
	@ID_servicio varchar(30),
	@Nombre varchar(30),
	@Costo int,
	@Descripcion varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Producto]([Bar_code],[ID_servicio],[Nombre],[Costo],[Descripcion])
     VALUES
           (@Bar_code,@ID_servicio,@Nombre,@Costo,@Descripcion)
		END
	GO

create procedure Borrar_Producto
	@Bar_code varchar(30) 
	as
	Begin
		DELETE FROM [dbo].[Producto] WHERE [dbo].[Producto].[Bar_code] = @Bar_code		
		END
	GO

create procedure Actualizar_Producto
	@Bar_code varchar(30) ,
	@ID_servicio varchar(30),
	@Nombre varchar(30),
	@Costo int,
	@Descripcion varchar(30)
	as
	Begin
		UPDATE [dbo].[Producto]
   SET 
	   [Nombre] = @Nombre,
	   [Costo] = @Costo,
	   [Descripcion] = @Descripcion
 WHERE [Bar_code] = @Bar_code
		END
	GO

create procedure Consultar_Producto
	@Bar_code varchar(30)
	as
	Begin
		SELECT * FROM [dbo].[Producto] WHERE [Bar_code] = @Bar_code 
		END
	GO

create procedure Consultar_All_Productos
	as
	Begin
		SELECT * FROM [dbo].[Producto]
		END
	GO
-----------------------------------------------------------------------------Activo----------------------------------------------------------------
create procedure Insertar_Activo
	@ID varchar(30) ,
	@Spa varchar(30),
	@Tienda varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Activo]([ID],[Spa],[Tienda])
     VALUES
           (@ID,@Spa,@Tienda)
		END
	GO
	
create procedure Actualizar_Activo
	@ID varchar(30) ,
	@Spa varchar(30),
	@Tienda varchar(30)
	as
	Begin
		UPDATE [dbo].[Activo]
   SET 
	   [Spa] = @Spa,
	   [Tienda] = @Tienda
 WHERE [ID] = @ID
		END
	GO

create procedure Consultar_Activo
	@ID varchar(30)
	as
	Begin
		SELECT * FROM [dbo].[Activo] WHERE [ID] = @ID 
		END
	GO
-----------------------------------------------------------------------------Roles Empleados--------------------------------------------------------
create procedure Insertar_Roles_empleados
	@Cedula int ,
	@ID_rol varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Roles_empleados]([Cedula],[ID_rol])
     VALUES
           (@Cedula,@ID_rol)
		END
	GO

create procedure Borrar_Roles_empleados
	@Cedula int
	as
	Begin
		DELETE FROM [dbo].[Roles_empleados] WHERE [dbo].[Roles_empleados].[Cedula] = @Cedula		
		END
	GO

create procedure Actualizar_Roles_empleados
	@Cedula int ,
	@ID_rol varchar(30)
	as
	Begin
		UPDATE [dbo].[Roles_empleados]
   SET 
	   [ID_rol] = @ID_rol
	   
 WHERE [Cedula] = @Cedula
		END
	GO

create procedure Consultar_Roles_empleados
	@Cedula int
	as
	Begin
		SELECT * FROM [dbo].[Roles_empleados] WHERE [Cedula] = @Cedula 
		END
	GO

-----------------------------------------------------------------------------Puesto Empleados-------------------------------------------------------
create procedure Insertar_Puestos_empleados
	@Cedula int ,
	@ID_puesto varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Puestos_empleados]([Cedula],[ID_puesto]) VALUES (@Cedula,@ID_puesto)
		END
	GO

create procedure Borrar_Puestos_empleados
	@Cedula int 
	as
	Begin
		DELETE FROM [dbo].[Puestos_empleados] WHERE [dbo].[Puestos_empleados].[Cedula] = @Cedula		
		END
	GO

create procedure Actualizar_Puestos_empleados
	@Cedula int ,
	@ID_puesto varchar(30)
	as
	Begin
		UPDATE [dbo].[Puestos_empleados]
   SET 
	   [ID_puesto] = @ID_puesto
	   
 WHERE [Cedula] = @Cedula
		END
	GO

create procedure Consultar_Puestos_empleados
	@Cedula int
	as
	Begin
		SELECT * FROM [dbo].[Puestos_empleados] WHERE [Cedula] = @Cedula 
		END
	GO
-----------------------------------------------------------------------------Maquinas Tipos---------------------------------------------------------
create procedure Insertar_Maquinas_Tipos
	@Serie varchar(30) ,
	@ID varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Maquinas_tipos]([Serie],[ID]) VALUES (@Serie,@ID)
		END
	GO

create procedure Borrar_Maquinas_Tipos
	@Serie varchar(30) 
	as
	Begin
		DELETE FROM [dbo].[Maquinas_tipos] WHERE [dbo].[Maquinas_tipos].[Serie] = @Serie		
		END
	GO

create procedure Actualizar_Maquinas_Tipos
	@Serie varchar(30) ,
	@ID varchar(30)
	as
	Begin
		UPDATE [dbo].[Maquinas_tipos]
   SET 
	   [ID] = @ID
	   
 WHERE [Serie] = @Serie
		END
	GO

-----------------------------------------------------------------------------Cliente----------------------------------------------------------------
create procedure Insertar_Cliente
	@Cedula int
	as
	Begin
		INSERT INTO [dbo].[Cliente]([Cedula]) VALUES (@Cedula)
		END
	GO

create procedure Borrar_Cliente
	@Cedula int
	as
	Begin
		DELETE FROM [dbo].[Cliente] WHERE [dbo].[Cliente].[Cedula] = @Cedula		
		END
	GO


create procedure Consultar_Cliente
	as
	Begin
		SELECT * FROM [dbo].[Cliente]
	END
	GO

-----------------------------------------------------------------------------Clase-----------------------------------------------------------------
create procedure Insertar_Clase
	@ID varchar(30) ,
	@ID_sucursal varchar(20),
	@Tipo varchar(30),
	@Modalidad varchar(30),
	@Instructor int,
	@Hora_inicio time(7),
	@Hora_fin time(7),
	@Fecha date
	as
	Begin
		INSERT INTO [dbo].[Clase]([ID],[ID_sucursal],[Tipo],[Modalidad],[Instructor],[Hora_inicio],[Hora_fin],[Fecha])
     VALUES
           (@ID,@ID_sucursal,@Tipo,@Modalidad,@Instructor,@Hora_inicio,@Hora_fin,@Fecha)
		END
	GO

create procedure Borrar_Clase
	@ID varchar(30) 
	as
	Begin
		DELETE FROM [dbo].[Clase] WHERE [dbo].[Clase].[ID] = @ID		
		END
	GO

create procedure Actualizar_Clase
	@ID varchar(30) ,
	@ID_sucursal varchar(20),
	@Tipo varchar(30),
	@Modalidad varchar(30),
	@Instructor int,
	@Hora_inicio time(7),
	@Hora_fin time(7),
	@Fecha date
	as
	Begin
		UPDATE [dbo].[Clase]
   SET 
	   [ID_sucursal] = @ID_sucursal,
	   [Tipo] = @Tipo,
	   [Modalidad] = @Modalidad,
	   [Instructor] = @Instructor,
	   [Hora_inicio] = @Hora_inicio,
	   [Hora_fin] = @Hora_fin,
	   [Fecha] = @Fecha
 WHERE [ID] = @ID
		END
	GO

create procedure Consultar_Clase
	@ID varchar(30)
	as
	Begin
		SELECT * FROM [dbo].[Clase] WHERE [ID] = @ID 
		END
	GO

create procedure Consultar_All_Clase
	as
	Begin
		SELECT * FROM [dbo].[Clase]
		END
	GO

-----------------------------------------------------------------------------Clases de Clientes----------------------------------------------------
create procedure Insertar_Clase_Cliente
	@Cedula int,
	@ID_clase varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Clases_de_clientes]([Cedula],[ID_clase]) VALUES (@Cedula,@ID_clase)
		END
	GO

create procedure Borrar_Clase_Cliente
	@Cedula int
	as
	Begin
		DELETE FROM [dbo].[Clases_de_clientes] WHERE [dbo].[Clases_de_clientes].[Cedula] = @Cedula		
		END
	GO


create procedure Consultar_Clase_Cliente
	@Cedula int
	as
	Begin
		SELECT * FROM [dbo].[Clases_de_clientes] WHERE [Cedula] = @Cedula 
	END
	GO
-----------------------------------------------------------------------------Empleado Admin---------------------------------------------------------
create procedure Insertar_Empleado_Admin
	@Cedula int,
	@ID_sucursal varchar(30)
	as
	Begin
		INSERT INTO [dbo].[Empleados_admin] ([Cedula],[ID_sucursal]) VALUES (@Cedula,@ID_sucursal)
		END
	GO

create procedure Borrar_Empleado_Admin
	@Cedula int
	as
	Begin
		DELETE FROM [dbo].[Empleados_admin] WHERE [dbo].[Empleados_admin].[Cedula] = @Cedula		
		END
	GO


create procedure Consultar_Empleado_Admin
	@Cedula int
	as
	Begin
		SELECT * FROM [dbo].[Empleados_admin] WHERE [Cedula] = @Cedula 
	END
	GO

	create procedure Actualizar_Empleado_Admin
	@Cedula int,
	@ID_sucursal varchar(30)
	as
	Begin
		UPDATE [dbo].[Empleados_admin]
   SET 
	   [Cedula] = @Cedula
 WHERE [ID_sucursal] = @ID_sucursal
		END
	GO

-----------------------------------------------------------------------------Planilla---------------------------------------------------------------
create procedure Generar_Plantilla
	as
	Begin
		SELECT [dbo].Empleado.Cedula,[dbo].Empleado.Nombre,[dbo].Empleado.Apellido1,[dbo].Empleado.Apellido2,[dbo].Tipos_planillas_empleados.Clases,[dbo].Tipos_planillas_empleados.Horas,  
		CASE WHEN [dbo].Tipo_planilla.Descripcion = 'Clase' THEN ([dbo].Tipos_planillas_empleados.Clases * [dbo].Empleado.Salario)
WHEN [dbo].Tipo_planilla.Descripcion = 'Hora' THEN ([dbo].Tipos_planillas_empleados.Horas * [dbo].Empleado.Salario)
ELSE [dbo].Empleado.Salario
END AS Pago
		FROM [dbo].Empleado inner join  [dbo].Tipos_planillas_empleados on [dbo].Empleado.Cedula = [dbo].Tipos_planillas_empleados.Cedula inner join [dbo].Tipo_planilla on [dbo].Tipos_planillas_empleados.ID_tipo_planilla = [dbo].Tipo_planilla.ID;
	END
	GO

-----------------------------------------------------------------------------Triggers---------------------------------------------------------------
  CREATE TRIGGER Default_Datos
  ON [dbo].[Sucursal]
  FOR INSERT
  AS DECLARE 
    @ID varchar(50) ,
	@Max_capacidad int ,
	@Nombre varchar(20),
	@Provincia varchar(20) ,
	@Distrito varchar(20),
	@Canton varchar(30),
	@Fecha_apertura date

SELECT @ID = ins.ID FROM INSERTED ins;
SELECT @Max_capacidad = ins.Max_capacidad FROM INSERTED ins;
SELECT @Nombre = ins.Nombre FROM INSERTED ins;
SELECT @Provincia = ins.Provincia FROM INSERTED ins;
SELECT @Distrito = ins.Distrito FROM INSERTED ins;
SELECT @Canton = ins.Canton FROM INSERTED ins;
SELECT @Fecha_apertura = ins.Fecha_apertura FROM INSERTED ins;
BEGIN
--Insertar en Tabla Activo para saber si tiene habilitado el spa o tienda 

  INSERT INTO [dbo].[Activo]([ID],[Spa],[Tienda])VALUES(@ID,'F','F');
--Insertar todos los servicios por default
declare @Num varchar(30),@Num2 varchar(30),@Num3 varchar(30),@Num4 varchar(30),@Num5 varchar(30),@Num6 varchar(30),@Num7 varchar(30),@Num8 varchar(30),@Num9 varchar(30),
@Num10 varchar(30),@Num11 varchar(30),@Num12 varchar(30),@Num13 varchar(30),@Num14 varchar(30),@Num15 varchar(30);
select @Num = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num2 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num3 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num4 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num5 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num6 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num7 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0));
select @Num8 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num9 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num10 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num11 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num12 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num13 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num14 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
select @Num15 = CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +CHAR(65 + ROUND( RAND()* 25, 0)) +
	CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)) +CHAR(48 + ROUND( RAND()* 9, 0)); 
  INSERT INTO [dbo].[Servicio]([ID],[ID_sucursal],[Descripcion])VALUES(@Num,@ID,'Indoor Cycling');

  INSERT INTO [dbo].[Servicio]([ID],[ID_sucursal],[Descripcion])VALUES(@Num2,@ID,'Pilates');

  INSERT INTO [dbo].[Servicio]([ID],[ID_sucursal],[Descripcion])VALUES(@Num3,@ID,'Yoga');

  INSERT INTO [dbo].[Servicio]([ID],[ID_sucursal],[Descripcion])VALUES(@Num4,@ID,'Zumba');

  INSERT INTO [dbo].[Servicio]([ID],[ID_sucursal],[Descripcion])VALUES(@Num5,@ID,'Natacion');

  INSERT INTO [dbo].[Servicio]([ID],[ID_sucursal],[Descripcion])VALUES(@Num6,@ID,'Spa');

  INSERT INTO [dbo].[Servicio]([ID],[ID_sucursal],[Descripcion])VALUES(@Num7,@ID,'Tienda');
--Insertar Tratamientod por defaul

  INSERT INTO [dbo].[Tratamiento]([ID],[ID_servicio],[Nombre])VALUES(@Num8,@Num6,'Masaje Relajante');

  INSERT INTO [dbo].[Tratamiento]([ID],[ID_servicio],[Nombre])VALUES(@Num9,@Num6,'Masaje Descarga Muscular');

  INSERT INTO [dbo].[Tratamiento]([ID],[ID_servicio],[Nombre])VALUES(@Num10,@Num6,'Sauna');

  INSERT INTO [dbo].[Tratamiento]([ID],[ID_servicio],[Nombre])VALUES(@Num11,@Num6,'Baños a vapor');
--Insertar Productos

  INSERT INTO [dbo].[Producto]([Bar_code],[ID_servicio],[Nombre],[Costo],[Descripcion])VALUES(@Num12,@Num7,'Pesas',9500,'Pesas de 5k, 10k, 20k');

  INSERT INTO [dbo].[Producto]([Bar_code],[ID_servicio],[Nombre],[Costo],[Descripcion])VALUES(@Num13,@Num7,'Ligas',5500,'Ligas para estiramiento');

  INSERT INTO [dbo].[Producto]([Bar_code],[ID_servicio],[Nombre],[Costo],[Descripcion])VALUES(@Num14,@Num7,'Mancuernas',12000,'Mancuernas 10k 20k');

  INSERT INTO [dbo].[Producto]([Bar_code],[ID_servicio],[Nombre],[Costo],[Descripcion])VALUES(@Num15,@Num7,'Pads',3000,'Diferentes tipos de pads');
END
GO

CREATE TRIGGER Mantener_Tratamientos
  ON [dbo].[Tratamiento]
  FOR UPDATE
  AS DECLARE 
    @ID varchar(30) ,
	@ID_servicio varchar(30),
	@Nombre varchar(30)

SELECT @ID = ins.ID FROM INSERTED ins;
SELECT @ID_servicio = ins.ID_servicio FROM INSERTED ins;
SELECT @Nombre= ins.Nombre FROM INSERTED ins;

IF @Nombre <> 'Masaje Relajante' AND @Nombre <> 'Masaje Descarga Muscular' AND @Nombre <> 'Sauna' AND @Nombre <> 'Baños a vapor'
BEGIN
  UPDATE [dbo].[Tratamiento] SET [ID_servicio] = @ID_servicio, [Nombre] = @Nombre WHERE [ID] = @ID
END
GO

CREATE TRIGGER Borrar_Activos
  ON [dbo].[Sucursal]
  FOR Delete
  AS DECLARE 
	@ID varchar(50) 
	

SELECT @ID = ins.ID FROM INSERTED ins;

BEGIN
	DELETE FROM [dbo].[Activo] WHERE [dbo].[Activo].[ID] = @ID;
END
GO

----------------------------------------------------------------------------Vistas---------------------------------------------------------
CREATE VIEW Maquina_R_Tipo
AS SELECT [Maquina].Serie,[Maquina].Marca,[Maquina].ID_sucursal,[Maquina].Costo,[Tipo_equipo].Nombre
FROM [dbo].[Maquina] INNER JOIN  [dbo].[Maquinas_tipos] ON [dbo].[Maquina].Serie = [dbo].[Maquinas_tipos].Serie
INNER JOIN [dbo].[Tipo_equipo] ON [dbo].[Maquinas_tipos].ID = [dbo].[Tipo_equipo].ID;
GO

CREATE VIEW Clase_R_Cliente
AS SELECT [Clase].ID,[Clase].ID_sucursal,[Clase].Instructor,[Clase].Modalidad,[Clase].Hora_inicio,[Clase].Hora_fin,[Clase].Fecha,[Clase].Tipo,[Cliente].Cedula as Cliente
FROM [dbo].[Clase] INNER JOIN  [dbo].[Clases_de_clientes] ON [dbo].[Clase].ID = [dbo].[Clases_de_clientes].ID_clase
INNER JOIN [dbo].[Cliente] ON [dbo].[Clases_de_clientes].Cedula = [dbo].[Cliente].Cedula;
GO

create procedure Consultar_Empleado_Total
	as
	Begin
		SELECT [dbo].[Empleado].Cedula,[dbo].[Empleado].Correo,[dbo].[Empleado].Nombre,[dbo].[Empleado].Apellido1,[dbo].[Empleado].Apellido2,[dbo].[Empleado].[Password],[dbo].[Empleado].Canton,
		[dbo].[Empleado].Distrito,[dbo].[Empleado].Provincia,[dbo].[Empleado].Salario,[dbo].Puesto.Descripcion,[dbo].Empleados_admin.ID_sucursal FROM [dbo].[Empleado] INNER JOIN [dbo].Puestos_empleados ON [dbo].[Empleado].Cedula = [dbo].Puestos_empleados.Cedula 
		INNER JOIN [dbo].Puesto ON [dbo].Puestos_empleados.ID_puesto = [dbo].Puesto.ID
		FULL OUTER JOIN [dbo].Empleados_admin ON [dbo].Empleados_admin.Cedula = [dbo].[Empleado].Cedula;
	END
	GO
----------------------------------------------------------------------------Inclusion de Datos----------------------------------------------
----Ingresa valores se los tipos de equipos
INSERT INTO [dbo].[Tipo_equipo]([ID],[Nombre]) VALUES('123a','Cintas de Correr');
INSERT INTO [dbo].[Tipo_equipo]([ID],[Nombre]) VALUES('123b','Bicicletas estacionarias');
INSERT INTO [dbo].[Tipo_equipo]([ID],[Nombre]) VALUES('123c','Multigimnacios');
INSERT INTO [dbo].[Tipo_equipo]([ID],[Nombre]) VALUES('123d','Remos');
INSERT INTO [dbo].[Tipo_equipo]([ID],[Nombre]) VALUES('123e','Pesas');

-----Rol
INSERT INTO [dbo].[Rol]([ID],[Descripcion])VALUES('12a','Instructor');
INSERT INTO [dbo].[Rol]([ID],[Descripcion])VALUES('12b','Dependiente de Tienda');
INSERT INTO [dbo].[Rol]([ID],[Descripcion])VALUES('12c','Dependiente de Spa');

-------Puestos

INSERT INTO [dbo].[Puesto]([ID],[Descripcion])VALUES('11a','Administrador');
INSERT INTO [dbo].[Puesto]([ID],[Descripcion])VALUES('11b','Instructor');
INSERT INTO [dbo].[Puesto]([ID],[Descripcion])VALUES('11c','Dependiente de Tienda');
INSERT INTO [dbo].[Puesto]([ID],[Descripcion])VALUES('11d','Dependiente de Spa');

---Tipo planilla
INSERT INTO [dbo].[Tipo_planilla]([ID],[Descripcion])VALUES('1','Clase');
INSERT INTO [dbo].[Tipo_planilla]([ID],[Descripcion])VALUES('2','Hora');
INSERT INTO [dbo].[Tipo_planilla]([ID],[Descripcion])VALUES('3','Mes');
GO
create procedure [dbo].Sucursal_Completo
	as
	Begin
		SELECT [dbo].Sucursal.ID,[dbo].Sucursal.Max_capacidad,[dbo].Sucursal.Nombre,[dbo].Sucursal.Provincia,[dbo].Sucursal.Fecha_apertura,[dbo].Sucursal.Distrito,[dbo].Sucursal.Canton,
		[dbo].Empleados_admin.Cedula,[dbo].Numeros_sucursal.Numero 
		FROM [dbo].Sucursal FULL OUTER JOIN [dbo].Empleados_admin ON [dbo].Empleados_admin.ID_sucursal = [dbo].Sucursal.ID
		FULL OUTER JOIN [dbo].Numeros_sucursal ON [dbo].Numeros_sucursal.ID_sucursal = [dbo].Sucursal.ID;
		END
GO