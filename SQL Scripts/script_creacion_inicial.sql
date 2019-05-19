USE GD2C2018
GO

--************CREACION DE SCHEMA**************
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'TROLLS')
	BEGIN
		EXEC sys.sp_executesql N'CREATE SCHEMA [TROLLS] AUTHORIZATION [gdCruceros2019]'
		PRINT 'Schema correctamente creado'

	END

GO

--****************DROP DE PROCEDURES*************
IF OBJECT_ID('TROLLS.BUSCAR_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.BUSCAR_USUARIO
GO
IF OBJECT_ID('TROLLS.REG_INTENTO_FALLIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.REG_INTENTO_FALLIDO
GO
IF OBJECT_ID('TROLLS.OBTENER_ID_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_ID_USUARIO
GO
IF OBJECT_ID('TROLLS.OBTENER_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_USUARIO
GO
IF OBJECT_ID('TROLLS.OBTENER_CANT_ROLES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_CANT_ROLES
GO
IF OBJECT_ID('TROLLS.GUARDAR_ROL', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.GUARDAR_ROL
GO
IF OBJECT_ID('TROLLS.ELIMINAR_ROL', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.ELIMINAR_ROL
GO
IF OBJECT_ID('TROLLS.OBTENER_ID_X_NOMBRE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_ID_X_NOMBRE
GO
IF OBJECT_ID('TROLLS.AGREGAR_FUNCIONALIDAD_A_ROL', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.AGREGAR_FUNCIONALIDAD_A_ROL
GO
IF OBJECT_ID('TROLLS.ELIMINAR_FUNCIONALIDAD_A_ROL', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.ELIMINAR_FUNCIONALIDAD_A_ROL
GO
IF OBJECT_ID('TROLLS.LISTAR_FUNCIONES_X_ROL', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_FUNCIONES_X_ROL 
GO
IF OBJECT_ID('TROLLS.LISTAR_FUNCIONES_X_ROL_NO_ASIGNADAS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_FUNCIONES_X_ROL_NO_ASIGNADAS
GO
IF OBJECT_ID('TROLLS.LISTAR_AFILIADOS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_AFILIADOS_EXISTENTES
GO
IF OBJECT_ID('TROLLS.OBTENER_ROLES_ACTIVOS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_ROLES_ACTIVOS
GO
IF OBJECT_ID('TROLLS.OBTENER_FUNCIONALIDADES_ROL', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_FUNCIONALIDADES_ROL
GO

IF OBJECT_ID('TROLLS.CREAR_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_USUARIO
GO

IF OBJECT_ID('TROLLS.CREAR_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_DIRECCION
GO

IF OBJECT_ID('TROLLS.OBTENER_ID_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_ID_DIRECCION
GO

IF OBJECT_ID('TROLLS.CREAR_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_CLIENTE
GO

IF OBJECT_ID('TROLLS.CREAR_EMPRESA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_EMPRESA
GO

IF OBJECT_ID('TROLLS.CREAR_ROLxUSUARIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_ROLxUSUARIO
GO

IF OBJECT_ID('TROLLS.OBTENER_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_CLIENTE
GO

IF OBJECT_ID('TROLLS.OBTENER_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_DIRECCION
GO

IF OBJECT_ID('TROLLS.MODIFICAR_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_CLIENTE
GO

IF OBJECT_ID('TROLLS.MODIFICAR_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_DIRECCION
GO

-----------------------------------------------------ABM CLIENTE--------------------------------------------------------

if EXISTS (SELECT * FROM sysobjects WHERE name='st_buscar_clientes') 
drop procedure TROLLS.st_buscar_clientes

go

if EXISTS (SELECT * FROM sysobjects WHERE name='st_agregar_cliente') 
drop procedure TROLLS.st_agregar_cliente

go

if EXISTS (SELECT * FROM sysobjects WHERE name='st_modificar_cliente') 
drop procedure TROLLS.st_modificar_cliente

go

--*************Inicio Creacion de tablas****************

if OBJECT_ID('TROLLS.Crucero', 'U') is not null
	drop table TROLLS.Crucero;
create table TROLLS.Crucero (cru_id nvarchar(25) IDENTITY(1,1) NOT NULL, 
					     cru_modelo nvarchar(20) not null,
						 cru_fabric VARCHAR(100) not null);

if OBJECT_ID('TROLLS.Cabina', 'U') is not null
	drop table TROLLS.Cabina;
create table TROLLS.Cabina (cab_nro NUMERIC(18,0)  NOT NULL,
							 cab_id NUMERIC(18,0)  IDENTITY(1,1) NOT NULL,
							 cab_piso NUMERIC(2,0) not null,
							 cab_tcab_id NUMERIC(18,0) not null, --FK Tipo_Cabina
							 --cab_porc_recargo decimal(4,2) not null, TABLA DE TIPO_CRUCERO
							 --cab_tipo varchar(400) not null, TABLA DE TIPO_CRUCERO
							 cab_cru_id NUMERIC(18,0), --FK Crucero
							 PRIMARY KEY(cab_id));

if OBJECT_ID('TROLLS.Tipo_Cabina', 'U') is not null
	drop table TROLLS.Tipo_Cabina;
create table TROLLS.Tipo_Cabina (tcab_id NUMERIC(18,0)  IDENTITY(1,1) NOT NULL,
							 tcab_porc_recargo decimal(4,2) not null,
							 tcab_tipo varchar(400) not null, 							 
							 PRIMARY KEY(tcab_id));

if OBJECT_ID('TROLLS.Reserva', 'U') is not null
	drop table TROLLS.Reserva;
create table TROLLS.Reserva (res_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					  res_fecha datetime not null,
					  res_via_id NUMERIC(18,0) not null, --FK Vaje
					  res_cab_id NUMERIC(18,0) not null, --FK Cabina
					  res_cli_id NUMERIC(18,0) not null, --FK Cliente
					  res_pue_hasta NUMERIC(18,0) not null, --FK Puerto
					  PRIMARY KEY(res_id));

if OBJECT_ID('TROLLS.Pasaje', 'U') is not null
	drop table TROLLS.Pasaje;
create table TROLLS.Pasaje (pas_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					 pas_precio decimal(18,2) not null,
					 pas_fec_compra datetime not null,
					 pas_cli_id NUMERIC(18,0) NOT NULL, --FK Cliente
					 pas_cab_id NUMERIC(18,0) NOT NULL, --FK Cabina
					 pas_mp_id NUMERIC(18,0) NOT NULL,  --FK Medio_De_Pago
					 pas_via_id NUMERIC(18,0) NOT NULL, --FK Viaje
					 pas_pue_hasta NUMERIC(18,0) NOT NULL --FK Puerto
					 PRIMARY KEY(pas_id));

if OBJECT_ID('TROLLS.MedioPago', 'U') is not null
	drop table TROLLS.MedioPago;
create table TROLLS.MedioPago (mp_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							mp_desc nvarchar(100) not null,
							PRIMARY KEY(mp_id));

if OBJECT_ID('TROLLS.Puerto', 'U') is not null
	drop table TROLLS.Puerto;
create table TROLLS.Puerto (pue_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							pue_nombre VARCHAR (100) not null,
							pue_estado BIT NOT NULL DEFAULT 1,
							PRIMARY KEY(pue_id));

if OBJECT_ID('TROLLS.Puerto_Tramo', 'U') is not null
	drop table TROLLS.Puerto_Tramo;
create table TROLLS.Puerto_Tramo (tra_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL, --FK Tramo
							pue_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL, --FK Puerto
							PRIMARY KEY(tra_id),
							PRIMARY KEY(pue_id));

if OBJECT_ID('TROLLS.Tramos', 'U') is not null
	drop table TROLLS.Tramos;
create table TROLLS.Tramos( tra_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
									tra_desde varchar(30) not null, --FK Recorrido
									tra_hasta varchar(30) not null, --FK Recorrido
									tra_rec_id NUMERIC(18,0), --FK Recorrido
									tra_durac NUMERIC(20),
									primary key (tra_id));	

if OBJECT_ID('TROLLS.Recorrido', 'U') is not null
	drop table TROLLS.Recorrido;
create table TROLLS.Recorrido( rec_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
									rec_precio_base DECIMAL(18,2) NOT NULL,
									rec_desde varchar(30) not null,
									rec_hasta varchar(30) not null,
									primary key (rec_id));	

if OBJECT_ID('TROLLS.Viaje', 'U') is not null
	drop table TROLLS.Viaje;
create table TROLLS.Viaje(via_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							 pub_estado nvarchar(10) NOT NULL check (pub_estado in ('Borrador', 'Publicada', 'Finalizada')),
							 pub_desc nvarchar(400) not null,
							 via_fecha_salida datetime not null, 
							 via_fecha_llegada datetime not null, 
							 via_fecha_llegada_estimada datetime not null, 
							 via_cru_id NUMERIC(18,0) not null, --FK Crucero
							 via_rec_id NUMERIC(18,0), --FK Recorrido
							 primary key (rec_id));

if OBJECT_ID('TROLLS.Cliente', 'U') is not null
	drop table TROLLS.Cliente;
create table TROLLS.Cliente (cli_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					  cli_rol_id NUMERIC(18,0)  NOT NULL, --FK Rol por usu_id
					  cli_nombre NVARCHAR(30) not null,
					  cli_apellido NVARCHAR(30) not null,
					  cli_nro_doc char(10)  NOT NULL,
					  cli_fecha_nac datetime not null,
					  cli_direccion NUMERIC(18,0), --FK Dirección
					  PRIMARY KEY(cli_id));

if OBJECT_ID('TROLLS.Direccion', 'U') is not null
	drop table TROLLS.Direccion;
create table TROLLS.Direccion( dir_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							dir_calle nvarchar(70) not null,
							dir_num char(5) not null,
							dir_telefono varchar(18),
							dir_mail nvarchar(50) not null,
							primary key (dir_id));

if OBJECT_ID('TROLLS.Rol_Usuario', 'U') is not null
	drop table TROLLS.Rol_Usuario;
create table TROLLS.Rol_Usuario(usu_id NUMERIC(18,0) NOT NULL,
							 rol_id NUMERIC(18,0) NOT NULL,
							 estado	BIT NOT NULL DEFAULT 0);

if OBJECT_ID('TROLLS.Rol_Funcionalidad', 'U') is not null
	drop table TROLLS.Rol_Funcionalidad;
create table TROLLS.Rol_Funcionalidad( rol_id NUMERIC(18,0) NOT NULL,
									fun_id NUMERIC(18,0) NOT NULL,
									estado BIT NOT NULL DEFAULT 1);

if OBJECT_ID('TROLLS.Rol', 'U') is not null
	drop table TROLLS.Rol;
	create table TROLLS.Rol(rol_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
						 rol_nombre NVARCHAR(50) NOT NULL,
						 rol_estado BIT NOT NULL DEFAULT 1, 
						 PRIMARY KEY (rol_id) );

if OBJECT_ID('TROLLS.Funcionalidad', 'U') is not null
	drop table TROLLS.Funcionalidad;
create table TROLLS.Funcionalidad( fun_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
								fun_nombre nvarchar(50) NOT NULL,
								fun_visible BIT NOT NULL DEFAULT 1,
								PRIMARY KEY (fun_id) );

if OBJECT_ID('TROLLS.Usuario', 'U') is not null
	drop table TROLLS.Usuario;
create table TROLLS.Usuario(usu_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
						usu_usuario NVARCHAR(30) NOT NULL,
						usu_password NVARCHAR(255) NOT NULL,
						usu_cant_int_fallidos int default 0,
						usu_estado bit default 1
						PRIMARY KEY (usu_id) );


									
-- ******** Fin Creacion de Tablas************


-- ******** Inicio Creacion de FKs************

ALTER TABLE TROLLS.Tramo  WITH CHECK ADD
	CONSTRAINT FK_tramo_recorrido FOREIGN KEY (tra_rec_id)
	REFERENCES TROLLS.Recorrido (rec_id)

ALTER TABLE TROLLS.Tramo  WITH CHECK ADD
	CONSTRAINT FK_tra_rec_desde FOREIGN KEY (tra_desde)
	REFERENCES TROLLS.Recorrido (rec_desde)

ALTER TABLE TROLLS.Tramo  WITH CHECK ADD
	CONSTRAINT FK_tra_rec_hasta FOREIGN KEY (tra_hasta)
	REFERENCES TROLLS.Recorrido (rec_hasta)

ALTER TABLE TROLLS.Viaje  WITH CHECK ADD
	CONSTRAINT FK_viaje_recorrido FOREIGN KEY (via_rec_id)
	REFERENCES TROLLS.Recorrido (rec_id)

ALTER TABLE TROLLS.Viaje  WITH CHECK ADD
	CONSTRAINT FK_viaje_crucero FOREIGN KEY (via_cru_id)
	REFERENCES TROLLS.Crucero (cru_id)

ALTER TABLE TROLLS.Reserva  WITH CHECK ADD
	CONSTRAINT FK_reserva_viaje FOREIGN KEY (res_via_id)
	REFERENCES TROLLS.Viaje (via_id)

ALTER TABLE TROLLS.Reserva  WITH CHECK ADD
	CONSTRAINT FK_Reserva_cabina FOREIGN KEY (res_cab_id)
	REFERENCES TROLLS.Cabina (cab_id)

ALTER TABLE TROLLS.Reserva  WITH CHECK ADD
	CONSTRAINT FK_Reserva_cliente FOREIGN KEY (res_cli_id)
	REFERENCES TROLLS.Cliente (cli_id)

ALTER TABLE TROLLS.Reserva  WITH CHECK ADD
	CONSTRAINT FK_Reserva_puerto FOREIGN KEY (res_pue_hasta)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_viaje FOREIGN KEY (pas_via_id)
	REFERENCES TROLLS.Viaje (via_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_cabina FOREIGN KEY (pas_cab_id)
	REFERENCES TROLLS.Cabina (cab_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_cliente FOREIGN KEY (pas_cli_id)
	REFERENCES TROLLS.Cliente (cli_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_puerto FOREIGN KEY (pas_pue_hasta)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_medioPago FOREIGN KEY (pas_mdp_id)
	REFERENCES TROLLS.MedioPago (mp_id)

ALTER TABLE TROLLS.Cabina  WITH CHECK ADD
	CONSTRAINT FK_Cabina_tipo FOREIGN KEY (cab_tcab_id)
	REFERENCES TROLLS.Tipo_Cabina (tcab_id)

ALTER TABLE TROLLS.Cabina  WITH CHECK ADD
	CONSTRAINT FK_Cabina_crucero FOREIGN KEY (cab_cru_id)
	REFERENCES TROLLS.Crucero (cru_id)

ALTER TABLE TROLLS.Puerto_Tramo  WITH CHECK ADD
	CONSTRAINT FK_Puerto_tramo FOREIGN KEY (tra_id)
	REFERENCES TROLLS.Tramo (tra_id)

ALTER TABLE TROLLS.Puerto_tramo  WITH CHECK ADD
	CONSTRAINT FK_Tramo_puerto FOREIGN KEY (pue_id)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Cliente  WITH CHECK ADD
	CONSTRAINT FK_Cliente_Usuario FOREIGN KEY (cli_usu_id)
	REFERENCES TROLLS.Usuario (usu_id)
	
ALTER TABLE TROLLS.Cliente  WITH CHECK ADD
	CONSTRAINT FK_Cliente_Direccion FOREIGN KEY (cli_direccion)
	REFERENCES TROLLS.Direccion (dir_id)

ALTER TABLE TROLLS.Rol_Usuario  WITH CHECK ADD
	CONSTRAINT FK_Usuario_ID FOREIGN KEY (usu_id)
	REFERENCES TROLLS.Usuario (usu_id)

ALTER TABLE TROLLS.Rol_Usuario  WITH CHECK ADD
	CONSTRAINT FK_Rol_ID FOREIGN KEY (rol_id)
	REFERENCES TROLLS.Rol (rol_id)
	
ALTER TABLE TROLLS.Rol_Funcionalidad WITH CHECK ADD
	CONSTRAINT FK_Funcionalidad_ID FOREIGN KEY (fun_id)
	REFERENCES TROLLS.Funcionalidad (fun_id)

ALTER TABLE TROLLS.Rol_Funcionalidad  WITH CHECK ADD
	CONSTRAINT FK_RolFun_ID FOREIGN KEY (rol_id)
	REFERENCES TROLLS.Rol (rol_id)

-- ******** FIN Creacion de FKs************


-- ******** Inicio Migracion************

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'TROLLS.MODIFICA_CUIT')
AND type in (N'FN', N'IF',N'TF', N'FS', N'FT'))
DROP FUNCTION TROLLS.MODIFICA_CUIT
GO

create function TROLLS.MODIFICA_CUIT (@Cuit nvarchar(255))
returns nvarchar(255)
as
begin 
	return REPLACE(@Cuit, '-', '');
end
go

-- Creo Roles
INSERT INTO TROLLS.Rol(rol_nombre, rol_estado)
VALUES
('Administrativo', 1),
('Empresa', 1),
('Cliente', 1);

--Creo Funcionalidades
INSERT INTO TROLLS.Funcionalidad(fun_nombre)
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
INSERT INTO TROLLS.Rol_Funcionalidad(rol_id, fun_id, estado)
VALUES
(1,1,1),(1,2,1),(1,3,1),(1,4,1),(1,5,1),(1,11,1),(1,12,1),
(2,6,1),(2,7,1),
(3,8,1),(3,9,1),(3,10,1)
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'TROLLS.ENCRIPTAR')
AND type in (N'FN', N'IF',N'TF', N'FS', N'FT'))
DROP FUNCTION TROLLS.ENCRIPTAR
GO

create function TROLLS.ENCRIPTAR (@Password nvarchar(255))
returns nvarchar(255)
as
begin 
	return HASHBYTES('SHA2_256',@Password)
end
go

IF OBJECT_ID('TROLLS.USUARIO_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.USUARIO_SEQ
CREATE SEQUENCE TROLLS.USUARIO_SEQ START WITH 1 INCREMENT BY 1;
GO

SET IDENTITY_INSERT TROLLS.usuario ON;
--Creo Usuario Admin
INSERT INTO TROLLS.Usuario(usu_id,usu_usuario, usu_password)
VALUES
(next value for TROLLS.USUARIO_SEQ, 'admin',TROLLS.ENCRIPTAR('w23e'))
SET IDENTITY_INSERT TROLLS.usuario OFF;

INSERT INTO TROLLS.Rol_Usuario(rol_id, usu_id, estado)
VALUES
(1,1,1),(2,1,1),(3,1,1)
GO

IF OBJECT_ID('TROLLS.Z_MIGRACION_CLIENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.Z_MIGRACION_CLIENTES
GO

IF OBJECT_ID('TROLLS.DIRECCION_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.DIRECCION_SEQ
CREATE SEQUENCE TROLLS.DIRECCION_SEQ START WITH 1 INCREMENT BY 1;
GO

/* TROLLS.MIGRAR_CLIENTES */

CREATE PROCEDURE TROLLS.Z_MIGRACION_CLIENTES     
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
	usu_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.USUARIO_SEQ,
	dir_mail NVARCHAR(50),
	dir_calle NVARCHAR(70),
	dir_num CHAR(5),
	dir_piso CHAR(2),
	dir_dpto CHAR(2),
	dir_cp CHAR(4),
	dir_localidad NVARCHAR(50),
	dir_telefono NVARCHAR(18),
	dir_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.DIRECCION_SEQ
	);
	--Tabla temporal
	INSERT INTO @MIGRA_CLIENTE_TEMP 
	(cli_nro_doc,cli_tipo_doc,cli_apellido,cli_nombre,cli_fecha_nac,
	usu_usuario,usu_password,
	dir_mail,dir_calle,dir_num,dir_piso,dir_dpto,dir_cp)
	SELECT DISTINCT(Cli_Dni),'DNI',Cli_Apeliido,Cli_Nombre,Cli_Fecha_Nac,Cli_Dni,TROLLS.ENCRIPTAR(cast(Cli_Dni as varchar(255))),
	Cli_Mail,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal
		   FROM GD_ESQUEMA.MAESTRA
	WHERE Cli_Dni IS NOT NULL

	--Usuario
	SET IDENTITY_INSERT TROLLS.usuario ON;
	INSERT INTO TROLLS.usuario(usu_id,usu_usuario,usu_password,usu_cant_int_fallidos,usu_estado)
	SELECT 
	usu_id,usu_usuario,usu_password,0,1
	FROM @MIGRA_CLIENTE_TEMP;
	SET IDENTITY_INSERT TROLLS.usuario OFF;
	--Se asigna rol Cliente
	insert into TROLLS.Rol_Usuario(usu_id,rol_id,estado)
	select usu_id,3,1 from @MIGRA_CLIENTE_TEMP
	--Domicilio
	SET IDENTITY_INSERT TROLLS.Direccion ON;
	INSERT INTO TROLLS.Direccion(dir_id,DIR_CALLE,DIR_NUM,DIR_PISO,DIR_DTO,DIR_CP,DIR_MAIL)
	SELECT 
	dir_id,dir_calle,dir_num,dir_piso,dir_dpto,dir_cp,dir_mail
	FROM @MIGRA_CLIENTE_TEMP;
	SET IDENTITY_INSERT TROLLS.Direccion OFF;
	--Cliente
	INSERT INTO TROLLS.CLIENTE(cli_nro_doc,cli_tipo_doc,cli_apellido,cli_nombre,cli_fecha_nac,cli_fecha_creacion,cli_usu_id,cli_direccion,cli_ptos,cli_estado)
	SELECT cli_nro_doc,cli_tipo_doc,cli_apellido,cli_nombre,cli_fecha_nac,GETDATE(),usu_id,dir_id,0,1
	FROM @MIGRA_CLIENTE_TEMP;

END;
GO

EXEC TROLLS.Z_MIGRACION_CLIENTES;
GO

IF OBJECT_ID('TROLLS.Z_MIGRACION_EMPRESAS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.Z_MIGRACION_EMPRESAS
GO

/* TROLLS.Z_MIGRACION_EMPRESAS */

CREATE PROCEDURE TROLLS.Z_MIGRACION_EMPRESAS     
AS 
BEGIN		
	DECLARE @MIGRA_EMPRESA_TEMP TABLE 
	(
	emp_razon_social NVARCHAR(50),
	emp_cuit CHAR(12),	
	usu_usuario NVARCHAR(30),
	usu_password NVARCHAR(255),
	usu_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.USUARIO_SEQ,
	dir_mail NVARCHAR(50),
	dir_calle NVARCHAR(70),
	dir_num CHAR(5),
	dir_piso CHAR(2),
	dir_dpto CHAR(2),
	dir_cp CHAR(4),
	dir_localidad NVARCHAR(50),
	dir_telefono NVARCHAR(18),
	dir_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.DIRECCION_SEQ
	);
	--Tabla temporal
	INSERT INTO @MIGRA_EMPRESA_TEMP 
	(emp_cuit,emp_razon_social,
	usu_usuario,usu_password,
	dir_mail,dir_calle,dir_num,dir_piso,dir_dpto,dir_cp)
	SELECT DISTINCT(Espec_Empresa_Cuit),Espec_Empresa_Razon_Social,TROLLS.MODIFICA_CUIT(Espec_Empresa_Cuit),TROLLS.ENCRIPTAR(cast(TROLLS.MODIFICA_CUIT(Espec_Empresa_Cuit) as varchar(255))),
	Espec_Empresa_Mail,Espec_Empresa_Dom_Calle,Espec_Empresa_Nro_Calle,Espec_Empresa_Piso,Espec_Empresa_Depto,Espec_Empresa_Cod_Postal
		   FROM GD_ESQUEMA.MAESTRA
	WHERE Espec_Empresa_Cuit IS NOT NULL

	--Se quita los guiones de los CUIT
	UPDATE @MIGRA_EMPRESA_TEMP SET emp_cuit = TROLLS.MODIFICA_CUIT(emp_cuit)

	--Usuario
	SET IDENTITY_INSERT TROLLS.usuario ON;
	INSERT INTO TROLLS.usuario(usu_id,usu_usuario,usu_password,usu_cant_int_fallidos,usu_estado)
	SELECT 
	usu_id,usu_usuario,usu_password,0,1
	FROM @MIGRA_EMPRESA_TEMP;
	SET IDENTITY_INSERT TROLLS.usuario OFF;
	--Se asigna rol Empresa
	insert into TROLLS.Rol_Usuario(usu_id,rol_id,estado)
	select usu_id,2,1 from @MIGRA_EMPRESA_TEMP
	--Domicilio
	SET IDENTITY_INSERT TROLLS.Direccion ON;
	INSERT INTO TROLLS.Direccion(dir_id,DIR_CALLE,DIR_NUM,DIR_PISO,DIR_DTO,DIR_CP,DIR_MAIL)
	SELECT 
	dir_id,dir_calle,dir_num,dir_piso,dir_dpto,dir_cp,dir_mail
	FROM @MIGRA_EMPRESA_TEMP;
	SET IDENTITY_INSERT TROLLS.Direccion OFF;
	--Empresa
	INSERT INTO TROLLS.Empresa(emp_cuit,emp_razon_social,emp_usu_id,emp_direccion,emp_estado)
	SELECT emp_cuit,emp_razon_social,usu_id,dir_id,1
	FROM @MIGRA_EMPRESA_TEMP;

END;
GO

EXEC TROLLS.Z_MIGRACION_EMPRESAS;
GO

--CREO RUBROS
INSERT INTO TROLLS.Rubro (rub_desc)
VALUES ('Sin Rubro'),('Teatral'),('Musical')
GO

--TipoPremio
INSERT INTO TROLLS.TipoPremio (tp_desc,tp_puntos)
VALUES ('Sofa',1000),('Mesa',500),('Silla',100)
GO

--Creo Medios de pago
INSERT INTO TROLLS.MedioPago (mp_desc)
select distinct Forma_Pago_Desc
FROM GD_ESQUEMA.MAESTRA
where Forma_Pago_Desc is not null

INSERT INTO TROLLS.MedioPago (mp_desc)
VALUES ('Tarjeta')
GO

SET IDENTITY_INSERT TROLLS.TipoUbicacion ON;
--TipoUbicacion
INSERT INTO TROLLS.TipoUbicacion (tu_id,tu_desc)
select distinct Ubicacion_Tipo_Codigo, Ubicacion_Tipo_Descripcion
FROM GD_ESQUEMA.MAESTRA
where Ubicacion_Tipo_Codigo is not null
GO
SET IDENTITY_INSERT TROLLS.TipoUbicacion OFF;

--CREO GRADOS DE PUBLICACION 
INSERT INTO TROLLS.GradoPublicacion (gra_desc,gra_comision,gra_peso,gra_estado)
VALUES ('Baja',5,1,1), ('Media',10,2,1), ('Alta',20,3,1)


--Creo Publicaciones
SET IDENTITY_INSERT TROLLS.Publicacion ON;
 INSERT INTO TROLLS.Publicacion ( pub_id,pub_estado,pub_desc,pub_fecha_espec,pub_fecha_pub,pub_usu,pub_dir,pub_rubro, pub_gra)
 select distinct Espectaculo_Cod,Espectaculo_Estado,Espectaculo_Descripcion,Espectaculo_Fecha,Espectaculo_Fecha_Venc
 				,e.emp_usu_id,null , 1 , 2
 from gd_esquema.Maestra m
join TROLLS.Empresa E on e.emp_cuit = m.Espec_Empresa_Cuit
order by Espectaculo_Cod
SET IDENTITY_INSERT TROLLS.Publicacion OFF;
GO

--Creo Facturas

INSERT INTO TROLLS.Factura (fact_nro,fact_fecha,fact_total,fact_emp)
select distinct Factura_Nro,Factura_Fecha,Factura_Total, e.emp_id
from gd_esquema.Maestra
join TROLLS.Empresa e on e.emp_cuit = Espec_Empresa_Cuit
where Factura_Nro is not null
order by Factura_Nro


--Creo ITEM Facturas

insert into TROLLS.Item_Factura (item_fact_nro,item_fact_monto,item_fact_desc)
select Factura_Nro,Item_Factura_Monto,Item_Factura_Descripcion
from gd_esquema.Maestra
where Factura_Nro is not null
order by Factura_Nro
GO

--CREO UBICACIONES/COMPRAS

IF OBJECT_ID('TROLLS.Z_MIGRACION_COMPRAS_UBICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.Z_MIGRACION_COMPRAS_UBICACION
GO
IF OBJECT_ID('TROLLS.COMPRA_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.COMPRA_SEQ
CREATE SEQUENCE TROLLS.COMPRA_SEQ START WITH 1 INCREMENT BY 1;
GO

CREATE PROCEDURE TROLLS.Z_MIGRACION_COMPRAS_UBICACION  
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
	com_id NUMERIC(18,0) default NEXT VALUE FOR TROLLS.COMPRA_SEQ,
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
	join TROLLS.Cliente C on c.cli_nro_doc = Cli_Dni
	join TROLLS.MedioPago MP on mp.mp_desc = Forma_Pago_Desc
	join TROLLS.TipoUbicacion TU on tu.tu_desc = Ubicacion_Tipo_Descripcion
	where Cli_Dni is not null and Factura_Nro is not null

	--INSERT UBICACION CON COMPRA SIN RENDICION
	INSERT INTO @MIGRA_UBICACION_COMPRA_TEMP
	(ubi_tipo,ubi_precio,ubi_sin_numeric,ubi_asiento,ubi_fila,ubi_pub,com_fecha,com_cli,com_mp,com_cant)
	SELECT tu.tu_id, Ubicacion_Precio, Ubicacion_Sin_numerar, Ubicacion_Asiento, Ubicacion_Fila,Espectaculo_Cod, Compra_Fecha,c.cli_id,mp.mp_id,Compra_Cantidad
	FROM GD_ESQUEMA.MAESTRA
	join TROLLS.Cliente C on c.cli_nro_doc = Cli_Dni
	join TROLLS.MedioPago MP on mp.mp_desc = Forma_Pago_Desc
	join TROLLS.TipoUbicacion TU on tu.tu_desc = Ubicacion_Tipo_Descripcion
	where Cli_Dni is not null and (select count(*) from @MIGRA_UBICACION_COMPRA_TEMP where ubi_asiento=Ubicacion_Asiento and ubi_fila=Ubicacion_Fila and ubi_pub=Espectaculo_Cod) =0;

	--INSERT UBICACION SIN COMPRA
	INSERT INTO @MIGRA_UBICACION_COMPRA_TEMP
	(ubi_tipo,ubi_precio,ubi_sin_numeric,ubi_asiento,ubi_fila,ubi_pub,com_id,com_fecha,com_cli,com_mp,com_cant)
	SELECT tu.tu_id, Ubicacion_Precio, Ubicacion_Sin_numerar, Ubicacion_Asiento, Ubicacion_Fila,Espectaculo_Cod,null,null,null,null,null
	FROM GD_ESQUEMA.MAESTRA M
	join TROLLS.TipoUbicacion TU on tu.tu_desc = Ubicacion_Tipo_Descripcion
	where Cli_Dni is null and (select count(*) from @MIGRA_UBICACION_COMPRA_TEMP where ubi_asiento=M.Ubicacion_Asiento and ubi_fila=M.Ubicacion_Fila and ubi_pub=M.Espectaculo_Cod) =0;

	--COMPRA
	SET IDENTITY_INSERT TROLLS.COMPRA ON;
	INSERT INTO TROLLS.COMPRA
	(com_id,com_fecha,com_cli,com_mp,com_cant,com_total,com_fact)
	SELECT com_id,com_fecha,com_cli,com_mp,com_cant,ubi_precio,com_fact
	FROM @MIGRA_UBICACION_COMPRA_TEMP where com_id is not null;
	SET IDENTITY_INSERT TROLLS.COMPRA OFF;
	--UBICACION
	INSERT INTO TROLLS.Ubicacion(ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_asiento,ubi_fila,ubi_pub,ubi_com)
	SELECT ubi_tipo,ubi_precio,ubi_sin_numeric,ubi_asiento,ubi_fila,ubi_pub,com_id
	FROM @MIGRA_UBICACION_COMPRA_TEMP;

END;
GO

EXEC TROLLS.Z_MIGRACION_COMPRAS_UBICACION;
GO

--Finalizar publicaciones con todas las ubicaciones compradas
update TROLLS.Publicacion set pub_estado='Finalizada' where pub_id in (

select pub_id from TROLLS.Publicacion p
group by pub_id 
having (select count(ubi_id) from TROLLS.Publicacion join TROLLS.Ubicacion on pub_id = ubi_pub where pub_id=p.pub_id
group by pub_id) = (select count(ubi_id) from TROLLS.Publicacion join TROLLS.Ubicacion on pub_id = ubi_pub where ubi_com is not null and pub_id=p.pub_id
group by pub_id)
)
GO

--Procedures
create procedure TROLLS.BUSCAR_USUARIO @Usuario varchar(30), @Password nvarchar(255)
as
begin 
	declare @estado bit
	declare @cant_int_fallido int
	select @estado = usu_Estado from TROLLS.USUARIO where usu_usuario =  @Usuario and usu_password = TROLLS.ENCRIPTAR (@Password)
	select @cant_int_fallido = usu_cant_int_fallidos from TROLLS.USUARIO where usu_usuario = @Usuario

	if not exists(select 1 from TROLLS.USUARIO where usu_usuario = @Usuario)
		select 0 as estado
	if exists(select 1 from TROLLS.USUARIO where usu_usuario = @Usuario and usu_password <> TROLLS.ENCRIPTAR (@Password))
		if (@cant_int_fallido = 3) 
			begin
				update TROLLS.USUARIO set usu_ESTADO = 0 where usu_usuario = @Usuario
				select 2 as estado
			end
		else select 1 as estado
	if @estado = 0
		select 2 as estado
	if @estado = 1
		begin
			if @cant_int_fallido = 1 or @cant_int_fallido = 2
				update TROLLS.USUARIO set usu_cant_int_fallidos = 0 where usu_usuario = @Usuario
			select 3 as estado
		end
end
go

create procedure TROLLS.REG_INTENTO_FALLIDO @Usuario varchar(50)
as
begin
	declare @cant_int_fallido int
	select @cant_int_fallido = usu_cant_int_fallidos from TROLLS.USUARIO where usu_usuario = @Usuario

	if @cant_int_fallido between 0 and 2
		update TROLLS.USUARIO set usu_cant_int_fallidos = usu_cant_int_fallidos + 1 where usu_usuario = @Usuario
end
go

create procedure TROLLS.OBTENER_ID_USUARIO @USUARIO varchar(50)
as
begin
	select usu_id from TROLLS.USUARIO where usu_usuario = @USUARIO
end
go

create procedure TROLLS.OBTENER_USUARIO @ID INT
as
begin
	declare @USER VARCHAR(250)
	select @USER = usu_usuario from TROLLS.USUARIO where usu_id = @ID
	RETURN @USER
end
go

create procedure TROLLS.OBTENER_CANT_ROLES @ID_USU int
as
begin
	select count(usu_id) from TROLLS.ROL_USUARIO where usu_id = @ID_USU and ESTADO = 1  
end
go

create procedure TROLLS.GUARDAR_ROL @nombre varchar(25), @estado bit
as
begin
	insert into TROLLS.ROL(rol_nombre,rol_estado) values (@nombre,@estado);
end
go

create procedure TROLLS.ELIMINAR_ROL @ID int
as
begin
	update TROLLS.ROL set rol_ESTADO = 0 where rol_id = @ID;
end
go

create procedure TROLLS.OBTENER_ID_X_NOMBRE @nombre varchar(25)
as
begin
	select rol_id from TROLLS.ROL where rol_nombre = @nombre 
end
go

create procedure TROLLS.AGREGAR_FUNCIONALIDAD_A_ROL @ID_ROL INT, @ID_FUNCIONALIDAD INT
as
begin
	if exists (select 1 from TROLLS.Rol_Funcionalidad where rol_id=@ID_ROL and fun_id=@ID_FUNCIONALIDAD)
	begin
		update TROLLS.Rol_Funcionalidad set estado = 1 where rol_id=@ID_ROL and fun_id=@ID_FUNCIONALIDAD;
	end
	else
	begin
		insert into TROLLS.ROL_FUNCIONALIDAD (rol_id,fun_id,estado) values (@ID_ROL,@ID_FUNCIONALIDAD,1);
	end	
end
go

create procedure TROLLS.ELIMINAR_FUNCIONALIDAD_A_ROL @ID_ROL INT, @ID_FUNCIONALIDAD INT
as
begin
	update TROLLS.Rol_Funcionalidad set estado = 0 where rol_id=@ID_ROL and fun_id=@ID_FUNCIONALIDAD;
end
go

create procedure TROLLS.LISTAR_FUNCIONES_X_ROL @ID_ROL int
as
begin
	select f.* from TROLLS.ROL_FUNCIONALIDAD as rxf inner join TROLLS.FUNCIONALIDAD as f
		   on rxf.fun_id = f.fun_id where rxf.rol_id = @ID_ROL and rxf.estado = 1;
end
go

create procedure TROLLS.LISTAR_FUNCIONES_X_ROL_NO_ASIGNADAS @ID_ROL int
as
begin
	select * from TROLLS.FUNCIONALIDAD except 
									     select f.* from TROLLS.ROL_FUNCIONALIDAD as rxf inner join TROLLS.FUNCIONALIDAD as f
										 on rxf.fun_id = f.fun_id where rxf.rol_id = @ID_ROL and rxf.estado = 1;
end
go

create procedure TROLLS.OBTENER_ROLES_ACTIVOS @ID int
as
begin
	select R.rol_NOMBRE,R.rol_id from TROLLS.ROL R inner join TROLLS.ROL_USUARIO RXU 
		on R.rol_id = RXU.rol_id where RXU.usu_id = @ID and R.rol_ESTADO = 1 
end
go

create procedure TROLLS.OBTENER_FUNCIONALIDADES_ROL @ID_ROL int
as
begin
	select F.fun_id from TROLLS.FUNCIONALIDAD F inner join TROLLS.ROL_FUNCIONALIDAD RXF 
		on F.fun_id = RXF.fun_id where RXF.rol_id = @ID_ROL and F.fun_visible = 1
end
go

--Crear Usuario
create procedure TROLLS.CREAR_USUARIO @USU_USUARIO varchar(30), @USU_PASSWORD nvarchar(255), @USU_CANT_INT_FALLIDOS int, @USU_ESTADO bit
as
begin
	insert into TROLLS.USUARIO values (@USU_USUARIO,TROLLS.ENCRIPTAR(@USU_PASSWORD),@USU_CANT_INT_FALLIDOS,@USU_ESTADO)
end
go
--Crear Direccion
create procedure TROLLS.CREAR_DIRECCION @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_PISO char(2), @DIR_DTO char(2), @DIR_CP char(4), @DIR_LOCALIDAD varchar(50), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	insert into TROLLS.DIRECCION values (@DIR_CALLE,@DIR_NUM,@DIR_PISO,@DIR_DTO,@DIR_CP,@DIR_LOCALIDAD,@DIR_TELEFONO,@DIR_MAIL)
end
go

--Obtener ID Direccion
create procedure TROLLS.OBTENER_ID_DIRECCION @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_PISO char(2), @DIR_DTO char(2), @DIR_CP char(4) ,@DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50), @DIR_LOCALIDAD varchar(50)
as
begin
	select dir_id from TROLLS.DIRECCION where dir_calle=@DIR_CALLE and dir_num = @DIR_NUM and dir_piso = @DIR_PISO and dir_dto = @DIR_DTO and DIR_CP=@DIR_CP and DIR_TELEFONO=@DIR_TELEFONO and DIR_MAIL=@DIR_MAIL and DIR_LOCALIDAD=@DIR_LOCALIDAD
end
go
--Crear Cliente
create procedure TROLLS.CREAR_CLIENTE @CLI_USU_ID int, @CLI_NOMBRE varchar(30), @CLI_APELLIDO varchar(30), @CLI_TIPO_DOC char(3), @CLI_NRO_DOC char(10), @CLI_CUIL char(11), @CLI_FECHA_NAC DateTime, @CLI_FECHA_CREACION DateTime, @CLI_PTOS int, @CLI_TARJ varchar(19), @CLI_DIRECCION int
as
begin
	insert into TROLLS.CLIENTE(CLI_USU_ID,CLI_NOMBRE,CLI_APELLIDO,CLI_TIPO_DOC,CLI_NRO_DOC,CLI_CUIL,CLI_FECHA_NAC,CLI_FECHA_CREACION,CLI_PTOS,CLI_TARJ,CLI_DIRECCION,cli_estado) values (@CLI_USU_ID,@CLI_NOMBRE,@CLI_APELLIDO,@CLI_TIPO_DOC,@CLI_NRO_DOC,@CLI_CUIL,@CLI_FECHA_NAC,@CLI_FECHA_CREACION,@CLI_PTOS,@CLI_TARJ,@CLI_DIRECCION,1)
end
go
--Crear Empresa
create procedure TROLLS.CREAR_EMPRESA @EMP_USU_ID int, @EMP_RAZON_SOCIAL varchar(50), @EMP_CUIT char(11), @EMP_DIRECCION int
as
begin
	insert into TROLLS.EMPRESA(EMP_USU_ID,EMP_RAZON_SOCIAL,EMP_CUIT,EMP_DIRECCION,EMP_ESTADO) values (@EMP_USU_ID,@EMP_RAZON_SOCIAL,@EMP_CUIT,@EMP_DIRECCION,1)
end
go
--Crear RolxUsuario
create procedure TROLLS.CREAR_ROLxUSUARIO @USU_ID int, @ROL_ID int
as
begin
	INSERT INTO TROLLS.Rol_Usuario(rol_id, usu_id, estado)
	VALUES (@ROL_ID,@USU_ID,1)
end
go

IF OBJECT_ID('TROLLS.LISTAR_CLIENTES_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_CLIENTES_EXISTENTES
GO

create procedure TROLLS.LISTAR_CLIENTES_EXISTENTES
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
	from TROLLS.CLIENTE C inner join TROLLS.DIRECCION D
	on c.cli_direccion = d.dir_id
		WHERE C.CLI_NOMBRE LIKE ISNULL('%' + @CLI_NOMBRE + '%', '%')
              AND C.CLI_APELLIDO LIKE ISNULL('%' + @CLI_APELLIDO + '%', '%')
              AND D.DIR_MAIL LIKE ISNULL('%' + @DIR_MAIL + '%', '%')
              AND (@CLI_NRO_DOC is null or C.CLI_NRO_DOC = @CLI_NRO_DOC);
end
go  


IF OBJECT_ID('TROLLS.LISTAR_EMPRESAS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_EMPRESAS_EXISTENTES
GO

create procedure TROLLS.LISTAR_EMPRESAS_EXISTENTES
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
	from TROLLS.EMPRESA E inner join TROLLS.DIRECCION D
	on e.emp_direccion = d.dir_id
		WHERE E.emp_razon_social LIKE ISNULL('%' + @EMP_RAZON_SOCIAL + '%', '%')
              AND D.DIR_MAIL LIKE ISNULL('%' + @DIR_MAIL + '%', '%')
              AND (@EMP_CUIT is null or e.emp_cuit = @EMP_CUIT);
			  
end
go

IF OBJECT_ID('TROLLS.OBTENER_EMPRESA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_EMPRESA
GO

create procedure TROLLS.OBTENER_EMPRESA @ID int
as
begin
	SELECT emp_razon_social,emp_cuit FROM TROLLS.Empresa where emp_id = @ID
end
GO

create procedure TROLLS.OBTENER_CLIENTE @ID int
as
begin
	SELECT cli_apellido,cli_nombre,cli_tipo_doc,cli_nro_doc,cli_tarj,cli_cuil,cli_fecha_nac FROM TROLLS.Cliente where cli_id = @ID
end
GO

create procedure TROLLS.OBTENER_DIRECCION @ID int
as
begin
	SELECT dir_calle,dir_num,dir_piso,dir_dto,dir_cp,dir_localidad,dir_telefono,dir_mail FROM TROLLS.Direccion where dir_id = @ID
end
GO

IF OBJECT_ID('TROLLS.MODIFICAR_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_CLIENTE
GO

CREATE PROCEDURE TROLLS.MODIFICAR_CLIENTE
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
	UPDATE TROLLS.CLIENTE SET cli_nombre = @CLI_NOMBRE, cli_apellido = @CLI_APELLIDO, cli_tipo_doc = @CLI_TIPO_DOC, cli_nro_doc = @CLI_NRO_DOC, cli_cuil = @CLI_CUIL, cli_fecha_nac = @CLI_FECHA_NAC, cli_tarj = @CLI_TARJ WHERE cli_id = @CLI_ID
COMMIT
GO 

IF OBJECT_ID('TROLLS.MODIFICAR_EMPRESA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_EMPRESA
GO

CREATE PROCEDURE TROLLS.MODIFICAR_EMPRESA
@EMP_ID int,
@EMP_RAZON_SOCIAL VARCHAR(50), 
@EMP_CUIT CHAR(11)
AS
BEGIN TRANSACTION
	UPDATE TROLLS.EMPRESA SET emp_razon_social = @EMP_RAZON_SOCIAL, emp_cuit = @EMP_CUIT WHERE emp_id = @EMP_ID
COMMIT
GO 


create procedure TROLLS.MODIFICAR_DIRECCION @DIR_ID int, @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_PISO char(2), @DIR_DTO char(2), @DIR_CP char(4), @DIR_LOCALIDAD varchar(50), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	UPDATE TROLLS.DIRECCION SET dir_calle= @DIR_CALLE,dir_num= @DIR_NUM,dir_piso= @DIR_PISO,dir_dto= @DIR_DTO,dir_cp= @DIR_CP,dir_localidad= @DIR_LOCALIDAD,dir_telefono= @DIR_TELEFONO,dir_mail= @DIR_MAIL WHERE dir_id = @DIR_ID
end
go

IF OBJECT_ID('TROLLS.OBTENERGRADOS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERGRADOS
GO

create procedure TROLLS.OBTENERGRADOS
AS
BEGIN 
	select gra_id,gra_desc from TROLLS.GradoPublicacion
END
GO

IF OBJECT_ID('TROLLS.OBTENERRUBROS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERRUBROS
GO

create procedure TROLLS.OBTENERRUBROS
AS
BEGIN 
	select rub_id,rub_desc from TROLLS.Rubro
END
GO

IF OBJECT_ID('TROLLS.OBTENERTIPOSUBICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERTIPOSUBICACION
GO

create procedure TROLLS.OBTENERTIPOSUBICACION
AS
BEGIN 
	select tu_id,tu_desc from TROLLS.TipoUbicacion
END
GO

IF OBJECT_ID('TROLLS.CREAR_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_PUBLICACION
GO

--Crear Publicacion
create procedure TROLLS.CREAR_PUBLICACION 
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
	insert into TROLLS.Publicacion(pub_estado,pub_desc,pub_fecha_pub,pub_fecha_espec,pub_rubro,pub_dir,pub_gra,pub_usu) values (@pub_estado,@pub_desc,@pub_fecha_pub,@pub_fecha_espec,@pub_rubro,@pub_dir,@pub_gra,@pub_usu)
end
go

IF OBJECT_ID('TROLLS.OBTENER_ID_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_ID_PUBLICACION
GO

create procedure TROLLS.OBTENER_ID_PUBLICACION @pub_desc varchar(400), @pub_dir int, @pub_usu int, @pub_fecha_espec datetime
as
begin
	select pub_id from TROLLS.Publicacion where pub_desc=@pub_desc and pub_dir = @pub_dir and pub_usu = @pub_usu and pub_fecha_espec = @pub_fecha_espec
end
go

IF OBJECT_ID('TROLLS.LISTAR_PUBLICACIONES_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_PUBLICACIONES_EXISTENTES
GO

create procedure TROLLS.LISTAR_PUBLICACIONES_EXISTENTES
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
	from TROLLS.Publicacion p
		where p.pub_usu = @PUB_USU and (p.pub_estado = @PUB_ESTADO1 or p.pub_estado = @PUB_ESTADO2)
end
go

IF OBJECT_ID('TROLLS.OBTENER_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_PUBLICACION
GO

create procedure TROLLS.OBTENER_PUBLICACION @ID int
as
begin
	SELECT pub_id,pub_estado,pub_desc,pub_fecha_pub,pub_fecha_espec,pub_rubro,pub_dir,pub_gra,pub_usu FROM TROLLS.Publicacion where pub_id = @ID
end
GO

IF OBJECT_ID('TROLLS.CREAR_UBICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_UBICACION
GO

--Crear Ubicación
create procedure TROLLS.CREAR_UBICACION
@ubi_tipo varchar(10), 
@ubi_precio numeric(10,2), 
@ubi_sin_numerar bit, 
@ubi_asiento varchar(5),
@ubi_fila varchar(5),
@ubi_pub int
as
begin
	insert into TROLLS.Ubicacion(ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_asiento,ubi_fila,ubi_pub) values (@ubi_tipo,@ubi_precio,@ubi_sin_numerar,@ubi_asiento,@ubi_fila,@ubi_pub)
end
go

IF OBJECT_ID('TROLLS.CREAR_UBICACION_SIN_NUMERAR', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_UBICACION_SIN_NUMERAR
GO

--Crear Ubicación sin Numerar
create procedure TROLLS.CREAR_UBICACION_SIN_NUMERAR
@ubi_tipo varchar(10), 
@ubi_precio numeric(10,2), 
@ubi_sin_numerar bit, 
@ubi_pub int
as
begin
	insert into TROLLS.Ubicacion(ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_pub) values (@ubi_tipo,@ubi_precio,@ubi_sin_numerar,@ubi_pub)
end
go

IF OBJECT_ID('TROLLS.MODIFICAR_ESTADO_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_ESTADO_PUBLICACION
GO

CREATE PROCEDURE TROLLS.MODIFICAR_ESTADO_PUBLICACION
@PUB_ID int,
@PUB_ESTADO VARCHAR(10),
@pub_fecha_pub datetime
AS
BEGIN TRANSACTION
	UPDATE TROLLS.Publicacion SET pub_estado = @PUB_ESTADO,pub_fecha_pub = @pub_fecha_pub WHERE pub_id = @PUB_ID
COMMIT
GO 

IF OBJECT_ID('TROLLS.OBTENER_UBICACIONES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_UBICACIONES
GO

create procedure TROLLS.OBTENER_UBICACIONES @ID int
as
begin
	SELECT ubi_id,ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_asiento,ubi_fila,ubi_pub FROM TROLLS.Ubicacion where ubi_pub = @ID
end
GO

IF OBJECT_ID('TROLLS.MODIFICAR_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_PUBLICACION
GO

--Modificar Publicacion
create procedure TROLLS.MODIFICAR_PUBLICACION
@pub_id int, 
@pub_estado varchar(10), 
@pub_desc varchar(400), 
@pub_fecha_pub datetime, 
@pub_fecha_espec datetime, 
@pub_rubro int,
@pub_gra int
as
begin
	UPDATE TROLLS.Publicacion SET pub_estado=@pub_estado,pub_desc=@pub_desc,pub_fecha_pub=@pub_fecha_pub,pub_fecha_espec=@pub_fecha_espec,pub_rubro=@pub_rubro,pub_gra=@pub_gra where pub_id=@pub_id
end
go

IF OBJECT_ID('TROLLS.VALIDAR_PUBLICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.VALIDAR_PUBLICACION
GO

--Validar Publicacion
create procedure TROLLS.VALIDAR_PUBLICACION
@pub_desc varchar(400), 
@pub_fecha_espec datetime
as
begin
	SELECT 1 FROM TROLLS.PUBLICACION WHERE pub_desc = @pub_desc and pub_fecha_espec = @pub_fecha_espec
end
go



IF OBJECT_ID('TROLLS.MODIFICAR_UBICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_UBICACION
GO

--Modificar Ubicación
create procedure TROLLS.MODIFICAR_UBICACION
@ubi_id int,
@ubi_tipo varchar(10),  
@ubi_precio numeric(10,2), 
@ubi_sin_numerar bit, 
@ubi_asiento varchar(5),
@ubi_fila varchar(5)
as
begin 
	UPDATE TROLLS.Ubicacion SET ubi_tipo=@ubi_tipo,ubi_precio=@ubi_precio,ubi_sin_numerar=@ubi_sin_numerar,ubi_asiento=@ubi_asiento,ubi_fila=@ubi_fila where ubi_id = @ubi_id
end
go

IF OBJECT_ID('TROLLS.LISTAR_PUBLICACIONES_PUBLICADAS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_PUBLICACIONES_PUBLICADAS
GO

--Tipo temporal para tabla rubros
IF type_id('TROLLS.Rubros') IS NOT NULL
        DROP TYPE TROLLS.Rubros;
CREATE TYPE TROLLS.Rubros AS TABLE ( 
  rub_id int
)
GO

create procedure TROLLS.LISTAR_PUBLICACIONES_PUBLICADAS
(@pub_desc VARCHAR(400),
@pub_fecha_espec_de VARCHAR(23), 
@pub_fecha_espec_hasta VARCHAR(23), 
@rubro TROLLS.Rubros READONLY)
as
begin
	select  p.pub_id as id,
			p.pub_desc as Descripcion,
			p.pub_fecha_espec as FechaEspectaculo,
			p.pub_fecha_pub as FechaPublicacion
	from TROLLS.Publicacion p join TROLLS.GradoPublicacion on pub_gra=gra_id
		where pub_desc LIKE ISNULL('%' + @pub_desc + '%', '%') and (pub_fecha_espec between (SELECT CONVERT(datetime, @pub_fecha_espec_de, 121)) and (SELECT CONVERT(datetime, @pub_fecha_espec_hasta, 121))) and pub_rubro in (select rub_id from @rubro) and pub_estado = 'Publicada'
		order by gra_peso desc
end
go



IF OBJECT_ID('TROLLS.OBTENER_UBICACIONES_SIN_COMPRA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_UBICACIONES_SIN_COMPRA
GO

create procedure TROLLS.OBTENER_UBICACIONES_SIN_COMPRA @ID int,@ubi_tipo int
as
begin
	SELECT ubi_id,ubi_tipo,ubi_precio,ubi_sin_numerar,ubi_asiento,ubi_fila,ubi_pub FROM TROLLS.Ubicacion where ubi_pub = @ID and ubi_com is null and ubi_tipo=@ubi_tipo
end
GO

IF OBJECT_ID('TROLLS.OBTENERDESCTIPOUBICACION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERDESCTIPOUBICACION
GO

create procedure TROLLS.OBTENERDESCTIPOUBICACION @ID int
as
begin
	SELECT tu_desc FROM TROLLS.TipoUbicacion where tu_id = @ID
end
GO

IF OBJECT_ID('TROLLS.CREAR_COMPRA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_COMPRA
GO

--Tipo temporal para tabla ubicaciones
IF type_id('TROLLS.Ubicaciones') IS NOT NULL
        DROP TYPE TROLLS.Ubicaciones;
CREATE TYPE TROLLS.Ubicaciones AS TABLE ( 
  ubi_id int,
  ubi_pub int,
  ubi_precio numeric(10,2)
)
GO

create procedure TROLLS.CREAR_COMPRA
(@cli_id int,
@com_fecha datetime, 
@ubicaciones TROLLS.Ubicaciones READONLY)
as
begin
	declare @com_cant int
	select @com_cant = (select count(*) from @ubicaciones)
	declare @com_id int	
	declare @com_total numeric(18,2)
	select @com_total = (select sum(ubi_precio) from @ubicaciones)
	--Insert compra
	insert into TROLLS.Compra(com_fecha,com_cli,com_mp,com_cant,com_total) values (@com_fecha,@cli_id,2,@com_cant,@com_total)

	--Update ubicaciones
	select @com_id = SCOPE_IDENTITY()
	UPDATE TROLLS.Ubicacion SET ubi_com=@com_id where ubi_id in (select ubi_id from @ubicaciones)

	--Comprobar publicaciones para finalizar de @ubicaciones
	update TROLLS.Publicacion set pub_estado='Finalizada' where pub_id in (
		select ubi_pub from @ubicaciones u
		group by ubi_pub 
		having (select count(ubi_id) from TROLLS.Publicacion join TROLLS.Ubicacion on pub_id = ubi_pub where pub_id=u.ubi_pub 
				group by pub_id) = 
				(select count(ubi_id) from TROLLS.Publicacion join TROLLS.Ubicacion on pub_id = ubi_pub where ubi_com is not null and pub_id=u.ubi_pub
				group by pub_id)
			  )
	--Otorgar puntos 10% de compra, extender el vencimiento a un mes de la compra
	declare @cli_puntos int
	select @cli_puntos = ROUND(@com_total*0.1,0,1)
	declare @cli_ptos_venc_nueva datetime
	select @cli_ptos_venc_nueva = (select DATEADD(month, 6, @com_fecha))

	if exists(select cli_ptos_venc from TROLLS.Cliente where cli_id = @cli_id)
	begin		
		declare @cli_ptos_venc datetime
		select @cli_ptos_venc = (select cli_ptos_venc from TROLLS.Cliente where cli_id = @cli_id)
		if(@cli_ptos_venc<@com_fecha)
		begin 
			--puntos vencidos, se renuevan
			UPDATE TROLLS.Cliente SET cli_ptos=@cli_puntos,cli_ptos_venc=@cli_ptos_venc_nueva where cli_id = @cli_id
		end
		else
		begin
			--puntos validos, se suman los nuevos y se renueva fecha de vencimiento
			declare @cli_puntos_anteriores int
			select @cli_puntos_anteriores = (select cli_ptos from TROLLS.Cliente where cli_id = @cli_id)
			UPDATE TROLLS.Cliente SET cli_ptos=(@cli_puntos+@cli_puntos_anteriores),cli_ptos_venc=@cli_ptos_venc_nueva where cli_id = @cli_id
		end
	end
	else
	begin
		--no tiene puntos
		UPDATE TROLLS.Cliente SET cli_ptos=@cli_puntos,cli_ptos_venc=@cli_ptos_venc_nueva where cli_id = @cli_id
	end
end
go

IF OBJECT_ID('TROLLS.CREAR_TARJETA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_TARJETA
GO

create procedure TROLLS.CREAR_TARJETA
@cli_id int,
@cli_tarj char(19)
as
begin
	UPDATE TROLLS.Cliente SET cli_tarj=@cli_tarj where cli_id = @cli_id
end
go

IF OBJECT_ID('TROLLS.LISTAR_COMPRAS_A_RENDIR', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_COMPRAS_A_RENDIR
GO

create procedure TROLLS.LISTAR_COMPRAS_A_RENDIR
as
begin
	select  distinct (com_id) as id,
			e.emp_razon_social as RazonSocial,
			e.emp_cuit as CUIT,
			p.pub_desc as Publicacion,
			com_cant as Cantidad,
			com_total as Total,
			com_fecha as FechaCompra
	from TROLLS.Compra co join TROLLS.Ubicacion u on co.com_id = u.ubi_com join TROLLS.Publicacion p on u.ubi_pub = p.pub_id join TROLLS.Empresa e on e.emp_usu_id = p.pub_usu
		where com_fact is null
		order by co.com_fecha asc
end
go


IF OBJECT_ID('TROLLS.RENDIR_COMPRA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.RENDIR_COMPRA
GO

--Tipo temporal para tabla ubicaciones
IF type_id('TROLLS.Compras') IS NOT NULL
        DROP TYPE TROLLS.Compras;
CREATE TYPE TROLLS.Compras AS TABLE ( 
  com_id int,
  orden int
)
GO

IF OBJECT_ID('TROLLS.FACTURA_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.FACTURA_SEQ

--Secuenciador a partir de ultima factura
	DECLARE @max int;
SELECT @max = MAX(fact_nro)+1
     FROM TROLLS.Factura

exec('CREATE SEQUENCE TROLLS.FACTURA_SEQ 
    START WITH ' + @max +
'   INCREMENT BY 1;');
GO

CREATE PROCEDURE TROLLS.RENDIR_COMPRA @compras TROLLS.Compras READONLY, @fact_fecha datetime
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
	fact_nro NUMERIC(18,0) default NEXT VALUE FOR TROLLS.FACTURA_SEQ,
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
			CONCAT('Comisión Ubicación ',(select tu_desc from TROLLS.TipoUbicacion where u.ubi_tipo=tu_id),' ',ISNULL(u.ubi_fila+u.ubi_asiento,'Sin numerar'),' ',p.pub_desc,' ',p.pub_fecha_espec),
			(u.ubi_precio*(g.gra_comision/100))	
	from TROLLS.Compra co join TROLLS.Ubicacion u on co.com_id = u.ubi_com join TROLLS.Publicacion p on u.ubi_pub = p.pub_id join TROLLS.Empresa e on e.emp_usu_id = p.pub_usu join TROLLS.GradoPublicacion g on p.pub_gra = g.gra_id 
		where com_fact is null and com_id in (select com_id from @compras)

	--Factura Temp
	INSERT INTO @FACT_TEMP(fact_emp,fact_total,fact_fecha)
	select distinct emp_id,sum(item_fact_monto),@fact_fecha
	from @ITEM_FACT_TEMP
	group by emp_id

	--Se agrega numeros de factura en items
	UPDATE i set i.fact_nro=f.fact_nro from @ITEM_FACT_TEMP i join @FACT_TEMP f on i.emp_id = f.fact_emp
	
	--Factura
	INSERT INTO TROLLS.Factura(fact_nro,fact_emp,fact_total,fact_fecha)
	select fact_nro,fact_emp,fact_total,fact_fecha from @FACT_TEMP

	--Item Factura
	INSERT INTO TROLLS.Item_Factura(item_fact_nro,item_fact_monto,item_fact_desc)
	select fact_nro,item_fact_monto,item_fact_desc from @ITEM_FACT_TEMP

	--Update Compra
	UPDATE c set c.com_fact= f.fact_nro from TROLLS.Compra c join @ITEM_FACT_TEMP i on c.com_id = i.com_id join @FACT_TEMP f on i.emp_id = f.fact_emp

END;
GO

IF OBJECT_ID('TROLLS.LISTAR_COMPRAS_REALIZADAS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_COMPRAS_REALIZADAS
GO

create procedure TROLLS.LISTAR_COMPRAS_REALIZADAS @ID int
as
begin
	select  p.pub_desc as Espectaculo,
			p.pub_fecha_espec as FechaEspectaculo,
			(select tu_desc from TROLLS.TipoUbicacion where u.ubi_tipo=tu_id) as TipoUbicacion,
			ISNULL(u.ubi_fila+u.ubi_asiento,'Sin numerar') as FilaAsiento,
			u.ubi_precio as Precio,
			(select mp_desc	from TROLLS.MedioPago where mp_id = co.com_mp) as MedioPago,
			co.com_fecha as FechaCompra
	from TROLLS.Compra co join TROLLS.Ubicacion u on co.com_id = u.ubi_com join TROLLS.Publicacion p on u.ubi_pub = p.pub_id join TROLLS.Cliente c on c.cli_id=co.com_cli 
		where c.cli_id = @ID
		order by co.com_fecha desc
end
go

IF OBJECT_ID('TROLLS.LISTAR_PREMIOS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_PREMIOS_EXISTENTES
GO

create procedure TROLLS.LISTAR_PREMIOS_EXISTENTES
as
begin
	select tp_id as id, tp_desc as Premio, tp_puntos as Puntos
	from TROLLS.TipoPremio
end
go

IF OBJECT_ID('TROLLS.OBTENER_PUNTOS_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_PUNTOS_CLIENTE 
GO

create procedure TROLLS.OBTENER_PUNTOS_CLIENTE @ID int
as
begin
	select cli_ptos,cli_ptos_venc
	from TROLLS.Cliente where cli_id = @ID
end
go

IF OBJECT_ID('TROLLS.CANJEAR_PUNTOS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CANJEAR_PUNTOS 
GO

create procedure TROLLS.CANJEAR_PUNTOS
@cli_id int, 
@tp_id int
as
begin
	declare @puntosPremio int = (select tp_puntos from TROLLS.TipoPremio where tp_id = @tp_id);
	insert into TROLLS.Premio(pre_tipo,pre_cli) values (@tp_id,@cli_id)
	UPDATE TROLLS.Cliente SET cli_ptos = (cli_ptos - @puntosPremio) WHERE cli_id = @cli_id
end
go

IF OBJECT_ID('TROLLS.LISTAR_GRADOS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_GRADOS_EXISTENTES
GO

create procedure TROLLS.LISTAR_GRADOS_EXISTENTES
as
begin
	select gra_id as id, gra_desc as GradoPublicacion, gra_comision as Comision, gra_peso as Peso
	from TROLLS.GradoPublicacion where gra_estado = 1
end
go

IF OBJECT_ID('TROLLS.LISTAR_USUARIOS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_USUARIOS_EXISTENTES
GO

create procedure TROLLS.LISTAR_USUARIOS_EXISTENTES
as
begin
	select usu_id as id, usu_cant_int_fallidos as IntentosFallidos, usu_estado as Estado
	from TROLLS.Usuario
end
go

IF OBJECT_ID('TROLLS.CREAR_GRADO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_GRADO 
GO

create procedure TROLLS.CREAR_GRADO
@gra_peso int, 
@gra_desc varchar(30),
@gra_comision numeric (2,0)
as
begin
	insert into TROLLS.GradoPublicacion(gra_peso,gra_desc,gra_comision,gra_estado) values (@gra_peso,@gra_desc,@gra_comision,1)
end
go

IF OBJECT_ID('TROLLS.MODIFICAR_GRADO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_GRADO 
GO

create procedure TROLLS.MODIFICAR_GRADO
@gra_peso int, 
@gra_desc varchar(30),
@gra_comision numeric (2,0),
@gra_id int
as
begin
	UPDATE TROLLS.GradoPublicacion SET gra_peso=@gra_peso,gra_desc=@gra_desc,gra_comision=@gra_comision WHERE gra_id = @gra_id
end
go

IF OBJECT_ID('TROLLS.OBTENER_GRADO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_GRADO 
GO

create procedure TROLLS.OBTENER_GRADO @ID int
as
begin
	select gra_id,gra_desc,gra_comision,gra_peso from TROLLS.GradoPublicacion where gra_id = @ID
end
go

IF OBJECT_ID('TROLLS.MODIFICAR_CLAVE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_CLAVE 
GO

create procedure TROLLS.MODIFICAR_CLAVE
@usu_id int,
@usu_password varchar(255)
as
begin
	UPDATE TROLLS.Usuario SET usu_password=TROLLS.ENCRIPTAR(@usu_password) WHERE usu_id = @usu_id
end
go


IF OBJECT_ID('TROLLS.sp_listado_estadistico_1', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.sp_listado_estadistico_1 
GO

--Listado 1
create procedure TROLLS.sp_listado_estadistico_1 (@trimestre int, @anio int)
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
	from TROLLS.Ubicacion
		join TROLLS.Publicacion on ubi_pub = pub_id join TROLLS.GradoPublicacion on pub_gra=gra_id
	where ubi_com is null
		and year(pub_fecha_espec) = @anio
		and month(pub_fecha_espec) between ((@trimestre * 3) - 2) and @trimestre * 3
	group by pub_id, pub_usu, pub_fecha_espec, gra_peso, pub_gra
	order by 3 desc, 4 desc, gra_peso desc

select e.emp_razon_social as RazonSocial, e.emp_cuit as CUIT
	from TROLLS.empresa e
	join @pub
		on pub_usu = emp_usu_id
	order by cantidad desc, fecha desc
end
go


IF OBJECT_ID('TROLLS.sp_listado_estadistico_2', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.sp_listado_estadistico_2 
GO

--Listado 2
create procedure TROLLS.sp_listado_estadistico_2(@trimestre int, @anio int, @fechasistema datetime)
as
begin
select top 5 cli_nombre as Nombre ,cli_apellido as Apellido ,cli_tipo_doc as Tipo ,cli_nro_doc as Documento
	from TROLLS.Cliente
	where cli_ptos is not null
		and cli_ptos_venc is not null
		and cli_ptos_venc < @fechasistema
		and month(cli_ptos_venc) between ((@trimestre * 3) - 2) and @trimestre * 3
		and year(cli_ptos_venc) = @anio
	order by cli_ptos desc
end
go


IF OBJECT_ID('TROLLS.sp_listado_estadistico_3', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.sp_listado_estadistico_3 
GO
--Listado 3
create procedure TROLLS.sp_listado_estadistico_3(@trimestre int, @anio int)
as
begin
select	top 5
		cli_id, cli_usu_id, cli_nombre as Nombre,
		cli_apellido as Apellido, cli_tipo_doc as Tipo, cli_nro_doc as Documento

	from TROLLS.Cliente as c
		join TROLLS.compra on com_cli = cli_id
		join TROLLS.Ubicacion on ubi_com = com_id
		join TROLLS.Publicacion on pub_id = ubi_pub
		join TROLLS.Usuario on usu_id = pub_usu
		join TROLLS.Empresa on emp_usu_id = usu_id
	where year(com_fecha) = @anio
		and month(pub_fecha_espec) between ((@trimestre * 3) - 2) and @trimestre * 3
	group by cli_id, cli_usu_id, cli_nombre,
		cli_apellido, cli_tipo_doc, cli_nro_doc
	order by sum(com_total) desc
end
go

--Se borran sps/funciones utilizadas en la migracion
DROP FUNCTION TROLLS.MODIFICA_CUIT
DROP PROCEDURE TROLLS.Z_MIGRACION_CLIENTES
DROP PROCEDURE TROLLS.Z_MIGRACION_EMPRESAS
DROP PROCEDURE TROLLS.Z_MIGRACION_COMPRAS_UBICACION
--Drop tabla maestra
drop table gd_esquema.Maestra;
go