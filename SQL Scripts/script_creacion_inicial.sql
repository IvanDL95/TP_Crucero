USE GD1C2019
GO

--************CREACION DE SCHEMA**************
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'TROLLS')
	BEGIN
		EXEC sys.sp_executesql N'CREATE SCHEMA TROLLS AUTHORIZATION gdCruceros2019'
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

if OBJECT_ID('TROLLS.Reserva', 'U') is not null
	drop table TROLLS.Reserva;
create table TROLLS.Reserva (res_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					  res_fecha datetime not null,
					  res_cab_nro NUMERIC(18,0) NOT NULL, 
					  res_cab_piso NUMERIC(18,0) NOT NULL,
					  res_cab_tcab_id NUMERIC(18,0) NOT NULL,
					  res_cli_id NUMERIC(10,0) not null, --FK Cliente
					  res_pue_hasta NUMERIC(18,0) not null, --FK Puerto
					  res_via_id NUMERIC(18,0) NOT NULL, --FK Viaje
					  res_estado BIT NOT NULL DEFAULT 1,
					  PRIMARY KEY(res_id));

if OBJECT_ID('TROLLS.Pasaje', 'U') is not null
	drop table TROLLS.Pasaje;
create table TROLLS.Pasaje (pas_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					 pas_precio decimal(18,2) not null,
					 pas_fec_compra datetime not null,
					 pas_cli_id NUMERIC(10,0) NOT NULL, --FK Cliente
					 pas_cab_nro NUMERIC(18,0) NOT NULL, 
					 pas_cab_piso NUMERIC(18,0) NOT NULL,
					 pas_cab_tcab_id NUMERIC(18,0) NOT NULL,
					 pas_mp_id NUMERIC(18,0) NOT NULL,  --FK Medio_De_Pago
					 pas_pue_hasta NUMERIC(18,0) NOT NULL, --FK Puerto
					 pas_via_id NUMERIC(18,0) NOT NULL, --FK Viaje
					 PRIMARY KEY(pas_id));

if OBJECT_ID('TROLLS.MedioPago', 'U') is not null
	drop table TROLLS.MedioPago;
create table TROLLS.MedioPago (mp_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							mp_desc nvarchar(100) not null,
							PRIMARY KEY(mp_id));

if OBJECT_ID('TROLLS.Recorrido_Tramo', 'U') is not null
	drop table TROLLS.Recorrido_Tramo;
create table TROLLS.Recorrido_Tramo (tra_id NUMERIC(18,0) NOT NULL, --FK Tramo
							rec_id NUMERIC(18,0) NOT NULL, --FK Puerto
							estado BIT NOT NULL DEFAULT 1
							);

if OBJECT_ID('TROLLS.Tramos', 'U') is not null
	drop table TROLLS.Tramos;
create table TROLLS.Tramos( tra_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
									tra_desde NUMERIC(18,0) not null, --FK Puerto
									tra_hasta NUMERIC(18,0) not null, --FK Puerto
									tra_precio_base DECIMAL(18,2) NOT NULL,
									tra_durac NUMERIC(20),
									primary key (tra_id));	

if OBJECT_ID('TROLLS.Cabina', 'U') is not null
	drop table TROLLS.Cabina;
create table TROLLS.Cabina (cab_nro NUMERIC(18,0)  NOT NULL,
							 cab_id NUMERIC(18,0)  IDENTITY(1,1) NOT NULL,
							 cab_piso NUMERIC(2,0) not null,
							 cab_tcab_id NUMERIC(18,0) not null, --FK Tipo_Cabina	 
							 cab_via_id NUMERIC(18,0), --FK Viaje
							 cab_ocupada BIT NOT NULL DEFAULT 0,
							 PRIMARY KEY(cab_id));

if OBJECT_ID('TROLLS.Viaje', 'U') is not null
	drop table TROLLS.Viaje;
create table TROLLS.Viaje(via_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							 via_fecha_salida datetime not null, 
							 via_fecha_llegada datetime not null, 
							 via_fecha_llegada_estimada datetime not null, 
							 via_cru_id CHAR(30) not null, --FK Crucero
							 via_rec_id NUMERIC(18,0) not null, --FK Recorrido
							 primary key (via_id));

if OBJECT_ID('TROLLS.Cabinas_Crucero', 'U') is not null
	drop table TROLLS.Cabinas_Crucero;
create table TROLLS.Cabinas_Crucero (cc_cru_id CHAR(30) NOT NULL, --FK Crucero
					     cc_cantidad NUMERIC(18,0) not null,
						 cc_tcab_id NUMERIC(18,0), --FK Tipo_Cabina
						 cc_piso NUMERIC(2,0)); 

if OBJECT_ID('TROLLS.Tipo_Cabina', 'U') is not null
	drop table TROLLS.Tipo_Cabina;
create table TROLLS.Tipo_Cabina (tcab_id NUMERIC(18,0)  IDENTITY(1,1) NOT NULL,
							 tcab_porc_recargo decimal(4,2) not null,
							 tcab_tipo varchar(400) not null, 							 
							 PRIMARY KEY(tcab_id));

if OBJECT_ID('TROLLS.Crucero', 'U') is not null
	drop table TROLLS.Crucero;
create table TROLLS.Crucero (cru_id CHAR(30) NOT NULL, 
					     cru_mod VARCHAR(50) not null, 
						 cru_fab_id NUMERIC(18,0) not null, --FK Fabricante_Crucero
						 cru_tser_id NUMERIC(18,0) not null, --FK Tipo_Servicio_Crucero
						 cru_fecha_alta datetime not null,
						 cru_baja_fuera_servicio BIT NOT NULL DEFAULT 0,
						 cru_baja_vida_util BIT NOT NULL DEFAULT 0,
						 cru_fecha_fuera_servicio datetime,
						 cru_fecha_reinicio_servicio datetime,
						 cru_fecha_baja_definitiva datetime
						 PRIMARY KEY(cru_id)); 

if OBJECT_ID('TROLLS.Fabricante_Crucero', 'U') is not null
	drop table TROLLS.Fabricante_Crucero;
create table TROLLS.Fabricante_Crucero (fab_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
					     fab_desc nvarchar(50) not null, 							 
							 PRIMARY KEY(fab_id));

if OBJECT_ID('TROLLS.Tipo_Servicio_Crucero', 'U') is not null
	drop table TROLLS.Tipo_Servicio_Crucero;
create table TROLLS.Tipo_Servicio_Crucero (tser_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
					     tser_desc nvarchar(50) not null, 							 
							 PRIMARY KEY(tser_id));

if OBJECT_ID('TROLLS.Recorrido', 'U') is not null
	drop table TROLLS.Recorrido;
create table TROLLS.Recorrido( rec_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,	
									rec_pue_id_desde NUMERIC(18,0) not null,
									rec_pue_id_hasta NUMERIC(18,0) not null,
									rec_estado BIT NOT NULL DEFAULT 1,
									primary key (rec_id));	

if OBJECT_ID('TROLLS.Cliente', 'U') is not null
	drop table TROLLS.Cliente;
create table TROLLS.Cliente (cli_id NUMERIC(10,0) IDENTITY(1,1)  NOT NULL, --Nro Doc
					  cli_usu_id NUMERIC(18,0) NOT NULL,
					  cli_nombre NVARCHAR(30) not null,
					  cli_apellido NVARCHAR(30) not null,
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

if OBJECT_ID('TROLLS.Puerto', 'U') is not null
	drop table TROLLS.Puerto;
create table TROLLS.Puerto (pue_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							pue_nombre VARCHAR (100) not null,
							pue_estado BIT NOT NULL DEFAULT 1,
							PRIMARY KEY(pue_id));

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
						usu_password NVARCHAR(255),
						usu_cant_int_fallidos int default 0,
						usu_estado bit default 1
						PRIMARY KEY (usu_id) );


									
-- ******** Fin Creacion de Tablas************


-- ******** Inicio Creacion de FKs************

ALTER TABLE TROLLS.Tramos  WITH CHECK ADD
	CONSTRAINT FK_tra_pue_id_desde FOREIGN KEY (tra_desde)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Tramos  WITH CHECK ADD
	CONSTRAINT FK_tra_pue_id_hasta FOREIGN KEY (tra_hasta)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Viaje  WITH CHECK ADD
	CONSTRAINT FK_viaje_recorrido FOREIGN KEY (via_rec_id)
	REFERENCES TROLLS.Recorrido (rec_id)

ALTER TABLE TROLLS.Viaje  WITH CHECK ADD
	CONSTRAINT FK_viaje_crucero FOREIGN KEY (via_cru_id)
	REFERENCES TROLLS.Crucero (cru_id)

ALTER TABLE TROLLS.Reserva  WITH CHECK ADD
	CONSTRAINT FK_Reserva_viaje FOREIGN KEY (res_via_id)
	REFERENCES TROLLS.Viaje (via_id)

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
	CONSTRAINT FK_Pasaje_cliente FOREIGN KEY (pas_cli_id)
	REFERENCES TROLLS.Cliente (cli_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_puerto FOREIGN KEY (pas_pue_hasta)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_medioPago FOREIGN KEY (pas_mp_id)
	REFERENCES TROLLS.MedioPago (mp_id)

ALTER TABLE TROLLS.Cabinas_Crucero  WITH CHECK ADD
	CONSTRAINT FK_Cabinas_CruceroID FOREIGN KEY (cc_cru_id)
	REFERENCES TROLLS.Crucero (cru_id)

ALTER TABLE TROLLS.Cabinas_Crucero  WITH CHECK ADD
	CONSTRAINT FK_CabinasID_Crucero FOREIGN KEY (cc_tcab_id)
	REFERENCES TROLLS.Tipo_Cabina (tcab_id)

ALTER TABLE TROLLS.Crucero  WITH CHECK ADD
	CONSTRAINT FK_Fabricante_Crucero FOREIGN KEY (cru_fab_id)
	REFERENCES TROLLS.Fabricante_Crucero (fab_id)

ALTER TABLE TROLLS.Crucero  WITH CHECK ADD
	CONSTRAINT FK_Tipo_Servicio_Crucero FOREIGN KEY (cru_tser_id)
	REFERENCES TROLLS.Tipo_Servicio_Crucero (tser_id)

ALTER TABLE TROLLS.Cabina  WITH CHECK ADD
	CONSTRAINT FK_Cabina_tipo FOREIGN KEY (cab_tcab_id)
	REFERENCES TROLLS.Tipo_Cabina (tcab_id)

ALTER TABLE TROLLS.Cabina  WITH CHECK ADD
	CONSTRAINT FK_Cabina_viaje FOREIGN KEY (cab_via_id)
	REFERENCES TROLLS.Viaje (via_id)

ALTER TABLE TROLLS.Recorrido  WITH CHECK ADD
	CONSTRAINT FK_Recorrido_Puerto_Desde FOREIGN KEY (rec_pue_id_desde)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Recorrido  WITH CHECK ADD
	CONSTRAINT FK_Recorrido_Puerto_Hasta FOREIGN KEY (rec_pue_id_hasta)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Recorrido_Tramo  WITH CHECK ADD
	CONSTRAINT FK_TramoID FOREIGN KEY (tra_id)
	REFERENCES TROLLS.Tramos (tra_id)

ALTER TABLE TROLLS.Recorrido_Tramo  WITH CHECK ADD
	CONSTRAINT FK_RecorridoID FOREIGN KEY (rec_id)
	REFERENCES TROLLS.Recorrido (rec_id)

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

--INDICES
IF EXISTS (SELECT *  FROM sys.indexes  WHERE name='indice_cabina' 
    AND object_id = OBJECT_ID('TROLLS.Cabina'))
  begin
    DROP INDEX indice_cabina ON TROLLS.Cabina;
  end

  CREATE INDEX indice_cabina ON TROLLS.Cabina (cab_nro , cab_piso , cab_tcab_id, cab_via_id)



-- ******** Inicio Migracion************

-- Creo Roles
INSERT INTO TROLLS.Rol(rol_nombre, rol_estado)
VALUES
('Administrativo', 1),
('Cliente', 1);

--Creo Funcionalidades
INSERT INTO TROLLS.Funcionalidad(fun_nombre)
VALUES
('ABM DE ROL'),
('ABM DE PUERTO'),
('ABM DE RECORRIDO'),
('ABM DE CRUCERO'),
('GENERAR VIAJE'),
('COMPRA Y/O RESERVA DE VIAJE'),
('PAGO RESERVA'),
('LISTADO ESTADISTICO');

--Asigno Funcionalidades a Roles
INSERT INTO TROLLS.Rol_Funcionalidad(rol_id, fun_id, estado)
VALUES
(1,1,1),(1,2,1),(1,3,1),(1,4,1),(1,5,1),(1,6,1),(1,7,1),(1,8,1),
(2,6,1),(2,7,1)
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
INSERT INTO TROLLS.Usuario(usu_id,usu_usuario, usu_password)
VALUES
(next value for TROLLS.USUARIO_SEQ, 'admin2',TROLLS.ENCRIPTAR('w23e'))
SET IDENTITY_INSERT TROLLS.usuario OFF;

INSERT INTO TROLLS.Rol_Usuario(rol_id, usu_id, estado)
VALUES
(1,1,1),(1,2,1)
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'TROLLS.GETNUMBER')
AND type in (N'FN', N'IF',N'TF', N'FS', N'FT'))
DROP FUNCTION TROLLS.GETNUMBER
GO

CREATE FUNCTION TROLLS.GETNUMBER
(@strAlphaNumeric VARCHAR(256))
RETURNS VARCHAR(256)
AS
BEGIN
DECLARE @intAlpha INT
SET @intAlpha = PATINDEX('%^0-9%', @strAlphaNumeric)
BEGIN
WHILE @intAlpha > 0
BEGIN
SET @strAlphaNumeric = STUFF(@strAlphaNumeric, @intAlpha, 1, '' )
SET @intAlpha = PATINDEX('%^0-9%', @strAlphaNumeric )
END
END
RETURN ISNULL(@strAlphaNumeric,0)
END
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
	cli_apellido NVARCHAR(30),
	cli_nombre NVARCHAR(30),
	cli_fecha_nac DATETIME,	
	usu_usuario NVARCHAR(30),
	usu_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.USUARIO_SEQ,
	dir_mail NVARCHAR(50),
	dir_calle NVARCHAR(70),
	dir_num CHAR(5),
	dir_telefono NVARCHAR(18),
	dir_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.DIRECCION_SEQ,
PRIMARY KEY (cli_nro_doc) 
WITH (IGNORE_DUP_KEY = ON) /*Evita DNI duplicados*/
	
	);

	--Tabla temporal
	INSERT INTO @MIGRA_CLIENTE_TEMP 
	(cli_nro_doc,cli_apellido,cli_nombre,cli_fecha_nac,
	usu_usuario,
	dir_mail,dir_calle,dir_num)
	SELECT DISTINCT Cli_Dni,Cli_Apellido,Cli_Nombre,Cli_Fecha_Nac,Cli_Dni,
	Cli_Mail,LEFT(CLI_DIRECCION, LEN(CLI_DIRECCION)-LEN(TROLLS.GETNUMBER((SELECT RIGHT(CLI_DIRECCION,4))))),TROLLS.GETNUMBER((SELECT RIGHT(CLI_DIRECCION,4)))
		   FROM GD_ESQUEMA.MAESTRA
	WHERE Cli_Dni IS NOT NULL 

	--Usuario
	SET IDENTITY_INSERT TROLLS.usuario ON;
	INSERT INTO TROLLS.usuario(usu_id,usu_usuario,usu_cant_int_fallidos,usu_estado)
	SELECT 
	usu_id,usu_usuario,0,1
	FROM @MIGRA_CLIENTE_TEMP;
	SET IDENTITY_INSERT TROLLS.usuario OFF;
	--Se asigna rol Cliente
	insert into TROLLS.Rol_Usuario(usu_id,rol_id,estado)
	select usu_id,2,1 from @MIGRA_CLIENTE_TEMP
	--Domicilio
	SET IDENTITY_INSERT TROLLS.Direccion ON;
	INSERT INTO TROLLS.Direccion(dir_id,DIR_CALLE,DIR_NUM,DIR_telefono,DIR_MAIL)
	SELECT 
	dir_id,dir_calle,dir_num,dir_telefono,dir_mail
	FROM @MIGRA_CLIENTE_TEMP;
	SET IDENTITY_INSERT TROLLS.Direccion OFF;
	--Cliente
	SET IDENTITY_INSERT TROLLS.CLIENTE ON;
	INSERT INTO TROLLS.CLIENTE(cli_id,cli_apellido,cli_nombre,cli_fecha_nac,cli_usu_id,cli_direccion)
	SELECT cli_nro_doc,cli_apellido,cli_nombre,cli_fecha_nac,usu_id,dir_id
	FROM @MIGRA_CLIENTE_TEMP;
	SET IDENTITY_INSERT TROLLS.CLIENTE OFF;

END;
GO

EXEC TROLLS.Z_MIGRACION_CLIENTES;
GO

--FABRICANTE
INSERT INTO TROLLS.Fabricante_Crucero(fab_desc)
	SELECT 
	distinct CRU_FABRICANTE
	FROM GD_ESQUEMA.MAESTRA
	WHERE CRU_FABRICANTE IS NOT NULL

--SERVICIO
INSERT INTO TROLLS.Tipo_Servicio_Crucero (tser_desc)
VALUES ('Lujo'),('Comun')
GO

--CRUCERO
INSERT INTO TROLLS.Crucero(cru_id,cru_mod,cru_fab_id,cru_tser_id,cru_fecha_alta)
	SELECT 
	distinct CRUCERO_IDENTIFICADOR, 
	CRUCERO_MODELO, 
	(SELECT fab_id from TROLLS.Fabricante_Crucero where fab_desc=CRU_FABRICANTE),1,GETDATE()
	FROM GD_ESQUEMA.MAESTRA
	WHERE CRUCERO_IDENTIFICADOR IS NOT NULL

--PUERTO
INSERT INTO TROLLS.Puerto(pue_nombre)
  SELECT PUERTO_DESDE
  FROM GD_ESQUEMA.MAESTRA
  union 
  SELECT PUERTO_HASTA
  FROM GD_ESQUEMA.MAESTRA

IF OBJECT_ID('TROLLS.TRAMOS_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.TRAMOS_SEQ
CREATE SEQUENCE TROLLS.TRAMOS_SEQ START WITH 1 INCREMENT BY 1;
GO

IF OBJECT_ID('TROLLS.Z_MIGRACION_RECORRIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.Z_MIGRACION_RECORRIDO
GO

CREATE PROCEDURE TROLLS.Z_MIGRACION_RECORRIDO     
AS 
BEGIN		
	DECLARE @MIGRA_RECORRIDO_TRAMO_TEMP TABLE 
	(
	RECORRIDO_CODIGO NUMERIC(18,0),
	RECORRIDO_PRECIO_BASE DECIMAL(18,2),
	PUERTO_DESDE NUMERIC(18,0),
	PUERTO_HASTA NUMERIC(18,0),	
	tra_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.TRAMOS_SEQ
	);

	DECLARE @MIGRA_RECORRIDO_TEMP TABLE 
	(
	RECORRIDO_CODIGO NVARCHAR(30),
	PUERTO_DESDE NUMERIC(18,0),
	PUERTO_HASTA NUMERIC(18,0)
	);

	--Tabla temporal
	INSERT INTO @MIGRA_RECORRIDO_TRAMO_TEMP 
	(RECORRIDO_CODIGO,RECORRIDO_PRECIO_BASE,PUERTO_DESDE,PUERTO_HASTA)
	SELECT
      RECORRIDO_CODIGO
      ,RECORRIDO_PRECIO_BASE
      ,(SELECT pue_id from TROLLS.Puerto where pue_nombre=PUERTO_DESDE)
      ,(SELECT pue_id from TROLLS.Puerto where pue_nombre=PUERTO_HASTA) 
 FROM GD_ESQUEMA.MAESTRA
 WHERE RECORRIDO_CODIGO IS NOT NULL
  group by RECORRIDO_CODIGO,RECORRIDO_PRECIO_BASE,PUERTO_DESDE,PUERTO_HASTA
	
	--Recorridos de 2 tramos
	INSERT INTO @MIGRA_RECORRIDO_TEMP(RECORRIDO_CODIGO,PUERTO_DESDE,PUERTO_HASTA)
	select t1.RECORRIDO_CODIGO,t1.PUERTO_DESDE,t2.PUERTO_HASTA from @MIGRA_RECORRIDO_TRAMO_TEMP t1 
join @MIGRA_RECORRIDO_TRAMO_TEMP t2 on t1.PUERTO_HASTA=t2.PUERTO_DESDE and t1.RECORRIDO_CODIGO=t2.RECORRIDO_CODIGO

	--Recorridos de 1 tramo
	INSERT INTO @MIGRA_RECORRIDO_TEMP(RECORRIDO_CODIGO,PUERTO_DESDE,PUERTO_HASTA)
	select RECORRIDO_CODIGO,PUERTO_DESDE,PUERTO_HASTA from @MIGRA_RECORRIDO_TRAMO_TEMP t1 where (select COUNT(*) from @MIGRA_RECORRIDO_TRAMO_TEMP t2 where t1.RECORRIDO_CODIGO=t2.RECORRIDO_CODIGO) =1

	--Recorrido
	SET IDENTITY_INSERT TROLLS.Recorrido ON;
	INSERT INTO TROLLS.RECORRIDO(rec_id,rec_pue_id_desde,rec_pue_id_hasta)
	select * from @MIGRA_RECORRIDO_TEMP
	SET IDENTITY_INSERT TROLLS.Recorrido OFF;

	--Tramos
	SET IDENTITY_INSERT TROLLS.Tramos ON;
	INSERT INTO TROLLS.Tramos(tra_id,tra_desde,tra_hasta,tra_durac,tra_precio_base)
	select tra_id,PUERTO_DESDE,PUERTO_HASTA,480,RECORRIDO_PRECIO_BASE from @MIGRA_RECORRIDO_TRAMO_TEMP
	SET IDENTITY_INSERT TROLLS.Tramos OFF;

	--Tramos por recorrido
	INSERT INTO TROLLS.Recorrido_Tramo (rec_id,tra_id)
	select RECORRIDO_CODIGO,tra_id from @MIGRA_RECORRIDO_TRAMO_TEMP

END;
GO

EXEC TROLLS.Z_MIGRACION_RECORRIDO;
GO

--VIAJE
INSERT INTO TROLLS.Viaje (via_fecha_salida,via_fecha_llegada,via_fecha_llegada_estimada,via_rec_id,via_cru_id)
SELECT 
      FECHA_SALIDA
      ,FECHA_LLEGADA
      ,FECHA_LLEGADA_ESTIMADA
      ,RECORRIDO_CODIGO
      ,CRUCERO_IDENTIFICADOR
  FROM GD_ESQUEMA.MAESTRA
  group by FECHA_SALIDA
      ,FECHA_LLEGADA
      ,FECHA_LLEGADA_ESTIMADA
      ,RECORRIDO_CODIGO
      ,CRUCERO_IDENTIFICADOR

--TIPOCABINA
INSERT INTO TROLLS.Tipo_Cabina(tcab_tipo,tcab_porc_recargo)
	SELECT 
	distinct CABINA_TIPO, CABINA_TIPO_PORC_RECARGO
	FROM GD_ESQUEMA.MAESTRA
	WHERE CABINA_TIPO IS NOT NULL

IF OBJECT_ID('TROLLS.Z_MIGRACION_CABINA_RESERVA_PASAJE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.Z_MIGRACION_CABINA_RESERVA_PASAJE
GO

CREATE PROCEDURE TROLLS.Z_MIGRACION_CABINA_RESERVA_PASAJE
AS 
BEGIN		
	DECLARE @MIGRA_CABINA_TEMP TABLE 
	(
	FECHA_SALIDA datetime,
	FECHA_LLEGADA datetime,
	FECHA_LLEGADA_ESTIMADA datetime,
	RECORRIDO_CODIGO NUMERIC(18,0),
	CABINA_NRO NUMERIC(18,0),
	CABINA_PISO NUMERIC(2,0),
	CRUCERO_IDENTIFICADOR CHAR(30),
	CABINA_TIPO NUMERIC(18,0)
	,RESERVA_CODIGO NUMERIC(18,0)
    ,RESERVA_FECHA datetime
	,cli_id NUMERIC(10,0)
	,PASAJE_CODIGO NUMERIC(18,0)
    ,PASAJE_PRECIO decimal(18,2)
    ,PASAJE_FECHA_COMPRA datetime
    ,PUERTO_HASTA  NUMERIC(18,0)
	,via_id NUMERIC(18,0)
	);

INSERT INTO @MIGRA_CABINA_TEMP
SELECT FECHA_SALIDA
      ,FECHA_LLEGADA
      ,FECHA_LLEGADA_ESTIMADA
      ,RECORRIDO_CODIGO
	  ,CABINA_NRO
      ,CABINA_PISO
      ,CRUCERO_IDENTIFICADOR
      ,(SELECT tcab_id from TROLLS.Tipo_Cabina where tcab_tipo=CABINA_TIPO)
	  ,RESERVA_CODIGO
      ,RESERVA_FECHA
	  ,CLI_DNI
	,PASAJE_CODIGO 
    ,PASAJE_PRECIO 
    ,PASAJE_FECHA_COMPRA 
    ,(SELECT pue_id from TROLLS.Puerto where pue_nombre=PUERTO_HASTA)
	,(SELECT via_id from TROLLS.Viaje where via_fecha_salida=FECHA_SALIDA and via_fecha_llegada=FECHA_LLEGADA and via_fecha_llegada_estimada=FECHA_LLEGADA_ESTIMADA 
	  and via_cru_id=CRUCERO_IDENTIFICADOR and via_rec_id=RECORRIDO_CODIGO)  
  FROM GD_ESQUEMA.MAESTRA
  group by FECHA_SALIDA
      ,FECHA_LLEGADA
      ,FECHA_LLEGADA_ESTIMADA
      ,RECORRIDO_CODIGO
      ,CABINA_NRO
      ,CABINA_PISO
      ,CRUCERO_IDENTIFICADOR
      ,CABINA_TIPO
	  ,RESERVA_CODIGO 
    ,RESERVA_FECHA 
	,CLI_DNI 
	,PASAJE_CODIGO 
    ,PASAJE_PRECIO 
    ,PASAJE_FECHA_COMPRA 
    ,PUERTO_HASTA   

	--CABINA_CRUCERO
	INSERT INTO TROLLS.Cabinas_Crucero(cc_cru_id,cc_piso,cc_tcab_id,cc_cantidad)
	select distinct CRUCERO_IDENTIFICADOR
	,CABINA_PISO
	,CABINA_TIPO
	,(select top 1 count([CABINA_NRO]) from @MIGRA_CABINA_TEMP
	  where CRUCERO_IDENTIFICADOR = M.CRUCERO_IDENTIFICADOR and CABINA_PISO = M.CABINA_PISO AND CABINA_TIPO = M.CABINA_TIPO
	  group by CRUCERO_IDENTIFICADOR,CABINA_TIPO,CABINA_PISO,RECORRIDO_CODIGO order by 1 desc) 
	from @MIGRA_CABINA_TEMP M
	group by CRUCERO_IDENTIFICADOR,CABINA_PISO,CABINA_TIPO 

	--CABINA
	INSERT INTO TROLLS.Cabina(cab_nro,cab_piso,cab_tcab_id,cab_via_id,cab_ocupada)
	SELECT distinct CABINA_NRO
      ,CABINA_PISO
      ,CABINA_TIPO
	  ,via_id ,1 --SIEMPRE OCUPADA
  FROM @MIGRA_CABINA_TEMP

  --RESERVA
  SET IDENTITY_INSERT TROLLS.Reserva ON;
  INSERT INTO TROLLS.Reserva(res_id,res_fecha,res_cab_nro,res_cab_piso,res_cab_tcab_id,res_cli_id,res_pue_hasta,res_via_id,res_estado)
	SELECT distinct RESERVA_CODIGO,RESERVA_FECHA
    ,CABINA_NRO
      ,CABINA_PISO
	  ,CABINA_TIPO
	,cli_id
	,PUERTO_HASTA
	,via_id, 1
  FROM @MIGRA_CABINA_TEMP 
  where RESERVA_CODIGO is not null
  group by RESERVA_CODIGO 
    ,RESERVA_FECHA,CABINA_NRO
      ,CABINA_PISO,via_id,CABINA_TIPO,cli_id,PUERTO_HASTA
SET IDENTITY_INSERT TROLLS.Reserva OFF;

 --Creo Medios de pago
INSERT INTO TROLLS.MedioPago (mp_desc)
VALUES ('Efectivo'),('Tarjeta')

  --PASAJE
  SET IDENTITY_INSERT TROLLS.Pasaje ON;
  INSERT INTO TROLLS.Pasaje(pas_id,pas_precio,pas_fec_compra,pas_cli_id,pas_cab_nro,pas_cab_piso,pas_cab_tcab_id,pas_mp_id,pas_pue_hasta,pas_via_id)
	SELECT distinct PASAJE_CODIGO,PASAJE_PRECIO,PASAJE_FECHA_COMPRA,cli_id
    ,CABINA_NRO
      ,CABINA_PISO
	  ,CABINA_TIPO
	,1 --Siempre Medio de Pago Efectivo
	,PUERTO_HASTA
	,via_id
  FROM @MIGRA_CABINA_TEMP 
  where PASAJE_CODIGO is not null
  group by PASAJE_CODIGO,PASAJE_PRECIO,PASAJE_FECHA_COMPRA,cli_id
    ,CABINA_NRO
      ,CABINA_PISO
	  ,CABINA_TIPO
	  ,PUERTO_HASTA
	  ,via_id
SET IDENTITY_INSERT TROLLS.Pasaje OFF;

END;
GO

EXEC TROLLS.Z_MIGRACION_CABINA_RESERVA_PASAJE;
GO

IF OBJECT_ID('TROLLS.LISTAR_CLIENTES_EXISTENTES_INICIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_CLIENTES_EXISTENTES_INICIO
GO

create procedure TROLLS.LISTAR_CLIENTES_EXISTENTES_INICIO
@CLI_NOMBRE VARCHAR(30), 
@CLI_APELLIDO VARCHAR(30),
@CLI_NRO_DOC CHAR(10)
as
begin
	select  
			C.CLI_ID as id,
			C.CLI_NOMBRE as Nombre,
			C.CLI_APELLIDO as Apellido,
			D.DIR_MAIL as Mail
	from TROLLS.CLIENTE C inner join TROLLS.DIRECCION D
	on c.cli_direccion = d.dir_id
		WHERE C.CLI_NOMBRE LIKE ISNULL('%' + @CLI_NOMBRE + '%', '%')
              AND C.CLI_APELLIDO LIKE ISNULL('%' + @CLI_APELLIDO + '%', '%')
              AND (@CLI_NRO_DOC is null or C.CLI_ID = @CLI_NRO_DOC);
end
go   


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

create procedure TROLLS.OBTENER_FUNCIONALIDADES_ROL @ID_ROL int
as
begin
	select F.fun_id from TROLLS.FUNCIONALIDAD F inner join TROLLS.ROL_FUNCIONALIDAD RXF 
		on F.fun_id = RXF.fun_id where RXF.rol_id = @ID_ROL and F.fun_visible = 1
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

IF OBJECT_ID('TROLLS.OBTENERTIPOSERVICIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERTIPOSERVICIO
GO

create procedure TROLLS.OBTENERTIPOSERVICIO
AS
BEGIN 
	select tser_id,tser_desc from TROLLS.Tipo_Servicio_Crucero
END
GO

IF OBJECT_ID('TROLLS.OBTENERFABRICANTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERFABRICANTES
GO

create procedure TROLLS.OBTENERFABRICANTES
AS
BEGIN 
	select fab_id,fab_desc from TROLLS.Fabricante_Crucero
END
GO

IF OBJECT_ID('TROLLS.LISTAR_CRUCEROS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_CRUCEROS_EXISTENTES
GO

create procedure TROLLS.LISTAR_CRUCEROS_EXISTENTES
@CRU_ID VARCHAR(30),
@cru_mod_desc VARCHAR(50),
@cru_tser_id int,
@cru_fab_id int
as
begin
	select  
			C.cru_id as id,
			C.cru_mod as Modelo,
			(select fab_desc from TROLLS.Fabricante_Crucero where fab_id=cru_fab_id) as Marca,
			(select tser_desc from TROLLS.Tipo_Servicio_Crucero where tser_id=cru_tser_id) as Tipo_Servicio,
			c.cru_fecha_alta as Fecha_Alta,
			c.cru_baja_fuera_servicio as Baja_Fuera_Servicio,
			c.cru_baja_vida_util as Baja_Vida_Util,
			c.cru_fecha_fuera_servicio as Fecha_Fuera_Servicio,
			c.cru_fecha_reinicio_servicio as Fecha_Reinicio_Servicio,
			c.cru_fecha_baja_definitiva as Fecha_Baja_Definitiva
	from TROLLS.Crucero C
		WHERE C.cru_id LIKE ISNULL('%' + @CRU_ID + '%', '%')
			  AND C.cru_mod LIKE ISNULL('%' + @cru_mod_desc + '%', '%')
              AND (@cru_tser_id is null or C.cru_tser_id = @cru_tser_id)
              AND (@cru_fab_id is null or C.cru_fab_id = @cru_fab_id);
end
go

IF OBJECT_ID('TROLLS.OBTENER_CRUCERO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_CRUCERO
GO

create procedure TROLLS.OBTENER_CRUCERO @ID char(30)
as
begin
	SELECT cru_id,cru_mod,cru_fab_id,cru_tser_id,cru_fecha_alta,cru_baja_fuera_servicio,cru_baja_vida_util,cru_fecha_fuera_servicio,cru_fecha_reinicio_servicio,cru_fecha_baja_definitiva FROM TROLLS.Crucero where cru_id = @ID
end
GO

IF OBJECT_ID('TROLLS.OBTENER_CABINA_CRUCERO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_CABINA_CRUCERO
GO

create procedure TROLLS.OBTENER_CABINA_CRUCERO @ID char(30)
as
begin
	SELECT cc_piso,cc_cantidad,cc_tcab_id FROM TROLLS.Cabinas_Crucero where cc_cru_id = @ID
end
GO

IF OBJECT_ID('TROLLS.OBTENERDESCTIPOCABINA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERDESCTIPOCABINA
GO

create procedure TROLLS.OBTENERDESCTIPOCABINA @ID int
as
begin
	SELECT tcab_tipo FROM TROLLS.Tipo_Cabina where tcab_id = @ID
end
GO

IF OBJECT_ID('TROLLS.OBTENERTIPOSCABINA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERTIPOSCABINA
GO

create procedure TROLLS.OBTENERTIPOSCABINA
AS
BEGIN 
	select tcab_id,tcab_tipo from TROLLS.Tipo_Cabina
END
GO

IF OBJECT_ID('TROLLS.CREAR_CRUCERO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_CRUCERO
GO

--Crear Crucero
create procedure TROLLS.CREAR_CRUCERO 
@cru_id char(30), 
@cru_mod varchar(50), 
@cru_fab_id int, 
@cru_tser_id int,
@cru_fecha_alta datetime
as
begin
	insert into TROLLS.Crucero(cru_id,cru_mod,cru_fab_id,cru_tser_id,cru_fecha_alta) values (@cru_id,@cru_mod,@cru_fab_id,@cru_tser_id,@cru_fecha_alta)
end
go

IF OBJECT_ID('TROLLS.CREAR_CABINA_CRUCERO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_CABINA_CRUCERO
GO

--Crear Cabina Crucero
create procedure TROLLS.CREAR_CABINA_CRUCERO
@cru_id char(30),
@cc_piso int,  
@cc_cantidad numeric(18,0), 
@cc_tcab_id int
as
begin
	insert into TROLLS.Cabinas_Crucero(cc_cru_id,cc_piso,cc_cantidad,cc_tcab_id) values (@cru_id,@cc_piso,@cc_cantidad,@cc_tcab_id)
end
go

/*IF OBJECT_ID('TROLLS.MODIFICAR_ESTADO_PUBLICACION', 'P') IS NOT NULL
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
GO */

IF OBJECT_ID('TROLLS.MODIFICAR_CRUCERO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_CRUCERO
GO

--Modificar Crucero
create procedure TROLLS.MODIFICAR_CRUCERO
@cru_id char(30), 
@cru_mod varchar(50), 
@cru_fab_id int, 
@cru_tser_id int
as
begin
	UPDATE TROLLS.Crucero SET cru_mod=@cru_mod,cru_fab_id=@cru_fab_id,cru_tser_id=@cru_tser_id where cru_id=@cru_id
end
go

IF OBJECT_ID('TROLLS.VALIDAR_CRUCERO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.VALIDAR_CRUCERO
GO

--Validar Crucero
create procedure TROLLS.VALIDAR_CRUCERO
@cru_id char(30)
as
begin
	SELECT 1 FROM TROLLS.CRUCERO WHERE cru_id = @cru_id
end
go



IF OBJECT_ID('TROLLS.MODIFICAR_CABINA_CRUCERO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_CABINA_CRUCERO
GO

--Modificar Cabina Crucero
create procedure TROLLS.MODIFICAR_CABINA_CRUCERO
@cru_id char(30),
@cc_piso int,  
@cc_cantidad numeric(18,0), 
@cc_tcab_id int
as
begin 
	UPDATE TROLLS.Cabinas_Crucero SET cc_cantidad=@cc_cantidad where cc_cru_id=@cru_id and cc_piso=@cc_piso and cc_tcab_id=@cc_tcab_id
end
go

/*

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

create procedure TROLLS.MODIFICAR_DIRECCION @DIR_ID int, @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_PISO char(2), @DIR_DTO char(2), @DIR_CP char(4), @DIR_LOCALIDAD varchar(50), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	UPDATE TROLLS.DIRECCION SET dir_calle= @DIR_CALLE,dir_num= @DIR_NUM,dir_piso= @DIR_PISO,dir_dto= @DIR_DTO,dir_cp= @DIR_CP,dir_localidad= @DIR_LOCALIDAD,dir_telefono= @DIR_TELEFONO,dir_mail= @DIR_MAIL WHERE dir_id = @DIR_ID
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
go*/