CREATE ROLE admin_copamundial WITH LOGIN CREATEDB PASSWORD 'copamundial';
CREATE DATABASE copamundial WITH OWNER = admin_copamundial ENCODING = UTF8;


--Modulo 1
--DROPS

Drop table usuario;
Drop SEQUENCE SEQ_Usuario;

--Modulo 4
--DROPS
Drop table equipo;
Drop SEQUENCE SEQ_Equipo;

--Creates Tables

--Modulo 1
CREATE TABLE USUARIO (
    us_id		integer,
    us_nombreUsuario 	  varchar(20)  UNIQUE,
    us_nombre         	varchar(30) NOT NULL,
    us_apellido        	varchar(30) NOT NULL,
    us_fechaNacimiento  date,
    us_correo	          varchar(30) NOT NULL UNIQUE,
    us_genero           varchar(1) CHECK (us_genero ='M' OR us_genero='F'),
    us_password         varchar(50),
    us_fotoPath		      varchar(100),
    us_esAdmin boolean default false not null,
    us_activo boolean default true not null,
    us_token            varchar(100),
    CONSTRAINT primaria_usuario PRIMARY KEY(us_id)

);
--Fin de modulo

--Modulo 4

CREATE TABLE PAIS (

	pa_id		integer,
	pa_iso		varchar(3),
	pa_nombre	varchar(20),

    CONSTRAINT primaria_pais PRIMARY KEY(pa_id)
);

CREATE TABLE EQUIPO (

	eq_id		integer,
    eq_descripcion varchar(100) NOT NULL,
    eq_status boolean default true NOT NULL,
    eq_grupo varchar(1) CHECK (eq_grupo ='A' OR eq_grupo ='B' OR eq_grupo ='C' OR eq_grupo ='D' OR eq_grupo ='E' OR eq_grupo ='F' OR eq_grupo ='G' OR eq_grupo ='H'),
    eq_pa_id  integer,

    CONSTRAINT primaria_equipo PRIMARY KEY(eq_id),
    CONSTRAINT eq_pa_id FOREIGN KEY (eq_pa_id) REFERENCES pais (pa_id)
);
--Fin de modulo 4

--ALTERS
--Modulo 1
--Fin de modulo

--ALTERS
--Modulo 4
--Fin de modulo 4

--SEQUENCES
--Modulo 1
CREATE SEQUENCE SEQ_Usuario
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;
--Fin de modulo

--Modulo 4
CREATE SEQUENCE SEQ_Equipo
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;

 CREATE SEQUENCE SEQ_Pais
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;
--Fin de modulo 4

--INDEX
--Modulo 1
--Fin de modulo
--Modulo 4
--Fin de modulo 4

GRANT ALL PRIVILEGES ON TABLE usuario TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE equipo TO admin_copamundial;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO admin_copamundial;

--Fin Creates tables
