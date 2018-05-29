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
Drop table pais;
Drop SEQUENCE SEQ_Pais;
Drop table i18n_equipo;
Drop SEQUENCE SEQ_i18n_Equipo;


--Modulo 6
--DROPS
Drop table partido;
Drop SEQUENCE SEQ_Partido;
Drop table alineacion;
Drop SEQ_Alineacion;
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

CREATE TABLE I18N_EQUIPO (
    i18n_pk    integer NOT NULL,
    i18n_id    integer NOT NULL,
    i18n_idioma     varchar(100) NOT NULL,
    i18n_mensaje    text NOT NULL,
    CONSTRAINT primaria_i18n_equipo PRIMARY KEY (i18n_pk)
);

CREATE TABLE PAIS (

  pa_iso    varchar(3),
  pa_i18n_nombre  integer NOT NULL,
  pa_urlBandera varchar(50),

    CONSTRAINT primaria_pais PRIMARY KEY(pa_iso)
);

CREATE TABLE EQUIPO (

  eq_id   integer,
  eq_i18n_descripcion integer NOT NULL,
  eq_status boolean default true NOT NULL,
  eq_grupo varchar(1) CHECK (eq_grupo ='A' OR eq_grupo ='B' OR eq_grupo ='C' OR eq_grupo ='D' OR eq_grupo ='E' OR eq_grupo ='F' OR eq_grupo ='G' OR eq_grupo ='H'),
  eq_pa_id  varchar(3),
  eq_habilitado boolean,

    CONSTRAINT primaria_equipo PRIMARY KEY(eq_id),
    CONSTRAINT eq_pa_id FOREIGN KEY (eq_pa_id) REFERENCES pais (pa_iso)
);
--Fin de modulo 4
--Modulo 6
CREATE TABLE PARTIDO(
	pa_id integer,
    pa_fecha varchar(25) NOT NULL,
    pa_horaInicio varchar(25) NOT NULL,
    pa_horaFin varchar(25),
    pa_arbitro varchar(30) NOT NULL,
    pa_status boolean NOT NULL,
    pa_eq1_id integer NOT NULL, 
    pa_eq2_id integer NOT NULL, 
    pa_es_id integer NOT NULL,
    
    CONSTRAINT pk_partido PRIMARY KEY(pa_id),
    CONSTRAINT pa_eq1_id FOREIGN KEY (pa_eq1_id) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT pa_eq2_id FOREIGN KEY (pa_eq2_id) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE
);

--Modulo 6
CREATE TABLE PARTIDO(
	pa_id integer,
    pa_fecha varchar(25) NOT NULL,
    pa_horaInicio varchar(25) NOT NULL,
    pa_horaFin varchar(25),
    pa_arbitro varchar(30) NOT NULL,
    pa_status boolean NOT NULL,
    pa_eq1_id integer NOT NULL, 
    pa_eq2_id integer NOT NULL, 
    pa_es_id integer NOT NULL,
    
    CONSTRAINT pk_partido PRIMARY KEY(pa_id),
    CONSTRAINT pa_eq1_id FOREIGN KEY (pa_eq1_id) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT pa_eq2_id FOREIGN KEY (pa_eq2_id) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE
  --  CONSTRAINT pa_es_id FOREIGN KEY (pa_es_id) REFERENCES ESTADIO(es_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE JUGADOR (
	ju_id serial,
	ju_nombre varchar(40) NOT NULL,
	ju_apellido varchar(40) NOT NULL,
	ju_estatura integer NOT NULL,
	ju_fotoPath varchar(100) NOT NULL,
	ju_arquero boolean default false not null,
	ju_eq_id integer,
	CONSTRAINT primaria_jugadores PRIMARY KEY(ju_id),
	CONSTRAINT ju_eq_id FOREIGN KEY (ju_eq_id) REFERENCES equipo (eq_id)
	
);


CREATE TABLE ALINEACION(
	al_id integer,
    al_capitan boolean NOT NULL,
    al_posicion varchar(30) NOT NULL,
    al_titular boolean NOT NULL,
    al_ju_id integer NOT NULL,
    al_eq_id integer NOT NULL,
    al_pa_id integer NOT NULL,
    CONSTRAINT pk_alineacion PRIMARY KEY(al_id),

    CONSTRAINT al_ju_id FOREIGN KEY (al_ju_id) REFERENCES JUGADOR(ju_id) ON DELETE CASCADE ON UPDATE CASCADE,

    CONSTRAINT al_eq_id FOREIGN KEY (al_eq_id) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT al_pa_id FOREIGN KEY (al_pa_id) REFERENCES PARTIDO(pa_id) ON DELETE CASCADE ON UPDATE CASCADE


);

--Fin de modulo 6

--tablas modulo 9 que necesitamos y no se han subido


create table equipo_partido(
	equi_part_id serial,
	equi_part_posesion integer check (equi_part_posesion >= 0 and equi_part_posesion <= 100),
	equi_part_rendimiento integer check (equi_part_rendimiento >= 0 and equi_part_rendimiento <= 10),
	equi_part_fg_part integer,
	equi_part_fg_equipo integer,
	constraint primaria_equipo_partido PRIMARY KEY (equi_part_id),
	constraint equi_part_fg_part foreign key(equi_part_fg_part) references partido(pa_id),
	constraint equi_part_fg_equipo foreign key(equi_part_fg_equipo) references equipo(eq_id)

);

create table eventos_partido(
	eve_id serial,
	eve_nombre varchar(35) check (eve_nombre = 'GOL' OR eve_nombre = 'ASISTENCIA' OR eve_nombre = 'FALTACOMETIDA' OR eve_nombre = 'TIROESQUINA'  OR  eve_nombre = 'FALTARECIBIDA'  OR  eve_nombre = 'TARJETAA'  OR eve_nombre = 'TARJETAR'  OR  eve_nombre = 'OFFSIDE'  OR  eve_nombre = 'TIEMPOJUGADO'  OR  eve_nombre = 'TIROS'  OR  eve_nombre = 'GOLESREC'  OR  eve_nombre = 'PENALESATAJADOS'),
	eve_valor integer check(eve_valor >=0),
	--eve_minutosjugados integer check (eve_minutosjugados >=0 and eve_minutosjugados <=90),
	eve_minuto_juego integer check (eve_minuto_juego > 0 and eve_minuto_juego <=90),
	eve_fg_equipart integer,
	eve_fg_jug integer,
	constraint primaria_eventos_partido PRIMARY KEY (eve_id),
	constraint eve_fg_equipart foreign key (eve_fg_equipart) references equipo_partido(equi_part_id),
	constraint eve_fg_jug foreign key (eve_fg_jug) references jugador(ju_id)
);

-- fin tablas modulo 9






--ALTERS
--Modulo 1
--Fin de modulo

--ALTERS
--Modulo 4
--Fin de modulo 4

--ALTERS
--Modulo 6
ALTER TABLE ALINEACION ADD CONSTRAINT al_ju_id FOREIGN KEY (al_ju_id) REFERENCES JUGADOR(ju_id) ON DELETE CASCADE ON UPDATE CASCADE;
--Fin de modulo 6

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

  CREATE SEQUENCE SEQ_i18n_Equipo
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


--Modulo 6
CREATE SEQUENCE SEQ_Partido
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;

CREATE SEQUENCE SEQ_Alineacion
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;
--Fin de modulo 6
--INDEX
--Modulo 1
--Fin de modulo
--Modulo 4
--Fin de modulo 4

--Modulo 6
CREATE SEQUENCE SEQ_Partido
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;

CREATE SEQUENCE SEQ_Alineacion
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;
--Fin de modulo 6



GRANT ALL PRIVILEGES ON TABLE usuario TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE equipo TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE partido TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE alineacion TO admin_copamundial;

GRANT ALL PRIVILEGES ON TABLE jugador TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE equipo_partido TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE eventos_partido TO admin_copamundial;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO admin_copamundial;

--Fin Creates tables
