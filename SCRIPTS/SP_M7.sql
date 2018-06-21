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
DROP FUNCTION IF EXISTS ConsultarLogrosPentientes;



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
---------------------------CONSULTAR LOGROS PENDIENTES DE UN PARTIDO----------------
/*
	Consulta una lista de logros sin resultado
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
