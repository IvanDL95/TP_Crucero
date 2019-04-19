USE GD2C2018
GO

--************CREACION DE SCHEMA**************
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'RJT')
	BEGIN
		EXEC sys.sp_executesql N'CREATE SCHEMA [RJT] AUTHORIZATION [gdEspectaculos2018]'
		PRINT 'Schema correctamente creado'

	END

GO

--****************DROP DE PROCEDURES*************
IF OBJECT_ID('RJT.BUSCAR_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE RJT.BUSCAR_USUARIO
GO
IF OBJECT_ID('RJT.REG_INTENTO_FALLIDO', 'P') IS NOT NULL
DROP PROCEDURE RJT.REG_INTENTO_FALLIDO
GO
IF OBJECT_ID('RJT.OBTENER_ID_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_ID_USUARIO
GO
IF OBJECT_ID('RJT.OBTENER_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_USUARIO
GO
IF OBJECT_ID('RJT.OBTENER_CANT_ROLES', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_CANT_ROLES
GO
IF OBJECT_ID('RJT.GUARDAR_ROL', 'P') IS NOT NULL
DROP PROCEDURE RJT.GUARDAR_ROL
GO
IF OBJECT_ID('RJT.ELIMINAR_ROL', 'P') IS NOT NULL
DROP PROCEDURE RJT.ELIMINAR_ROL
GO
IF OBJECT_ID('RJT.OBTENER_ID_X_NOMBRE', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_ID_X_NOMBRE
GO
IF OBJECT_ID('RJT.AGREGAR_FUNCIONALIDAD_A_ROL', 'P') IS NOT NULL
DROP PROCEDURE RJT.AGREGAR_FUNCIONALIDAD_A_ROL
GO
IF OBJECT_ID('RJT.ELIMINAR_FUNCIONALIDAD_A_ROL', 'P') IS NOT NULL
DROP PROCEDURE RJT.ELIMINAR_FUNCIONALIDAD_A_ROL
GO
IF OBJECT_ID('RJT.LISTAR_FUNCIONES_X_ROL', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_FUNCIONES_X_ROL 
GO
IF OBJECT_ID('RJT.LISTAR_FUNCIONES_X_ROL_NO_ASIGNADAS', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_FUNCIONES_X_ROL_NO_ASIGNADAS
GO
IF OBJECT_ID('RJT.LISTAR_AFILIADOS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_AFILIADOS_EXISTENTES
GO
IF OBJECT_ID('RJT.OBTENER_ROLES_ACTIVOS', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_ROLES_ACTIVOS
GO
IF OBJECT_ID('RJT.OBTENER_FUNCIONALIDADES_ROL', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_FUNCIONALIDADES_ROL
GO

IF OBJECT_ID('RJT.CREAR_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_USUARIO
GO

IF OBJECT_ID('RJT.CREAR_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_DIRECCION
GO

IF OBJECT_ID('RJT.OBTENER_ID_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_ID_DIRECCION
GO

IF OBJECT_ID('RJT.CREAR_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_CLIENTE
GO

IF OBJECT_ID('RJT.CREAR_EMPRESA', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_EMPRESA
GO

IF OBJECT_ID('RJT.CREAR_ROLxUSUARIO', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_ROLxUSUARIO
GO

IF OBJECT_ID('RJT.OBTENER_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_CLIENTE
GO

IF OBJECT_ID('RJT.OBTENER_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_DIRECCION
GO

IF OBJECT_ID('RJT.MODIFICAR_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE RJT.MODIFICAR_CLIENTE
GO

IF OBJECT_ID('RJT.MODIFICAR_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE RJT.MODIFICAR_DIRECCION
GO

-----------------------------------------------------ABM CLIENTE--------------------------------------------------------

if EXISTS (SELECT * FROM sysobjects WHERE name='st_buscar_clientes') 
drop procedure RJT.st_buscar_clientes

go

if EXISTS (SELECT * FROM sysobjects WHERE name='st_agregar_cliente') 
drop procedure RJT.st_agregar_cliente

go

if EXISTS (SELECT * FROM sysobjects WHERE name='st_modificar_cliente') 
drop procedure RJT.st_modificar_cliente

go

--*************Inicio Creacion de tablas****************

if OBJECT_ID('RJT.Ubicacion', 'U') is not null
	drop table RJT.Ubicacion;
create table RJT.Ubicacion(ubi_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							ubi_tipo NUMERIC(18,0) not null, --FK Tipo
							ubi_precio numeric(10,2) not null,
							ubi_sin_numerar bit not null,
							ubi_asiento char(5),
							ubi_fila char(5),
							ubi_pub NUMERIC(18,0) NOT NULL, --FK Publicacion
							ubi_com NUMERIC(18,0), --FK Compra
							primary key (ubi_id));


if OBJECT_ID('RJT.Compra', 'U') is not null
	drop table RJT.Compra;

create table RJT.Compra (com_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					 com_fecha datetime not null,
					 com_cli NUMERIC(18,0) NOT NULL,
					 com_mp NUMERIC(18,0) NOT NULL,
					 com_cant int NOT NULL check(com_cant > 0),
					 com_total decimal(18,2) not null,
					 com_fact NUMERIC(18,0)
					 PRIMARY KEY(com_id));

if OBJECT_ID('RJT.Item_Factura', 'U') is not null
	drop table RJT.Item_Factura;

create table RJT.Item_Factura (item_fact_nro NUMERIC(18,0)  NOT NULL,
							 item_fact_id NUMERIC(18,0)  IDENTITY(1,1) NOT NULL,
							 item_fact_monto decimal(18,2) not null,
							 item_fact_desc varchar(400) not null
							 PRIMARY KEY(item_fact_id));

if OBJECT_ID('RJT.Factura', 'U') is not null
	drop table RJT.Factura;

create table RJT.Factura (fact_nro NUMERIC(18,0) NOT NULL,
					  fact_fecha datetime not null,
					  fact_emp NUMERIC(18,0) not null,
					  fact_total decimal(18,2) not null
					  PRIMARY KEY(fact_nro));

if OBJECT_ID('RJT.Empresa', 'U') is not null
	drop table RJT.Empresa;

create table  RJT.Empresa  (emp_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					  emp_usu_id NUMERIC(18,0) not null, -- FK usuario
					  emp_razon_social nvarchar(50) not null,
					  emp_cuit char(14) not null,
					  emp_direccion NUMERIC(18,0),
					  emp_estado bit,
					  PRIMARY KEY(emp_id));

if OBJECT_ID('RJT.Premio', 'U') is not null
	drop table RJT.Premio;
create table RJT.Premio (pre_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					     pre_tipo NUMERIC(18,0) not null, --FK Tipo
						 pre_cli NUMERIC(18,0)NOT NULL,
						 PRIMARY KEY(pre_id));

if OBJECT_ID('RJT.MedioPago', 'U') is not null
	drop table RJT.MedioPago;
create table RJT.MedioPago (mp_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							mp_desc nvarchar(100) not null,
							PRIMARY KEY(mp_id));

if OBJECT_ID('RJT.TipoUbicacion', 'U') is not null
	drop table RJT.TipoUbicacion;
create table RJT.TipoUbicacion (tu_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							tu_desc nvarchar(100) not null,
							PRIMARY KEY(tu_id));

if OBJECT_ID('RJT.TipoPremio', 'U') is not null
	drop table RJT.TipoPremio;
create table RJT.TipoPremio (tp_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							tp_desc nvarchar(100) not null,
							tp_puntos int not null,
							PRIMARY KEY(tp_id));

if OBJECT_ID('RJT.Cliente', 'U') is not null
	drop table RJT.Cliente;

create table RJT.Cliente (cli_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					  cli_usu_id NUMERIC(18,0)  NOT NULL,
					  cli_nombre NVARCHAR(30) not null,
					  cli_apellido NVARCHAR(30) not null,
					  cli_tipo_doc char(3) not null,
					  cli_nro_doc char(10)  NOT NULL,
					  cli_cuil char(14),
					  cli_fecha_nac datetime not null,
					  cli_fecha_creacion datetime,
					  cli_ptos int,
					  cli_ptos_venc datetime,
					  cli_tarj char(19),
					  cli_direccion NUMERIC(18,0),
					  cli_estado bit,
					  PRIMARY KEY(cli_id));

if OBJECT_ID('RJT.Rol_Usuario', 'U') is not null
	drop table RJT.Rol_Usuario;
create table RJT.Rol_Usuario(usu_id NUMERIC(18,0) NOT NULL,
							 rol_id NUMERIC(18,0) NOT NULL,
							 estado	BIT NOT NULL DEFAULT 0);

if OBJECT_ID('RJT.Rol_Funcionalidad', 'U') is not null
	drop table RJT.Rol_Funcionalidad;
create table RJT.Rol_Funcionalidad( rol_id NUMERIC(18,0) NOT NULL,
									fun_id NUMERIC(18,0) NOT NULL,
									estado BIT NOT NULL DEFAULT 1);

if OBJECT_ID('RJT.Rol', 'U') is not null
	drop table RJT.Rol;
	create table RJT.Rol(rol_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
						 rol_nombre NVARCHAR(50) NOT NULL,
						 rol_estado BIT NOT NULL DEFAULT 1, 
						 PRIMARY KEY (rol_id) );

if OBJECT_ID('RJT.Funcionalidad', 'U') is not null
	drop table RJT.Funcionalidad;
create table RJT.Funcionalidad( fun_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
								fun_nombre nvarchar(50) NOT NULL,
								fun_visible BIT NOT NULL DEFAULT 1,
								PRIMARY KEY (fun_id) );

if OBJECT_ID('RJT.Publicacion', 'U') is not null
	drop table RJT.Publicacion;
create table RJT.Publicacion(pub_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							 pub_estado nvarchar(10) NOT NULL check (pub_estado in ('Borrador', 'Publicada', 'Finalizada')),
							 pub_desc nvarchar(400) not null,
							 pub_fecha_pub datetime, 
							 pub_fecha_espec datetime not null, 
							 pub_rubro NUMERIC(18,0) not null, --FK rubro
							 pub_dir NUMERIC(18,0), --FK Direccion
							 pub_gra NUMERIC(18,0) not null, --FK grado de publicacion
							 pub_usu NUMERIC(18,0) NOT NULL, -- FK usuario
							 primary key (pub_id));

if OBJECT_ID('RJT.Rubro', 'U') is not null
	drop table RJT.Rubro;
create table RJT.Rubro( rub_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
						rub_desc nvarchar(100) not null,
						primary key (rub_id));

if OBJECT_ID('RJT.GradoPublicacion', 'U') is not null
	drop table RJT.GradoPublicacion;
create table RJT.GradoPublicacion( gra_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
									gra_desc char(30) not null,
									gra_comision numeric (2,0) not null,
									gra_peso int not null,
									gra_estado bit,
									primary key (gra_id));	

if OBJECT_ID('RJT.Usuario', 'U') is not null
	drop table RJT.Usuario;
create table RJT.Usuario(usu_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
						usu_usuario NVARCHAR(30) NOT NULL,
						usu_password NVARCHAR(255) NOT NULL,
						usu_cant_int_fallidos int default 0,
						usu_estado bit default 1
						PRIMARY KEY (usu_id) );

if OBJECT_ID('RJT.Direccion', 'U') is not null
	drop table RJT.Direccion;
create table RJT.Direccion( dir_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							dir_calle nvarchar(70) not null,
							dir_num char(5) not null,
							dir_piso char(2) not  null,
							dir_dto char(2) not null,
							dir_cp char(4) not null,
							dir_localidad nvarchar(50),
							dir_telefono varchar(18),
							dir_mail nvarchar(50) not null,
							primary key (dir_id));
									
-- ******** Fin Creacion de Tablas************


-- ******** Inicio Creacion de FKs************

ALTER TABLE RJT.Ubicacion  WITH CHECK ADD
	CONSTRAINT FK_pub_ubic FOREIGN KEY (ubi_pub)
	REFERENCES RJT.Publicacion (pub_id)

ALTER TABLE RJT.Ubicacion  WITH CHECK ADD
	CONSTRAINT FK_ubic_compra FOREIGN KEY (ubi_com)
	REFERENCES RJT.Compra (com_id)

ALTER TABLE RJT.Ubicacion  WITH CHECK ADD
	CONSTRAINT FK_ubic_tipo FOREIGN KEY (ubi_tipo)
	REFERENCES RJT.TipoUbicacion (tu_id)

ALTER TABLE RJT.Empresa  WITH CHECK ADD
	CONSTRAINT FK_emp_usu_id FOREIGN KEY (emp_usu_id)
	REFERENCES RJT.Usuario (usu_id)

ALTER TABLE RJT.Empresa  WITH CHECK ADD
	CONSTRAINT FK_Empresa_Direccion FOREIGN KEY (emp_direccion)
	REFERENCES RJT.Direccion (dir_id)

ALTER TABLE RJT.Factura  WITH CHECK ADD
	CONSTRAINT FK_fact_empresa FOREIGN KEY (fact_emp)
	REFERENCES RJT.Empresa (emp_id)

ALTER TABLE RJT.Item_Factura  WITH CHECK ADD
	CONSTRAINT FK_fact_item FOREIGN KEY (item_fact_nro)
	REFERENCES RJT.Factura (fact_nro)

ALTER TABLE RJT.Compra  WITH CHECK ADD
	CONSTRAINT FK_compra_cliente FOREIGN KEY (com_cli)
	REFERENCES RJT.Cliente (cli_id)

ALTER TABLE RJT.Compra  WITH CHECK ADD
	CONSTRAINT FK_compra_factura FOREIGN KEY (com_fact)
	REFERENCES RJT.Factura (fact_nro)

ALTER TABLE RJT.Compra  WITH CHECK ADD
	CONSTRAINT FK_compra_medioPago FOREIGN KEY (com_mp)
	REFERENCES RJT.MedioPago (mp_id)

ALTER TABLE RJT.Cliente  WITH CHECK ADD
	CONSTRAINT FK_Cliente_Usuario FOREIGN KEY (cli_usu_id)
	REFERENCES RJT.Usuario (usu_id)
	
ALTER TABLE RJT.Cliente  WITH CHECK ADD
	CONSTRAINT FK_Cliente_Direccion FOREIGN KEY (cli_direccion)
	REFERENCES RJT.Direccion (dir_id)

ALTER TABLE RJT.Premio  WITH CHECK ADD
	CONSTRAINT FK_Premio_Cliente FOREIGN KEY (pre_cli)
	REFERENCES RJT.Cliente (cli_id)

ALTER TABLE RJT.Premio  WITH CHECK ADD
	CONSTRAINT FK_Premio_Tipo FOREIGN KEY (pre_tipo)
	REFERENCES RJT.TipoPremio (tp_id)

ALTER TABLE RJT.Rol_Usuario  WITH CHECK ADD
	CONSTRAINT FK_Usuario_ID FOREIGN KEY (usu_id)
	REFERENCES RJT.Usuario (usu_id)

ALTER TABLE RJT.Rol_Usuario  WITH CHECK ADD
	CONSTRAINT FK_Rol_ID FOREIGN KEY (rol_id)
	REFERENCES RJT.Rol (rol_id)
	
ALTER TABLE RJT.Rol_Funcionalidad WITH CHECK ADD
	CONSTRAINT FK_Funcionalidad_ID FOREIGN KEY (fun_id)
	REFERENCES RJT.Funcionalidad (fun_id)

ALTER TABLE RJT.Rol_Funcionalidad  WITH CHECK ADD
	CONSTRAINT FK_RolFun_ID FOREIGN KEY (rol_id)
	REFERENCES RJT.Rol (rol_id)

ALTER TABLE RJT.Publicacion  WITH CHECK ADD
	CONSTRAINT FK_Publicacion_Rubro FOREIGN KEY (pub_rubro)
	REFERENCES RJT.Rubro (rub_id)

ALTER TABLE RJT.Publicacion  WITH CHECK ADD
	CONSTRAINT FK_Publicacion_Direccion FOREIGN KEY (pub_dir)
	REFERENCES RJT.Direccion (dir_id)

ALTER TABLE RJT.Publicacion  WITH CHECK ADD
	CONSTRAINT FK_Publicacion_Grado FOREIGN KEY (pub_gra)
	REFERENCES RJT.GradoPublicacion (gra_id)
ALTER TABLE RJT.Publicacion  WITH CHECK ADD
	CONSTRAINT FK_Publicacion_Usuario FOREIGN KEY (pub_usu)
	REFERENCES RJT.Usuario (usu_id)

-- ******** FIN Creacion de FKs************


-- ******** Inicio Migracion************

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'RJT.MODIFICA_CUIT')
AND type in (N'FN', N'IF',N'TF', N'FS', N'FT'))
DROP FUNCTION RJT.MODIFICA_CUIT
GO

create function RJT.MODIFICA_CUIT (@Cuit nvarchar(255))
returns nvarchar(255)
as
begin 
	return REPLACE(@Cuit, '-', '');
end
go

-- Creo Roles
INSERT INTO RJT.Rol(rol_nombre, rol_estado)
VALUES
('Administrativo', 1),
('Empresa', 1),
('Cliente', 1);

--Creo Funcionalidades
INSERT INTO RJT.Funcionalidad(fun_nombre)
VALUES
('ABM DE ROL'),
('REGISTRO DE USUARIO'),
('ABM DE CLIENTES'),
('ABM DE EMPRESA DE ESPECTACULOS'),
('ABM GRADO DE PUBLICACION'),
('GENERAR PUBLICACION'),
('EDITAR PUBLICACION'),
('COMPRAR'),
('HISTORIAL DE CLIENTE'),
('CANJE Y ADMINISTRACIOND DE PUNTOS'),
('GENERAR RENDICION DE COMISIONES'),
('LISTADO ESTADISTICO');

--Asigno Funcionalidades a Roles
INSERT INTO RJT.Rol_Funcionalidad(rol_id, fun_id, estado)
VALUES
(1,1,1),(1,2,1),(1,3,1),(1,4,1),(1,5,1),(1,11,1),(1,12,1),
(2,6,1),(2,7,1),
(3,8,1),(3,9,1),(3,10,1)
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'RJT.ENCRIPTAR')
AND type in (N'FN', N'IF',N'TF', N'FS', N'FT'))
DROP FUNCTION RJT.ENCRIPTAR
GO

create function RJT.ENCRIPTAR (@Password nvarchar(255))
returns nvarchar(255)
as
begin 
	return HASHBYTES('SHA2_256',@Password)
end
go

IF OBJECT_ID('RJT.USUARIO_SEQ') IS NOT NULL
DROP SEQUENCE RJT.USUARIO_SEQ
CREATE SEQUENCE RJT.USUARIO_SEQ START WITH 1 INCREMENT BY 1;
GO

SET IDENTITY_INSERT RJT.usuario ON;
--Creo Usuario Admin
INSERT INTO RJT.Usuario(usu_id,usu_usuario, usu_password)
VALUES
(next value for RJT.USUARIO_SEQ, 'admin',RJT.ENCRIPTAR('w23e'))
SET IDENTITY_INSERT RJT.usuario OFF;

INSERT INTO RJT.Rol_Usuario(rol_id, usu_id, estado)
VALUES
(1,1,1),(2,1,1),(3,1,1)
GO

IF OBJECT_ID('RJT.Z_MIGRACION_CLIENTES', 'P') IS NOT NULL
DROP PROCEDURE RJT.Z_MIGRACION_CLIENTES
GO

IF OBJECT_ID('RJT.DIRECCION_SEQ') IS NOT NULL
DROP SEQUENCE RJT.DIRECCION_SEQ
CREATE SEQUENCE RJT.DIRECCION_SEQ START WITH 1 INCREMENT BY 1;
GO

/* RJT.MIGRAR_CLIENTES */

CREATE PROCEDURE RJT.Z_MIGRACION_CLIENTES     
AS 
BEGIN		
	DECLARE @MIGRA_CLIENTE_TEMP TABLE 
	(
	cli_nro_doc CHAR(8),
	cli_cuil CHAR(14),
	cli_apellido NVARCHAR(30),
	cli_nombre NVARCHAR(30),
	cli_tipo_doc CHAR(3),
	cli_fecha_nac DATETIME,	
	cli_fecha_creacion DATETIME,	
	usu_usuario NVARCHAR(30),
	usu_password NVARCHAR(255),
	usu_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR RJT.USUARIO_SEQ,
	dir_mail NVARCHAR(50),
	dir_calle NVARCHAR(70),
	dir_num CHAR(5),
	dir_piso CHAR(2),
	dir_dpto CHAR(2),
	dir_cp CHAR(4),
	dir_localidad NVARCHAR(50),
	dir_telefono NVARCHAR(18),
	dir_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR RJT.DIRECCION_SEQ
	);
	--Tabla temporal
	INSERT INTO @MIGRA_CLIENTE_TEMP 
	(cli_nro_doc,cli_tipo_doc,cli_apellido,cli_nombre,cli_fecha_nac,
	usu_usuario,usu_password,
	dir_mail,dir_calle,dir_num,dir_piso,dir_dpto,dir_cp)
	SELECT DISTINCT(Cli_Dni),'DNI',Cli_Apeliido,Cli_Nombre,Cli_Fecha_Nac,Cli_Dni,RJT.ENCRIPTAR(cast(Cli_Dni as varchar(255))),
	Cli_Mail,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal
		   FROM GD_ESQUEMA.MAESTRA
	WHERE Cli_Dni IS NOT NULL

	--Usuario
	SET IDENTITY_INSERT RJT.usuario ON;
	INSERT INTO RJT.usuario(usu_id,usu_usuario,usu_password,usu_cant_int_fallidos,usu_estado)
	SELECT 
	usu_id,usu_usuario,usu_password,0,1
	FROM @MIGRA_CLIENTE_TEMP;
	SET IDENTITY_INSERT RJT.usuario OFF;
	--Se asigna rol Cliente
	insert into RJT.Rol_Usuario(usu_id,rol_id,estado)
	select usu_id,3,1 from @MIGRA_CLIENTE_TEMP
	--Domicilio
	SET IDENTITY_INSERT RJT.Direccion ON;
	INSERT INTO RJT.Direccion(dir_id,DIR_CALLE,DIR_NUM,DIR_PISO,DIR_DTO,DIR_CP,DIR_MAIL)
	SELECT 
	dir_id,dir_calle,dir_num,dir_piso,dir_dpto,dir_cp,dir_mail
	FROM @MIGRA_CLIENTE_TEMP;
	SET IDENTITY_INSERT RJT.Direccion OFF;
	--Cliente
	INSERT INTO RJT.CLIENTE(cli_nro_doc,cli_tipo_doc,cli_apellido,cli_nombre,cli_fecha_nac,cli_fecha_creacion,cli_usu_id,cli_direccion,cli_ptos,cli_estado)
	SELECT cli_nro_doc,cli_tipo_doc,cli_apellido,cli_nombre,cli_fecha_nac,GETDATE(),usu_id,dir_id,0,1
	FROM @MIGRA_CLIENTE_TEMP;

END;
GO

EXEC RJT.Z_MIGRACION_CLIENTES;
GO

IF OBJECT_ID('RJT.Z_MIGRACION_EMPRESAS', 'P') IS NOT NULL
DROP PROCEDURE RJT.Z_MIGRACION_EMPRESAS
GO

/* RJT.Z_MIGRACION_EMPRESAS */

CREATE PROCEDURE RJT.Z_MIGRACION_EMPRESAS     
AS 
BEGIN		
	DECLARE @MIGRA_EMPRESA_TEMP TABLE 
	(
	emp_razon_social NVARCHAR(50),
	emp_cuit CHAR(12),	
	usu_usuario NVARCHAR(30),
	usu_password NVARCHAR(255),
	usu_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR RJT.USUARIO_SEQ,
	dir_mail NVARCHAR(50),
	dir_calle NVARCHAR(70),
	dir_num CHAR(5),
	dir_piso CHAR(2),
	dir_dpto CHAR(2),
	dir_cp CHAR(4),
	dir_localidad NVARCHAR(50),
	dir_telefono NVARCHAR(18),
	dir_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR RJT.DIRECCION_SEQ
	);
	--Tabla temporal
	INSERT INTO @MIGRA_EMPRESA_TEMP 
	(emp_cuit,emp_razon_social,
	usu_usuario,usu_password,
	dir_mail,dir_calle,dir_num,dir_piso,dir_dpto,dir_cp)
	SELECT DISTINCT(Espec_Empresa_Cuit),Espec_Empresa_Razon_Social,RJT.MODIFICA_CUIT(Espec_Empresa_Cuit),RJT.ENCRIPTAR(cast(RJT.MODIFICA_CUIT(Espec_Empresa_Cuit) as varchar(255))),
	Espec_Empresa_Mail,Espec_Empresa_Dom_Calle,Espec_Empresa_Nro_Calle,Espec_Empresa_Piso,Espec_Empresa_Depto,Espec_Empresa_Cod_Postal
		   FROM GD_ESQUEMA.MAESTRA
	WHERE Espec_Empresa_Cuit IS NOT NULL

	--Se quita los guiones de los CUIT
	UPDATE @MIGRA_EMPRESA_TEMP SET emp_cuit = RJT.MODIFICA_CUIT(emp_cuit)

	--Usuario
	SET IDENTITY_INSERT RJT.usuario ON;
	INSERT INTO RJT.usuario(usu_id,usu_usuario,usu_password,usu_cant_int_fallidos,usu_estado)
	SELECT 
	usu_id,usu_usuario,usu_password,0,1
	FROM @MIGRA_EMPRESA_TEMP;
	SET IDENTITY_INSERT RJT.usuario OFF;
	--Se asigna rol Empresa
	insert into RJT.Rol_Usuario(usu_id,rol_id,estado)
	select usu_id,2,1 from @MIGRA_EMPRESA_TEMP
	--Domicilio
	SET IDENTITY_INSERT RJT.Direccion ON;
	INSERT INTO RJT.Direccion(dir_id,DIR_CALLE,DIR_NUM,DIR_PISO,DIR_DTO,DIR_CP,DIR_MAIL)
	SELECT 
	dir_id,dir_calle,dir_num,dir_piso,dir_dpto,dir_cp,dir_mail
	FROM @MIGRA_EMPRESA_TEMP;
	SET IDENTITY_INSERT RJT.Direccion OFF;
	--Empresa
	INSERT INTO RJT.Empresa(emp_cuit,emp_razon_social,emp_usu_id,emp_direccion,emp_estado)
	SELECT emp_cuit,emp_razon_social,usu_id,dir_id,1
	FROM @MIGRA_EMPRESA_TEMP;

END;
GO

EXEC RJT.Z_MIGRACION_EMPRESAS;
GO

--CREO RUBROS
INSERT INTO RJT.Rubro (rub_desc)
VALUES ('Sin Rubro'),('Teatral'),('Musical')
GO

--TipoPremio
INSERT INTO RJT.TipoPremio (tp_desc,tp_puntos)
VALUES ('Sofa',1000),('Mesa',500),('Silla',100)
GO

--Creo Medios de pago
INSERT INTO RJT.MedioPago (mp_desc)
select distinct Forma_Pago_Desc
FROM GD_ESQUEMA.MAESTRA
where Forma_Pago_Desc is not null

INSERT INTO RJT.MedioPago (mp_desc)
VALUES ('Tarjeta')
GO

SET IDENTITY_INSERT RJT.TipoUbicacion ON;
--TipoUbicacion
INSERT INTO RJT.TipoUbicacion (tu_id,tu_desc)
select distinct Ubicacion_Tipo_Codigo, Ubicacion_Tipo_Descripcion
FROM GD_ESQUEMA.MAESTRA
where Ubicacion_Tipo_Codigo is not null
GO
SET IDENTITY_INSERT RJT.TipoUbicacion OFF;

--CREO GRADOS DE PUBLICACION 
INSERT INTO RJT.GradoPublicacion (gra_desc,gra_comision,gra_peso,gra_estado)
VALUES ('Baja',5,1,1), ('Media',10,2,1), ('Alta',20,3,1)


--Creo Publicaciones
SET IDENTITY_INSERT RJT.Publicacion ON;
 INSERT INTO RJT.Publicacion ( pub_id,pub_estado,pub_desc,pub_fecha_espec,pub_fecha_pub,pub_usu,pub_dir,pub_rubro, pub_gra)
 select distinct Espectaculo_Cod,Espectaculo_Estado,Espectaculo_Descripcion,Espectaculo_Fecha,Espectaculo_Fecha_Venc
 				,e.emp_usu_id,null , 1 , 2
 from gd_esquema.Maestra m
join RJT.Empresa E on e.emp_cuit = m.Espec_Empresa_Cuit
order by Espectaculo_Cod
SET IDENTITY_INSERT RJT.Publicacion OFF;
GO

--Creo Facturas

INSERT INTO RJT.Factura (fact_nro,fact_fecha,fact_total,fact_emp)
select distinct Factura_Nro,Factura_Fecha,Factura_Total, e.emp_id
from gd_esquema.Maestra
join RJT.Empresa e on e.emp_cuit = Espec_Empresa_Cuit
where Factura_Nro is not null
order by Factura_Nro


--Creo ITEM Facturas

insert into RJT.Item_Factura (item_fact_nro,item_fact_monto,item_fact_desc)
select Factura_Nro,Item_Factura_Monto,Item_Factura_Descripcion
from gd_esquema.Maestra
where Factura_Nro is not null
order by Factura_Nro
GO

--CREO UBICACIONES/COMPRAS

IF OBJECT_ID('RJT.Z_MIGRACION_COMPRAS_UBICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.Z_MIGRACION_COMPRAS_UBICACION
GO
IF OBJECT_ID('RJT.COMPRA_SEQ') IS NOT NULL
DROP SEQUENCE RJT.COMPRA_SEQ
CREATE SEQUENCE RJT.COMPRA_SEQ START WITH 1 INCREMENT BY 1;
GO

CREATE PROCEDURE RJT.Z_MIGRACION_COMPRAS_UBICACION  
AS 
BEGIN
	declare @MIGRA_UBICACION_COMPRA_TEMP table
	(
	ubi_tipo NUMERIC(10,0),
	ubi_precio NUMERIC(10,2),
	ubi_sin_numeric BIT,
	ubi_asiento CHAR(5),
	ubi_fila CHAR(5),
	ubi_pub NUMERIC(18,0),
	com_id NUMERIC(18,0) default NEXT VALUE FOR RJT.COMPRA_SEQ,
	com_fecha DATETIME,
	com_cli NUMERIC(18,0),
	com_mp NUMERIC(18,0),
	com_cant INT,
	com_fact NUMERIC(18,0)
	);
	
	--INSERT UBICACION CON COMPRA CON RENDICION
	INSERT INTO @MIGRA_UBICACION_COMPRA_TEMP
	(ubi_tipo,ubi_precio,ubi_sin_numeric,ubi_asiento,ubi_fila,ubi_pub,com_fecha,com_cli,com_mp,com_cant,com_fact)
	SELECT tu.tu_id, Ubicacion_Precio, Ubicacion_Sin_numerar, Ubicacion_Asiento, Ubicacion_Fila,Espectaculo_Cod, Compra_Fecha,c.cli_id,mp.mp_id,Compra_Cantidad,Factura_Nro
	FROM GD_ESQUEMA.MAESTRA
	join RJT.Cliente C on c.cli_nro_doc = Cli_Dni
	join RJT.MedioPago MP on mp.mp_desc = Forma_Pago_Desc
	join RJT.TipoUbicacion TU on tu.tu_desc = Ubicacion_Tipo_Descripcion
	where Cli_Dni is not null and Factura_Nro is not null

	--INSERT UBICACION CON COMPRA SIN RENDICION
	INSERT INTO @MIGRA_UBICACION_COMPRA_TEMP
	(ubi_tipo,ubi_precio,ubi_sin_numeric,ubi_asiento,ubi_fila,ubi_pub,com_fecha,com_cli,com_mp,com_cant)
	SELECT tu.tu_id, Ubicacion_Precio, Ubicacion_Sin_numerar, Ubicacion_Asiento, Ubicacion_Fila,Espectaculo_Cod, Compra_Fecha,c.cli_id,mp.mp_id,Compra_Cantidad
	FROM GD_ESQUEMA.MAESTRA
	join RJT.Cliente C on c.cli_nro_doc = Cli_Dni
	join RJT.MedioPago MP on mp.mp_desc = Forma_Pago_Desc
	join RJT.TipoUbicacion TU on tu.tu_desc = Ubicacion_Tipo_Descripcion
	where Cli_Dni is not null and (select count(*) from @MIGRA_UBICACION_COMPRA_TEMP where ubi_asiento=Ubicacion_Asiento and ubi_fila=Ubicacion_Fila and ubi_pub=Espectaculo_Cod) =0;

	--INSERT UBICACION SIN COMPRA
	INSERT INTO @MIGRA_UBICACION_COMPRA_TEMP
	(ubi_tipo,ubi_precio,ubi_sin_numeric,ubi_asiento,ubi_fila,ubi_pub,com_id,com_fecha,com_cli,com_mp,com_cant)
	SELECT tu.tu_id, Ubicacion_Precio, Ubicacion_Sin_numerar, Ubicacion_Asiento, Ubicacion_Fila,Espectaculo_Cod,null,null,null,null,null
	FROM GD_ESQUEMA.MAESTRA M
	join RJT.TipoUbicacion TU on tu.tu_desc = Ubicacion_Tipo_Descripcion
	where Cli_Dni is null and (select count(*) from @MIGRA_UBICACION_COMPRA_TEMP where ubi_asiento=M.Ubicacion_Asiento and ubi_fila=M.Ubicacion_Fila and ubi_pub=M.Espectaculo_Cod) =0;

	--COMPRA
	SET IDENTITY_INSERT RJT.COMPRA ON;
	INSERT INTO RJT.COMPRA
	(com_id,com_fecha,com_cli,com_mp,com_cant,com_total,com_fact)
	SELECT com_id,com_fecha,com_cli,com_mp,com_cant,ubi_precio,com_fact
	FROM @MIGRA_UBICACION_COMPRA_TEMP where com_id is not null;
	SET IDENTITY_INSERT RJT.COMPRA OFF;
	--UBICACION
	INSERT INTO RJT.Ubicacion(ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_asiento,ubi_fila,ubi_pub,ubi_com)
	SELECT ubi_tipo,ubi_precio,ubi_sin_numeric,ubi_asiento,ubi_fila,ubi_pub,com_id
	FROM @MIGRA_UBICACION_COMPRA_TEMP;

END;
GO

EXEC RJT.Z_MIGRACION_COMPRAS_UBICACION;
GO

--Finalizar publicaciones con todas las ubicaciones compradas
update RJT.Publicacion set pub_estado='Finalizada' where pub_id in (

select pub_id from RJT.Publicacion p
group by pub_id 
having (select count(ubi_id) from RJT.Publicacion join RJT.Ubicacion on pub_id = ubi_pub where pub_id=p.pub_id
group by pub_id) = (select count(ubi_id) from RJT.Publicacion join RJT.Ubicacion on pub_id = ubi_pub where ubi_com is not null and pub_id=p.pub_id
group by pub_id)
)
GO

--Procedures
create procedure RJT.BUSCAR_USUARIO @Usuario varchar(30), @Password nvarchar(255)
as
begin 
	declare @estado bit
	declare @cant_int_fallido int
	select @estado = usu_Estado from RJT.USUARIO where usu_usuario =  @Usuario and usu_password = RJT.ENCRIPTAR (@Password)
	select @cant_int_fallido = usu_cant_int_fallidos from RJT.USUARIO where usu_usuario = @Usuario

	if not exists(select 1 from RJT.USUARIO where usu_usuario = @Usuario)
		select 0 as estado
	if exists(select 1 from RJT.USUARIO where usu_usuario = @Usuario and usu_password <> RJT.ENCRIPTAR (@Password))
		if (@cant_int_fallido = 3) 
			begin
				update RJT.USUARIO set usu_ESTADO = 0 where usu_usuario = @Usuario
				select 2 as estado
			end
		else select 1 as estado
	if @estado = 0
		select 2 as estado
	if @estado = 1
		begin
			if @cant_int_fallido = 1 or @cant_int_fallido = 2
				update RJT.USUARIO set usu_cant_int_fallidos = 0 where usu_usuario = @Usuario
			select 3 as estado
		end
end
go

create procedure RJT.REG_INTENTO_FALLIDO @Usuario varchar(50)
as
begin
	declare @cant_int_fallido int
	select @cant_int_fallido = usu_cant_int_fallidos from RJT.USUARIO where usu_usuario = @Usuario

	if @cant_int_fallido between 0 and 2
		update RJT.USUARIO set usu_cant_int_fallidos = usu_cant_int_fallidos + 1 where usu_usuario = @Usuario
end
go

create procedure RJT.OBTENER_ID_USUARIO @USUARIO varchar(50)
as
begin
	select usu_id from RJT.USUARIO where usu_usuario = @USUARIO
end
go

create procedure RJT.OBTENER_USUARIO @ID INT
as
begin
	declare @USER VARCHAR(250)
	select @USER = usu_usuario from RJT.USUARIO where usu_id = @ID
	RETURN @USER
end
go

create procedure RJT.OBTENER_CANT_ROLES @ID_USU int
as
begin
	select count(usu_id) from RJT.ROL_USUARIO where usu_id = @ID_USU and ESTADO = 1  
end
go

create procedure RJT.GUARDAR_ROL @nombre varchar(25), @estado bit
as
begin
	insert into RJT.ROL(rol_nombre,rol_estado) values (@nombre,@estado);
end
go

create procedure RJT.ELIMINAR_ROL @ID int
as
begin
	update RJT.ROL set rol_ESTADO = 0 where rol_id = @ID;
end
go

create procedure RJT.OBTENER_ID_X_NOMBRE @nombre varchar(25)
as
begin
	select rol_id from RJT.ROL where rol_nombre = @nombre 
end
go

create procedure RJT.AGREGAR_FUNCIONALIDAD_A_ROL @ID_ROL INT, @ID_FUNCIONALIDAD INT
as
begin
	if exists (select 1 from RJT.Rol_Funcionalidad where rol_id=@ID_ROL and fun_id=@ID_FUNCIONALIDAD)
	begin
		update RJT.Rol_Funcionalidad set estado = 1 where rol_id=@ID_ROL and fun_id=@ID_FUNCIONALIDAD;
	end
	else
	begin
		insert into RJT.ROL_FUNCIONALIDAD (rol_id,fun_id,estado) values (@ID_ROL,@ID_FUNCIONALIDAD,1);
	end	
end
go

create procedure RJT.ELIMINAR_FUNCIONALIDAD_A_ROL @ID_ROL INT, @ID_FUNCIONALIDAD INT
as
begin
	update RJT.Rol_Funcionalidad set estado = 0 where rol_id=@ID_ROL and fun_id=@ID_FUNCIONALIDAD;
end
go

create procedure RJT.LISTAR_FUNCIONES_X_ROL @ID_ROL int
as
begin
	select f.* from RJT.ROL_FUNCIONALIDAD as rxf inner join RJT.FUNCIONALIDAD as f
		   on rxf.fun_id = f.fun_id where rxf.rol_id = @ID_ROL and rxf.estado = 1;
end
go

create procedure RJT.LISTAR_FUNCIONES_X_ROL_NO_ASIGNADAS @ID_ROL int
as
begin
	select * from RJT.FUNCIONALIDAD except 
									     select f.* from RJT.ROL_FUNCIONALIDAD as rxf inner join RJT.FUNCIONALIDAD as f
										 on rxf.fun_id = f.fun_id where rxf.rol_id = @ID_ROL and rxf.estado = 1;
end
go

create procedure RJT.OBTENER_ROLES_ACTIVOS @ID int
as
begin
	select R.rol_NOMBRE,R.rol_id from RJT.ROL R inner join RJT.ROL_USUARIO RXU 
		on R.rol_id = RXU.rol_id where RXU.usu_id = @ID and R.rol_ESTADO = 1 
end
go

create procedure RJT.OBTENER_FUNCIONALIDADES_ROL @ID_ROL int
as
begin
	select F.fun_id from RJT.FUNCIONALIDAD F inner join RJT.ROL_FUNCIONALIDAD RXF 
		on F.fun_id = RXF.fun_id where RXF.rol_id = @ID_ROL and F.fun_visible = 1
end
go

--Crear Usuario
create procedure RJT.CREAR_USUARIO @USU_USUARIO varchar(30), @USU_PASSWORD nvarchar(255), @USU_CANT_INT_FALLIDOS int, @USU_ESTADO bit
as
begin
	insert into RJT.USUARIO values (@USU_USUARIO,RJT.ENCRIPTAR(@USU_PASSWORD),@USU_CANT_INT_FALLIDOS,@USU_ESTADO)
end
go
--Crear Direccion
create procedure RJT.CREAR_DIRECCION @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_PISO char(2), @DIR_DTO char(2), @DIR_CP char(4), @DIR_LOCALIDAD varchar(50), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	insert into RJT.DIRECCION values (@DIR_CALLE,@DIR_NUM,@DIR_PISO,@DIR_DTO,@DIR_CP,@DIR_LOCALIDAD,@DIR_TELEFONO,@DIR_MAIL)
end
go

--Obtener ID Direccion
create procedure RJT.OBTENER_ID_DIRECCION @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_PISO char(2), @DIR_DTO char(2), @DIR_CP char(4) ,@DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50), @DIR_LOCALIDAD varchar(50)
as
begin
	select dir_id from RJT.DIRECCION where dir_calle=@DIR_CALLE and dir_num = @DIR_NUM and dir_piso = @DIR_PISO and dir_dto = @DIR_DTO and DIR_CP=@DIR_CP and DIR_TELEFONO=@DIR_TELEFONO and DIR_MAIL=@DIR_MAIL and DIR_LOCALIDAD=@DIR_LOCALIDAD
end
go
--Crear Cliente
create procedure RJT.CREAR_CLIENTE @CLI_USU_ID int, @CLI_NOMBRE varchar(30), @CLI_APELLIDO varchar(30), @CLI_TIPO_DOC char(3), @CLI_NRO_DOC char(10), @CLI_CUIL char(11), @CLI_FECHA_NAC DateTime, @CLI_FECHA_CREACION DateTime, @CLI_PTOS int, @CLI_TARJ varchar(19), @CLI_DIRECCION int
as
begin
	insert into RJT.CLIENTE(CLI_USU_ID,CLI_NOMBRE,CLI_APELLIDO,CLI_TIPO_DOC,CLI_NRO_DOC,CLI_CUIL,CLI_FECHA_NAC,CLI_FECHA_CREACION,CLI_PTOS,CLI_TARJ,CLI_DIRECCION,cli_estado) values (@CLI_USU_ID,@CLI_NOMBRE,@CLI_APELLIDO,@CLI_TIPO_DOC,@CLI_NRO_DOC,@CLI_CUIL,@CLI_FECHA_NAC,@CLI_FECHA_CREACION,@CLI_PTOS,@CLI_TARJ,@CLI_DIRECCION,1)
end
go
--Crear Empresa
create procedure RJT.CREAR_EMPRESA @EMP_USU_ID int, @EMP_RAZON_SOCIAL varchar(50), @EMP_CUIT char(11), @EMP_DIRECCION int
as
begin
	insert into RJT.EMPRESA(EMP_USU_ID,EMP_RAZON_SOCIAL,EMP_CUIT,EMP_DIRECCION,EMP_ESTADO) values (@EMP_USU_ID,@EMP_RAZON_SOCIAL,@EMP_CUIT,@EMP_DIRECCION,1)
end
go
--Crear RolxUsuario
create procedure RJT.CREAR_ROLxUSUARIO @USU_ID int, @ROL_ID int
as
begin
	INSERT INTO RJT.Rol_Usuario(rol_id, usu_id, estado)
	VALUES (@ROL_ID,@USU_ID,1)
end
go

IF OBJECT_ID('RJT.LISTAR_CLIENTES_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_CLIENTES_EXISTENTES
GO

create procedure RJT.LISTAR_CLIENTES_EXISTENTES
@CLI_NOMBRE VARCHAR(30), 
@CLI_APELLIDO VARCHAR(30),
@DIR_MAIL VARCHAR(50),
@CLI_NRO_DOC CHAR(10)
as
begin
	select  
			C.CLI_ID as id,
			C.CLI_NOMBRE as Nombre,
			C.CLI_APELLIDO as Apellido,
			D.DIR_MAIL as Mail,
			C.CLI_TIPO_DOC as Tipo,
			C.CLI_NRO_DOC as Documento,
			C.CLI_ESTADO as Estado
	from RJT.CLIENTE C inner join RJT.DIRECCION D
	on c.cli_direccion = d.dir_id
		WHERE C.CLI_NOMBRE LIKE ISNULL('%' + @CLI_NOMBRE + '%', '%')
              AND C.CLI_APELLIDO LIKE ISNULL('%' + @CLI_APELLIDO + '%', '%')
              AND D.DIR_MAIL LIKE ISNULL('%' + @DIR_MAIL + '%', '%')
              AND (@CLI_NRO_DOC is null or C.CLI_NRO_DOC = @CLI_NRO_DOC);
end
go  


IF OBJECT_ID('RJT.LISTAR_EMPRESAS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_EMPRESAS_EXISTENTES
GO

create procedure RJT.LISTAR_EMPRESAS_EXISTENTES
@EMP_RAZON_SOCIAL VARCHAR(50), 
@DIR_MAIL VARCHAR(50),
@EMP_CUIT CHAR(12)
as
begin
	select  
			E.emp_id as id,
			E.emp_razon_social as RazonSocial,
			D.DIR_MAIL as Mail,
			E.emp_cuit as CUIT,
			E.emp_estado as Estado
	from RJT.EMPRESA E inner join RJT.DIRECCION D
	on e.emp_direccion = d.dir_id
		WHERE E.emp_razon_social LIKE ISNULL('%' + @EMP_RAZON_SOCIAL + '%', '%')
              AND D.DIR_MAIL LIKE ISNULL('%' + @DIR_MAIL + '%', '%')
              AND (@EMP_CUIT is null or e.emp_cuit = @EMP_CUIT);
			  
end
go

IF OBJECT_ID('RJT.OBTENER_EMPRESA', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_EMPRESA
GO

create procedure RJT.OBTENER_EMPRESA @ID int
as
begin
	SELECT emp_razon_social,emp_cuit FROM rjt.Empresa where emp_id = @ID
end
GO

create procedure RJT.OBTENER_CLIENTE @ID int
as
begin
	SELECT cli_apellido,cli_nombre,cli_tipo_doc,cli_nro_doc,cli_tarj,cli_cuil,cli_fecha_nac FROM rjt.Cliente where cli_id = @ID
end
GO

create procedure RJT.OBTENER_DIRECCION @ID int
as
begin
	SELECT dir_calle,dir_num,dir_piso,dir_dto,dir_cp,dir_localidad,dir_telefono,dir_mail FROM rjt.Direccion where dir_id = @ID
end
GO

IF OBJECT_ID('RJT.MODIFICAR_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE RJT.MODIFICAR_CLIENTE
GO

CREATE PROCEDURE RJT.MODIFICAR_CLIENTE
@CLI_ID int,
@CLI_NOMBRE VARCHAR(30), 
@CLI_APELLIDO VARCHAR(30),
@CLI_TIPO_DOC CHAR(3),
@CLI_NRO_DOC CHAR(10),
@CLI_CUIL CHAR(11), 
@CLI_FECHA_NAC DATETIME,
@CLI_TARJ VARCHAR(19)
AS
BEGIN TRANSACTION
	UPDATE RJT.CLIENTE SET cli_nombre = @CLI_NOMBRE, cli_apellido = @CLI_APELLIDO, cli_tipo_doc = @CLI_TIPO_DOC, cli_nro_doc = @CLI_NRO_DOC, cli_cuil = @CLI_CUIL, cli_fecha_nac = @CLI_FECHA_NAC, cli_tarj = @CLI_TARJ WHERE cli_id = @CLI_ID
COMMIT
GO 

IF OBJECT_ID('RJT.MODIFICAR_EMPRESA', 'P') IS NOT NULL
DROP PROCEDURE RJT.MODIFICAR_EMPRESA
GO

CREATE PROCEDURE RJT.MODIFICAR_EMPRESA
@EMP_ID int,
@EMP_RAZON_SOCIAL VARCHAR(50), 
@EMP_CUIT CHAR(11)
AS
BEGIN TRANSACTION
	UPDATE RJT.EMPRESA SET emp_razon_social = @EMP_RAZON_SOCIAL, emp_cuit = @EMP_CUIT WHERE emp_id = @EMP_ID
COMMIT
GO 


create procedure RJT.MODIFICAR_DIRECCION @DIR_ID int, @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_PISO char(2), @DIR_DTO char(2), @DIR_CP char(4), @DIR_LOCALIDAD varchar(50), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	UPDATE RJT.DIRECCION SET dir_calle= @DIR_CALLE,dir_num= @DIR_NUM,dir_piso= @DIR_PISO,dir_dto= @DIR_DTO,dir_cp= @DIR_CP,dir_localidad= @DIR_LOCALIDAD,dir_telefono= @DIR_TELEFONO,dir_mail= @DIR_MAIL WHERE dir_id = @DIR_ID
end
go

IF OBJECT_ID('RJT.OBTENERGRADOS', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENERGRADOS
GO

create procedure RJT.OBTENERGRADOS
AS
BEGIN 
	select gra_id,gra_desc from Rjt.GradoPublicacion
END
GO

IF OBJECT_ID('RJT.OBTENERRUBROS', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENERRUBROS
GO

create procedure RJT.OBTENERRUBROS
AS
BEGIN 
	select rub_id,rub_desc from Rjt.Rubro
END
GO

IF OBJECT_ID('RJT.OBTENERTIPOSUBICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENERTIPOSUBICACION
GO

create procedure RJT.OBTENERTIPOSUBICACION
AS
BEGIN 
	select tu_id,tu_desc from Rjt.TipoUbicacion
END
GO

IF OBJECT_ID('RJT.CREAR_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_PUBLICACION
GO

--Crear Publicacion
create procedure RJT.CREAR_PUBLICACION 
@pub_estado varchar(10), 
@pub_desc varchar(400), 
@pub_fecha_pub datetime, 
@pub_fecha_espec datetime, 
@pub_rubro int,
@pub_dir int,
@pub_gra int,
@pub_usu int
as
begin
	insert into RJT.Publicacion(pub_estado,pub_desc,pub_fecha_pub,pub_fecha_espec,pub_rubro,pub_dir,pub_gra,pub_usu) values (@pub_estado,@pub_desc,@pub_fecha_pub,@pub_fecha_espec,@pub_rubro,@pub_dir,@pub_gra,@pub_usu)
end
go

IF OBJECT_ID('RJT.OBTENER_ID_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_ID_PUBLICACION
GO

create procedure RJT.OBTENER_ID_PUBLICACION @pub_desc varchar(400), @pub_dir int, @pub_usu int, @pub_fecha_espec datetime
as
begin
	select pub_id from RJT.Publicacion where pub_desc=@pub_desc and pub_dir = @pub_dir and pub_usu = @pub_usu and pub_fecha_espec = @pub_fecha_espec
end
go

IF OBJECT_ID('RJT.LISTAR_PUBLICACIONES_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_PUBLICACIONES_EXISTENTES
GO

create procedure RJT.LISTAR_PUBLICACIONES_EXISTENTES
@PUB_USU int, 
@PUB_ESTADO1 VARCHAR(10),
@PUB_ESTADO2 VARCHAR(10)
as
begin
	select  p.pub_id as id,
			p.pub_desc as Descripcion,
			p.pub_estado as Estado,
			p.pub_fecha_espec as FechaEspectaculo,
			p.pub_fecha_pub as FechaPublicacion
	from RJT.Publicacion p
		where p.pub_usu = @PUB_USU and (p.pub_estado = @PUB_ESTADO1 or p.pub_estado = @PUB_ESTADO2)
end
go

IF OBJECT_ID('RJT.OBTENER_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_PUBLICACION
GO

create procedure RJT.OBTENER_PUBLICACION @ID int
as
begin
	SELECT pub_id,pub_estado,pub_desc,pub_fecha_pub,pub_fecha_espec,pub_rubro,pub_dir,pub_gra,pub_usu FROM rjt.Publicacion where pub_id = @ID
end
GO

IF OBJECT_ID('RJT.CREAR_UBICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_UBICACION
GO

--Crear Ubicación
create procedure RJT.CREAR_UBICACION
@ubi_tipo varchar(10), 
@ubi_precio numeric(10,2), 
@ubi_sin_numerar bit, 
@ubi_asiento varchar(5),
@ubi_fila varchar(5),
@ubi_pub int
as
begin
	insert into RJT.Ubicacion(ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_asiento,ubi_fila,ubi_pub) values (@ubi_tipo,@ubi_precio,@ubi_sin_numerar,@ubi_asiento,@ubi_fila,@ubi_pub)
end
go

IF OBJECT_ID('RJT.CREAR_UBICACION_SIN_NUMERAR', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_UBICACION_SIN_NUMERAR
GO

--Crear Ubicación sin Numerar
create procedure RJT.CREAR_UBICACION_SIN_NUMERAR
@ubi_tipo varchar(10), 
@ubi_precio numeric(10,2), 
@ubi_sin_numerar bit, 
@ubi_pub int
as
begin
	insert into RJT.Ubicacion(ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_pub) values (@ubi_tipo,@ubi_precio,@ubi_sin_numerar,@ubi_pub)
end
go

IF OBJECT_ID('RJT.MODIFICAR_ESTADO_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.MODIFICAR_ESTADO_PUBLICACION
GO

CREATE PROCEDURE RJT.MODIFICAR_ESTADO_PUBLICACION
@PUB_ID int,
@PUB_ESTADO VARCHAR(10),
@pub_fecha_pub datetime
AS
BEGIN TRANSACTION
	UPDATE RJT.Publicacion SET pub_estado = @PUB_ESTADO,pub_fecha_pub = @pub_fecha_pub WHERE pub_id = @PUB_ID
COMMIT
GO 

IF OBJECT_ID('RJT.OBTENER_UBICACIONES', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_UBICACIONES
GO

create procedure RJT.OBTENER_UBICACIONES @ID int
as
begin
	SELECT ubi_id,ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_asiento,ubi_fila,ubi_pub FROM rjt.Ubicacion where ubi_pub = @ID
end
GO

IF OBJECT_ID('RJT.MODIFICAR_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.MODIFICAR_PUBLICACION
GO

--Modificar Publicacion
create procedure RJT.MODIFICAR_PUBLICACION
@pub_id int, 
@pub_estado varchar(10), 
@pub_desc varchar(400), 
@pub_fecha_pub datetime, 
@pub_fecha_espec datetime, 
@pub_rubro int,
@pub_gra int
as
begin
	UPDATE RJT.Publicacion SET pub_estado=@pub_estado,pub_desc=@pub_desc,pub_fecha_pub=@pub_fecha_pub,pub_fecha_espec=@pub_fecha_espec,pub_rubro=@pub_rubro,pub_gra=@pub_gra where pub_id=@pub_id
end
go

IF OBJECT_ID('RJT.VALIDAR_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.VALIDAR_PUBLICACION
GO

--Validar Publicacion
create procedure RJT.VALIDAR_PUBLICACION
@pub_desc varchar(400), 
@pub_fecha_espec datetime
as
begin
	SELECT 1 FROM RJT.PUBLICACION WHERE pub_desc = @pub_desc and pub_fecha_espec = @pub_fecha_espec
end
go



IF OBJECT_ID('RJT.MODIFICAR_UBICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.MODIFICAR_UBICACION
GO

--Modificar Ubicación
create procedure RJT.MODIFICAR_UBICACION
@ubi_id int,
@ubi_tipo varchar(10),  
@ubi_precio numeric(10,2), 
@ubi_sin_numerar bit, 
@ubi_asiento varchar(5),
@ubi_fila varchar(5)
as
begin 
	UPDATE RJT.Ubicacion SET ubi_tipo=@ubi_tipo,ubi_precio=@ubi_precio,ubi_sin_numerar=@ubi_sin_numerar,ubi_asiento=@ubi_asiento,ubi_fila=@ubi_fila where ubi_id = @ubi_id
end
go

IF OBJECT_ID('RJT.LISTAR_PUBLICACIONES_PUBLICADAS', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_PUBLICACIONES_PUBLICADAS
GO

--Tipo temporal para tabla rubros
IF type_id('RJT.Rubros') IS NOT NULL
        DROP TYPE RJT.Rubros;
CREATE TYPE RJT.Rubros AS TABLE ( 
  rub_id int
)
GO

create procedure RJT.LISTAR_PUBLICACIONES_PUBLICADAS
(@pub_desc VARCHAR(400),
@pub_fecha_espec_de VARCHAR(23), 
@pub_fecha_espec_hasta VARCHAR(23), 
@rubro RJT.Rubros READONLY)
as
begin
	select  p.pub_id as id,
			p.pub_desc as Descripcion,
			p.pub_fecha_espec as FechaEspectaculo,
			p.pub_fecha_pub as FechaPublicacion
	from RJT.Publicacion p join RJT.GradoPublicacion on pub_gra=gra_id
		where pub_desc LIKE ISNULL('%' + @pub_desc + '%', '%') and (pub_fecha_espec between (SELECT CONVERT(datetime, @pub_fecha_espec_de, 121)) and (SELECT CONVERT(datetime, @pub_fecha_espec_hasta, 121))) and pub_rubro in (select rub_id from @rubro) and pub_estado = 'Publicada'
		order by gra_peso desc
end
go



IF OBJECT_ID('RJT.OBTENER_UBICACIONES_SIN_COMPRA', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_UBICACIONES_SIN_COMPRA
GO

create procedure RJT.OBTENER_UBICACIONES_SIN_COMPRA @ID int,@ubi_tipo int
as
begin
	SELECT ubi_id,ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_asiento,ubi_fila,ubi_pub FROM rjt.Ubicacion where ubi_pub = @ID and ubi_com is null and ubi_tipo=@ubi_tipo
end
GO

IF OBJECT_ID('RJT.OBTENERDESCTIPOUBICACION', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENERDESCTIPOUBICACION
GO

create procedure RJT.OBTENERDESCTIPOUBICACION @ID int
as
begin
	SELECT tu_desc FROM rjt.TipoUbicacion where tu_id = @ID
end
GO

IF OBJECT_ID('RJT.CREAR_COMPRA', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_COMPRA
GO

--Tipo temporal para tabla ubicaciones
IF type_id('RJT.Ubicaciones') IS NOT NULL
        DROP TYPE RJT.Ubicaciones;
CREATE TYPE RJT.Ubicaciones AS TABLE ( 
  ubi_id int,
  ubi_pub int,
  ubi_precio numeric(10,2)
)
GO

create procedure RJT.CREAR_COMPRA
(@cli_id int,
@com_fecha datetime, 
@ubicaciones RJT.Ubicaciones READONLY)
as
begin
	declare @com_cant int
	select @com_cant = (select count(*) from @ubicaciones)
	declare @com_id int	
	declare @com_total numeric(18,2)
	select @com_total = (select sum(ubi_precio) from @ubicaciones)
	--Insert compra
	insert into RJT.Compra(com_fecha,com_cli,com_mp,com_cant,com_total) values (@com_fecha,@cli_id,2,@com_cant,@com_total)

	--Update ubicaciones
	select @com_id = SCOPE_IDENTITY()
	UPDATE RJT.Ubicacion SET ubi_com=@com_id where ubi_id in (select ubi_id from @ubicaciones)

	--Comprobar publicaciones para finalizar de @ubicaciones
	update RJT.Publicacion set pub_estado='Finalizada' where pub_id in (
		select ubi_pub from @ubicaciones u
		group by ubi_pub 
		having (select count(ubi_id) from RJT.Publicacion join RJT.Ubicacion on pub_id = ubi_pub where pub_id=u.ubi_pub 
				group by pub_id) = 
				(select count(ubi_id) from RJT.Publicacion join RJT.Ubicacion on pub_id = ubi_pub where ubi_com is not null and pub_id=u.ubi_pub
				group by pub_id)
			  )
	--Otorgar puntos 10% de compra, extender el vencimiento a un mes de la compra
	declare @cli_puntos int
	select @cli_puntos = ROUND(@com_total*0.1,0,1)
	declare @cli_ptos_venc_nueva datetime
	select @cli_ptos_venc_nueva = (select DATEADD(month, 6, @com_fecha))

	if exists(select cli_ptos_venc from RJT.Cliente where cli_id = @cli_id)
	begin		
		declare @cli_ptos_venc datetime
		select @cli_ptos_venc = (select cli_ptos_venc from RJT.Cliente where cli_id = @cli_id)
		if(@cli_ptos_venc<@com_fecha)
		begin 
			--puntos vencidos, se renuevan
			UPDATE RJT.Cliente SET cli_ptos=@cli_puntos,cli_ptos_venc=@cli_ptos_venc_nueva where cli_id = @cli_id
		end
		else
		begin
			--puntos validos, se suman los nuevos y se renueva fecha de vencimiento
			declare @cli_puntos_anteriores int
			select @cli_puntos_anteriores = (select cli_ptos from RJT.Cliente where cli_id = @cli_id)
			UPDATE RJT.Cliente SET cli_ptos=(@cli_puntos+@cli_puntos_anteriores),cli_ptos_venc=@cli_ptos_venc_nueva where cli_id = @cli_id
		end
	end
	else
	begin
		--no tiene puntos
		UPDATE RJT.Cliente SET cli_ptos=@cli_puntos,cli_ptos_venc=@cli_ptos_venc_nueva where cli_id = @cli_id
	end
end
go

IF OBJECT_ID('RJT.CREAR_TARJETA', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_TARJETA
GO

create procedure RJT.CREAR_TARJETA
@cli_id int,
@cli_tarj char(19)
as
begin
	UPDATE RJT.Cliente SET cli_tarj=@cli_tarj where cli_id = @cli_id
end
go

IF OBJECT_ID('RJT.LISTAR_COMPRAS_A_RENDIR', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_COMPRAS_A_RENDIR
GO

create procedure RJT.LISTAR_COMPRAS_A_RENDIR
as
begin
	select  distinct (com_id) as id,
			e.emp_razon_social as RazonSocial,
			e.emp_cuit as CUIT,
			p.pub_desc as Publicacion,
			com_cant as Cantidad,
			com_total as Total,
			com_fecha as FechaCompra
	from RJT.Compra co join RJT.Ubicacion u on co.com_id = u.ubi_com join RJT.Publicacion p on u.ubi_pub = p.pub_id join RJT.Empresa e on e.emp_usu_id = p.pub_usu
		where com_fact is null
		order by co.com_fecha asc
end
go


IF OBJECT_ID('RJT.RENDIR_COMPRA', 'P') IS NOT NULL
DROP PROCEDURE RJT.RENDIR_COMPRA
GO

--Tipo temporal para tabla ubicaciones
IF type_id('RJT.Compras') IS NOT NULL
        DROP TYPE RJT.Compras;
CREATE TYPE RJT.Compras AS TABLE ( 
  com_id int,
  orden int
)
GO

IF OBJECT_ID('RJT.FACTURA_SEQ') IS NOT NULL
DROP SEQUENCE RJT.FACTURA_SEQ

--Secuenciador a partir de ultima factura
	DECLARE @max int;
SELECT @max = MAX(fact_nro)+1
     FROM RJT.Factura

exec('CREATE SEQUENCE RJT.FACTURA_SEQ 
    START WITH ' + @max +
'   INCREMENT BY 1;');
GO

CREATE PROCEDURE RJT.RENDIR_COMPRA @compras RJT.Compras READONLY, @fact_fecha datetime
AS 
BEGIN
	declare @ITEM_FACT_TEMP table
	(
	com_id NUMERIC(18,0),
	item_fact_monto DECIMAL(18,2),
	emp_id NUMERIC(18,0),
	fact_nro NUMERIC(18,0),
	item_fact_desc VARCHAR(400)
	);

	declare @FACT_TEMP table
	(
	fact_nro NUMERIC(18,0) default NEXT VALUE FOR RJT.FACTURA_SEQ,
	fact_total DECIMAL(18,2),
	fact_emp NUMERIC(18,0),
	fact_fecha DATETIME
	);

	--Item Facturas Temp
	INSERT INTO @ITEM_FACT_TEMP(
			com_id,
			emp_id,
			item_fact_desc,
			item_fact_monto)	
	select  co.com_id,
			e.emp_id,
			CONCAT('Comisión Ubicación ',(select tu_desc from RJT.TipoUbicacion where u.ubi_tipo=tu_id),' ',ISNULL(u.ubi_fila+u.ubi_asiento,'Sin numerar'),' ',p.pub_desc,' ',p.pub_fecha_espec),
			(u.ubi_precio*(g.gra_comision/100))	
	from RJT.Compra co join RJT.Ubicacion u on co.com_id = u.ubi_com join RJT.Publicacion p on u.ubi_pub = p.pub_id join RJT.Empresa e on e.emp_usu_id = p.pub_usu join RJT.GradoPublicacion g on p.pub_gra = g.gra_id 
		where com_fact is null and com_id in (select com_id from @compras)

	--Factura Temp
	INSERT INTO @FACT_TEMP(fact_emp,fact_total,fact_fecha)
	select distinct emp_id,sum(item_fact_monto),@fact_fecha
	from @ITEM_FACT_TEMP
	group by emp_id

	--Se agrega numeros de factura en items
	UPDATE i set i.fact_nro=f.fact_nro from @ITEM_FACT_TEMP i join @FACT_TEMP f on i.emp_id = f.fact_emp
	
	--Factura
	INSERT INTO RJT.Factura(fact_nro,fact_emp,fact_total,fact_fecha)
	select fact_nro,fact_emp,fact_total,fact_fecha from @FACT_TEMP

	--Item Factura
	INSERT INTO RJT.Item_Factura(item_fact_nro,item_fact_monto,item_fact_desc)
	select fact_nro,item_fact_monto,item_fact_desc from @ITEM_FACT_TEMP

	--Update Compra
	UPDATE c set c.com_fact= f.fact_nro from RJT.Compra c join @ITEM_FACT_TEMP i on c.com_id = i.com_id join @FACT_TEMP f on i.emp_id = f.fact_emp

END;
GO

IF OBJECT_ID('RJT.LISTAR_COMPRAS_REALIZADAS', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_COMPRAS_REALIZADAS
GO

create procedure RJT.LISTAR_COMPRAS_REALIZADAS @ID int
as
begin
	select  p.pub_desc as Espectaculo,
			p.pub_fecha_espec as FechaEspectaculo,
			(select tu_desc from RJT.TipoUbicacion where u.ubi_tipo=tu_id) as TipoUbicacion,
			ISNULL(u.ubi_fila+u.ubi_asiento,'Sin numerar') as FilaAsiento,
			u.ubi_precio as Precio,
			(select mp_desc	from RJT.MedioPago where mp_id = co.com_mp) as MedioPago,
			co.com_fecha as FechaCompra
	from RJT.Compra co join RJT.Ubicacion u on co.com_id = u.ubi_com join RJT.Publicacion p on u.ubi_pub = p.pub_id join RJT.Cliente c on c.cli_id=co.com_cli 
		where c.cli_id = @ID
		order by co.com_fecha desc
end
go

IF OBJECT_ID('RJT.LISTAR_PREMIOS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_PREMIOS_EXISTENTES
GO

create procedure RJT.LISTAR_PREMIOS_EXISTENTES
as
begin
	select tp_id as id, tp_desc as Premio, tp_puntos as Puntos
	from RJT.TipoPremio
end
go

IF OBJECT_ID('RJT.OBTENER_PUNTOS_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_PUNTOS_CLIENTE 
GO

create procedure RJT.OBTENER_PUNTOS_CLIENTE @ID int
as
begin
	select cli_ptos,cli_ptos_venc
	from RJT.Cliente where cli_id = @ID
end
go

IF OBJECT_ID('RJT.CANJEAR_PUNTOS', 'P') IS NOT NULL
DROP PROCEDURE RJT.CANJEAR_PUNTOS 
GO

create procedure RJT.CANJEAR_PUNTOS
@cli_id int, 
@tp_id int
as
begin
	declare @puntosPremio int = (select tp_puntos from RJT.TipoPremio where tp_id = @tp_id);
	insert into RJT.Premio(pre_tipo,pre_cli) values (@tp_id,@cli_id)
	UPDATE RJT.Cliente SET cli_ptos = (cli_ptos - @puntosPremio) WHERE cli_id = @cli_id
end
go

IF OBJECT_ID('RJT.LISTAR_GRADOS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_GRADOS_EXISTENTES
GO

create procedure RJT.LISTAR_GRADOS_EXISTENTES
as
begin
	select gra_id as id, gra_desc as GradoPublicacion, gra_comision as Comision, gra_peso as Peso
	from RJT.GradoPublicacion where gra_estado = 1
end
go

IF OBJECT_ID('RJT.LISTAR_USUARIOS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE RJT.LISTAR_USUARIOS_EXISTENTES
GO

create procedure RJT.LISTAR_USUARIOS_EXISTENTES
as
begin
	select usu_id as id, usu_cant_int_fallidos as IntentosFallidos, usu_estado as Estado
	from RJT.Usuario
end
go

IF OBJECT_ID('RJT.CREAR_GRADO', 'P') IS NOT NULL
DROP PROCEDURE RJT.CREAR_GRADO 
GO

create procedure RJT.CREAR_GRADO
@gra_peso int, 
@gra_desc varchar(30),
@gra_comision numeric (2,0)
as
begin
	insert into RJT.GradoPublicacion(gra_peso,gra_desc,gra_comision,gra_estado) values (@gra_peso,@gra_desc,@gra_comision,1)
end
go

IF OBJECT_ID('RJT.MODIFICAR_GRADO', 'P') IS NOT NULL
DROP PROCEDURE RJT.MODIFICAR_GRADO 
GO

create procedure RJT.MODIFICAR_GRADO
@gra_peso int, 
@gra_desc varchar(30),
@gra_comision numeric (2,0),
@gra_id int
as
begin
	UPDATE RJT.GradoPublicacion SET gra_peso=@gra_peso,gra_desc=@gra_desc,gra_comision=@gra_comision WHERE gra_id = @gra_id
end
go

IF OBJECT_ID('RJT.OBTENER_GRADO', 'P') IS NOT NULL
DROP PROCEDURE RJT.OBTENER_GRADO 
GO

create procedure RJT.OBTENER_GRADO @ID int
as
begin
	select gra_id,gra_desc,gra_comision,gra_peso from RJT.GradoPublicacion where gra_id = @ID
end
go

IF OBJECT_ID('RJT.MODIFICAR_CLAVE', 'P') IS NOT NULL
DROP PROCEDURE RJT.MODIFICAR_CLAVE 
GO

create procedure RJT.MODIFICAR_CLAVE
@usu_id int,
@usu_password varchar(255)
as
begin
	UPDATE RJT.Usuario SET usu_password=RJT.ENCRIPTAR(@usu_password) WHERE usu_id = @usu_id
end
go


IF OBJECT_ID('RJT.sp_listado_estadistico_1', 'P') IS NOT NULL
DROP PROCEDURE RJT.sp_listado_estadistico_1 
GO

--Listado 1
create procedure RJT.sp_listado_estadistico_1 (@trimestre int, @anio int)
as
begin
declare @pub table (pub_id int,
					pub_usu int,
					cantidad int,
					fecha datetime,
					grado int)
insert into @pub
select top 5
		pub_id,
		pub_usu,
		count(ubi_pub),
		pub_fecha_espec,
		pub_gra
	from rjt.Ubicacion
		join rjt.Publicacion on ubi_pub = pub_id join rjt.GradoPublicacion on pub_gra=gra_id
	where ubi_com is null
		and year(pub_fecha_espec) = @anio
		and month(pub_fecha_espec) between ((@trimestre * 3) - 2) and @trimestre * 3
	group by pub_id, pub_usu, pub_fecha_espec, gra_peso, pub_gra
	order by 3 desc, 4 desc, gra_peso desc

select e.emp_razon_social as RazonSocial, e.emp_cuit as CUIT
	from rjt.empresa e
	join @pub
		on pub_usu = emp_usu_id
	order by cantidad desc, fecha desc
end
go


IF OBJECT_ID('RJT.sp_listado_estadistico_2', 'P') IS NOT NULL
DROP PROCEDURE RJT.sp_listado_estadistico_2 
GO

--Listado 2
create procedure RJT.sp_listado_estadistico_2(@trimestre int, @anio int, @fechasistema datetime)
as
begin
select top 5 cli_nombre as Nombre ,cli_apellido as Apellido ,cli_tipo_doc as Tipo ,cli_nro_doc as Documento
	from rjt.Cliente
	where cli_ptos is not null
		and cli_ptos_venc is not null
		and cli_ptos_venc < @fechasistema
		and month(cli_ptos_venc) between ((@trimestre * 3) - 2) and @trimestre * 3
		and year(cli_ptos_venc) = @anio
	order by cli_ptos desc
end
go


IF OBJECT_ID('RJT.sp_listado_estadistico_3', 'P') IS NOT NULL
DROP PROCEDURE RJT.sp_listado_estadistico_3 
GO
--Listado 3
create procedure RJT.sp_listado_estadistico_3(@trimestre int, @anio int)
as
begin
select	top 5
		cli_id, cli_usu_id, cli_nombre as Nombre,
		cli_apellido as Apellido, cli_tipo_doc as Tipo, cli_nro_doc as Documento

	from rjt.Cliente as c
		join rjt.compra on com_cli = cli_id
		join rjt.Ubicacion on ubi_com = com_id
		join rjt.Publicacion on pub_id = ubi_pub
		join rjt.Usuario on usu_id = pub_usu
		join rjt.Empresa on emp_usu_id = usu_id
	where year(com_fecha) = @anio
		and month(pub_fecha_espec) between ((@trimestre * 3) - 2) and @trimestre * 3
	group by cli_id, cli_usu_id, cli_nombre,
		cli_apellido, cli_tipo_doc, cli_nro_doc
	order by sum(com_total) desc
end
go

--Se borran sps/funciones utilizadas en la migracion
DROP FUNCTION RJT.MODIFICA_CUIT
DROP PROCEDURE RJT.Z_MIGRACION_CLIENTES
DROP PROCEDURE RJT.Z_MIGRACION_EMPRESAS
DROP PROCEDURE RJT.Z_MIGRACION_COMPRAS_UBICACION
--Drop tabla maestra
drop table gd_esquema.Maestra;
go