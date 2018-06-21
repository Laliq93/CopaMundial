--===========================================STORED PROCEDURES===============================================
--=====================DROPS===========
DROP FUNCTION IF EXISTS AgregarTipoLogro;
DROP FUNCTION IF EXISTS ConsultarTiposLogros;
DROP FUNCTION IF EXISTS ModificarTipoLogro;

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

