/**
Procedimientos del Modulo_1 de autoregistro, inicio de sesión, recuperación de contraseña y home
Autores:
  Sabina Quiroga 
  Laura Quiñones
**/

/*INSERT*/
-- Inserta el Usuario
-- devuelve el id del usuario
CREATE OR REPLACE FUNCTION AgregarUsuario
(_nombreUsuario VARCHAR(20), _nombre VARCHAR(30),
 _apellido VARCHAR(30), _fechaNacimiento date,
_correo VARCHAR(30),  _genero VARCHAR(1),
 _password VARCHAR(20))
RETURNS integer AS
$$
BEGIN

   INSERT INTO usuario VALUES
    (nextval('seq_Usuario'), _nombreUsuario, _nombre, _apellido, _fechaNacimiento, _correo, _genero, md5(_password), null, false, true, null);

   RETURN currval('seq_Usuario');

END;
$$ LANGUAGE plpgsql;

-- Consulta un usuario por su nombre de usuario y clave
-- devuelve los datos del usuario


CREATE OR REPLACE FUNCTION IniciarSesionUsuario(_nombreUsuario varchar, _password varchar)
RETURNS TABLE
  (id integer)
AS
$$
BEGIN
	RETURN QUERY SELECT
	us_id
	FROM usuario
	WHERE us_nombreUsuario=_nombreUsuario AND md5(_password) = us_password AND us_activo = true;
END;
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION IniciarSesionCorreo(_correo varchar, _password varchar)
RETURNS TABLE
  (id integer)
AS
$$
BEGIN
	RETURN QUERY SELECT
	us_id
	FROM usuario
	WHERE us_correo=_correo AND md5(_password) = us_password AND us_activo = true;
END;
$$ LANGUAGE plpgsql;

-- Consulta un usuario por su correo y clave
-- devuelve los datos del usuario
CREATE OR REPLACE FUNCTION ConsultarCorreoPassword(_correo varchar, _password varchar)
RETURNS TABLE
  (contador bigint)
AS
$$
BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_correo=_correo AND  us_password=md5(_password);
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION ConsultarUsuarioPassword(_nombreUsuario varchar, _password varchar)
RETURNS TABLE
  (contador bigint)
AS
$$
BEGIN
  RETURN QUERY SELECT
  count(us_id)
  FROM usuario
  WHERE us_nombreUsuario=_nombreUsuario AND  us_password=md5(_password);
END;
$$ LANGUAGE plpgsql;


--Consulta el usuario por su nombre de usuario sin clave
CREATE OR REPLACE FUNCTION ConsultarNombreUsuario(_nombreUsuario varchar)
RETURNS TABLE
  (contadorUsuario bigint)
AS
$$
BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_nombreUsuario=_nombreUsuario;
END;
$$ LANGUAGE plpgsql;

--Consulta el usuario por su correo sin clave
CREATE OR REPLACE FUNCTION ConsultarCorreoUsuario(_correo varchar)
RETURNS TABLE
  (contadorCorreo bigint)
AS
$$
BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_correo=_correo;
END;
$$ LANGUAGE plpgsql;


/*UPDATES*/


--Cambia la contraseña del usuario, recibe el correo y la nueva contraseña

CREATE OR REPLACE FUNCTION CambiarPassword(_correo varchar, _password varchar)
RETURNS void
AS $$
BEGIN
  
  UPDATE usuario SET us_password = md5(_password)
  WHERE us_correo = _correo;

END;
$$ LANGUAGE plpgsql;


/**
Procedimientos del Modulo_6
Autores:
  Giselle Mingue 
  Minerva Morales
**/

/*INSERT*/
-- Inserta el Partido
-- devuelve el id del partido

CREATE OR REPLACE FUNCTION AgregarPartido
(_fecha VARCHAR(25), _horaInicio VARCHAR(25), _arbitro VARCHAR(30),
 _equipo1 integer, _equipo2 integer, _estadio integer)
RETURNS integer AS
$$
BEGIN

   INSERT INTO PARTIDO(pa_id, pa_fecha, 
    pa_horaInicio, pa_arbitro, pa_status, pa_eq1_id, pa_eq2_id, pa_es_id) VALUES
    (nextval('seq_Partido'), _fecha, _horaInicio, _arbitro,
     true, _equipo1, _equipo2, _estadio);

   RETURN currval('seq_Partido');

END;
$$ LANGUAGE plpgsql;

-- Consulta un partido por su id
-- devuelve los datos del partido
CREATE OR REPLACE FUNCTION ConsultarPartido(_idPartido integer)
RETURNS TABLE
  (id integer,
   fecha varchar(25),
   horaInicio varchar(25),
   arbitro varchar,
   equipo1 integer,
   equipo2 integer,
   estadio integer)
AS
$$
BEGIN
	RETURN QUERY SELECT
	pa_id, pa_fecha, pa_horaInicio, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id
	FROM Partido
	WHERE pa_id=_idPartido;
END;
$$ LANGUAGE plpgsql;

--Consulta de todos los partidos 
--devuelve una lista de todos los partidos
CREATE OR REPLACE FUNCTION ConsultarPartidos()
RETURNS TABLE
  (id integer,
   fecha varchar(25),
   horaInicio varchar(25),
   arbitro varchar,
   equipo1 integer,
   equipo2 integer,
   estadio integer)
AS
$$
BEGIN
	RETURN QUERY SELECT
	pa_id, pa_fecha, pa_horaInicio, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id
	FROM Partido;
END;
$$ LANGUAGE plpgsql;


--Consulta si un estadio esta ocupado en un fecha 
--devuelve  0 o 1 si esta ocupado
CREATE OR REPLACE FUNCTION ConsultarDisponibilidadEstadio(_fecha varchar(25), _horaInicio varchar(25), _estadio int)
RETURNS INTEGER
AS
$$
DECLARE 
count integer;
BEGIN
	 count:= (SELECT
	COUNT(*) FROM Partido
	WHERE pa_fecha=_fecha and pa_horaInicio= _horaInicio and pa_es_id= _estadio);
    RETURN count;
     
END;
$$ LANGUAGE plpgsql;


--Modifica los datos de un partido
--devuelve el id del partido moficado
CREATE OR REPLACE FUNCTION ModificarPartido
(_idPartido integer, _fecha VARCHAR(25), _horaInicio VARCHAR(25), _arbitro VARCHAR(30),
 _equipo1 integer, _equipo2 integer, _estadio integer)
RETURNS integer AS
$$
BEGIN

   UPDATE PARTIDO SET pa_fecha= _fecha, 
    pa_horaInicio= _horaInicio,  pa_arbitro= _arbitro, pa_eq1_id =_equipo1,
    pa_eq2_id =_equipo2, pa_es_id = _estadio
	WHERE (pa_id = _idPartido);
   RETURN currval('seq_Partido');

END;
$$ LANGUAGE plpgsql;

--Registra una alineacion a un partido
--devuelve el id de la alineacion creada
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

--Consultar una alineacion por el id del partido y el equipo
--retorna la lista de todos los jugadores de la alineacion 
CREATE OR REPLACE FUNCTION ConsultarAlineacion(idPartido integer, idEquipo integer)
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
	WHERE al_pa_id = idPartido and al_eq_id = idEquipo;
END;
$$ LANGUAGE plpgsql;

--Consultar un jugador dentro de la alineacion
--retorna los datos de la alineacion de un jugador en especifico
CREATE OR REPLACE FUNCTION ConsultarJugadorAlineacion(idPartido integer, idEquipo integer, idJugador integer)
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
	WHERE al_pa_id = idPartido and al_eq_id = idEquipo and al_ju_id= idJugador;
END;
$$ LANGUAGE plpgsql;

--Modificar la alineacion de los jugadores
--retorn el id de la alineacion modificada
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

--Limpiar las tablas despues de las PU
CREATE OR REPLACE FUNCTION CleanPU_Partido(_idPartido integer)
RETURNS VOID
AS
$$
BEGIN
	DELETE FROM Partido WHERE pa_id= _idPartido;
END;
$$ LANGUAGE plpgsql;


