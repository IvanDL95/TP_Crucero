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

if OBJECT_ID('TROLLS.Tramo', 'U') is not null
	drop table TROLLS.Tramo;
create table TROLLS.Tramo( tra_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
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
							 via_fecha_salida datetime not null, 
							 via_fecha_llegada datetime not null, 
							 via_fecha_llegada_estimada datetime not null, 
							 via_cru_id NUMERIC(18,0) not null, --FK Crucero
							 via_rec_id nvarchar(25), --FK Recorrido
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
('Cliente', 1);

--Creo Funcionalidades
INSERT INTO TROLLS.Funcionalidad(fun_nombre)
VALUES
('ABM DE ROL'),
('REGISTRO DE USUARIO'),
('ABM DE CLIENTES'),
('ABM DE CRUCEROS'),
('ABM DE RECORRIDO'),
('GENERAR VIAJE'),
('COMPRA DE VIAJE O RESERVA'),
('PAGO DE RESERVA'),
('LISTADO ESTADISTICO')
--,('ABM DE PUERTO')
;

--Asigno Funcionalidades a Roles
INSERT INTO TROLLS.Rol_Funcionalidad(rol_id, fun_id, estado)
VALUES
(1,1,1),(1,2,1),(1,3,1),(1,4,1),(1,5,1),(1,6,1),(1,7,1),(1,8,1),(1,9,1),
(2,7,1),(2,8,1)
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
(1,1,1),(2,1,1)
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

--CREO CRUCEROS
SET IDENTITY_INSERT TROLLS.Crucero ON;
INSERT INTO TROLLS.Crucero (cru_id, cru_modelo, cru_fabric)
SELECT crucero_identificador, crucero_modelo, cru_fabricante
FROM GD_ESQUEMA.MAESTRA
where	crucero_identificador is not null
and		crucero_modelo is not null
and 	cru_fabricante IS NOT NULL
GROUP BY crucero_identificador, crucero_modelo, cru_fabricante
SET IDENTITY_INSERT TROLLS.Crucero OFF;
GO

--Creo TipoCabinas
IF OBJECT_ID('TROLLS.TIPOCABINA_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.TIPOCABINA_SEQ
CREATE SEQUENCE TROLLS.TIPOCABINA_SEQ START WITH 1 INCREMENT BY 1;
GO
--INSERT TIPO CABINA
SET IDENTITY_INSERT TROLLS.TipoCabina ON;
INSERT INTO TROLLS.TipoCabina (tcab_id,tcab_tipo,tcab_porc_recargo)
SELECT (NEXT VALUE FOR TROLLS.TIPOCABINA_SEQ), CABINA_TIPO, CABINA_TIPO_PORC_RECARGO
FROM GD_ESQUEMA.MAESTRA
GROUP BY CABINA_TIPO, CABINA_TIPO_PORC_RECARGO
SET IDENTITY_INSERT TROLLS.TipoCabina OFF;
GO

--Creo Cabinas
IF OBJECT_ID('TROLLS.CABINA_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.CABINA_SEQ
CREATE SEQUENCE TROLLS.CABINA_SEQ START WITH 1 INCREMENT BY 1;
GO
--INSERT CABINA
SET IDENTITY_INSERT TROLLS.Cabina ON;
INSERT INTO TROLLS.Cabina (cab_id,cab_nro,cab_piso,cab_tcab_id,cru_id)
SELECT (NEXT VALUE FOR TROLLS.CABINA_SEQ),
m.cabina_nro, m.cabina_piso, tc.tcab_id, cr.cru_id
join TipoCabina TC on tc.tcab_porc_recargo = m.CABINA_TIPO_PORC_RECARGO
join Crucero CR on cr.cru_id = m.CRUCERO_IDENTIFICADOR
FROM GD_ESQUEMA.MAESTRA M
SET IDENTITY_INSERT TROLLS.Cabina OFF;
GO

--Creo Puertos
IF OBJECT_ID('TROLLS.PUERTO_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.PUERTO_SEQ
CREATE SEQUENCE TROLLS.PUERTO_SEQ START WITH 1 INCREMENT BY 1;
GO

SET IDENTITY_INSERT TROLLS.Puerto ON;
INSERT INTO TROLLS.Puerto (pue_id,pue_nombre,pue_estado)
SELECT (next value for TROLLS.PUERTO_SEQ), distinct(PUERTO_DESDE),1
FROM GD_ESQUEMA.MAESTRA
where PUERTO_DESDE is not null
GO

INSERT INTO TROLLS.Puerto (pue_id,pue_nombre,pue_estado)
SELECT (next value for TROLLS.PUERTO_SEQ), distinct(PUERTO_HASTA),1
FROM GD_ESQUEMA.MAESTRA
where PUERTO_HASTA is not null
AND PUERTO_HASTA not in (
	SELECT distinct(pue_nombre)
	FROM TROLLS.Puerto
	where pue_nombre is not null
)
SET IDENTITY_INSERT TROLLS.Puerto OFF;
GO

--Creo Tramos
IF OBJECT_ID('TROLLS.TRAMO_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.TRAMO_SEQ
CREATE SEQUENCE TROLLS.TRAMO_SEQ START WITH 1 INCREMENT BY 1;
GO

SET IDENTITY_INSERT TROLLS.Tramo ON;
INSERT INTO TROLLS.Tramo (tra_id, tra_desde, tra_hasta, tra_rec_id, tra_precio)
SELECT (next value for TROLLS.TRAMO_SEQ), PUERTO_DESDE, PUERTO_HASTA, RECORRIDO_CODIGO, RECORRIDO_PRECIO_BASE
FROM GD_ESQUEMA.MAESTRA
where	RECORRIDO_CODIGO is not null
and		RECORRIDO_PRECIO_BASE is not null
GROUP BY RECORRIDO_CODIGO, RECORRIDO_PRECIO_BASE, PUERTO_DESDE, PUERTO_HASTA
SET IDENTITY_INSERT TROLLS.Tramo OFF;
GO

--Creo Recorridos
SET IDENTITY_INSERT TROLLS.Tramo ON;
INSERT INTO TROLLS.RECORRIDO (rec_id, rec_precio_base, rec_desde, rec_hasta)
SELECT RECORRIDO_CODIGO, sum(tr.tra_precio) ,PUERTO_DESDE, PUERTO_HASTA
FROM GD_ESQUEMA.MAESTRA m
join TROLLS.Tramo TR on tr.tra_desde = m.puerto_desde
where	(tr.tra_id,tr.tra_desde) <> (tr.tra_id,tr.tra_hasta)
and		RECORRIDO_PRECIO_BASE is not null
GROUP BY RECORRIDO_CODIGO, RECORRIDO_PRECIO_BASE, PUERTO_DESDE, PUERTO_HASTA
SET IDENTITY_INSERT TROLLS.Tramo OFF;
GO

--Creo Medios de pago
/* 
NO HAY MEDIOS DE PAGO EN LA TABLA MAESTRA!!

INSERT INTO TROLLS.MedioPago (mp_desc)
select distinct Forma_Pago_Desc
FROM GD_ESQUEMA.MAESTRA
where Forma_Pago_Desc is not null
*/
SET IDENTITY_INSERT TROLLS.MedioPago ON;
INSERT INTO TROLLS.MedioPago (mdp_id,mdp_desc)
VALUES (1,'Efectivo'),(2,'Tarjeta'),(3,'Débito')
SET IDENTITY_INSERT TROLLS.MedioPago OFF;
GO

--Creo Viajes
SET IDENTITY_INSERT TROLLS.Viaje ON;
 INSERT INTO TROLLS.Viaje (via_id,via_fec_salida,via_fec_llegada,via_fec_llegada_estimada,via_cru_id,via_rec_id)
 select distinct m.RECORRIDO_CODIGO, m.fecha_salida, m.fecha_llegada, m.FECHA_LLEGADA_ESTIMADA,c.cru_id,r.rec_id
 from gd_esquema.Maestra m
join TROLLS.Crucero C on c.cru_id = m.identificador_creucero
join TROLLS.Recorrido R on r.rec_id = m.RECORRIDO_CODIGO
order by RECORRIDO_CODIGO
SET IDENTITY_INSERT TROLLS.Viaje OFF;
GO

--Creo Pasajes

SET IDENTITY_INSERT TROLLS.Pasaje ON;
 INSERT INTO TROLLS.Pasaje (pas_id,pas_precio,pas_fec_compra,pas_cab_id,pas_mdp_id,pas_via_id, pas_cli_id, pas_pue_hasta)
 select distinct m.PASAJE_CODIGO, m.PASAJE_PRECIO, m.PASAJE_FECHA_COMPRA,cab.cab_id,cr.cru_id,via.via_id,cl.cli_id,re.rec_hasta,re.rec_hasta
 from gd_esquema.Maestra m
join TROLLS.Cabina CAB on cab.cru_id = m.CRUCERO_IDENTIFICADOR
join TROLLS.Cliente CL on cl.cli_nro_doc = m.CLI_DNI
join TROLLS.Recorrido RE on re.rec_id = m.RECORRIDO_CODIGO
join TROLLS.Viaje VIA on via.via_rec_id = m.RECORRIDO_CODIGO
order by PASAJE_CODIGO
SET IDENTITY_INSERT TROLLS.Pasaje OFF;
GO

--Creo Reservas

SET IDENTITY_INSERT TROLLS.Reserva ON;
insert into TROLLS.Reserva (res_id,res_fec,res_via_id,res_cab_id,res_cli_id,res_pue_hasta)
select RESERVA_CODIGO,RESERVA_FECHA,via.via_id,cab.cab_id,cli.cli_id,rec.rec_hasta
from gd_esquema.Maestra m
join TROLLS.Cabina CAB on cab.cru_id = m.CRUCERO_IDENTIFICADOR
join TROLLS.Cliente CLI on cli.cli_nro_doc = m.CLI_DNI
join TROLLS.Recorrido REC on rec.rec_id = m.RECORRIDO_CODIGO
join TROLLS.Viaje VIA on via.via_rec_id = m.RECORRIDO_CODIGO
order by Factura_Nro
SET IDENTITY_INSERT TROLLS.Reserva OFF;
GO

/*

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
*/
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
create procedure TROLLS.CREAR_DIRECCION @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	insert into TROLLS.DIRECCION values (@DIR_CALLE,@DIR_NUM,@DIR_TELEFONO,@DIR_MAIL)
end
go

--Obtener ID Direccion
create procedure TROLLS.OBTENER_ID_DIRECCION @DIR_CALLE varchar(70), @DIR_NUM char(5),@DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	select dir_id from TROLLS.DIRECCION where dir_calle=@DIR_CALLE and dir_num = @DIR_NUM and DIR_TELEFONO=@DIR_TELEFONO and DIR_MAIL=@DIR_MAIL
end
go
--Crear Cliente
create procedure TROLLS.CREAR_CLIENTE @CLI_USU_ID int, @CLI_NOMBRE varchar(30), @CLI_APELLIDO varchar(30), @CLI_NRO_DOC char(10), @CLI_FECHA_NAC DateTime, @CLI_FECHA_CREACION DateTime, @CLI_DIRECCION int
as
begin
	insert into TROLLS.CLIENTE(CLI_USU_ID,CLI_NOMBRE,CLI_APELLIDO,CLI_NRO_DOC,CLI_FECHA_NAC,CLI_FECHA_CREACION,CLI_DIRECCION,cli_estado) 
	values (@CLI_USU_ID,@CLI_NOMBRE,@CLI_APELLIDO,@CLI_NRO_DOC,@CLI_FECHA_NAC,@CLI_FECHA_CREACION,@CLI_DIRECCION,1)
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

create procedure TROLLS.OBTENER_CLIENTE @ID int
as
begin
	SELECT cli_apellido,cli_nombre,cli_nro_doc,cli_fecha_nac 
	FROM TROLLS.Cliente where cli_id = @ID
end
GO

create procedure TROLLS.OBTENER_DIRECCION @ID int
as
begin
	SELECT dir_calle,dir_num,dir_telefono,dir_mail 
	FROM TROLLS.Direccion where dir_id = @ID
end
GO

IF OBJECT_ID('TROLLS.MODIFICAR_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_CLIENTE
GO

CREATE PROCEDURE TROLLS.MODIFICAR_CLIENTE
@CLI_ID int,
@CLI_NOMBRE VARCHAR(30), 
@CLI_APELLIDO VARCHAR(30),
@CLI_NRO_DOC CHAR(10),
@CLI_FECHA_NAC DATETIME
AS
BEGIN TRANSACTION
	UPDATE TROLLS.CLIENTE SET cli_nombre = @CLI_NOMBRE, cli_apellido = @CLI_APELLIDO, cli_nro_doc = @CLI_NRO_DOC, cli_fecha_nac = @CLI_FECHA_NAC
	WHERE cli_id = @CLI_ID
COMMIT
GO

create procedure TROLLS.MODIFICAR_DIRECCION @DIR_ID int, @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	UPDATE TROLLS.DIRECCION SET dir_calle= @DIR_CALLE,dir_num= @DIR_NUM,dir_telefono= @DIR_TELEFONO,dir_mail= @DIR_MAIL 
	WHERE dir_id = @DIR_ID
end
go

-- ABM CRUCERO

--Crear Cruceros
create procedure TROLLS.CREAR_CRUCERO @CRU_IDENTIFICADOR varchar(400), @CRU_MODELO nvarchar(20), @CRU_FABRICANTE VARCHAR(100)
as
begin
	insert into TROLLS.CRUCERO values (@CRU_IDENTIFICADOR,@CRU_MODELO,@CRU_FABRICANTE)
end
go

--Listar Cruceros
create procedure TROLLS.LISTAR_CRUCEROS_EXISTENTES
@CRU_IDENTIFICADOR VARCHAR(400), 
@CRU_MODELO nvarchar(20),
@CRU_FABRICANTE VARCHAR(100)
as
begin
	select  
			C.CRU_ID as id,
			C.CRU_MODELO as Modelo,
			C.CRU_FABRIC as Fabricante
	from TROLLS.CRUCERO C 
		WHERE C.CRU_ID LIKE ISNULL('%' + @CRU_IDENTIFICADOR + '%', '%')
			  AND C.CRU_MODELO LIKE ISNULL('%' + @CRU_MODELO + '%', '%')
              AND C.CRU_FABRIC LIKE ISNULL('%' + @CRU_FABRICANTE + '%', '%');
end
go  

--Obtener Cruceros
IF OBJECT_ID('TROLLS.OBTENER_CRUCEROS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_CRUCEROS
GO

create procedure TROLLS.OBTENER_CRUCEROS
@cru_id VARCHAR(400)
as
begin
	select
			C.CRU_ID as id,
			C.CRU_MODELO as Modelo,
			C.CRU_FABRIC as Fabricante
	from TROLLS.CRUCERO C 
		WHERE C.CRU_ID LIKE ISNULL('%' + @cru_id + '%', '%');
end
go

--Modificar Cruceros
IF OBJECT_ID('TROLLS.MODIFICAR_CRUCEROS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_CRUCEROS
GO

create procedure TROLLS.MODIFICAR_CRUCEROS
@cru_id VARCHAR(400), 
@cru_modelo varchar(30), 
@cru_fabric varchar(30)
as
begin
	UPDATE TROLLS.Recorrido 
	SET cru_id=@cru_id,cru_modelo=@cru_modelo,cru_fabric=@cru_fabric
	where cru_id=@cru_id
end
go

--ABM RECORRIDO

--Crear Recorrido 
create procedure TROLLS.CREAR_RECORRIDO @REC_IDENTIFICADOR NUMERIC(18,0), @REC_PREC_BASE DECIMAL(18,2), @REC_DESDE varchar(30), @REC_HASTA varchar(30)
as
begin
	insert into TROLLS.RECORRIDO values (@REC_IDENTIFICADOR,@REC_PREC_BASE,@REC_DESDE,@REC_HASTA)
end
go

--Listar Recorridos
IF OBJECT_ID('TROLLS.LISTAR_RECORRIDOS_EXISTENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_RECORRIDOS_EXISTENTES
GO

create procedure TROLLS.LISTAR_RECORRIDOS_EXISTENTES
@REC_IDENTIFICADOR NUMERIC(18,0), 
@REC_PUERTO_DESDE varchar(30),
@REC_PUERTO_HASTA VARCHAR(30),
@REC_PRECIO DECIMAL(18,2)
as
begin
	select  
			R.REC_ID as id,
			R.REC_DESDE as Desde,
			R.REC_HASTA as Hasta,
			R.REC_PRECIO_BASE as PrecioBase
	from TROLLS.RECORRIDO R 
		WHERE R.REC_ID LIKE ISNULL('%' + @REC_IDENTIFICADOR + '%', '%')
			  AND R.REC_DESDE LIKE ISNULL('%' + @REC_PUERTO_DESDE + '%', '%')
              AND R.REC_HASTA LIKE ISNULL('%' + @REC_PUERTO_HASTA + '%', '%')
			  AND R.REC_PRECIO_BASE LIKE ISNULL('%' + @CRU_FABRICANTE + '%', '%');
end
go  

--Obtener Recorridos
IF OBJECT_ID('TROLLS.OBTENER_RECORRIDOS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_RECORRIDOS
GO

create procedure TROLLS.OBTENER_RECORRIDOS
@rec_id NUMERIC(18,0)
as
begin
	select
			R.REC_ID as id,
			R.REC_DESDE as Desde,
			R.REC_HASTA as Hasta,
			R.REC_PRECIO_BASE as PrecioBase
	from TROLLS.RECORRIDO R 
		WHERE R.REC_ID LIKE ISNULL('%' + @rec_id + '%', '%');
end
go

--Modificar Recorrido
IF OBJECT_ID('TROLLS.MODIFICAR_RECORRIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_RECORRIDO
GO

create procedure TROLLS.MODIFICAR_RECORRIDO
@rec_id NUMERIC(18,0), 
@rec_desde varchar(30), 
@rec_hasta varchar(30), 
@rec_precio_base DECIMAL(18,2)
as
begin
	UPDATE TROLLS.Recorrido 
	SET rec_id=@rec_id,rec_desde=@rec_desde,rec_hasta=@rec_hasta,rec_precio_base=@rec_precio_base 
	where rec_id=@rec_id
end
go

--GENERAR VIAJE
IF OBJECT_ID('TROLLS.GENERAR_VIAJE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.GENERAR_VIAJE
GO

IF OBJECT_ID('TROLLS.VIAJE_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.VIAJE_SEQ

	DECLARE @max int;
SELECT @max = MAX(via_id)+1
     FROM TROLLS.Viaje

exec('CREATE SEQUENCE TROLLS.VIAJE_SEQ 
    START WITH ' + @max +
'   INCREMENT BY 1;');
GO

create procedure TROLLS.GENERAR_VIAJE 
@via_fec_salida datetime, 
@via_fec_llegada datetime, 
@via_cru_id  NUMERIC(18,0),
@via_rec_id nvarchar(25)
as
begin
	INSERT INTO TROLLS.VIAJE (via_id,via_fec_salida,via_fec_llegada,via_cru_id,via_rec_id)
	values((NEXT VALUE FOR TROLLS.VIAJE_SEQ) , @via_fec_salida, @via_fec_llegada, @via_cru_id, @via_rec_id)
end
go

--COMPRA DE VIAJE O RESERVA
IF OBJECT_ID('TROLLS.COMPRA_O_RESERVA_VIAJE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.COMPRA_O_RESERVA_VIAJE
GO

create procedure TROLLS.COMPRA_O_RESERVA_VIAJE 
@via_fec_salida datetime, 
@pue_desde varchar(30), 
@pue_hasta varchar(30)
as
begin
	INSERT INTO TROLLS.VIAJE (via_id,via_fec_salida,via_fec_llegada,via_cru_id,via_rec_id)
	values((NEXT VALUE FOR TROLLS.VIAJE_SEQ) , @via_fec_salida, @via_fec_llegada, @via_cru_id, @via_rec_id)
end
go

--PAGO DE RESERVA
IF OBJECT_ID('TROLLS.PAGO_RESERVA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.PAGO_RESERVA
GO

create procedure TROLLS.PAGO_RESERVA 
@codigo_reserva NUMERIC(18,0)
as
begin
	SELECT 
	r.res_fec as FechaReserva
	via.via_fec_salida as FechaSalida
	cab.cab_nro as NumeroCabina
	cab.cab_piso as PisoCabina 
	tc.tcab_tipo as TipoCabina
	tc.tcab_porc_recargo as PorcentajeRecargo
	FROM TROLLS.Reserva R
	join TROLLS.Cabina CAB on cab.cab_id = r.res_cab_id
	join TROLLS.Viaje VIA  on via.via_id = r.res_via_id
	join TROLLS.TipoCabina TC on tc.tcab_id = cab.cab_tcab_id
	WHERE res_id LIKE ISNULL('%' + @codigo_reserva + '%', '%');
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

/* Top 5 de los recorridos con más pasajes comprados. */

--Listado 1
create procedure TROLLS.sp_listado_estadistico_1 (@semestre int, @anio int)
as
begin
declare @via table (via_id NUMERIC(18,0),
					rec_id NUMERIC(18,0),
					cantidad int)
insert into @via 
select top 5
		pas_via_id,
		v.via_rec_id,
		count(distinct(pas_via_id))
	from TROLLS.Pasaje
		join TROLLS.Viaje V on v.via_id = pas_via_id 
	where pas_id is not null
		and year(pas_fec_compra) = @anio
		and month(pas_fec_compra) between ((@semestre * 6) - 5) and @semestre * 6
	group by pas_via_id, v.via_rec_id
	order by 3 desc, 2 desc, 1 desc

select v.cantidad as CantidadDePasajes, r.rec_desde as DestinoDesde, r.rec_hasta as DestinoHasta
	from TROLLS.Recorrido R
	join @via V
		on v.rec_id = r.rec_id
	order by v.cantidad desc
end
go


IF OBJECT_ID('TROLLS.sp_listado_estadistico_2', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.sp_listado_estadistico_2 
GO

/* Bueno, a ver, agarrre todos los viajes del semestre, con su crucero y cantidad de cabinas, en temp1 
	luego todos los pasajes del semestre metiendolos en temp2
	y despues seleccione ambas tablas temporales 
	restando cantidad de cabinas a cantidad de pasajes por cada crucero */

--Listado 2
create procedure TROLLS.sp_listado_estadistico_2(@semestre int, @anio int)
as
begin
declare @temp1 table (rec_id NUMERIC(18,0),
					  via_fec_salida datetime,
					  cru_id nvarchar(25),
					  cant_cabinas INT)

declare @temp2 table (pas_id NUMERIC(18,0),
					  cru_id NUMERIC(18,0),
					  rec_id NUMERIC(18,0),
					  cant_pasajes INT)

insert into @temp1 
	select via_rec_id, via_fec_salida, via_cru_id, count(c.cab_id)
	FROM TROLLS.Viaje
	join TROLLS.Cabina C on c.cru_id = via_cru_id
	where via_id is not null
		and month(via_fec_salida) between ((@semestre * 6) - 5) and @trimestre * 6
		and year(via_fec_salida) = @anio
	group by via_id, via_fec_salida, rec_desde, rec_hasta, via_cru_id
	order by 6;

insert into @temp2
	select pas_id, v.via_cru_id, v.via_rec_id, count(pas_cab_id)
	FROM TROLLS.PASAJE
	join TROLLS.Viaje V on v.via_id = pas_via_id
	where pas_id is not null
		and month(v.via_fec_salida) between ((@semestre * 6) - 5) and @trimestre * 6
		and year(v.via_fec_salida) = @anio
	group by pas_id, v.via_cru_id, v.via_rec_id
	order by 4

select top 5
	t1.cant_cabinas - t2.cant_pasajes as CabinasLibres, 
	rec_desde as DesdeDestino,
	rec_hasta as HastaDestino

	FROM TROLLS.Recorrido R
	join @temp1 T1 on t1.rec_id = r.rec_id
	join @temp2 T2 on t2.rec_id = r.rec_id
	where t1.cru_id = t2.cru_id
	group by rec_desde, rec_hasta
	order by 1;
end
go


/* Top 5 de los cruceros con mayor cantidad de días fuera de servicio. */


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