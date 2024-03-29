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

if OBJECT_ID('TROLLS.Cancelacion_Pasaje', 'U') is not null
	drop table TROLLS.Cancelacion_Pasaje;
create table TROLLS.Cancelacion_Pasaje (can_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					 can_pas_id NUMERIC(18,0) not null,
					 can_motivo VARCHAR(100) not null, 				
					 PRIMARY KEY(can_id));

if OBJECT_ID('TROLLS.Recorrido_Tramo', 'U') is not null
	drop table TROLLS.Recorrido_Tramo;
create table TROLLS.Recorrido_Tramo (tra_id NUMERIC(18,0) NOT NULL, --FK Tramo
							rec_id VARCHAR(30) NOT NULL, --FK Puerto
							estado BIT NOT NULL DEFAULT 1
							);

if OBJECT_ID('TROLLS.Tramos', 'U') is not null
	drop table TROLLS.Tramos;
create table TROLLS.Tramos( tra_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
									tra_desde NUMERIC(18,0) not null, --FK Puerto
									tra_hasta NUMERIC(18,0) not null, --FK Puerto
									tra_precio_base DECIMAL(18,2) NOT NULL,
									primary key (tra_id));

if OBJECT_ID('TROLLS.Pasaje', 'U') is not null
	drop table TROLLS.Pasaje;
create table TROLLS.Pasaje (pas_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					 pas_precio decimal(18,2) not null,					 
					 pas_cli_id NUMERIC(10,0) NOT NULL, --FK Cliente
					 pas_cli_tdoc_id NUMERIC(18,0),
					 pas_cab_nro NUMERIC(18,0) NOT NULL, 
					 pas_cab_piso NUMERIC(18,0) NOT NULL,
					 pas_cab_tcab_id NUMERIC(18,0) NOT NULL,
					 pas_pue_hasta NUMERIC(18,0) NOT NULL, --FK Puerto
					 pas_via_id NUMERIC(18,0) NOT NULL, --FK Viaje
					 pas_estado BIT NOT NULL DEFAULT 1,
					 pas_com_id NUMERIC(18,0), --FK Compra
					 PRIMARY KEY(pas_id));

if OBJECT_ID('TROLLS.Cabinas_Crucero', 'U') is not null
	drop table TROLLS.Cabinas_Crucero;
create table TROLLS.Cabinas_Crucero (cc_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
						 cc_cru_id CHAR(30) NOT NULL, --FK Crucero
					     cc_nro NUMERIC(18,0) not null,
						 cc_tcab_id NUMERIC(18,0), --FK Tipo_Cabina
						 cc_piso NUMERIC(18,0)); 



if OBJECT_ID('TROLLS.Reserva', 'U') is not null
	drop table TROLLS.Reserva;
create table TROLLS.Reserva (res_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					  res_fecha datetime not null,
					  res_cab_nro NUMERIC(18,0) NOT NULL, 
					  res_cab_piso NUMERIC(18,0) NOT NULL,
					  res_cab_tcab_id NUMERIC(18,0) NOT NULL,
					  res_cli_id NUMERIC(10,0) not null, --FK Cliente
					  res_cli_tdoc_id NUMERIC(18,0),
					  res_pue_hasta NUMERIC(18,0) not null, --FK Puerto
					  res_via_id NUMERIC(18,0) NOT NULL, --FK Viaje
					  res_estado BIT NOT NULL DEFAULT 1,
					  res_comprada BIT NOT NULL DEFAULT 1,
					  PRIMARY KEY(res_id));

if OBJECT_ID('TROLLS.Cabina', 'U') is not null
	drop table TROLLS.Cabina;
create table TROLLS.Cabina (cab_nro NUMERIC(18,0)  NOT NULL,
							 cab_piso NUMERIC(18,0) not null,
							 cab_tcab_id NUMERIC(18,0) not null, --FK Tipo_Cabina	 
							 cab_via_id NUMERIC(18,0), --FK Viaje
							 cab_ocupada BIT NOT NULL DEFAULT 0,
							 PRIMARY KEY(cab_nro,cab_piso,cab_tcab_id,cab_via_id));

if OBJECT_ID('TROLLS.Tipo_Cabina', 'U') is not null
	drop table TROLLS.Tipo_Cabina;
create table TROLLS.Tipo_Cabina (tcab_id NUMERIC(18,0)  IDENTITY(1,1) NOT NULL,
							 tcab_porc_recargo decimal(4,2) not null,
							 tcab_tipo varchar(400) not null, 							 
							 PRIMARY KEY(tcab_id));

if OBJECT_ID('TROLLS.Compra', 'U') is not null
	drop table TROLLS.Compra;
create table TROLLS.Compra (com_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
					 com_cli_id NUMERIC(10,0) not null, --FK Cliente
					 com_cli_tdoc_id NUMERIC(18,0),
					 com_mp_id NUMERIC(18,0) not null, --FK MP
					 com_cant int not null,
					 com_detalle NVARCHAR(50), --N° Cuotas
					 com_total NUMERIC(18,2) not null,
					 com_fecha_compra datetime not null,		
					 PRIMARY KEY(com_id));

if OBJECT_ID('TROLLS.MedioPago', 'U') is not null
	drop table TROLLS.MedioPago;
create table TROLLS.MedioPago (mp_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							mp_desc nvarchar(100) not null,
							PRIMARY KEY(mp_id));

if OBJECT_ID('TROLLS.Cliente', 'U') is not null
	drop table TROLLS.Cliente;
create table TROLLS.Cliente (cli_id NUMERIC(10,0) IDENTITY(1,1)  NOT NULL, --Nro Doc
					  cli_tdoc_id NUMERIC(18,0),
					  cli_nombre NVARCHAR(30) not null,
					  cli_apellido NVARCHAR(30) not null,
					  cli_fecha_nac datetime not null,
					  cli_direccion NUMERIC(18,0), --FK Dirección
					  PRIMARY KEY(cli_id,cli_tdoc_id));

if OBJECT_ID('TROLLS.Tipo_Doc', 'U') is not null
	drop table TROLLS.Tipo_Doc;
create table TROLLS.Tipo_Doc (tdoc_id NUMERIC(18,0)  IDENTITY(1,1) NOT NULL,
							 tdoc_desc varchar(400) not null, 							 
							 PRIMARY KEY(tdoc_id));

if OBJECT_ID('TROLLS.Direccion', 'U') is not null
	drop table TROLLS.Direccion;
create table TROLLS.Direccion( dir_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							dir_calle nvarchar(70) not null,
							dir_num char(5) not null,
							dir_telefono varchar(18),
							dir_mail nvarchar(50) null,
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
						usu_password NVARCHAR(255),
						usu_cant_int_fallidos int default 0,
						usu_estado bit default 1
						PRIMARY KEY (usu_id) );

if OBJECT_ID('TROLLS.Viaje', 'U') is not null
	drop table TROLLS.Viaje;
create table TROLLS.Viaje(via_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							 via_fecha_salida datetime not null, 
							 via_fecha_llegada datetime not null, 
							 via_fecha_llegada_estimada datetime not null, 
							 via_cru_id CHAR(30) not null, --FK Crucero
							 via_rec_id VARCHAR(30) not null, --FK Recorrido
							 primary key (via_id));

if OBJECT_ID('TROLLS.HistorialBajaCrucero', 'U') is not null
	drop table TROLLS.HistorialBajaCrucero;
create table TROLLS.HistorialBajaCrucero (hist_cru_id CHAR(30) NOT NULL, 
						 hist_cru_fecha datetime,
						 hist_motivo varchar(50)); 

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
create table TROLLS.Recorrido( rec_id VARCHAR(30) NOT NULL,	
									rec_pue_id_desde NUMERIC(18,0) not null,
									rec_pue_id_hasta NUMERIC(18,0) not null,
									rec_estado BIT NOT NULL DEFAULT 1,
									primary key (rec_id));	

if OBJECT_ID('TROLLS.Puerto', 'U') is not null
	drop table TROLLS.Puerto;
create table TROLLS.Puerto (pue_id NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
							pue_nombre VARCHAR (100) not null,
							pue_estado BIT NOT NULL DEFAULT 1,
							PRIMARY KEY(pue_id));

									
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
	CONSTRAINT FK_Reserva_cliente FOREIGN KEY (res_cli_id,res_cli_tdoc_id)
	REFERENCES TROLLS.Cliente (cli_id,cli_tdoc_id)

ALTER TABLE TROLLS.Reserva  WITH CHECK ADD
	CONSTRAINT FK_Reserva_puerto FOREIGN KEY (res_pue_hasta)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_compra FOREIGN KEY (pas_com_id)
	REFERENCES TROLLS.Compra (com_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_viaje FOREIGN KEY (pas_via_id)
	REFERENCES TROLLS.Viaje (via_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_cliente FOREIGN KEY (pas_cli_id,pas_cli_tdoc_id)
	REFERENCES TROLLS.Cliente (cli_id,cli_tdoc_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_cabina FOREIGN KEY (pas_cab_nro,pas_cab_piso,pas_cab_tcab_id,pas_via_id)
	REFERENCES TROLLS.Cabina (cab_nro,cab_piso,cab_tcab_id,cab_via_id)

ALTER TABLE TROLLS.Reserva  WITH CHECK ADD
	CONSTRAINT FK_Reserva_cabina FOREIGN KEY (res_cab_nro,res_cab_piso,res_cab_tcab_id,res_via_id)
	REFERENCES TROLLS.Cabina (cab_nro,cab_piso,cab_tcab_id,cab_via_id)

ALTER TABLE TROLLS.Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Pasaje_puerto FOREIGN KEY (pas_pue_hasta)
	REFERENCES TROLLS.Puerto (pue_id)

ALTER TABLE TROLLS.Compra  WITH CHECK ADD
	CONSTRAINT FK_Compra_cliente FOREIGN KEY (com_cli_id,com_cli_tdoc_id)
	REFERENCES TROLLS.Cliente (cli_id,cli_tdoc_id)

ALTER TABLE TROLLS.Compra  WITH CHECK ADD
	CONSTRAINT FK_Compra_mp FOREIGN KEY (com_mp_id)
	REFERENCES TROLLS.MedioPago(mp_id)

ALTER TABLE TROLLS.Cancelacion_Pasaje  WITH CHECK ADD
	CONSTRAINT FK_Cancelacion_pasaje FOREIGN KEY (can_pas_id)
	REFERENCES TROLLS.Pasaje (pas_id)

ALTER TABLE TROLLS.HistorialBajaCrucero  WITH CHECK ADD
	CONSTRAINT FK_Historial_Crucero FOREIGN KEY (hist_cru_id)
	REFERENCES TROLLS.Crucero (cru_id)

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
	CONSTRAINT FK_Cliente_TDoc FOREIGN KEY (cli_tdoc_id)
	REFERENCES TROLLS.Tipo_Doc (tdoc_id)
	
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
SET @intAlpha = PATINDEX('%[^0-9]%', @strAlphaNumeric)
BEGIN
WHILE @intAlpha > 0
BEGIN
SET @strAlphaNumeric = STUFF(@strAlphaNumeric, @intAlpha, 1, '' )
SET @intAlpha = PATINDEX('%[^0-9]%', @strAlphaNumeric )
END
END
RETURN ISNULL(@strAlphaNumeric,0)
END
GO

--TDOC
INSERT INTO TROLLS.Tipo_Doc (tdoc_desc)
VALUES ('DNI'),('DU')
GO

IF OBJECT_ID('TROLLS.DIRECCION_SEQ') IS NULL
CREATE SEQUENCE TROLLS.DIRECCION_SEQ START WITH 1 INCREMENT BY 1;

GO

if OBJECT_ID('TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP', 'U') is not null
	drop table TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP;
	CREATE TABLE TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP  
	(
	cli_nro_doc CHAR(8),
	cli_tdoc_id NUMERIC(18,0),
	cli_apellido NVARCHAR(30),
	cli_nombre NVARCHAR(30),
	cli_fecha_nac DATETIME,	
	dir_mail NVARCHAR(50),
	dir_calle NVARCHAR(70),
	dir_num CHAR(5),
	dir_telefono NVARCHAR(18),
	dir_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.DIRECCION_SEQ
	);

if OBJECT_ID('TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP', 'U') is not null
	drop table TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP;
	CREATE TABLE TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP 
	(
	cli_nro_doc CHAR(8)
	);

IF OBJECT_ID('TROLLS.Z_MIGRACION_CLIENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.Z_MIGRACION_CLIENTES
GO




/* TROLLS.MIGRAR_CLIENTES */

CREATE PROCEDURE TROLLS.Z_MIGRACION_CLIENTES     
AS 
BEGIN		
	DECLARE @MIGRA_CLIENTE_TEMP TABLE 
	(
	cli_nro_doc CHAR(8),
	cli_tdoc_id NUMERIC(18,0),
	cli_apellido NVARCHAR(30),
	cli_nombre NVARCHAR(30),
	cli_fecha_nac DATETIME,	
	dir_mail NVARCHAR(50),
	dir_calle NVARCHAR(70),
	dir_num CHAR(5),
	dir_telefono NVARCHAR(18),
	dir_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.DIRECCION_SEQ	
	PRIMARY KEY(cli_nro_doc));
	
	INSERT INTO TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP (cli_nro_doc)
	(select M.Cli_Dni from GD_ESQUEMA.MAESTRA M join GD_ESQUEMA.MAESTRA M2 on M.Cli_Dni = M2.Cli_Dni
	where M.Cli_nombre <> M2.Cli_nombre and M.Cli_apellido <> M2.Cli_apellido
	and M.[CLI_DIRECCION] <> M2.[CLI_DIRECCION]
	and M.[CLI_TELEFONO] <> M2.[CLI_TELEFONO]
	and M.[CLI_MAIL] <> M2.[CLI_MAIL]
	and M.[CLI_FECHA_NAC] <> M2.[CLI_FECHA_NAC]
	group by M.Cli_Dni
	UNION
	select M.Cli_Dni from GD_ESQUEMA.MAESTRA M join GD_ESQUEMA.MAESTRA M2 on M.Cli_Dni = M2.Cli_Dni
	where M.Cli_nombre <> M2.Cli_nombre and M.Cli_apellido = M2.Cli_apellido
	and M.[CLI_DIRECCION] <> M2.[CLI_DIRECCION]
	and M.[CLI_TELEFONO] <> M2.[CLI_TELEFONO]
	and M.[CLI_MAIL] <> M2.[CLI_MAIL]
	and M.[CLI_FECHA_NAC] <> M2.[CLI_FECHA_NAC]
	group by M.Cli_Dni)

	INSERT INTO TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP
	(cli_nro_doc,cli_tdoc_id,cli_apellido,cli_nombre,cli_fecha_nac,
	dir_mail,dir_calle,dir_num)
	SELECT DISTINCT Cli_Dni,null,Cli_Apellido,Cli_Nombre,Cli_Fecha_Nac,
	Cli_Mail,LEFT(CLI_DIRECCION, LEN(CLI_DIRECCION)-LEN(TROLLS.GETNUMBER((SELECT RIGHT(CLI_DIRECCION,4))))),TROLLS.GETNUMBER((SELECT RIGHT(CLI_DIRECCION,4)))
		   FROM GD_ESQUEMA.MAESTRA
	WHERE Cli_Dni IS NOT NULL and Cli_Dni in (select cli_nro_doc from TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP) 
	
	--Tabla temporal
	INSERT INTO @MIGRA_CLIENTE_TEMP 
	(cli_nro_doc,cli_tdoc_id,cli_apellido,cli_nombre,cli_fecha_nac,
	dir_mail,dir_calle,dir_num)
	SELECT DISTINCT Cli_Dni,1,Cli_Apellido,Cli_Nombre,Cli_Fecha_Nac,
	Cli_Mail,LEFT(CLI_DIRECCION, LEN(CLI_DIRECCION)-LEN(TROLLS.GETNUMBER((SELECT RIGHT(CLI_DIRECCION,4))))),TROLLS.GETNUMBER((SELECT RIGHT(CLI_DIRECCION,4)))
		   FROM GD_ESQUEMA.MAESTRA
	WHERE Cli_Dni IS NOT NULL and Cli_Dni not in (select cli_nro_doc from TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP) 

	--Se asigna distintos tipos de documento a los clientes con el mismo numero de documento
	update TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP set cli_tdoc_id = 
	(case 
	when dir_id % 2 = 1 then 1
	when dir_id % 2 = 0 then 2 end)

	--Domicilio
	SET IDENTITY_INSERT TROLLS.Direccion ON;
	INSERT INTO TROLLS.Direccion(dir_id,DIR_CALLE,DIR_NUM,DIR_telefono,DIR_MAIL)
	(SELECT 
	dir_id,dir_calle,dir_num,dir_telefono,dir_mail
	FROM @MIGRA_CLIENTE_TEMP
	UNION
	SELECT 
	dir_id,dir_calle,dir_num,dir_telefono,dir_mail
	FROM TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP)
	SET IDENTITY_INSERT TROLLS.Direccion OFF;
	--Cliente
	SET IDENTITY_INSERT TROLLS.CLIENTE ON;
	INSERT INTO TROLLS.CLIENTE(cli_id,cli_tdoc_id,cli_apellido,cli_nombre,cli_fecha_nac,cli_direccion)
	(SELECT cli_nro_doc,cli_tdoc_id,cli_apellido,cli_nombre,cli_fecha_nac,dir_id
	FROM @MIGRA_CLIENTE_TEMP
	UNION
	SELECT cli_nro_doc,cli_tdoc_id,cli_apellido,cli_nombre,cli_fecha_nac,dir_id
	FROM TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP)
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
	RECORRIDO_CODIGO VARCHAR(30),
	RECORRIDO_PRECIO_BASE DECIMAL(18,2),
	PUERTO_DESDE NUMERIC(18,0),
	PUERTO_HASTA NUMERIC(18,0),	
	tra_id NUMERIC(18, 0) DEFAULT NEXT VALUE FOR TROLLS.TRAMOS_SEQ
	);

	DECLARE @MIGRA_RECORRIDO_TEMP TABLE 
	(
	RECORRIDO_CODIGO VARCHAR(30),
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
	INSERT INTO TROLLS.RECORRIDO(rec_id,rec_pue_id_desde,rec_pue_id_hasta)
	select * from @MIGRA_RECORRIDO_TEMP

	--Tramos
	SET IDENTITY_INSERT TROLLS.Tramos ON;
	INSERT INTO TROLLS.Tramos(tra_id,tra_desde,tra_hasta,tra_precio_base)
	select tra_id,PUERTO_DESDE,PUERTO_HASTA,RECORRIDO_PRECIO_BASE from @MIGRA_RECORRIDO_TRAMO_TEMP
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

IF OBJECT_ID('TROLLS.COMPRA_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.COMPRA_SEQ
CREATE SEQUENCE TROLLS.COMPRA_SEQ START WITH 1 INCREMENT BY 1;
GO

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
	RECORRIDO_CODIGO VARCHAR(30),
	CABINA_NRO NUMERIC(18,0),
	CABINA_PISO NUMERIC(2,0),
	CRUCERO_IDENTIFICADOR CHAR(30),
	CABINA_TIPO NUMERIC(18,0)
	,RESERVA_CODIGO VARCHAR(30)
    ,RESERVA_FECHA datetime
	,cli_id NUMERIC(10,0)
	,cli_tdoc_id NUMERIC(18,0)
	,PASAJE_CODIGO NUMERIC(18,0)
    ,PASAJE_PRECIO decimal(18,2)
    ,PASAJE_FECHA_COMPRA datetime
    ,PUERTO_HASTA  NUMERIC(18,0)
	,via_id NUMERIC(18,0)
	,com_id NUMERIC(18,0)
	);
--Clientes no repetidos
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
	  ,1
	,PASAJE_CODIGO 
    ,PASAJE_PRECIO 
    ,PASAJE_FECHA_COMPRA 
    ,(SELECT pue_id from TROLLS.Puerto where pue_nombre=PUERTO_HASTA)
	,(SELECT via_id from TROLLS.Viaje where via_fecha_salida=FECHA_SALIDA and via_fecha_llegada=FECHA_LLEGADA and via_fecha_llegada_estimada=FECHA_LLEGADA_ESTIMADA 
	  and via_cru_id=CRUCERO_IDENTIFICADOR and via_rec_id=RECORRIDO_CODIGO)  
	,null
  FROM GD_ESQUEMA.MAESTRA
  where Cli_Dni not in (select cli_nro_doc from TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP)
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

	/*select * from TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP
	select count(cli_nro_doc+cli_apellido+cli_nombre+cli_fecha_nac) from TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP
	group by cli_nro_doc,cli_apellido,cli_nombre,cli_fecha_nac

	select cli_tdoc_id from TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP T where T.cli_nro_doc=33557963 and T.cli_apellido='Escobar' and T.cli_nombre='EPIFANIA' and T.cli_fecha_nac='1962-09-28 00:00:00.000'
	*/
--Clientes repetidos
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
	  ,(select T.cli_tdoc_id from TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP T where T.cli_nro_doc=M.CLI_DNI and T.cli_apellido=M.cli_apellido and T.cli_nombre=M.cli_nombre and T.cli_fecha_nac=M.cli_fecha_nac and T.dir_mail = M.CLI_MAIL
	  )
	,PASAJE_CODIGO 
    ,PASAJE_PRECIO 
    ,PASAJE_FECHA_COMPRA 
    ,(SELECT pue_id from TROLLS.Puerto where pue_nombre=PUERTO_HASTA)
	,(SELECT via_id from TROLLS.Viaje where via_fecha_salida=FECHA_SALIDA and via_fecha_llegada=FECHA_LLEGADA and via_fecha_llegada_estimada=FECHA_LLEGADA_ESTIMADA 
	  and via_cru_id=CRUCERO_IDENTIFICADOR and via_rec_id=RECORRIDO_CODIGO)  
	,null
  FROM GD_ESQUEMA.MAESTRA M
  where Cli_Dni in (select cli_nro_doc from TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP)
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
    ,PUERTO_HASTA,M.CLI_DNI,M.cli_apellido,M.cli_nombre,M.cli_fecha_nac,M.CLI_MAIL

	--Llenar com_id
	UPDATE @MIGRA_CABINA_TEMP SET com_id = (NEXT VALUE FOR COMPRA_SEQ) where PASAJE_CODIGO is not null

	--CABINA_CRUCERO
	INSERT INTO TROLLS.Cabinas_Crucero(cc_cru_id,cc_piso,cc_tcab_id,cc_nro)
	select distinct CRUCERO_IDENTIFICADOR
	,CABINA_PISO
	,CABINA_TIPO
	,CABINA_NRO
	from @MIGRA_CABINA_TEMP M
	group by CRUCERO_IDENTIFICADOR,CABINA_PISO,CABINA_TIPO,CABINA_NRO

	--CABINA
	
	--Inserta Cabinas ocupadas x viaje
	INSERT INTO TROLLS.Cabina(cab_nro,cab_piso,cab_tcab_id,cab_via_id,cab_ocupada)
	SELECT distinct CABINA_NRO
      ,CABINA_PISO
      ,CABINA_TIPO
	  ,via_id 
	  ,1 --SIEMPRE OCUPADA
	  FROM @MIGRA_CABINA_TEMP
  
  --Inserto Cabinas desocupadas x viaje
  INSERT INTO TROLLS.Cabina(cab_nro,cab_piso,cab_tcab_id,cab_via_id,cab_ocupada)
  	select distinct cc_nro
	  , cc_piso
	  , cc_tcab_id
	  , via_id
	  , 0 
	FROM [GD1C2019].TROLLS.Cabinas_Crucero
	join [GD1C2019].TROLLS.Viaje on via_cru_id = cc_cru_id
	where cc_nro not in (select cab_nro from [GD1C2019].TROLLS.Cabina where cab_via_id = via_id  AND cab_piso = cc_piso AND cab_tcab_id = cc_tcab_id)
	group by cc_nro, cc_cru_id, cc_piso, cc_tcab_id, via_id

  --RESERVA
  SET IDENTITY_INSERT TROLLS.Reserva ON;
  INSERT INTO TROLLS.Reserva(res_id,res_fecha,res_cab_nro,res_cab_piso,res_cab_tcab_id,res_cli_id,res_cli_tdoc_id,res_pue_hasta,res_via_id,res_estado)
	SELECT distinct RESERVA_CODIGO,RESERVA_FECHA
    ,CABINA_NRO
      ,CABINA_PISO
	  ,CABINA_TIPO
	,cli_id
	,cli_tdoc_id
	,PUERTO_HASTA
	,via_id, 1
  FROM @MIGRA_CABINA_TEMP 
  where RESERVA_CODIGO is not null
  group by RESERVA_CODIGO 
    ,RESERVA_FECHA,CABINA_NRO
      ,CABINA_PISO,via_id,CABINA_TIPO,cli_id,cli_tdoc_id,PUERTO_HASTA
SET IDENTITY_INSERT TROLLS.Reserva OFF;

 --Creo Medios de pago
INSERT INTO TROLLS.MedioPago (mp_desc)
VALUES ('Efectivo'),('Tarjeta Credito'),('Tarjeta Debito')

--COMPRA
 SET IDENTITY_INSERT TROLLS.Compra ON;
  INSERT INTO TROLLS.Compra(com_id,com_cli_id,com_cli_tdoc_id,com_mp_id,com_cant,com_total,com_fecha_compra)
	SELECT com_id,cli_id,cli_tdoc_id,1,1,PASAJE_PRECIO,PASAJE_FECHA_COMPRA  
  FROM @MIGRA_CABINA_TEMP 
  where PASAJE_CODIGO is not null
  group by com_id,cli_id,cli_tdoc_id,PASAJE_PRECIO,PASAJE_FECHA_COMPRA
  SET IDENTITY_INSERT TROLLS.Compra OFF;

    --PASAJE
  SET IDENTITY_INSERT TROLLS.Pasaje ON;
  INSERT INTO TROLLS.Pasaje(pas_id,pas_precio,pas_cli_id,pas_cli_tdoc_id,pas_cab_nro,pas_cab_piso,pas_cab_tcab_id,pas_pue_hasta,pas_via_id,pas_com_id)
	SELECT distinct PASAJE_CODIGO,PASAJE_PRECIO,cli_id,cli_tdoc_id
    ,CABINA_NRO
      ,CABINA_PISO
	  ,CABINA_TIPO
	 --Siempre Medio de Pago Efectivo
	,PUERTO_HASTA
	,via_id
	,com_id
  FROM @MIGRA_CABINA_TEMP 
  where PASAJE_CODIGO is not null
  group by PASAJE_CODIGO,PASAJE_PRECIO,PASAJE_FECHA_COMPRA,cli_id,cli_tdoc_id
    ,CABINA_NRO
      ,CABINA_PISO
	  ,CABINA_TIPO
	  ,PUERTO_HASTA
	  ,via_id
	  ,com_id
SET IDENTITY_INSERT TROLLS.Pasaje OFF;

END;
GO


EXEC TROLLS.Z_MIGRACION_CABINA_RESERVA_PASAJE;
GO

--DROP TABLAS TEMPORALES
if OBJECT_ID('TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP', 'U') is not null
	drop table TROLLS.MIGRA_CLIENTE_DUPLICADOS_TEMP;

if OBJECT_ID('TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP', 'U') is not null
	drop table TROLLS.MIGRA_CLIENTE_DUPLICADOS_ID_TEMP;

IF OBJECT_ID('TROLLS.Z_MIGRACION_CLIENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.Z_MIGRACION_CLIENTES

IF OBJECT_ID('TROLLS.DIRECCION_SEQ') IS NOT NULL
DROP SEQUENCE TROLLS.DIRECCION_SEQ;

IF OBJECT_ID('TROLLS.BUSCAR_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.BUSCAR_USUARIO;
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

IF OBJECT_ID('TROLLS.OBTENERMP', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERMP
GO

create procedure TROLLS.OBTENERMP
AS
BEGIN 
	select mp_id,mp_desc from [TROLLS].[MedioPago]
END
GO

IF OBJECT_ID('TROLLS.OBTENERPUERTO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERPUERTO
GO

create procedure TROLLS.OBTENERPUERTO
AS
BEGIN 
	select pue_id,pue_nombre from TROLLS.Puerto
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
	SELECT cc_piso,cc_nro,cc_tcab_id,cc_id FROM TROLLS.Cabinas_Crucero where cc_cru_id = @ID
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
	select tcab_id,tcab_tipo,tcab_porc_recargo from TROLLS.Tipo_Cabina
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
@cc_piso numeric(18,0),  
@cc_nro numeric(18,0), 
@cc_tcab_id int
as
begin
	insert into TROLLS.Cabinas_Crucero(cc_cru_id,cc_piso,cc_nro,cc_tcab_id) values (@cru_id,@cc_piso,@cc_nro,@cc_tcab_id)
end
go

IF OBJECT_ID('TROLLS.CREAR_CABINA_CRUCERO_REEMPLAZO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_CABINA_CRUCERO_REEMPLAZO
GO

create procedure TROLLS.CREAR_CABINA_CRUCERO_REEMPLAZO
@cru_id_orginal char(30),
@cru_id_reemplazo char(30)
as
begin
	INSERT INTO TROLLS.Cabinas_Crucero(cc_cru_id,cc_piso,cc_tcab_id,cc_nro)
	select @cru_id_reemplazo
	,cc_piso
	,cc_tcab_id
	,cc_nro
	from TROLLS.Cabinas_Crucero where cc_cru_id=@cru_id_orginal
end
go

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

IF OBJECT_ID('TROLLS.VALIDAR_RECORRIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.VALIDAR_RECORRIDO
GO

--Validar Recorrido
create procedure TROLLS.VALIDAR_RECORRIDO
@rec_id varchar(30)
as
begin
	SELECT 1 FROM TROLLS.RECORRIDO WHERE rec_id = @rec_id
end
go

IF OBJECT_ID('TROLLS.VALIDAR_VIAJES_PENDIENTES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.VALIDAR_VIAJES_PENDIENTES
GO

--Validar Crucero
create procedure TROLLS.VALIDAR_VIAJES_PENDIENTES
@cru_id char(30),
@cru_fecha_baja datetime
as
begin
	select 1 from TROLLS.Viaje where via_cru_id = @cru_id and via_fecha_salida >= @cru_fecha_baja
end
go


IF OBJECT_ID('TROLLS.MODIFICAR_CABINA_CRUCERO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_CABINA_CRUCERO
GO

--Modificar Cabina Crucero
create procedure TROLLS.MODIFICAR_CABINA_CRUCERO
@cc_id numeric(18,0),
@cc_piso numeric(18,0),  
@cc_nro numeric(18,0), 
@cc_tcab_id numeric(18,0)
as
begin 
	UPDATE TROLLS.Cabinas_Crucero SET cc_nro=@cc_nro,cc_piso=@cc_piso,cc_tcab_id=@cc_tcab_id where cc_id=@cc_id
end
go

IF OBJECT_ID('TROLLS.CANCELAR_VIAJES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CANCELAR_VIAJES
GO

create procedure TROLLS.CANCELAR_VIAJES
@cru_id char(30), 
@cru_fecha_baja_fuera_servicio datetime,
@cru_fecha_reinicio_servicio datetime,
@can_motivo varchar(100)
as
begin

	DECLARE @CANCELACION_TEMP TABLE 
	(
	pas_id NUMERIC(18,0)
	);

	INSERT INTO @CANCELACION_TEMP 
	(pas_id)
	SELECT
    pas_id	  
	FROM TROLLS.Pasaje
	WHERE pas_via_id in (select via_id from TROLLS.Viaje where via_cru_id = @cru_id and via_fecha_salida >= @cru_fecha_baja_fuera_servicio)
	

	UPDATE TROLLS.Pasaje SET pas_estado = 0 where pas_id in (select pas_id from @CANCELACION_TEMP)

	INSERT INTO TROLLS.Cancelacion_Pasaje
	(can_pas_id,can_motivo)
	SELECT
    pas_id
	,@can_motivo	  
	FROM @CANCELACION_TEMP
end
go

IF OBJECT_ID('TROLLS.CRUCERO_BAJA_SERVICIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CRUCERO_BAJA_SERVICIO
GO

create procedure TROLLS.CRUCERO_BAJA_SERVICIO
@cru_id char(30), 
@cru_fecha_baja_fuera_servicio datetime,
@cru_fecha_reinicio_servicio datetime
as
begin
		UPDATE TROLLS.CRUCERO SET cru_fecha_reinicio_servicio = @cru_fecha_reinicio_servicio, cru_fecha_fuera_servicio= @cru_fecha_baja_fuera_servicio, cru_baja_fuera_servicio=1 where cru_id = @cru_id
		INSERT INTO [TROLLS].[HistorialBajaCrucero]
		([hist_cru_id],[hist_cru_fecha],[hist_motivo])
		VALUES
		(@cru_id
		,@cru_fecha_baja_fuera_servicio	  
		,'Baja Servicio')
end
go


IF OBJECT_ID('TROLLS.CANCELAR_VIAJES_BAJA_DEFINITIVA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CANCELAR_VIAJES_BAJA_DEFINITIVA
GO

create procedure TROLLS.CANCELAR_VIAJES_BAJA_DEFINITIVA
@cru_id char(30), 
@cru_fecha_baja_definitiva datetime,
@can_motivo varchar (100)
as
begin

	DECLARE @CANCELACION_TEMP TABLE 
	(
	pas_id NUMERIC(18,0)
	);

	INSERT INTO @CANCELACION_TEMP 
	(pas_id)
	SELECT
    pas_id	  
	FROM TROLLS.Pasaje
	WHERE pas_via_id in (select via_id from TROLLS.Viaje where via_cru_id = @cru_id and via_fecha_salida >= @cru_fecha_baja_definitiva)
	

	UPDATE TROLLS.Pasaje SET pas_estado = 0 where pas_id in (select pas_id from @CANCELACION_TEMP)

	INSERT INTO TROLLS.Cancelacion_Pasaje
	(can_pas_id,can_motivo)
	SELECT
    pas_id
	,@can_motivo	  
	FROM @CANCELACION_TEMP
end
go

IF OBJECT_ID('TROLLS.CRUCERO_BAJA_DEFINITIVA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CRUCERO_BAJA_DEFINITIVA
GO

create procedure TROLLS.CRUCERO_BAJA_DEFINITIVA
@cru_id char(30), 
@cru_fecha_baja_definitiva datetime
as
begin
	UPDATE TROLLS.CRUCERO SET cru_fecha_baja_definitiva = @cru_fecha_baja_definitiva, cru_baja_vida_util=1  where cru_id = @cru_id

	INSERT INTO [TROLLS].[HistorialBajaCrucero]
		([hist_cru_id],[hist_cru_fecha],[hist_motivo])
		VALUES
		(@cru_id
		,@cru_fecha_baja_definitiva	  
		,'Baja Definitiva')
end
go

IF OBJECT_ID('TROLLS.ACTUALIZAR_VIAJES_REEMPLAZO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.ACTUALIZAR_VIAJES_REEMPLAZO
GO

create procedure TROLLS.ACTUALIZAR_VIAJES_REEMPLAZO
@cru_id_original char(30),
@cru_id_reemplazo char(30),
@cru_fecha_baja_definitiva datetime
as
begin
	UPDATE TROLLS.Viaje SET  via_cru_id=@cru_id_reemplazo
	where via_id in (SELECT via_id  FROM TROLLS.Viaje
					 where via_cru_id = @cru_id_original and via_fecha_salida >= @cru_fecha_baja_definitiva)	
end
go

IF OBJECT_ID('TROLLS.REPROGRAMAR_VIAJES', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.REPROGRAMAR_VIAJES
GO

create procedure TROLLS.REPROGRAMAR_VIAJES
@cru_id char(30),
@cru_fecha_baja_fuera_servicio datetime, 
@cru_fecha_reinicio_servicio datetime,
@dias int
as
begin
	UPDATE TROLLS.Viaje SET via_fecha_salida = dateadd(day, @dias , via_fecha_salida), via_fecha_llegada = dateadd(day, @dias , via_fecha_llegada), via_fecha_llegada_estimada = dateadd(day, @dias , via_fecha_llegada_estimada)  
	where via_id in (SELECT via_id  FROM TROLLS.Viaje
					 where via_cru_id = @cru_id and via_fecha_salida >= @cru_fecha_baja_fuera_servicio)	
end
go

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'TROLLS.COMPARARCABINAS')
AND type in (N'FN', N'IF',N'TF', N'FS', N'FT'))
DROP FUNCTION TROLLS.COMPARARCABINAS
GO

CREATE FUNCTION TROLLS.COMPARARCABINAS
(@cru_id_original VARCHAR(30), @cru_id VARCHAR(30))
RETURNS VARCHAR(1)
AS
BEGIN

DECLARE @CC_ORIGINAL TABLE 
	(
	cc_tcab_id NUMERIC(18,0),
	cant int
	);

DECLARE @CC_REEMPLAZO TABLE 
	(
	cc_tcab_id NUMERIC(18,0),
	cant int
	);

DECLARE @totalRecords INT
DECLARE @I INT
DECLARE @CANT_ORI INT
DECLARE @CANT_REM INT

insert into @CC_ORIGINAL (cc_tcab_id,cant)
select cc_tcab_id, Count(cc_tcab_id) from [TROLLS].[Cabinas_Crucero] where cc_cru_id = @cru_id_original
	group by cc_tcab_id
insert into @CC_REEMPLAZO (cc_tcab_id,cant)
	select cc_tcab_id, Count(cc_tcab_id) from [TROLLS].[Cabinas_Crucero] where cc_cru_id = @cru_id
	group by cc_tcab_id

IF ((select COUNT(*) from @CC_ORIGINAL) <> (select COUNT(*) from @CC_ORIGINAL))
BEGIN
	RETURN 0
END
ELSE
BEGIN

	SELECT @I = 1
	SELECT @totalRecords = COUNT(*) FROM @CC_ORIGINAL
	WHILE (@I <= @totalRecords)
	BEGIN
		SET @CANT_ORI = ISNULL((SELECT cant FROM @CC_ORIGINAL where cc_tcab_id=@I),0)
		SET @CANT_REM = ISNULL((SELECT cant FROM @CC_REEMPLAZO where cc_tcab_id=@I),0)
		IF (@CANT_ORI > @CANT_REM)
			RETURN 0
        SELECT @I = @I + 1
	END

END

RETURN 1

END
GO


IF OBJECT_ID('TROLLS.LISTAR_CRUCEROS_REEMPLAZO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_CRUCEROS_REEMPLAZO
GO

create procedure TROLLS.LISTAR_CRUCEROS_REEMPLAZO
@cru_id_original char(30),
@cru_fecha_baja_definitiva datetime
as
begin
select cru_id FROM [TROLLS].Crucero where not cru_id in (
select via_cru_id from [TROLLS].[Viaje] where [via_fecha_salida] between 
(SELECT MIN(via_fecha_salida)
  FROM [GD1C2019].[TROLLS].[Viaje]
  where via_cru_id = @cru_id_original and via_fecha_salida >= @cru_fecha_baja_definitiva)
and
(SELECT MAX(via_fecha_salida)
  FROM [GD1C2019].[TROLLS].[Viaje]
  where via_cru_id = @cru_id_original and via_fecha_salida >= @cru_fecha_baja_definitiva)
and [via_fecha_llegada] between
(SELECT MIN(via_fecha_llegada)
  FROM [GD1C2019].[TROLLS].[Viaje]
  where via_cru_id = @cru_id_original and via_fecha_salida >= @cru_fecha_baja_definitiva)
  and
(SELECT MAX(via_fecha_llegada)
  FROM [GD1C2019].[TROLLS].[Viaje]
  where via_cru_id = @cru_id_original and via_fecha_salida >= @cru_fecha_baja_definitiva) ) and not cru_id = @cru_id_original and [cru_baja_fuera_servicio]=0 and [cru_baja_vida_util]=0
  
  /* mismas cabinas */
  and TROLLS.COMPARARCABINAS(@cru_id_original,cru_id)=1

end
go



IF OBJECT_ID('TROLLS.LISTAR_CRUCEROS_VIAJE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_CRUCEROS_VIAJE
GO

create procedure TROLLS.LISTAR_CRUCEROS_VIAJE
@via_fecha_salida datetime,
@via_fecha_llegada datetime
as
begin
select cru_id as Crucero, [cru_mod] as Modelo, (select fab_desc from TROLLS.Fabricante_Crucero where fab_id= [cru_fab_id]) as Marca,  (select tser_desc from TROLLS.Tipo_Servicio_Crucero where tser_id=cru_tser_id) as Tipo_Servicio  FROM [TROLLS].Crucero where not cru_id in (
select via_cru_id from [TROLLS].[Viaje] 
where 
(@via_fecha_salida >= [via_fecha_salida] and @via_fecha_llegada <= via_fecha_llegada) or (@via_fecha_salida <= [via_fecha_salida] and @via_fecha_llegada >= via_fecha_llegada) or
((@via_fecha_salida >= [via_fecha_salida] and @via_fecha_salida <= via_fecha_llegada) and (@via_fecha_llegada >= via_fecha_llegada))
or ((@via_fecha_salida <= [via_fecha_salida]) and (@via_fecha_llegada >= [via_fecha_salida] and @via_fecha_llegada <= via_fecha_llegada )))
and [cru_baja_fuera_servicio]=0 and [cru_baja_vida_util]=0

end
go

IF OBJECT_ID('TROLLS.LISTAR_RECORRIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_RECORRIDO
GO

create procedure TROLLS.LISTAR_RECORRIDO
@puerto_desde varchar(100),
@puerto_hasta varchar(100)
as
begin
SELECT R.[rec_id] as Recorrido
      ,P.pue_nombre as Puerto_Desde
      ,P2.pue_nombre as Puerto_Hasta
  FROM [TROLLS].[Recorrido] R inner join [TROLLS].Puerto P on R.[rec_pue_id_desde] = P.pue_id inner join [TROLLS].Puerto P2 on R.[rec_pue_id_hasta] = P2.pue_id
  where R.[rec_estado]=1 and P.pue_nombre LIKE ISNULL('%' + @puerto_desde + '%', '%')
			  AND P2.pue_nombre LIKE ISNULL('%' + @puerto_hasta + '%', '%')
end
go

IF OBJECT_ID('TROLLS.CREAR_VIAJE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_VIAJE
GO

--Crear Viaje
create procedure TROLLS.CREAR_VIAJE
@cru_id char(30), 
@rec_id VARCHAR(30), 
@via_fecha_salida datetime,
@via_fecha_llegada datetime
as
begin
	insert into TROLLS.Viaje([via_cru_id],[via_rec_id],[via_fecha_salida],[via_fecha_llegada],[via_fecha_llegada_estimada]) values (@cru_id,@rec_id,@via_fecha_salida,@via_fecha_llegada,@via_fecha_llegada)
end
go

IF OBJECT_ID('TROLLS.OBTENER_ID_VIAJE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_ID_VIAJE
GO
create procedure TROLLS.OBTENER_ID_VIAJE 
@cru_id char(30), 
@rec_id VARCHAR(30), 
@via_fecha_salida datetime,
@via_fecha_llegada datetime
as
begin
	select via_id from TROLLS.Viaje where via_cru_id = @cru_id and via_rec_id = @rec_id and via_fecha_salida=@via_fecha_salida and via_fecha_llegada=@via_fecha_llegada
end
go

IF OBJECT_ID('TROLLS.CREAR_CABINA_VIAJE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_CABINA_VIAJE
GO

create procedure TROLLS.CREAR_CABINA_VIAJE
@via_id int, 
@cru_id char(30)
as
begin
	INSERT INTO TROLLS.Cabina
	([cab_nro],[cab_piso],[cab_tcab_id],[cab_via_id],[cab_ocupada])
	SELECT
    [cc_nro]
	,[cc_piso]
	,[cc_tcab_id]
	,@via_id
	,0  
	FROM [TROLLS].[Cabinas_Crucero] where [cc_cru_id] = @cru_id
end
go

IF OBJECT_ID('TROLLS.LISTAR_VIAJE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_VIAJE
GO

create procedure TROLLS.LISTAR_VIAJE
@pue_id_desde varchar(100),
@pue_id_hasta varchar(100),
@via_fecha_salida datetime,
@via_fecha_llegada datetime
as
begin
select via_id,[via_fecha_salida] as 'Fecha Salida',[via_fecha_llegada] as 'Fecha Llegada',[via_cru_id] as 'Crucero',[via_rec_id],
(select pue_nombre from TROLLS.PUERTO where pue_id = (select [rec_pue_id_desde] from TROLLS.RECORRIDO where rec_id = via_rec_id)) as 'Puerto Salida',
(select pue_nombre from TROLLS.PUERTO where pue_id = (select [rec_pue_id_hasta] from TROLLS.RECORRIDO where rec_id = via_rec_id)) as 'Puerto Destino' 
from [TROLLS].[Viaje] where via_rec_id in
(SELECT R.[rec_id]
  FROM [GD1C2019].[TROLLS].[Recorrido] R join [TROLLS].[Recorrido_Tramo] RXT on R.rec_id=RXT.rec_id join [TROLLS].[Tramos] T on RXT.tra_id = T.tra_id
  where R.[rec_pue_id_desde] = @pue_id_desde and T.tra_hasta = @pue_id_hasta) and
  via_cru_id in (select cru_id from [TROLLS].[Crucero] where cru_baja_fuera_servicio=0 and cru_baja_vida_util=0) and
  ([via_fecha_salida] >= @via_fecha_salida and [via_fecha_salida] <= @via_fecha_llegada) or (@via_fecha_salida>= [via_fecha_llegada] and [via_fecha_llegada] >= @via_fecha_llegada ) 
  and via_id in (select via_id from [TROLLS].[Cabina] join [TROLLS].[Viaje] on via_id = cab_via_id
where [cab_ocupada] = 0
group by via_id)
end
go

IF OBJECT_ID('TROLLS.OBTENER_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_CLIENTE
GO

create procedure TROLLS.OBTENER_CLIENTE @ID int, @cli_tdoc_id int  
as
begin
	SELECT cli_apellido,cli_nombre,cli_fecha_nac,[cli_direccion] FROM TROLLS.Cliente where cli_id = @ID and cli_tdoc_id=@cli_tdoc_id
end
GO

IF OBJECT_ID('TROLLS.OBTENER_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_DIRECCION
GO

create procedure TROLLS.OBTENER_DIRECCION @ID int
as
begin
	SELECT dir_calle,dir_num,dir_telefono,dir_mail FROM TROLLS.Direccion where dir_id = @ID
end
GO

IF OBJECT_ID('TROLLS.MODIFICAR_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_CLIENTE
GO

CREATE PROCEDURE TROLLS.MODIFICAR_CLIENTE
@CLI_ID int,
@cli_tdoc_id int,
@CLI_NOMBRE VARCHAR(30), 
@CLI_APELLIDO VARCHAR(30),
@CLI_FECHA_NAC DATETIME
AS
BEGIN TRANSACTION
	UPDATE TROLLS.CLIENTE SET cli_nombre = @CLI_NOMBRE, cli_apellido = @CLI_APELLIDO, cli_fecha_nac = @CLI_FECHA_NAC WHERE cli_id = @CLI_ID and cli_tdoc_id=@cli_tdoc_id
COMMIT
GO 

IF OBJECT_ID('TROLLS.MODIFICAR_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_DIRECCION
GO

create procedure TROLLS.MODIFICAR_DIRECCION @DIR_ID int, @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	UPDATE TROLLS.DIRECCION SET dir_calle= @DIR_CALLE,dir_num= @DIR_NUM,dir_telefono= @DIR_TELEFONO,dir_mail= @DIR_MAIL WHERE dir_id = @DIR_ID
end
go

IF OBJECT_ID('TROLLS.CREAR_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_DIRECCION
GO

--Crear Direccion
create procedure TROLLS.CREAR_DIRECCION @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	insert into TROLLS.DIRECCION values (@DIR_CALLE,@DIR_NUM,@DIR_TELEFONO,@DIR_MAIL)
end
go

IF OBJECT_ID('TROLLS.OBTENER_ID_DIRECCION', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_ID_DIRECCION
GO

--Obtener ID Direccion
create procedure TROLLS.OBTENER_ID_DIRECCION @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_TELEFONO varchar(18), @DIR_MAIL varchar(50)
as
begin
	select dir_id from TROLLS.Direccion where dir_calle=@DIR_CALLE and dir_num = @DIR_NUM and DIR_TELEFONO=@DIR_TELEFONO and DIR_MAIL=@DIR_MAIL
end
go

IF OBJECT_ID('TROLLS.OBTENER_ID_DIRECCION_SIN_MAIL', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_ID_DIRECCION_SIN_MAIL
GO

--Obtener ID Direccion
create procedure TROLLS.OBTENER_ID_DIRECCION_SIN_MAIL @DIR_CALLE varchar(70), @DIR_NUM char(5), @DIR_TELEFONO varchar(18)
as
begin
	select dir_id from TROLLS.Direccion where dir_calle=@DIR_CALLE and dir_num = @DIR_NUM and DIR_TELEFONO=@DIR_TELEFONO
end
go

IF OBJECT_ID('TROLLS.CREAR_CLIENTE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_CLIENTE
GO

--Crear Cliente
create procedure TROLLS.CREAR_CLIENTE @CLI_ID int, @cli_tdoc_id int, @CLI_NOMBRE varchar(30), @CLI_APELLIDO varchar(30), @CLI_FECHA_NAC DateTime, @CLI_DIRECCION int
as
begin
	SET IDENTITY_INSERT TROLLS.CLIENTE ON;
	insert into TROLLS.CLIENTE(CLI_ID,cli_tdoc_id,CLI_NOMBRE,CLI_APELLIDO,CLI_FECHA_NAC,CLI_DIRECCION) values (@CLI_ID,@cli_tdoc_id,@CLI_NOMBRE,@CLI_APELLIDO,@CLI_FECHA_NAC,@CLI_DIRECCION)
	SET IDENTITY_INSERT TROLLS.CLIENTE OFF;
end
go

--Crear Usuario
IF OBJECT_ID('TROLLS.CREAR_USUARIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_USUARIO
GO

create procedure TROLLS.CREAR_USUARIO @USU_USUARIO varchar(30), @USU_CANT_INT_FALLIDOS int, @USU_ESTADO bit
as
begin
	insert into TROLLS.USUARIO values (@USU_USUARIO,null,@USU_CANT_INT_FALLIDOS,@USU_ESTADO)
end
go

--Crear RolxUsuario

IF OBJECT_ID('TROLLS.CREAR_ROLxUSUARIO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_ROLxUSUARIO
GO

create procedure TROLLS.CREAR_ROLxUSUARIO @USU_ID int, @ROL_ID int
as
begin
	INSERT INTO TROLLS.Rol_Usuario(rol_id, usu_id, estado)
	VALUES (@ROL_ID,@USU_ID,1)
end
go

IF OBJECT_ID('TROLLS.OBTENER_CABINAS_SIN_COMPRA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_CABINAS_SIN_COMPRA
GO

create procedure TROLLS.OBTENER_CABINAS_SIN_COMPRA @ID int,@tcab_id int
as
begin
	SELECT cab_tcab_id,cab_piso,cab_nro,cab_via_id FROM TROLLS.Cabina where cab_via_id = @ID and cab_tcab_id=@tcab_id and cab_ocupada=0
end
GO

IF OBJECT_ID('TROLLS.OBTENERDESCTIPOCABINA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERDESCTIPOCABINA
GO

create procedure TROLLS.OBTENERDESCTIPOCABINA @ID int
as
begin
	SELECT [tcab_tipo] FROM TROLLS.[Tipo_Cabina] where [tcab_id] = @ID
end
GO

IF OBJECT_ID('TROLLS.OBTENERPORCTIPOCABINA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERPORCTIPOCABINA
GO

create procedure TROLLS.OBTENERPORCTIPOCABINA @ID int
as
begin
	SELECT tcab_porc_recargo FROM TROLLS.Tipo_Cabina where tcab_id = @ID
end
GO

IF OBJECT_ID('TROLLS.OBTENERPRECIORECORRIDO_2', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERPRECIORECORRIDO_2
GO

create procedure TROLLS.OBTENERPRECIORECORRIDO_2 @REC_ID VARCHAR(30), @PUE_ID_DESDE int, @PUE_ID_HASTA int, @total DECIMAL(18,2) OUTPUT
as
begin

CREATE TABLE #tramos(
    tra_id NUMERIC(18,0),
	tra_desde NUMERIC(18,0), --FK Puerto
	tra_hasta NUMERIC(18,0), --FK Puerto
	tra_precio_base DECIMAL(18,2));	

INSERT INTO #tramos
SELECT T.tra_id
		  ,T.tra_desde
		  ,T.tra_hasta
		  ,tra_precio_base
	FROM TROLLS.Recorrido_Tramo RT
	join TROLLS.Tramos T on T.tra_id = RT.tra_id
	WHERE (@REC_ID is null or rec_id = @REC_ID)
	AND RT.estado = 1
	group by T.tra_id
			,tra_desde
		    ,tra_hasta
		    ,tra_precio_base

DECLARE @siguiente_pue NUMERIC(18,0);
DECLARE @siguiente_tra NUMERIC(18,0);
DECLARE @primero_tra NUMERIC(18,0);
SELECT @primero_tra=0;
SELECT @siguiente_pue=0;
SELECT @siguiente_tra=0;

CREATE TABLE #tramosordenados(
    tra_id NUMERIC(18,0),
	tra_desde NUMERIC(18,0), --FK Puerto
	tra_hasta NUMERIC(18,0), --FK Puerto
	tra_precio_base DECIMAL(18,2));	

select @primero_tra = (SELECT tra_id FROM #tramos where tra_desde=@PUE_ID_DESDE);	

INSERT INTO #tramosordenados
select * from #tramos where tra_id = @primero_tra

select @siguiente_pue = (SELECT tra_hasta FROM #tramos where tra_desde=@PUE_ID_DESDE);

WHILE @PUE_ID_HASTA <> @siguiente_pue
BEGIN
	select @siguiente_tra = (SELECT tra_id FROM #tramos where tra_desde=@siguiente_pue);	

	INSERT INTO #tramosordenados
    select * from #tramos where tra_id = @siguiente_tra

	select @siguiente_pue = (SELECT tra_hasta FROM #tramos where tra_id=@siguiente_tra);
END

declare @rec_pue_id_desde int
declare @rec_pue_id_hasta int
declare @canttramos int
declare @canttramosord int

set @rec_pue_id_desde = (select [rec_pue_id_desde] FROM [GD1C2019].[TROLLS].[Recorrido] where rec_id = @REC_ID)
set @rec_pue_id_hasta = (select [rec_pue_id_hasta] FROM [GD1C2019].[TROLLS].[Recorrido] where rec_id = @REC_ID)
set @canttramos = ((select count(*) from #tramos)-1)
set @canttramosord = (select count(*) from #tramosordenados)

if((@rec_pue_id_desde = @rec_pue_id_hasta) and (@canttramos = @canttramosord))
begin
		select @total = (SELECT sum(tra_precio_base) FROM #tramos);
end
else
begin
select @total = (SELECT sum(tra_precio_base) FROM #tramosordenados);
end


DROP TABLE #tramos;
DROP TABLE #tramosordenados

end
GO

IF OBJECT_ID('TROLLS.OBTENERPRECIORECORRIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERPRECIORECORRIDO
GO

create procedure TROLLS.OBTENERPRECIORECORRIDO @REC_ID VARCHAR(30), @PUE_ID_DESDE int, @PUE_ID_HASTA int
as
begin
declare @total DECIMAL(18,2)

EXEC TROLLS.OBTENERPRECIORECORRIDO_2 @REC_ID,@PUE_ID_DESDE,@PUE_ID_HASTA,@total OUTPUT

select @total

end
GO

IF type_id('TROLLS.Cabinas') IS NULL
--Tipo temporal para tabla Cabinas
CREATE TYPE TROLLS.Cabinas AS TABLE ( 
  cab_via_id int,
  cab_precio numeric(10,2),
  cab_nro int,
  cab_piso int,
  cab_tcab_id int,
  pue_id_hasta int
)
GO

IF OBJECT_ID('TROLLS.CREAR_COMPRA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_COMPRA
GO

create procedure TROLLS.CREAR_COMPRA
(@cli_id int,
@cli_tdoc_id int,
@com_fecha datetime, 
@com_mp int,
@detalle varchar(50),
@cabinas TROLLS.Cabinas READONLY)
as
begin
	declare @com_cant int
	select @com_cant = (select count(*) from @cabinas)
	declare @com_id numeric(18,0)
	declare @com_total numeric(18,2)
	select @com_total = (select sum(cab_precio) from @cabinas)
	--Insert compra
	insert into TROLLS.Compra(com_fecha_compra,com_cli_id,com_cli_tdoc_id,com_mp_id,com_cant,com_total,com_detalle) values (@com_fecha,@cli_id,@cli_tdoc_id,@com_mp,@com_cant,@com_total,@detalle)
		
	select @com_id = SCOPE_IDENTITY()

	--Update cabinas
	UPDATE TROLLS.Cabina SET cab_ocupada=1 WHERE
	EXISTS (
    SELECT * FROM @cabinas C WHERE C.cab_nro = TROLLS.Cabina.cab_nro AND C.cab_piso = TROLLS.Cabina.cab_piso AND C.cab_tcab_id = TROLLS.Cabina.cab_tcab_id AND C.cab_via_id = TROLLS.Cabina.cab_via_id
	)

	

	--Crear pasajes
	Insert into TROLLS.Pasaje([pas_precio],[pas_cli_id],pas_cli_tdoc_id,[pas_cab_nro],[pas_cab_piso],[pas_cab_tcab_id],[pas_pue_hasta],[pas_via_id],[pas_estado],[pas_com_id])  
    select cab_precio,@cli_id,@cli_tdoc_id,cab_nro,cab_piso,cab_tcab_id,pue_id_hasta,cab_via_id,1,@com_id
	from @cabinas

	--Voucher
	select @com_id
		
end
go

IF OBJECT_ID('TROLLS.VOUCHER_COMPRA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.VOUCHER_COMPRA
GO

create procedure TROLLS.VOUCHER_COMPRA
(@cli_id int,
@cli_tdoc_id int,
@com_fecha datetime, 
@com_mp int,
@detalle varchar(50),
@cabinas TROLLS.Cabinas READONLY,
@com_id int)
as
begin
	select
	@com_id as 'Compra'
	,C.cab_nro as 'Numero'
	,C.cab_piso as 'Piso'
	,(select [tcab_tipo] from [TROLLS].[Tipo_Cabina] where tcab_id = C.cab_tcab_id) as 'Tipo Cabina'
	,(select pas_id from [TROLLS].[Pasaje] where [pas_cab_nro] = C.cab_nro and [pas_cab_piso] = C.cab_piso and [pas_cab_tcab_id] = C.cab_tcab_id and [pas_via_id] = C.cab_via_id) as 'Pasaje'
	,C.cab_precio as 'Precio'
	,V.[via_fecha_salida] as 'Fecha Salida'
	,V.[via_fecha_llegada] as 'Fecha Llegada'
	,V.[via_cru_id] as 'Crucero'
	,P.pue_nombre as 'Puerto Desde'
	,(select pue_nombre from [TROLLS].[Puerto] where pue_id = C.pue_id_hasta) as 'Puerto Hasta'
	,(select [cli_apellido] from [TROLLS].[Cliente] where cli_id = @cli_id and cli_tdoc_id = @cli_tdoc_id ) as 'Nombre'
	,(select [cli_nombre] from [TROLLS].[Cliente] where cli_id = @cli_id and cli_tdoc_id = @cli_tdoc_id ) as 'Apellido'
	,@cli_id as 'Documento'
	,(select tdoc_desc from TROLLS.TIPO_DOC where tdoc_id=@cli_tdoc_id) as 'Tipo Doc'
	,(select [mp_desc] from [TROLLS].[MedioPago] where [mp_id] = @com_mp) as 'Medio Pago'
	,@detalle as 'Detalle'
	from @cabinas C join [TROLLS].[Viaje] V on V.via_id = C.cab_via_id join [TROLLS].[Recorrido] R on R.rec_id=via_rec_id 
	inner join [TROLLS].Puerto P on R.[rec_pue_id_desde] = P.pue_id		
end
go

IF OBJECT_ID('TROLLS.VOUCHER_RESERVA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.VOUCHER_RESERVA
GO

create procedure TROLLS.VOUCHER_RESERVA
(@cli_id int,
@cli_tdoc_id int,
@cabinas TROLLS.Cabinas READONLY)
as
begin
	select
	RES.res_id as 'Reserva'
	,C.cab_nro as 'Numero'
	,C.cab_piso as 'Piso'
	,(select [tcab_tipo] from [TROLLS].[Tipo_Cabina] where tcab_id = C.cab_tcab_id) as 'Tipo Cabina'
	,V.[via_fecha_salida] as 'Fecha Salida'
	,V.[via_fecha_llegada] as 'Fecha Llegada'
	,V.[via_cru_id] as 'Crucero'
	,P.pue_nombre as 'Puerto Desde'
	,(select pue_nombre from [TROLLS].[Puerto] where pue_id = C.pue_id_hasta) as 'Puerto Hasta'
	,(select [cli_apellido] from [TROLLS].[Cliente] where cli_id = @cli_id  and cli_tdoc_id = @cli_tdoc_id ) as 'Nombre'
	,(select [cli_nombre] from [TROLLS].[Cliente] where cli_id = @cli_id and cli_tdoc_id = @cli_tdoc_id ) as 'Apellido'
	,@cli_id as 'Documento'
	,(select tdoc_desc from TROLLS.TIPO_DOC where tdoc_id=@cli_tdoc_id) as 'Tipo Doc'
	from @cabinas C join [TROLLS].[Viaje] V on V.via_id = C.cab_via_id join [TROLLS].[Recorrido] R on R.rec_id=via_rec_id 
	inner join [TROLLS].Puerto P on R.[rec_pue_id_desde] = P.pue_id	
	join [TROLLS].[Reserva] RES on RES.[res_cab_nro] = C.cab_nro and RES.[res_cab_piso] = C.cab_piso and RES.[res_cab_tcab_id] = C.cab_tcab_id and RES.[res_via_id] = C.cab_via_id

end
go

IF OBJECT_ID('TROLLS.VERIFICAR_RESERVA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.VERIFICAR_RESERVA
GO

create procedure TROLLS.VERIFICAR_RESERVA
(@res_id int)
as
begin

	declare @PUE_ID_DESDE int
	select @PUE_ID_DESDE = (select R.[rec_pue_id_desde]
	from [TROLLS].[Reserva] RES join [TROLLS].[Viaje] V on V.via_id = RES.res_via_id join [TROLLS].[Recorrido] R on R.rec_id=via_rec_id 
	where res_id = @res_id)
	declare @PUE_ID_HASTA int
	select @PUE_ID_HASTA = (select RES.res_pue_hasta
	from [TROLLS].[Reserva] RES where res_id = @res_id)
	declare @REC_ID VARCHAR(30)
	select @REC_ID = (select V.via_rec_id from [TROLLS].[Reserva] RES join [TROLLS].[Viaje] V on V.via_id = RES.res_via_id 
	where res_id = @res_id)
	
	DECLARE @total numeric (18,2)

	exec TROLLS.OBTENERPRECIORECORRIDO_2 @REC_ID, @PUE_ID_DESDE, @PUE_ID_HASTA, @total OUTPUT

	select
	RES.res_id as 'Reserva'
	,RES.res_cab_nro as 'Numero'
	,RES.res_cab_piso as 'Piso'
	,(select [tcab_tipo] from [TROLLS].[Tipo_Cabina] where tcab_id = RES.res_cab_tcab_id) as 'TipoCabina'
	,ROUND((SELECT tcab_porc_recargo FROM TROLLS.Tipo_Cabina where tcab_id = RES.res_cab_tcab_id)*@total/100+@total,2) as 'Precio'
	,V.[via_fecha_salida] as 'FechaSalida'
	,V.[via_fecha_llegada] as 'FechaLlegada'
	,V.[via_cru_id] as 'Crucero'
	,P.pue_nombre as 'PuertoDesde'
	,(select pue_nombre from [TROLLS].[Puerto] where pue_id = RES.res_pue_hasta) as 'PuertoHasta'
	,(select [cli_apellido] from [TROLLS].[Cliente] where cli_id = RES.res_cli_id and cli_tdoc_id = RES.res_cli_tdoc_id ) as 'Nombre'
	,(select [cli_nombre] from [TROLLS].[Cliente] where cli_id = RES.res_cli_id and cli_tdoc_id = RES.res_cli_tdoc_id ) as 'Apellido'
	,RES.res_cli_id as 'Documento'
	,(select tdoc_desc from TROLLS.TIPO_DOC where tdoc_id=RES.res_cli_tdoc_id) as 'TipoDoc'
	from [TROLLS].[Reserva] RES join [TROLLS].[Viaje] V on V.via_id = RES.res_via_id join [TROLLS].[Recorrido] R on R.rec_id=via_rec_id 
	inner join [TROLLS].Puerto P on R.[rec_pue_id_desde] = P.pue_id
	where RES.res_id = @res_id and RES.res_estado = 1 and RES.res_comprada = 0
end
go

IF OBJECT_ID('TROLLS.CREAR_RESERVA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_RESERVA
GO

create procedure TROLLS.CREAR_RESERVA
(@cli_id int,
@cli_tdoc_id int,
@res_fecha datetime, 
@cabinas TROLLS.Cabinas READONLY)
as
begin
	--Update cabinas
	UPDATE TROLLS.Cabina SET cab_ocupada=1 WHERE
	EXISTS (
    SELECT * FROM @cabinas C WHERE C.cab_nro = TROLLS.Cabina.cab_nro AND C.cab_piso = TROLLS.Cabina.cab_piso AND C.cab_tcab_id = TROLLS.Cabina.cab_tcab_id AND C.cab_via_id = TROLLS.Cabina.cab_via_id
	)

	--Crear reservas
	Insert into TROLLS.Reserva([res_fecha],[res_cab_nro],[res_cab_piso],[res_cab_tcab_id],[res_cli_id],res_cli_tdoc_id,[res_pue_hasta],[res_via_id],[res_estado],[res_comprada])  
    select @res_fecha,cab_nro,cab_piso,cab_tcab_id,@cli_id,@cli_tdoc_id,pue_id_hasta,cab_via_id,1,0
	from @cabinas
		
end
go

IF OBJECT_ID('TROLLS.RESERVA_COMPRADA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.RESERVA_COMPRADA
GO

create procedure TROLLS.RESERVA_COMPRADA
(@res_id int)
as
begin
	--Update cabinas
	UPDATE TROLLS.Reserva SET [res_comprada]=1 where res_id =@res_id
		
end
go

IF OBJECT_ID('TROLLS.CANCELAR_RESERVA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CANCELAR_RESERVA
GO

create procedure TROLLS.CANCELAR_RESERVA
(@fecha_sistema datetime)
as
begin
	--Update cabinas
	UPDATE TROLLS.Reserva SET [res_estado]=0 where res_fecha < @fecha_sistema and res_comprada = 0	
end
go

IF OBJECT_ID('TROLLS.HABILITAR_CRUCERO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.HABILITAR_CRUCERO
GO

create procedure TROLLS.HABILITAR_CRUCERO
(@fecha_sistema datetime)
as
begin
	
DECLARE @CRUCERO_HABILITAR TABLE 
	(
	cru_id CHAR(30),
	cru_fecha_reinicio_servicio datetime
	);

	Insert into @CRUCERO_HABILITAR(cru_id,cru_fecha_reinicio_servicio)  
    select cru_id,cru_fecha_reinicio_servicio
	from TROLLS.Crucero where [cru_fecha_reinicio_servicio] <= @fecha_sistema and [cru_baja_vida_util]= 0 and [cru_baja_fuera_servicio]=1	

	--Update crucero
	UPDATE TROLLS.Crucero SET [cru_baja_fuera_servicio]=0,[cru_fecha_fuera_servicio]=null,[cru_fecha_reinicio_servicio]=null where [cru_fecha_reinicio_servicio] <= @fecha_sistema and [cru_baja_vida_util]= 0 and [cru_baja_fuera_servicio]=1
		
		Insert into [TROLLS].[HistorialBajaCrucero] ([hist_cru_id],[hist_cru_fecha],[hist_motivo])
		select 
		cru_id,
		cru_fecha_reinicio_servicio
		,'Reinicio'
		from @CRUCERO_HABILITAR
end
go

IF OBJECT_ID('TROLLS.VALIDARCLIENTEVIAJE', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.VALIDARCLIENTEVIAJE
GO

create procedure TROLLS.VALIDARCLIENTEVIAJE
@via_fecha_salida datetime,
@via_fecha_llegada datetime,
@pue_id_desde int,
@pue_id_hasta int,
@cli_id int,
@cli_tdoc_id int
as
begin

	select 1 from [TROLLS].[Viaje] join [TROLLS].[Pasaje] on via_id=pas_via_id join [TROLLS].[Recorrido] on rec_id = via_rec_id where 
  ((@via_fecha_salida >= [via_fecha_salida] and @via_fecha_llegada <= via_fecha_llegada) or (@via_fecha_salida <= [via_fecha_salida] and @via_fecha_llegada >= via_fecha_llegada) or
((@via_fecha_salida >= [via_fecha_salida] and @via_fecha_salida <= via_fecha_llegada) and (@via_fecha_llegada >= via_fecha_llegada))
or ((@via_fecha_salida <= [via_fecha_salida]) and (@via_fecha_llegada >= [via_fecha_salida] and @via_fecha_llegada <= via_fecha_llegada )))
  and pas_cli_id = @cli_id and pas_cli_tdoc_id=@cli_tdoc_id and [rec_pue_id_desde]<>@pue_id_desde and [rec_pue_id_hasta]<>@pue_id_hasta
  and pas_estado=1

	union

	select 1 from [TROLLS].[Viaje] join [TROLLS].Reserva on via_id=res_via_id join [TROLLS].[Recorrido] on rec_id = via_rec_id where 
  ((@via_fecha_salida >= [via_fecha_salida] and @via_fecha_llegada <= via_fecha_llegada) or (@via_fecha_salida <= [via_fecha_salida] and @via_fecha_llegada >= via_fecha_llegada) or
((@via_fecha_salida >= [via_fecha_salida] and @via_fecha_salida <= via_fecha_llegada) and (@via_fecha_llegada >= via_fecha_llegada))
or ((@via_fecha_salida <= [via_fecha_salida]) and (@via_fecha_llegada >= [via_fecha_salida] and @via_fecha_llegada <= via_fecha_llegada )))
  and res_cli_id = @cli_id and res_cli_tdoc_id=@cli_tdoc_id and [rec_pue_id_desde]<>@pue_id_desde and [rec_pue_id_hasta]<>@pue_id_hasta
  and res_estado=1

end
go

IF OBJECT_ID('TROLLS.OBTENERIDCABINA', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENERIDCABINA
GO

create procedure TROLLS.OBTENERIDCABINA
@cab_piso int,
@cab_numero int,
@cab_tcab_id int,
@via_id int
as
begin
	select cab_nro,cab_piso,cab_tcab_id,cab_via_id from [TROLLS].[Cabina] where [cab_piso]=@cab_piso and [cab_nro]=@cab_numero and [cab_tcab_id]=@cab_tcab_id and [cab_via_id]=@via_id
end
go 

-------------------------- ABM RECORRIDO -----------------------------------------------------
--Obtener Recorridos

IF OBJECT_ID('TROLLS.OBTENER_RECORRIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_RECORRIDO
GO

create procedure TROLLS.OBTENER_RECORRIDO 
@rec_id VARCHAR(30)
as
begin
	SELECT rec_id
		  ,rec_pue_id_desde
		  ,rec_pue_id_hasta
		  ,rec_estado
	FROM TROLLS.Recorrido where rec_id = @rec_id
end
GO

--Listar Recorridos

IF OBJECT_ID('TROLLS.LISTAR_RECORRIDOS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_RECORRIDOS
GO

CREATE PROCEDURE TROLLS.LISTAR_RECORRIDOS
@rec_id VARCHAR(30),
@rec_pue_desde VARCHAR(100),
@rec_pue_hasta VARCHAR(100)
AS
BEGIN
  	SELECT rec_id as Código_recorrido
		  ,(SELECT pue_nombre FROM TROLLS.Puerto where pue_id = rec_pue_id_desde) as Puerto_Salida
		  ,(SELECT pue_nombre FROM TROLLS.Puerto where pue_id = rec_pue_id_hasta) as Puerto_Destino
		  ,(select sum(tra_precio_base) from [GD1C2019].[TROLLS].Recorrido_Tramo RT 
			join [GD1C2019].[TROLLS].Tramos T on T.tra_id = RT.tra_id
		    where RT.rec_id = R.rec_id
			AND RT.estado = 1) as Precio
		  ,rec_estado as Estado
	FROM [GD1C2019].[TROLLS].[Recorrido] R
			WHERE rec_id LIKE ISNULL('%' + @rec_id + '%', '%')
			  AND (@rec_pue_desde is null or rec_pue_id_desde = @rec_pue_desde)
			  AND (@rec_pue_hasta is null or rec_pue_id_hasta = @rec_pue_hasta)			  
		--	  AND C.cru_mod LIKE ISNULL('%' + @cru_mod_desc + '%', '%')
	group by rec_id,rec_pue_id_desde,rec_pue_id_hasta,rec_estado
END
GO

--Obtener Puertos

IF OBJECT_ID('TROLLS.OBTENER_PUERTO_DESDE_PARAMETRO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_PUERTO_DESDE_PARAMETRO
GO

create procedure TROLLS.OBTENER_PUERTO_DESDE_PARAMETRO
@pue_id NUMERIC(18,0),
@pue_nombre VARCHAR(100)
AS
BEGIN 
	select pue_id,pue_nombre,pue_estado from TROLLS.Puerto 
	where  (@pue_id is null or pue_id = @pue_id)
	AND pue_nombre LIKE ISNULL('%' + @pue_nombre + '%', '%')
END
GO

--Listar Tramos

IF OBJECT_ID('TROLLS.LISTAR_TRAMOS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.LISTAR_TRAMOS
GO

CREATE PROCEDURE TROLLS.LISTAR_TRAMOS
@rec_id VARCHAR(30)
AS
BEGIN
	SELECT T.tra_id
		  ,(select pue_nombre FROM TROLLS.Puerto where pue_id = T.tra_desde) as tra_desde
		  ,(select pue_nombre FROM TROLLS.Puerto where pue_id = T.tra_hasta) as tra_hasta
		  ,tra_precio_base
	FROM TROLLS.Recorrido_Tramo RT
	join TROLLS.Tramos T on T.tra_id = RT.tra_id
	WHERE (@rec_id is null or rec_id = @rec_id)
	AND RT.estado = 1
	group by T.tra_id
			,tra_desde
		    ,tra_hasta
		    ,tra_precio_base
END
GO

--Obtener Tramos

IF OBJECT_ID('TROLLS.OBTENER_TRAMOS', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_TRAMOS
GO

CREATE PROCEDURE TROLLS.OBTENER_TRAMOS
@tra_desde NUMERIC(18,0),
@tra_hasta  NUMERIC(18,0)
AS
BEGIN
	SELECT tra_id
		  ,tra_desde
		  ,tra_hasta
		  ,tra_precio_base
	FROM TROLLS.Tramos
		WHERE (tra_desde = @tra_desde)
		  AND (tra_hasta = @tra_hasta)
END
GO

--Insertar Tramos

IF OBJECT_ID('TROLLS.INSERTAR_TRAMO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.INSERTAR_TRAMO
GO

CREATE PROCEDURE TROLLS.INSERTAR_TRAMO
@tra_desde NUMERIC(18,0),
@tra_hasta  NUMERIC(18,0),
@tra_precio_base DECIMAL(18,2)
AS
BEGIN
	SET IDENTITY_INSERT TROLLS.Tramos ON;
	INSERT INTO TROLLS.Tramos (tra_id,tra_desde,tra_hasta,tra_precio_base)
		VALUES ((SELECT (max(tra_id)+1) FROM TROLLS.Tramos)
				,@tra_desde
				,@tra_hasta
				,@tra_precio_base)
				
	SET IDENTITY_INSERT TROLLS.Tramos OFF;

	SELECT max(tra_id) FROM TROLLS.Tramos
END
GO

-- Actualizar precio Tramos

IF OBJECT_ID('TROLLS.ACTUALIZAR_TRAMO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.ACTUALIZAR_TRAMO
GO

CREATE PROCEDURE TROLLS.ACTUALIZAR_TRAMO
@tra_id NUMERIC(18,0),
@tra_precio_base DECIMAL(18,2)
AS
BEGIN
	UPDATE TROLLS.Tramos
		SET tra_precio_base = @tra_precio_base
		WHERE tra_id = @tra_id
END
GO

--Crear Recorridos

IF OBJECT_ID('TROLLS.CREAR_RECORRIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.CREAR_RECORRIDO
GO

CREATE PROCEDURE TROLLS.CREAR_RECORRIDO
@rec_id VARCHAR(30),
@rec_pue_desde NUMERIC(18,0),
@rec_pue_hasta  NUMERIC(18,0)
AS
BEGIN
	insert into TROLLS.Recorrido(rec_id,rec_pue_id_desde,rec_pue_id_hasta,rec_estado)
				values (@rec_id
						,@rec_pue_desde
						,@rec_pue_hasta
						,1)

END
GO


-- Obtener Recorrido_x_Tramo

IF OBJECT_ID('TROLLS.OBTENER_RECORRIDO_X_TRAMO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.OBTENER_RECORRIDO_X_TRAMO
GO

CREATE PROCEDURE TROLLS.OBTENER_RECORRIDO_X_TRAMO
@rec_id VARCHAR(30),
@tra_id numeric(18,0)
AS
BEGIN
	SELECT tra_id, rec_id, estado FROM TROLLS.Recorrido_Tramo
		WHERE rec_id = @rec_id
		  AND tra_id = @tra_id
END
GO

--Inserta en Recorrdo_Tramo. Se debe insertar de a uno desde la aplicacion

IF OBJECT_ID('TROLLS.INSERTAR_RECORRIDO_X_TRAMO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.INSERTAR_RECORRIDO_X_TRAMO
GO

CREATE PROCEDURE TROLLS.INSERTAR_RECORRIDO_X_TRAMO
@rec_id VARCHAR(30),
@tra_id numeric(18,0)
AS
BEGIN
	insert into TROLLS.Recorrido_Tramo(tra_id,rec_id,estado)
		values(@tra_id
			  ,@rec_id
			  ,1)
END
GO

--Modificar Recorridos

IF OBJECT_ID('TROLLS.MODIFICAR_RECORRIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_RECORRIDO
GO

CREATE PROCEDURE TROLLS.MODIFICAR_RECORRIDO
@rec_id VARCHAR(30),
@rec_pue_desde numeric(18,0),
@rec_pue_hasta  numeric(18,0),
@rec_estado bit
AS
BEGIN
	update TROLLS.Recorrido set 
		rec_pue_id_desde = @rec_pue_desde,
		rec_pue_id_hasta = @rec_pue_hasta,
		rec_estado = @rec_estado
	where rec_id = @rec_id
END
GO

-- """dar de baja o de alta"" RECORRIDO x TRAMO

IF OBJECT_ID('TROLLS.MODIFICAR_RECORRIDO_TRAMO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.MODIFICAR_RECORRIDO_TRAMO
GO

CREATE PROCEDURE TROLLS.MODIFICAR_RECORRIDO_TRAMO
@rec_id VARCHAR(30),
@tra_id numeric(18,0),
@estado bit
AS
BEGIN
	update TROLLS.Recorrido_Tramo set 
		estado = @estado
	where	rec_id = @rec_id
		AND	tra_id = @tra_id
END
GO

--Dar de baja Recorrido

IF OBJECT_ID('TROLLS.BAJA_RECORRIDO', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.BAJA_RECORRIDO
GO

CREATE PROCEDURE TROLLS.BAJA_RECORRIDO
@rec_id VARCHAR(30)
AS
BEGIN
	update TROLLS.Recorrido
	set rec_estado = 0
	where rec_id = @rec_id
END
GO

--Listados estadisticos
IF OBJECT_ID('TROLLS.sp_listado_estadistico_1', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.sp_listado_estadistico_1 
GO

--Listado 1
create procedure TROLLS.sp_listado_estadistico_1 (@semestre int, @anio int)
as
begin

DECLARE @LIST_CANTIDAD_PASAJES_TEMP TABLE 
	(
	RECORRIDO_CODIGO  VARCHAR(30),
	CANTIDAD_PASAJES INT
	);
	
	INSERT INTO @LIST_CANTIDAD_PASAJES_TEMP (RECORRIDO_CODIGO, CANTIDAD_PASAJES)
	(select via_rec_id, count(pas_id)
	from  [GD1C2019].[TROLLS].Pasaje 
	join [GD1C2019].[TROLLS].[Viaje] on pas_via_id = via_id join [TROLLS].[Compra] on pas_com_id = com_id
	where	year(com_fecha_compra) = @anio
		and	month(com_fecha_compra) between ((@semestre * 6) - 5) and @semestre * 6
	group by via_rec_id)
	

	select TOP 5
	CANTIDAD_PASAJES,
	(select pue_nombre from [GD1C2019].[TROLLS].Puerto where R.rec_pue_id_desde = pue_id) as PUERTO_DESDE, 
	(select pue_nombre from [GD1C2019].[TROLLS].Puerto where R.rec_pue_id_hasta = pue_id) as PUERTO_HASTA
	from [GD1C2019].[TROLLS].Recorrido R
	join @LIST_CANTIDAD_PASAJES_TEMP on R.rec_id = RECORRIDO_CODIGO
	order by CANTIDAD_PASAJES desc
end
go


IF OBJECT_ID('TROLLS.sp_listado_estadistico_2', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.sp_listado_estadistico_2 
GO

--Listado 2
create procedure TROLLS.sp_listado_estadistico_2(@semestre int, @anio int)
as
begin

DECLARE @CABINAS_LIBRES_TEMP TABLE 
	(
	via_id NUMERIC(18,0),
	rec_id VARCHAR(30),
	cru_id CHAR(30),
	cabs_libs INT
	);

INSERT INTO @CABINAS_LIBRES_TEMP (via_id,rec_id,cru_id,cabs_libs)
SELECT via_id
	  ,via_rec_id
	  ,via_cru_id
	  ,count( cab_nro+cab_piso+cab_tcab_id+cab_via_id )
  FROM [GD1C2019].[TROLLS].[Viaje]
  join [GD1C2019].[TROLLS].Cabina C on cab_via_id = via_id
  	where	year(via_fecha_salida) = @anio
		and	month(via_fecha_salida) between ((@semestre * 6) - 5) and @semestre * 6
	AND cab_ocupada = 0
  group by via_id,via_rec_id,via_cru_id

select top 5 
	R.rec_id as RECORRIDO_CODIGO,
	(select pue_nombre from [GD1C2019].[TROLLS].Puerto where R.rec_pue_id_desde = pue_id) as PUERTO_DESDE, 
	(select pue_nombre from [GD1C2019].[TROLLS].Puerto where R.rec_pue_id_hasta = pue_id) as PUERTO_HASTA,
	sum(cabs_libs) as CABINAS_LIBRES
	FROM @CABINAS_LIBRES_TEMP C
	join [GD1C2019].[TROLLS].RECORRIDO R on C.rec_id = R.rec_id
	group by R.rec_id, R.rec_pue_id_desde, R.rec_pue_id_hasta
	order by 4 desc
end
go


IF OBJECT_ID('TROLLS.sp_listado_estadistico_3', 'P') IS NOT NULL
DROP PROCEDURE TROLLS.sp_listado_estadistico_3 
GO
--Listado 3
create procedure TROLLS.sp_listado_estadistico_3(@semestre int, @anio int)
as
begin

declare @fechaActual varchar(8) = (select convert(varchar(8),getdate(),112))

select 
		cru_mod 'Modelo de Crucero',
		fab_desc 'Fabricante de Crucero',
		case when cru_fecha_reinicio_servicio is not null
			then datediff(dd,cru_fecha_fuera_servicio,cru_fecha_reinicio_servicio)
			else datediff(dd,cru_fecha_fuera_servicio,@fechaActual)
		end 'Cantidad de días'
	from trolls.Crucero
	join trolls.Fabricante_Crucero on fab_id = cru_fab_id
	where cru_fecha_fuera_servicio is not null 
		and year(cru_fecha_fuera_servicio) = @anio
		and month(cru_fecha_fuera_servicio) between ((@semestre * 6) - 5) and @semestre * 6
	order by [Cantidad de días] desc
end
go

--Se borran sps/funciones utilizadas en la migracion
DROP PROCEDURE TROLLS.Z_MIGRACION_RECORRIDO
DROP PROCEDURE TROLLS.Z_MIGRACION_CABINA_RESERVA_PASAJE
--Drop tabla maestra
drop table gd_esquema.Maestra;
go