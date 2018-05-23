CREATE ROLE admin_copamundial WITH LOGIN CREATEDB PASSWORD 'copamundial';
CREATE DATABASE copamundial WITH OWNER = admin_copamundial ENCODING = UTF8;


--Modulo 1
--DROPS

Drop table usuario;
Drop SEQUENCE SEQ_Usuario;

--Creates Tables

--Modulo 1
CREATE TABLE USUARIO (
    us_id		integer,
    us_nombreUsuario 	varchar(20)  UNIQUE,
    us_nombre         	varchar(30) NOT NULL,
    us_apellido        	varchar(30) NOT NULL,
    us_fechaNacimiento  date,
    us_correo	        varchar(30) NOT NULL UNIQUE,
    us_genero   varchar(1) CHECK (us_genero ='M' OR us_genero='F'),
    us_password         varchar(50),
    us_fotoPath		varchar(100),
    us_esAdmin boolean default false not null,
    us_activo boolean default true not null,
    CONSTRAINT primaria_usuario PRIMARY KEY(us_id)

);
--Fin de modulo

--ALTERS
--Modulo 1
--Fin de modulo

--SEQUENCES
--Modulo 1
CREATE SEQUENCE SEQ_Usuario
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;
--Fin de modulo

--INDEX
--Modulo 1
--Fin de modulo

GRANT ALL PRIVILEGES ON TABLE usuario TO admin_copamundial;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO admin_copamundial;

--Fin Creates tables
