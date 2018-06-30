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
	RETURN QUERY SELECT pa_id, to_char(pa_horainicio, 'DD-MM-YYYY'),
	pa_eq1_id, pa_eq2_id FROM partido WHERE pa_horainicio > _fecha ORDER BY pa_horainicio;
END;
$$ LANGUAGE plpgsql;
------------------------------------CONSULTAR PARTIDOS FINALIZADOS-----------------------
CREATE OR REPLACE FUNCTION ConsultarLogroPartidoFinalizados(
	_fecha timestamp with time zone)
    RETURNS TABLE(idpartido integer, fechapartido text, equipo1 integer, equipo2 integer) 
AS 
$$
BEGIN
	RETURN QUERY SELECT pa_id, to_char(pa_horainicio, 'DD-MM-YYYY'),
	pa_eq1_id, pa_eq2_id FROM partido WHERE pa_horainicio < _fecha ORDER BY pa_horainicio;
END;
$$ LANGUAGE plpgsql;

----------------------------------CONSULTAR LOGRO PARTIDO--------------------------------
CREATE OR REPLACE FUNCTION ConsultarLogroPartidoPorId(_idPartido integer)
    RETURNS TABLE(idpartido integer, fechapartido text, equipo1 integer, equipo2 integer) 
AS 
$$
BEGIN
	RETURN QUERY SELECT pa_id, to_char(pa_horainicio, 'DD-MM-YYYY'),
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

