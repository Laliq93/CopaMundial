DROP SEQUENCE IF EXISTS SEQ_Usuario;
DROP SEQUENCE IF EXISTS SEQ_Jugador;
DROP SEQUENCE IF EXISTS SEQ_Partido;
DROP SEQUENCE IF EXISTS SEQ_Alineacion;
DROP SEQUENCE IF EXISTS SEQ_TipoLogro;
DROP SEQUENCE IF EXISTS SEQ_LogroPartido;

DROP TABLE IF EXISTS USUARIO CASCADE;
DROP TABLE IF EXISTS CIUDAD CASCADE;
DROP TABLE IF EXISTS JUGADOR CASCADE;
DROP TABLE IF EXISTS PARTIDO CASCADE;
DROP TABLE IF EXISTS ALINEACION CASCADE;
DROP TABLE IF EXISTS TIPO_LOGRO CASCADE;
DROP TABLE IF EXISTS LOGRO_PARTIDO CASCADE;
DROP TABLE IF EXISTS apuesta CASCADE;

CREATE SEQUENCE SEQ_Usuario
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;
  
 CREATE SEQUENCE SEQ_Jugador
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;
  
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
  
 CREATE SEQUENCE SEQ_TipoLogro
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;

CREATE SEQUENCE SEQ_LogroPartido
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;

CREATE TABLE public.USUARIO (
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

) TABLESPACE pg_default;

CREATE TABLE CIUDAD (
   	ci_id		serial,
    ci_nombre 	  varchar(70) not null,
    ci_poblacion  integer,
    ci_descripcion  varchar(250),
	ci_nombreingles varchar(70),
	ci_descripcioningles varchar(250),
	ci_habilitado boolean default (true),
    CONSTRAINT pk_ciudad PRIMARY KEY(ci_id)

);

CREATE TABLE JUGADOR
(
    ju_id integer,
    ju_nombre varchar(40) NOT NULL,
    ju_apellido varchar(20) NOT NULL,
    ju_fechaNacimiento date,
    ju_lugarNacimiento varchar(40) NOT NULL,
    ju_peso decimal(5,2) NOT NULL,
    ju_altura decimal(5,2) NOT NULL,
    ju_posicion varchar(20) CHECK (ju_posicion ='PORTERO' OR ju_posicion='LATERAL DERECHO' OR ju_posicion='LATERAL IZQUIERDO' OR ju_posicion='CENTRAL' OR ju_posicion='DEFENSA' OR ju_posicion='DELANTERO' OR ju_posicion='CENTROCAMPISTA'),
    ju_numero decimal,
    ju_equipo varchar(20) NOT NULL,
    ju_capitan boolean default false not null,
    ju_activo boolean default true not null,
    CONSTRAINT primaria_jugador PRIMARY KEY (ju_id)
    );

	CREATE TABLE PARTIDO(
    pa_id integer,
    pa_fechaInicio timestamp  NOT NULL,
    pa_fechaFin timestamp default null,
    pa_arbitro varchar(30) NOT NULL,
    pa_eq1_id integer NOT NULL, 
    pa_eq2_id integer NOT NULL, 
    pa_es_id integer NOT NULL,
    
    CONSTRAINT pk_partido PRIMARY KEY(pa_id)
    --CONSTRAINT pa_eq1_id FOREIGN KEY (pa_eq1_id) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE,
    --CONSTRAINT pa_eq2_id FOREIGN KEY (pa_eq2_id) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE,
    --CONSTRAINT pa_es_id FOREIGN KEY (pa_es_id) REFERENCES ESTADIO(es_id) ON DELETE CASCADE ON UPDATE CASCADE
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
    --CONSTRAINT al_eq_id FOREIGN KEY (al_eq_id) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT al_pa_id FOREIGN KEY (al_pa_id) REFERENCES PARTIDO(pa_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE TIPO_LOGRO(
    ti_id integer,
    ti_nombre varchar(35) UNIQUE NOT NULL,  
    ti_status bool,
    constraint primaria_tipo_logros PRIMARY KEY (ti_id)
);

CREATE TABLE LOGRO_PARTIDO(
	lo_id integer,
	lo_nombre varchar(100) not null,
        lo_cantidad integer check(lo_cantidad >=0),
        lo_status bool,
        lo_fg_tipoLogro integer,
	lo_resultado_pa integer,
        lo_resultado_eq integer,
	lo_resultado_ju integer,
	lo_resultado_vf bool,
	constraint primaria_logros_partido PRIMARY KEY (lo_id)
);

ALTER TABLE LOGRO_PARTIDO ADD CONSTRAINT lo_fg_tipoLogro foreign key (lo_fg_tipoLogro) references TIPO_LOGRO(ti_id);
ALTER TABLE LOGRO_PARTIDO ADD CONSTRAINT lo_resultado_pa foreign key (lo_resultado_pa) references PARTIDO(pa_id);
ALTER TABLE LOGRO_PARTIDO ADD CONSTRAINT lo_resultado_jug foreign key (lo_resultado_ju) references JUGADOR(ju_id);

CREATE TABLE public.apuesta
(
    "idlogro" integer NOT NULL,
    "idusuario" integer NOT NULL,
    "fechacreacion" date NOT NULL,
    estado character varying(30) COLLATE pg_catalog."default" DEFAULT 'en curso'::character varying,
    "respuestacantidad" integer,
    "respuestajugador" integer,
    "respuestaequipo" integer,
    "respuestavof" boolean,
    CONSTRAINT "Apuesta_pkey" PRIMARY KEY ("idlogro", "idusuario"),
    CONSTRAINT fk_idjugador FOREIGN KEY ("respuestajugador")
        REFERENCES public.jugador (ju_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_idlogro FOREIGN KEY ("idlogro")
        REFERENCES public.logro_partido (lo_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fk_idusuario FOREIGN KEY ("idusuario")
        REFERENCES public.usuario (us_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "Apuesta_estado_check" CHECK (estado::text = ANY (ARRAY['ganada'::character varying, 'perdida'::character varying, 'en curso'::character varying]::text[]))
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;


DROP USER IF EXISTS admin_copamundial;
CREATE USER admin_copamundial WITH ENCRYPTED PASSWORD 'copamundial';
GRANT ALL PRIVILEGES ON DATABASE copamundial TO admin_copamundial;

GRANT ALL PRIVILEGES ON TABLE USUARIO TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE CIUDAD TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE JUGADOR TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE PARTIDO TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE ALINEACION TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE TIPO_LOGRO TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE LOGRO_PARTIDO TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE apuesta TO admin_copamundial;


GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO admin_copamundial;


-------- Stored Procedures ---------

--------- INICIO MODULO 1 ---------
DROP FUNCTION IF EXISTS AgregarUsuario(
	_nombreUsuario VARCHAR(20), 
	_nombre VARCHAR(30),
 	_apellido VARCHAR(30), 
 	_fechaNacimiento VARCHAR(30),
	_correo VARCHAR(30),  
	_genero VARCHAR(1),
 	_password VARCHAR(20)
 );

CREATE OR REPLACE FUNCTION AgregarUsuario(
	_nombreUsuario VARCHAR(20), 
	_nombre VARCHAR(30),
 	_apellido VARCHAR(30), 
 	_fechaNacimiento VARCHAR(30),
	_correo VARCHAR(30),  
	_genero VARCHAR(1),
 	_password VARCHAR(20)
 	) RETURNS integer
	LANGUAGE 'plpgsql'

AS $BODY$

BEGIN

   INSERT INTO usuario VALUES
    (nextval('seq_Usuario'), _nombreUsuario, _nombre, _apellido, to_date(_fechaNacimiento, 'YYYY-MM-DD'), _correo, _genero, md5(_password), null, false, true, null);

   RETURN currval('seq_Usuario');

END;
$BODY$;

--------- FIN MODULO 1 ---------

--------- INICIO MODULO 2 ---------

create or replace function insertarciudad(_nombre varchar, _poblacion integer, _descripcion varchar, _nombreingles varchar, _descripcioningles varchar)
RETURNS void AS
$$
BEGIN

   insert into ciudad values (nextval('ciudad_ci_id_seq'::regclass),_nombre,_poblacion,_descripcion,_nombreingles, _descripcioningles,true);
END;
$$ LANGUAGE plpgsql;


/*funcion eliminar ciudad*/

create or replace function eliminarciudad(id integer)
RETURNS void AS
$$
BEGIN

   delete from ciudad where ci_id = id;
END;
$$ LANGUAGE plpgsql;


/* funcion actualizar ciudad*/


create or replace function updateciudad(_id integer,_nombre varchar, _poblacion integer, _descripcion varchar, _nombreingles varchar, _descripcioningles varchar,_habilitado boolean)
RETURNS void
AS
$$
BEGIN
	
	update ciudad set ci_nombre = _nombre, ci_poblacion = _poblacion, ci_descripcion = _descripcion, ci_nombreingles = _nombreingles, ci_habilitado = _habilitado,
	ci_descripcioningles = _descripcioningles
	where ci_id = _id;
	
END;
$$ LANGUAGE plpgsql;


create or replace function getciudad(_id integer)
RETURNS table(
	ci_id integer,
	ci_nombre varchar,
	ci_descripcion varchar,
	ci_poblacion integer,
	ci_nombreingles varchar,
	ci_descripcioningles varchar,
	ci_habilitado boolean
)
AS
$$
BEGIN

	return query select ciudad.ci_id, ciudad.ci_nombre, ciudad.ci_descripcion, ciudad.ci_poblacion, ciudad.ci_nombreingles,ciudad.ci_descripcioningles,ciudad.ci_habilitado from ciudad
	where ciudad.ci_id = _id; 
	
	
	
END;
$$ LANGUAGE plpgsql;


create or replace function getallciudad()
RETURNS table(
	ci_id integer,
	ci_nombre varchar,
	ci_descripcion varchar,
	ci_poblacion integer,
	ci_nombreingles varchar,
	ci_descripcioningles varchar,
	ci_habilitado boolean
)
AS
$$
BEGIN

	return query select ciudad.ci_id, ciudad.ci_nombre, ciudad.ci_descripcion, ciudad.ci_poblacion, ciudad.ci_nombreingles,ciudad.ci_descripcioningles,ciudad.ci_habilitado from ciudad; 
	
	
	
END;
$$ LANGUAGE plpgsql;

create or replace function getciudadbyname(_nombre varchar)
RETURNS table(
	ci_id integer,
	ci_nombre varchar,
	ci_descripcion varchar,
	ci_poblacion integer,
	ci_nombreingles varchar,
	ci_descripcioningles varchar,
	ci_habilitado boolean
)
AS
$$
BEGIN

	return query select ciudad.ci_id, ciudad.ci_nombre, ciudad.ci_descripcion, ciudad.ci_poblacion, ciudad.ci_nombreingles,ciudad.ci_descripcioningles,ciudad.ci_habilitado from ciudad
	where LOWER(_nombre) = LOWER(ciudad.ci_nombre);
	
	
	
END;
$$ LANGUAGE plpgsql;

create or replace function getciudadbynameingles(_nombre varchar)
RETURNS table(
	ci_id integer,
	ci_nombre varchar,
	ci_descripcion varchar,
	ci_poblacion integer,
	ci_nombreingles varchar,
	ci_descripcioningles varchar,
	ci_habilitado boolean
)
AS
$$
BEGIN

	return query select ciudad.ci_id, ciudad.ci_nombre, ciudad.ci_descripcion, ciudad.ci_poblacion, ciudad.ci_nombreingles,ciudad.ci_descripcioningles,ciudad.ci_habilitado from ciudad
	where LOWER(_nombre) = LOWER(ciudad.ci_nombreingles);
	
	
	
END;
$$ LANGUAGE plpgsql;


create or replace function getallciudadtrue()
RETURNS table(
	ci_id integer,
	ci_nombre varchar,
	ci_descripcion varchar,
	ci_poblacion integer,
	ci_nombreingles varchar,
	ci_descripcioningles varchar,
	ci_habilitado boolean
)
AS
$$
BEGIN

	return query select ciudad.ci_id, ciudad.ci_nombre, ciudad.ci_descripcion, ciudad.ci_poblacion, ciudad.ci_nombreingles,ciudad.ci_descripcioningles,ciudad.ci_habilitado from ciudad
	where ciudad.ci_habilitado = true	; 
	
	
	
END;
$$ LANGUAGE plpgsql;

--------- FIN MODULO 2 ---------

--------- INICIO MODULO 5 ---------

-- Agrega al jugador en la base de datos

CREATE OR REPLACE FUNCTION insertarJugador
(_nombre varchar,
 _apellido varchar,
 _fechaNacimiento date,
 _lugarNacimiento varchar, 
 _peso decimal(5,2),
 _altura decimal(5,2), 
 _posicion varchar, 
 _numero decimal,
 _equipo varchar)
RETURNS integer AS
$$
BEGIN
    INSERT INTO jugador
    VALUES
        (nextval('seq_Jugador'), _nombre, _apellido, _fechaNacimiento, _lugarNacimiento, _peso, _altura, 
            _posicion, _numero,  _equipo, false, true);
    RETURN currval('seq_Jugador');
END;
$$ LANGUAGE plpgsql;


-- edita todos los campos de jugador 

CREATE OR REPLACE FUNCTION editarJugador(
    _id integer,
    _nombre varchar,
    _apellido varchar,
    _fechaNacimiento date,
    _lugarNacimiento varchar,  
    _peso decimal,
    _altura decimal, 
    _posicion varchar, 
    _numero decimal,
    _capitan boolean)

RETURNS void
AS $$
BEGIN
    UPDATE jugador SET ju_nombre = _nombre, ju_apellido = _apellido, ju_fechaNacimiento = _fechaNacimiento, 
    ju_lugarNacimiento = _lugarNacimiento, ju_peso = _peso, ju_altura = _altura, ju_posicion = _posicion,
    ju_numero = _numero, ju_capitan = _capitan
    WHERE ju_id = _id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadorId(_id integer)
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal, 
     equipo varchar, capitan boolean)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_equipo, ju_capitan
    FROM jugador
    WHERE ju_id=_id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadores()
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal,
    equipo varchar, capitan boolean)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_equipo, ju_capitan
    FROM jugador;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadorNombre(_nombre varchar)
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal,
    capitan boolean, equipo varchar)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_capitan, ju_equipo
    FROM jugador
    WHERE ju_nombre = _nombre;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadorPosicion(_posicion varchar)
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal,
    capitan boolean, equipo varchar)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_capitan, ju_equipo
    FROM jugador
    WHERE ju_posicion = _posicion;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION desactivarJugador(_id integer)
RETURNS void
AS $$
BEGIN
    UPDATE jugador SET ju_activo = false
    WHERE ju_id = _id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION activarJugador(_id integer)
RETURNS void
AS $$
BEGIN
    UPDATE jugador SET ju_activo = true
    WHERE ju_id = _id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadoresActivo()
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal,
    equipo varchar, capitan boolean)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_equipo, ju_capitan
    FROM jugador
    WHERE ju_activo = true;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadoresInactivo()
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal,
    equipo varchar, capitan boolean)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_equipo, ju_capitan
    FROM jugador
    WHERE ju_activo = false;
END;
$$ LANGUAGE plpgsql;

--------- FIN MODULO 5 ---------

--------- INICIO MODULO 6 ---------

/* stored procedure para agrear un nuevo partido */
CREATE OR REPLACE FUNCTION AgregarPartido
(_fechaInicio timestamp, _fechaFin timestamp, _arbitro VARCHAR(30),
 _equipo1 integer, _equipo2 integer, _estadio integer)
RETURNS integer AS
$$
BEGIN

   INSERT INTO PARTIDO(pa_id, pa_fechaInicio, pa_fechaFin, 
    pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id) VALUES
    (nextval('seq_Partido'), _fechaInicio, _fechaFin , _arbitro,
     _equipo1, _equipo2, _estadio);

   RETURN currval('seq_Partido');

END;
$$ LANGUAGE plpgsql;
--select * from agregarpartido('2018/02/12 1:00:00', '2018/02/12 1:00:00' , 'pedro',1, 2, 3);

/* stored procedure para consultar un partido en especifico por su Id */
CREATE OR REPLACE FUNCTION ConsultarPartido(_idPartido integer)
RETURNS TABLE
  (id integer,
   fechaInicio timestamp,
   fechaFin timestamp,
   arbitro varchar,
   equipo1 integer,
   equipo2 integer,
   estadio integer)
AS
$$
BEGIN
  RETURN QUERY SELECT
  pa_id, pa_fechaInicio, pa_fechaFin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id
  FROM Partido
  WHERE pa_id=_idPartido;
END;
$$ LANGUAGE plpgsql;
--select * from consultarpartido(2)

/* stored procedure para consultar todos los partidos existentes */
   CREATE OR REPLACE FUNCTION ConsultarPartidos()
RETURNS TABLE
  (id integer,
   fechaInicio timestamp,
   fechafin timestamp,
   arbitro varchar,
   equipo1 integer,
   equipo2 integer,
   estadio integer)
AS
$$
BEGIN
  RETURN QUERY SELECT
  pa_id, pa_fechaInicio, pa_fechaFin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id
  FROM Partido;
END;
$$ LANGUAGE plpgsql;

--select * from consultarpartidos()

/* stored procedure para consultar los partidos a futuro de la fecha*/
CREATE OR REPLACE FUNCTION ConsultarPartidosSiguientes(fecha timestamp)
RETURNS TABLE
  (id integer,
   fechaInicio timestamp,
   fechaFin timestamp,
   arbitro varchar,
   equipo1 integer,
   equipo2 integer,
   estadio integer)
AS
$$
BEGIN
  RETURN QUERY SELECT
  pa_id, pa_fechaInicio, pa_fechaFin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id
  FROM Partido
  WHERE pa_fechaInicio > fecha;
END;
$$ LANGUAGE plpgsql;

--select * from ConsultarPartidosSiguientes('2018-02-13 01:00:00')

/* stored procedure para modificar el partido al que le corresponda el Id */
CREATE OR REPLACE FUNCTION ModificarPartido
(_idPartido integer, _fechaInicio timestamp, _fechaFin timestamp, _arbitro VARCHAR(30),
 _equipo1 integer, _equipo2 integer, _estadio integer)
RETURNS void AS
$$
BEGIN

   UPDATE PARTIDO SET pa_fechaInicio= _fechaInicio, pa_fechaFin = _fechaFin,  pa_arbitro= _arbitro,
    pa_eq1_id =_equipo1,  pa_eq2_id =_equipo2, pa_es_id = _estadio
  WHERE (pa_id = _idPartido);

END;
$$ LANGUAGE plpgsql;


--select * from Modificarpartido(1,'2018/06/27 1:00:00', '2018/06/27 3:00:00', 'pedro', 1, 2, 3)

/* stored procedure para agrear la alineacion a equipo y partido en especifico */
CREATE OR REPLACE FUNCTION AgregarAlineacion
(_capitan boolean, _posicion VARCHAR(30), _titular boolean,
 _jugador integer, _equipo integer, _partido integer)
RETURNS integer AS
$$
BEGIN

   INSERT INTO ALINEACION(al_id, al_capitan, 
    al_posicion, al_titular, al_ju_id, al_eq_id, al_pa_id) VALUES
    (nextval('seq_Alineacion'), _capitan, _posicion, _titular,
     _jugador, _equipo, _partido);

   RETURN currval('seq_Alineacion');

END;
$$ LANGUAGE plpgsql;
--select * from agregaralineacion(true, 'delantero', true, 1, 1, 1)

/* stored procedure para consultar la alineacion de un partido en especifico */
CREATE OR REPLACE FUNCTION ConsultarAlineacionPorPartido(idPartido integer)
RETURNS TABLE
  (id integer,
   _capitan boolean,
   _posicion varchar(30),
   _titular boolean,
   _jugador integer,
   _equipo integer,
   _partido integer)
AS
$$
BEGIN
  RETURN QUERY SELECT
  al_id, al_capitan, al_posicion, al_titular, al_ju_id, al_eq_id, al_pa_id
  FROM Alineacion
  WHERE al_pa_id = idPartido;
END;
$$ LANGUAGE plpgsql;

--select * from consultaralineacionporpartido(1)

/* stored procedure para modificar la alineacion que corresponde al Id */
CREATE OR REPLACE FUNCTION ModificarAlineacion
(_idAlineacion integer, _capitan boolean, _posicion VARCHAR(30), _titular boolean,
 _jugador integer, _equipo integer, _partido integer)
RETURNS integer AS
$$
BEGIN

     UPDATE ALINEACION SET  al_capitan = _capitan, 
    al_posicion= _posicion, al_titular= _titular, al_ju_id= _jugador, al_eq_id= _equipo, al_pa_id= _partido
    WHERE (al_id= _idAlineacion);

   RETURN _idAlineacion;

END;
$$ LANGUAGE plpgsql;

--select * from modificaralineacion(1, false, 'defensa', true, 1,1,1)

/* stored procedure para eliminar la alineacion de un partido*/
CREATE OR REPLACE FUNCTION EliminarAlineacion(_idAlineacion integer)
RETURNS void AS
$$
BEGIN

    DELETE FROM ALINEACION 
    WHERE (al_id= _idAlineacion);

END;
$$ LANGUAGE plpgsql;

--select * from EliminarAlineacion(1)

/* stored procedure para consultar la alineacion de un partido en especifico */
CREATE OR REPLACE FUNCTION ConsultarTitularesPorPartidoYEquipo(idPartido integer, idEquipo integer)
RETURNS TABLE
  (id integer,
   _capitan boolean,
   _posicion varchar(30),
   _titular boolean,
   _jugador integer,
   _equipo integer,
   _partido integer)
AS
$$
BEGIN
  RETURN QUERY SELECT
  al_id, al_capitan, al_posicion, al_titular, al_ju_id, al_eq_id, al_pa_id
  FROM Alineacion
  WHERE al_pa_id = idPartido AND al_eq_id = idEquipo AND al_titular = true;
END;
$$ LANGUAGE plpgsql;

--select * from ConsultarTitularesPorPartidoYEquipo(1, 4)

/* stored procedure para consultar la alineacion de un partido en especifico */
CREATE OR REPLACE FUNCTION ConsultarCapitanPorPartidoYEquipo(idPartido integer, idEquipo integer)
RETURNS TABLE
  (id integer,
   _capitan boolean,
   _posicion varchar(30),
   _titular boolean,
   _jugador integer,
   _equipo integer,
   _partido integer)
AS
$$
BEGIN
  RETURN QUERY SELECT
  al_id, al_capitan, al_posicion, al_titular, al_ju_id, al_eq_id, al_pa_id
  FROM Alineacion
  WHERE al_pa_id = idPartido AND al_eq_id = idEquipo AND al_capitan = true;
END;
$$ LANGUAGE plpgsql;

--select * from ConsultarCapitanPorPartidoYEquipo(1, 4)

--------- FIN MODULO 6 ---------

--------- INICIO MODULO 7 ---------

--===========================================STORED PROCEDURES===============================================
--=====================DROPS===========
DROP FUNCTION IF EXISTS AgregarTipoLogro;
DROP FUNCTION IF EXISTS ConsultarTiposLogros;
DROP FUNCTION IF EXISTS ModificarTipoLogro;
DROP FUNCTION IF EXISTS AsignarLogro;
DROP FUNCTION IF EXISTS RegistrarLogroCantidad;
DROP FUNCTION IF EXISTS RegistrarLogroJugador;
DROP FUNCTION IF EXISTS RegistrarLogroEquipo;
DROP FUNCTION IF EXISTS RegistrarLogroVoF;
DROP FUNCTION IF EXISTS ConsultarLogrosCantidadPendiente;
DROP FUNCTION IF EXISTS ConsultarLogrosJugadorPendiente;
DROP FUNCTION IF EXISTS ConsultarLogrosEquipoPendiente;
DROP FUNCTION IF EXISTS ConsultarLogrosVoFPendiente;
DROP FUNCTION IF EXISTS ConsultarLogrosPentientes;
DROP FUNCTION IF EXISTS ConsultarLogroCantidad;
DROP FUNCTION IF EXISTS ConsultarLogroJugador;
DROP FUNCTION IF EXISTS ConsultarLogroEquipo;
DROP FUNCTION IF EXISTS ConsultarLogroVF;
DROP FUNCTION IF EXISTS ConsultarLogrosCantidadResultados;
DROP FUNCTION IF EXISTS ConsultarLogrosJugadorResultados;
DROP FUNCTION IF EXISTS ConsultarLogrosEquipoResultados;
DROP FUNCTION IF EXISTS ConsultarLogrosVFResultados;
DROP FUNCTION IF EXISTS ConsultarProximosLogroPartido;
DROP FUNCTION IF EXISTS ConsultarLogroPartidoFinalizados;
DROP FUNCTION IF EXISTS ConsultarLogroPartidoPorId;
DROP FUNCTION IF EXISTS AsignarLogroPU;




-------------AGREGAR TIPO LOGRO-----------------

CREATE OR REPLACE FUNCTION AgregarTipoLogro
(_nombreTipoLogro VARCHAR(35))
RETURNS integer AS
$$
BEGIN

   INSERT INTO TIPO_LOGRO(ti_id, ti_nombre, ti_status) VALUES
    (nextval('SEQ_TipoLogro'), _nombreTipoLogro, true);
   RETURN currval('SEQ_TipoLogro');
END;
$$ LANGUAGE plpgsql;

------------CONSULTAR TIPOS DE LOGROS-------------

CREATE OR REPLACE FUNCTION ConsultarTiposLogros()
RETURNS TABLE
  (id integer,
   tipo varchar(35),
   status bool
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	ti_id, ti_nombre, ti_status
	FROM TIPO_LOGRO WHERE ti_status = true;
END;
$$ LANGUAGE plpgsql;

---------MODIFICAR TIPO DE LOGRO-----------------
CREATE OR REPLACE FUNCTION ModificarTipoLogro(_idTipoLogro integer, 
    _nombreTipoLogro VARCHAR(35), _status bool)
RETURNS integer AS
$$
BEGIN

   UPDATE TIPO_LOGRO SET ti_nombre= _nombreTipoLogro, 
    ti_status= _status
	WHERE (ti_id = _idTipoLogro);
   RETURN _idTipoLogro;
END;
$$ LANGUAGE plpgsql;

----------ASIGNAR LOGRO --------------------
   
CREATE OR REPLACE FUNCTION AsignarLogro
(_nombre VARCHAR, _idTipoLogro integer, _idPartido integer)
RETURNS integer AS
$$
BEGIN

   INSERT INTO LOGRO_PARTIDO(lo_id, lo_nombre, lo_status, lo_fg_tipoLogro, lo_resultado_pa) VALUES
    (nextval('SEQ_LogroPartido'), _nombre, true, _idTipoLogro, _idPartido);
   RETURN currval('SEQ_LogroPartido');
END;
$$ LANGUAGE plpgsql;


----------------------------REGISTRAR LOGRO CANTIDAD-------------------
CREATE OR REPLACE FUNCTION RegistrarLogroCantidad(_idLogro integer, 
    _cantidad integer)
RETURNS integer AS
$$
BEGIN
   UPDATE LOGRO_PARTIDO SET lo_cantidad= _cantidad 
	WHERE (lo_id = _idLogro);
   RETURN _idLogro;
END;
$$ LANGUAGE plpgsql;

----------------------------REGISTRAR LOGRO JUGADOR-------------------
CREATE OR REPLACE FUNCTION RegistrarLogroJugador(_idLogro integer, 
    _jugador integer)
RETURNS integer AS
$$
BEGIN
   UPDATE LOGRO_PARTIDO SET lo_resultado_ju= _jugador 
	WHERE (lo_id = _idLogro);
   RETURN _idLogro;
END;
$$ LANGUAGE plpgsql;

----------------------------REGISTRAR LOGRO EQUIPO-------------------
CREATE OR REPLACE FUNCTION RegistrarLogroEquipo(_idLogro integer, 
    _equipo integer)
RETURNS integer AS
$$
BEGIN
   UPDATE LOGRO_PARTIDO SET lo_resultado_eq= _equipo 
	WHERE (lo_id = _idLogro);
   RETURN _idLogro;
END;
$$ LANGUAGE plpgsql;


----------------------------REGISTRAR LOGRO VoF-------------------
CREATE OR REPLACE FUNCTION RegistrarLogroVoF(_idLogro integer, 
    _vf bool)
RETURNS integer AS
$$
BEGIN
   UPDATE LOGRO_PARTIDO SET lo_resultado_vf= _vf 
	WHERE (lo_id = _idLogro);
   RETURN _idLogro;
END;
$$ LANGUAGE plpgsql;

--------------------------CONSULTAR LOGROS CANTIDAD PENDIENTE--------------------
CREATE OR REPLACE FUNCTION ConsultarLogrosCantidadPendiente(_idPartido integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre
	FROM LOGRO_PARTIDO WHERE lo_resultado_pa = _idPartido and lo_fg_tipologro = 1 and lo_cantidad is null;
END;
$$ LANGUAGE plpgsql;

--------------------------CONSULTAR LOGROS JUGADOR PENDIENTE--------------------
CREATE OR REPLACE FUNCTION ConsultarLogrosJugadorPendiente(_idPartido integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre
	FROM LOGRO_PARTIDO WHERE lo_resultado_pa = _idPartido and lo_fg_tipologro = 2 and lo_resultado_ju is null;
END;
$$ LANGUAGE plpgsql;
--------------------------CONSULTAR LOGROS EQUIPO PENDIENTE--------------------
CREATE OR REPLACE FUNCTION ConsultarLogrosEquipoPendiente(_idPartido integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre
	FROM LOGRO_PARTIDO WHERE lo_resultado_pa = _idPartido and lo_fg_tipologro = 3 and lo_resultado_eq is null;
END;
$$ LANGUAGE plpgsql;

--------------------------CONSULTAR LOGROS VOF PENDIENTE--------------------
CREATE OR REPLACE FUNCTION ConsultarLogrosVoFPendiente(_idPartido integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre
	FROM LOGRO_PARTIDO WHERE lo_resultado_pa = _idPartido and lo_fg_tipologro = 4 and lo_resultado_vf is null;
END;
$$ LANGUAGE plpgsql;

--------------------------CONSULTAR LOGROS CANTIDAD RESULTADOS--------------------
CREATE OR REPLACE FUNCTION ConsultarLogrosCantidadResultados(_idPartido integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar, 
   cantidad integer
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre, lo_cantidad
	FROM LOGRO_PARTIDO WHERE lo_resultado_pa = _idPartido and lo_fg_tipologro = 1 and lo_cantidad is not null;
END;
$$ LANGUAGE plpgsql;

--------------------------CONSULTAR LOGROS JUGADOR RESULTADOS--------------------
CREATE OR REPLACE FUNCTION ConsultarLogrosJugadorResultados(_idPartido integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar,
   jugador integer
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre, lo_resultado_ju
	FROM LOGRO_PARTIDO WHERE lo_resultado_pa = _idPartido and lo_fg_tipologro = 2 and lo_resultado_ju is not null;
END;
$$ LANGUAGE plpgsql;
--------------------------CONSULTAR LOGROS EQUIPO RESULTADOS--------------------
CREATE OR REPLACE FUNCTION ConsultarLogrosEquipoResultados(_idPartido integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar,
   equipo integer
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre, lo_resultado_eq
	FROM LOGRO_PARTIDO WHERE lo_resultado_pa = _idPartido and lo_fg_tipologro = 3 and lo_resultado_eq is not null;
END;
$$ LANGUAGE plpgsql;
--------------------------CONSULTAR LOGROS VF RESULTADOS--------------------
CREATE OR REPLACE FUNCTION ConsultarLogrosVFResultados(_idPartido integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar,
   vf bool
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre, lo_resultado_vf
	FROM LOGRO_PARTIDO WHERE lo_resultado_pa = _idPartido and lo_fg_tipologro = 4 and lo_resultado_vf is not null;
END;
$$ LANGUAGE plpgsql;
--------------------------CONSULTAR LOGRO CANTIDAD --------------------
CREATE OR REPLACE FUNCTION ConsultarLogroCantidad(_idLogro integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar,
   cantidad integer,
   status bool
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre,lo_cantidad,lo_status
	FROM LOGRO_PARTIDO WHERE lo_id = _idLogro and lo_status is true and lo_fg_tipologro=1;
END;
$$ LANGUAGE plpgsql;

--------------------------CONSULTAR LOGRO JUGADOR --------------------
CREATE OR REPLACE FUNCTION ConsultarLogroJugador(_idLogro integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar,
   jugador integer,
   status bool
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre,lo_resultado_ju,lo_status
	FROM LOGRO_PARTIDO WHERE lo_id = _idLogro and lo_status is true and lo_fg_tipologro=2;
END;
$$ LANGUAGE plpgsql;

--------------------------CONSULTAR LOGRO EQUIPO --------------------
CREATE OR REPLACE FUNCTION ConsultarLogroEquipo(_idLogro integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar,
   equipo integer,
   status bool
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre,lo_resultado_eq,lo_status
	FROM LOGRO_PARTIDO WHERE lo_id = _idLogro and lo_status is true and lo_fg_tipologro=3;
END;
$$ LANGUAGE plpgsql;

--------------------------CONSULTAR LOGRO VF --------------------
CREATE OR REPLACE FUNCTION ConsultarLogroVF(_idLogro integer)
RETURNS TABLE
  (id integer,
   tipo integer,
   nombre varchar,
   vf bool,
   status bool
  )
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id,lo_fg_tipologro,lo_nombre,lo_resultado_vf,lo_status
	FROM LOGRO_PARTIDO WHERE lo_id = _idLogro and lo_status is true and lo_fg_tipologro=4;
END;
$$ LANGUAGE plpgsql;

---------------------------CONSULTAR TODOS LOS LOGROS PENDIENTES DE UN PARTIDO----------------
/*
	Consulta una lista de logros sin resultado (NO SE ESTA IMPLEMENTANDO TODAVIA)
*/
CREATE OR REPLACE FUNCTION ConsultarLogrosPendientes(_idPartido integer)
RETURNS TABLE
  (id integer,
   nombre varchar(100), 
   status bool,
   idTipoLogro integer,
   partido integer)
AS
$$
BEGIN
	RETURN QUERY SELECT
	lo_id, lo_nombre, lo_status, lo_fg_tipoLogro, lo_resultado_pa
	FROM LOGRO_PARTIDO WHERE lo_resultado_pa = _idPartido and lo_status = true and lo_cantidad is null
    and lo_resultado_eq is null and lo_resultado_ju is null and  lo_resultado_vf is null;
END;
$$ LANGUAGE plpgsql;

--**************************************SP PARA INTERFAZ**********************************

-------------------------------------CONSULTAR PROXIMOS PARTIDOS-------------------------
CREATE OR REPLACE FUNCTION ConsultarProximosLogroPartido(
	_fecha timestamp with time zone)
    RETURNS TABLE(idpartido integer, fechapartido text, equipo1 integer, equipo2 integer) 
AS 
$$
BEGIN
	RETURN QUERY SELECT pa_id, to_char(pa_fechainicio, 'DD-MM-YYYY'),
	pa_eq1_id, pa_eq2_id FROM partido WHERE pa_fechainicio > _fecha ORDER BY pa_fechainicio;
END;
$$ LANGUAGE plpgsql;
------------------------------------CONSULTAR PARTIDOS FINALIZADOS-----------------------
CREATE OR REPLACE FUNCTION ConsultarLogroPartidoFinalizados(
	_fecha timestamp with time zone)
    RETURNS TABLE(idpartido integer, fechapartido text, equipo1 integer, equipo2 integer) 
AS 
$$
BEGIN
	RETURN QUERY SELECT pa_id, to_char(pa_fechainicio, 'DD-MM-YYYY'),
	pa_eq1_id, pa_eq2_id FROM partido WHERE pa_fechainicio < _fecha ORDER BY pa_fechainicio;
END;
$$ LANGUAGE plpgsql;

----------------------------------CONSULTAR LOGRO PARTIDO--------------------------------
CREATE OR REPLACE FUNCTION ConsultarLogroPartidoPorId(_idPartido integer)
    RETURNS TABLE(idpartido integer, fechapartido text, equipo1 integer, equipo2 integer) 
AS 
$$
BEGIN
	RETURN QUERY SELECT pa_id, to_char(pa_fechainicio, 'DD-MM-YYYY'),
	pa_eq1_id, pa_eq2_id FROM partido WHERE pa_id = _idPartido;
END;
$$ LANGUAGE plpgsql;

--**************************************SP PARA PU***************************************
----------------------------------------AsignarLogroPU
CREATE OR REPLACE FUNCTION AsignarLogroPU
(_idLogro integer, _nombre VARCHAR, _idTipoLogro integer, _idPartido integer)
RETURNS integer AS
$$
BEGIN

   INSERT INTO LOGRO_PARTIDO(lo_id, lo_nombre, lo_status, lo_fg_tipoLogro, lo_resultado_pa) VALUES
    (_idLogro, _nombre, true, _idTipoLogro, _idPartido);
   RETURN _idLogro;
END;
$$ LANGUAGE plpgsql;

--------- FIN MODULO 7 ---------

--------- INICIO MODULO 8 ---------

CREATE OR REPLACE FUNCTION public.agregarapuestacantidad(
	_idlogro integer,
	_idusuario integer,
	_apuesta integer)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

INSERT INTO apuesta(idLogro , idUsuario, respuestacantidad, fechaCreacion) 
	values (_idlogro,_idUsuario,_apuesta, now());

	RETURN 1;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.agregarapuestaequipo(
	_idlogro integer,
	_idusuario integer,
	_apuesta integer)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

INSERT INTO apuesta(idLogro , idUsuario, respuestaequipo, fechaCreacion) 
	values (_idlogro,_idUsuario,_apuesta, now());

	RETURN 1;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.agregarapuestajugador(
	_idlogro integer,
	_idusuario integer,
	_apuesta integer)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

INSERT INTO apuesta(idLogro , idUsuario, respuestajugador, fechaCreacion) 
	values (_idlogro,_idUsuario,_apuesta, now());

	RETURN 1;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerproximasapuestap(
	_fecha timestamp with time zone)
    RETURNS TABLE(idpartido integer, fechapartido text, equipo1 integer, equipo2 integer) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT pa_id, to_char(pa_fechainicio, 'DD-MM-YYYY'),
	pa_eq1_id, pa_eq2_id FROM partido WHERE pa_fechainicio > _fecha ORDER BY pa_fechainicio;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.agregarapuestavof(
	_idlogro integer,
	_idusuario integer,
	_apuesta boolean)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

INSERT INTO apuesta(idLogro , idUsuario, respuestaVOF, fechaCreacion) 
	values (_idlogro,_idUsuario,_apuesta, now());

	RETURN 1;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.verificarapuestaexiste(
	_idusuario integer,
	_idlogro integer)
    RETURNS TABLE(conteo bigint) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT count(idlogro) from apuesta where idlogro = _idLogro AND idusuario = _idUsuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerapuestascantidadencurso(
	_idusuario integer)
    RETURNS TABLE(logroid integer, logroenunciado character varying, respuestausuario integer, estadoapuesta character varying, fechaapuesta date) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT lo.lo_id, lo.lo_nombre, ap.respuestacantidad, ap.estado, ap.fechacreacion FROM logro_partido lo 
	INNER JOIN apuesta ap ON lo.lo_id = ap.idlogro WHERE lo.lo_fg_tipologro = 1 AND ap.estado = 'en curso' 
	AND ap.idusuario = _idusuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerapuestasequipoencurso(
	_idusuario integer)
    RETURNS TABLE(logroid integer, logroenunciado character varying, respuestausuario integer, estadoapuesta character varying, fechaapuesta date) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT lo.lo_id, lo.lo_nombre, ap.respuestaequipo, ap.estado, ap.fechacreacion FROM logro_partido lo 
	INNER JOIN apuesta ap ON lo.lo_id = ap.idlogro WHERE lo.lo_fg_tipologro = 3 AND ap.estado = 'en curso' 
	AND ap.idusuario = _idusuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerapuestasjugadorencurso(
	_idusuario integer)
    RETURNS TABLE(logroid integer, logroenunciado character varying, idjugador integer, nombrejugador character varying, 
				  apellidojugador character varying, estadoapuesta character varying, fechaapuesta date) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT lo.lo_id, lo.lo_nombre, ap.respuestajugador,ju.ju_nombre, ju.ju_apellido ,ap.estado, ap.fechacreacion FROM logro_partido lo 
	INNER JOIN apuesta ap ON lo.lo_id = ap.idlogro INNER JOIN jugador ju ON ju.ju_id = ap.respuestajugador WHERE lo.lo_fg_tipologro = 2 AND ap.estado = 'en curso' 
	AND ap.idusuario = _idusuario;
END;

$BODY$;


CREATE OR REPLACE FUNCTION public.obtenerapuestasvofencurso(
	_idusuario integer)
    RETURNS TABLE(logroid integer, logroenunciado character varying, respuestausuario boolean, estadoapuesta character varying, fechaapuesta date) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT lo.lo_id, lo.lo_nombre, ap.respuestavof, ap.estado, ap.fechacreacion FROM logro_partido lo 
	INNER JOIN apuesta ap ON lo.lo_id = ap.idlogro WHERE lo.lo_fg_tipologro = 4 AND ap.estado = 'en curso' 
	AND ap.idusuario = _idusuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.verificarapuestavalida(
	_idusuario integer,
	_idlogro integer)
    RETURNS TABLE(conteo bigint) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY select count(apuesta.idusuario) from apuesta inner join logro_partido ON apuesta.idlogro = logro_partido.lo_id 
	inner join partido on logro_partido.lo_resultado_pa = partido.pa_id where partido.pa_fechainicio > now() 
	AND apuesta.idusuario = _idusuario AND logro_partido.lo_id = _idlogro;
END;

$BODY$;
	
CREATE OR REPLACE FUNCTION public.editarapuestavof(
	_idlogro integer,
	_idusuario integer,
	_apuesta boolean)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

UPDATE apuesta SET respuestavof = _apuesta WHERE idusuario = _idusuario AND idlogro = _idlogro;

	RETURN 1;
	
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.editarapuestacantidad(
	_idlogro integer,
	_idusuario integer,
	_apuesta integer)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

UPDATE apuesta SET respuestacantidad = _apuesta WHERE idusuario = _idusuario AND idlogro = _idlogro;

	RETURN 1;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.editarapuestaequipo(
	_idlogro integer,
	_idusuario integer,
	_apuesta integer)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

UPDATE apuesta SET respuestaequipo = _apuesta WHERE idusuario = _idusuario AND idlogro = _idlogro;

	RETURN 1;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.editarapuestajugador(
	_idlogro integer,
	_idusuario integer,
	_apuesta integer)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

UPDATE apuesta SET respuestajugador = _apuesta WHERE idusuario = _idusuario AND idlogro = _idlogro;

	RETURN 1;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.eliminarapuesta(
	_idusuario integer,
	_idlogro integer)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

	DELETE FROM apuesta WHERE idusuario = _idusuario AND idlogro = _idlogro;

	RETURN 1;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerapuestasvoffinalizadas(
	_idusuario integer)
    RETURNS TABLE(logroid integer, logroenunciado character varying, respuestausuario boolean, estadoapuesta character varying, fechaapuesta date) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT lo.lo_id, lo.lo_nombre, ap.respuestavof, ap.estado, ap.fechacreacion FROM logro_partido lo 
	INNER JOIN apuesta ap ON lo.lo_id = ap.idlogro WHERE lo.lo_fg_tipologro = 4 AND ap.estado != 'en curso' 
	AND ap.idusuario = _idusuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerapuestascantidadfinalizadas(
	_idusuario integer)
    RETURNS TABLE(logroid integer, logroenunciado character varying, respuestausuario integer, estadoapuesta character varying, fechaapuesta date) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT lo.lo_id, lo.lo_nombre, ap.respuestacantidad, ap.estado, ap.fechacreacion FROM logro_partido lo 
	INNER JOIN apuesta ap ON lo.lo_id = ap.idlogro WHERE lo.lo_fg_tipologro = 1 AND ap.estado != 'en curso' 
	AND ap.idusuario = _idusuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerapuestasjugadorfinalizadas(
	_idusuario integer)
    RETURNS TABLE(logroid integer, logroenunciado character varying, idjugador integer, nombrejugador character varying, apellidojugador character varying, estadoapuesta character varying, fechaapuesta date) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT lo.lo_id, lo.lo_nombre, ap.respuestajugador,ju.ju_nombre, ju.ju_apellido ,ap.estado, ap.fechacreacion FROM logro_partido lo 
	INNER JOIN apuesta ap ON lo.lo_id = ap.idlogro INNER JOIN jugador ju ON ju.ju_id = ap.respuestajugador WHERE lo.lo_fg_tipologro = 2 AND ap.estado != 'en curso' 
	AND ap.idusuario = _idusuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerapuestasequipofinalizadas(
	_idusuario integer)
    RETURNS TABLE(logroid integer, logroenunciado character varying, respuestausuario integer, estadoapuesta character varying, fechaapuesta date) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT lo.lo_id, lo.lo_nombre, ap.respuestaequipo, ap.estado, ap.fechacreacion FROM logro_partido lo 
	INNER JOIN apuesta ap ON lo.lo_id = ap.idlogro WHERE lo.lo_fg_tipologro = 3 AND ap.estado != 'en curso' 
	AND ap.idusuario = _idusuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.finalizarapuestavof(
	)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

UPDATE apuesta ap SET estado = 'ganada' FROM logro_partido lo WHERE lo.lo_id = ap.idlogro AND lo.lo_fg_tipologro = 4 
AND lo.lo_resultado_vf is not null AND lo.lo_resultado_vf = ap.respuestavof AND ap.estado != 'ganada';

UPDATE apuesta ap SET estado = 'perdida' FROM logro_partido lo WHERE lo.lo_id = ap.idlogro AND lo.lo_fg_tipologro = 4 
AND lo.lo_resultado_vf is not null AND lo.lo_resultado_vf != ap.respuestavof AND ap.estado != 'perdida';

	RETURN 1;
	
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.finalizarapuestacantidad(
	)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

UPDATE apuesta ap SET estado = 'ganada' FROM logro_partido lo WHERE lo.lo_id = ap.idlogro AND lo.lo_fg_tipologro = 1 
AND lo.lo_cantidad is not null AND lo.lo_cantidad = ap.respuestacantidad AND ap.estado != 'ganada';

UPDATE apuesta ap SET estado = 'perdida' FROM logro_partido lo WHERE lo.lo_id = ap.idlogro AND lo.lo_fg_tipologro = 1 
AND lo.lo_cantidad is not null AND lo.lo_cantidad != ap.respuestacantidad AND ap.estado != 'perdida';

	RETURN 1;
	
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.finalizarapuestajugador(
	)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

UPDATE apuesta ap SET estado = 'ganada' FROM logro_partido lo WHERE lo.lo_id = ap.idlogro AND lo.lo_fg_tipologro = 2 
AND lo.lo_resultado_ju is not null AND lo.lo_resultado_ju = ap.respuestajugador AND ap.estado != 'ganada';

UPDATE apuesta ap SET estado = 'perdida' FROM logro_partido lo WHERE lo.lo_id = ap.idlogro AND lo.lo_fg_tipologro = 2 
AND lo.lo_resultado_ju is not null AND lo.lo_resultado_ju != ap.respuestajugador AND ap.estado != 'perdida';

	RETURN 1;
	
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.finalizarapuestaequipo(
	)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

UPDATE apuesta ap SET estado = 'ganada' FROM logro_partido lo WHERE lo.lo_id = ap.idlogro AND lo.lo_fg_tipologro = 3 
AND lo.lo_resultado_eq is not null AND lo.lo_resultado_eq = ap.respuestaequipo AND ap.estado != 'ganada';

UPDATE apuesta ap SET estado = 'perdida' FROM logro_partido lo WHERE lo.lo_id = ap.idlogro AND lo.lo_fg_tipologro = 3 
AND lo.lo_resultado_eq is not null AND lo.lo_resultado_eq != ap.respuestaequipo AND ap.estado != 'perdida';

	RETURN 1;
	
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerapuestatest(
	_idusuario integer, _idlogro integer)
    RETURNS TABLE(usuario integer, logro integer, _estado character varying, _respuestavof boolean,
				 _respuestacantidad integer, _respuestajugador integer, _respuestaequipo integer) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT idusuario, idlogro, estado, respuestavof, respuestacantidad, 
	respuestajugador, respuestaequipo FROM apuesta WHERE idusuario = _idusuario AND idlogro = _idlogro;
END;

$BODY$;

--------- FIN MODULO 8 ---------

--------- INICIO MODULO 10 ---------

CREATE OR REPLACE FUNCTION public.cambiarcorreousuario(
	_id integer,
	_correo character varying)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN
	UPDATE usuario SET us_correo = _correo WHERE us_id = _id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.cambiarpasswordusuario(
	_id integer,
	_clave character varying)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN
	UPDATE usuario SET us_password = md5(_clave) WHERE us_id = _id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.consultarusuarioid(
	_id integer)
    RETURNS TABLE(idusuario integer, nombreusuario character varying, nombre character varying, apellido character varying, fechanacimiento date, correo character varying, genero character varying, foto character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	us_id, us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_fotoPath
	FROM usuario
	WHERE us_id=_id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.crearusuarioadministrador(
	_nombreusuario character varying,
	_nombre character varying,
	_apellido character varying,
	_fechanacimiento date,
	_correo character varying,
	_genero character varying,
	_password character varying)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

INSERT INTO public.usuario(
	us_id, us_nombreusuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_password, us_esadmin)
	VALUES (nextval('seq_Usuario'), _nombreUsuario, _nombre, _apellido, _fechaNacimiento, _correo, _genero, md5(_password), true);

   RETURN currval('seq_Usuario');

END;

$BODY$;

CREATE OR REPLACE FUNCTION public.editarperfilusuario(
	_id integer,
	_nombre character varying,
	_apellido character varying,
	_fechanacimiento date,
	_genero character,
	_foto character varying)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
BEGIN
	UPDATE usuario SET us_nombre = _nombre, us_apellido = _apellido, us_fechaNacimiento = _fechaNacimiento, us_genero = _genero, us_fotoPath = _foto
	WHERE us_id = _id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.gestionaractivocuentausuario(
	_id integer,
	_activo boolean)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN
	UPDATE usuario SET us_activo = _activo WHERE us_id = _id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerusuario(
	_id integer)
    RETURNS TABLE(nombreusuario character varying, nombre character varying, apellido character varying, fechanacimiento date, correo character varying, genero character varying, clave character varying, foto character varying, esadmin boolean, activo boolean) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
		us_nombreusuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, 
		us_password, us_fotopath, us_esadmin, us_activo
	FROM usuario
	WHERE us_id=_id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerusuariosactivos(
	)
    RETURNS TABLE(idusuario integer, nombreusuario character varying, nombre character varying, apellido character varying, fechanacimiento date, correo character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	us_id, us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo
	FROM usuario
	WHERE us_activo = true AND us_esAdmin = false order by us_nombre;
END;

$BODY$;


CREATE OR REPLACE FUNCTION public.obtenerusuariosnoactivos(
	)
    RETURNS TABLE(idusuario integer, nombreusuario character varying, nombre character varying, apellido character varying, fechanacimiento date, correo character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	us_id, us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo
	FROM usuario
	WHERE us_activo = false AND us_esAdmin = false order by us_nombre;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.verificarclaveusuario(
	_clave character varying,
	_idusuario integer)
    RETURNS TABLE(cantidadclave bigint) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_password = md5(_clave) AND us_id = _idUsuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.verificarcorreoexiste(
	correo character varying)
    RETURNS TABLE(cantidadcorreo bigint) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_correo = correo;
END;

$BODY$;

--------- FIN MODULO 10 ---------


----------------- DML ------------------

INSERT INTO USUARIO(us_id,us_nombreusuario,us_nombre,us_apellido,us_fechanacimiento,us_correo,us_genero,us_password,us_esadmin,us_activo) VALUES (nextval('seq_Usuario'),'mfelix','Felix','Morales','1995-12-13','felix@hotmail.com','M','test',false,true);

INSERT INTO public.tipo_logro(ti_id, ti_nombre, ti_status) VALUES (1,'cantidad',true);
INSERT INTO public.tipo_logro(ti_id, ti_nombre, ti_status) VALUES (2,'jugador',true);
INSERT INTO public.tipo_logro(ti_id, ti_nombre, ti_status) VALUES (3,'equipo',true);
INSERT INTO public.tipo_logro(ti_id, ti_nombre, ti_status) VALUES (4,'VoF',true);

INSERT INTO public.ciudad(
	ci_nombre, ci_poblacion, ci_descripcion, ci_nombreingles, ci_descripcioningles, ci_habilitado)
	VALUES ('Moscu', 1000, 'Descripcion', 'Moscu', 'hi', true);