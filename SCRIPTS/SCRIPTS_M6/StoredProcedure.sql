/**
Procedimientos del Modulo_6 Agregar Partido, Consultar Partido, Modificar Partido
Autores:
  Giselle Mingue
  Minerva Morales 
**/
------------------------------------------------------STORE PROCEDURES-------------------
----------------------------AGREGAR PARTIDO--------------------------------------------
CREATE OR REPLACE FUNCTION AgregarPartido
(_fecha date, _horaInicio Time, _arbitro VARCHAR(30),
 _equipo1 integer, _equipo2 integer, _estadio integer)
RETURNS integer AS
$$
BEGIN

   INSERT INTO PARTIDO(pa_id, pa_fecha, 
    pa_horaInicio, pa_arbitro, pa_status, fk_equipo1, fk_equipo2, fk_estadio) VALUES
    (nextval('seq_Partido'), _fecha, _horaInicio, _arbitro,
     true, _equipo1, _equipo2, _estadio);

   RETURN currval('seq_Partido');

END;
$$ LANGUAGE plpgsql;

---------------------------------CONSULTAR PARTIDO POR ID --------------------------------------------------
CREATE OR REPLACE FUNCTION ConsultarPartido(_idPartido integer)
RETURNS TABLE
  (id integer,
   fecha Date,
   horaInicio Time,
   horaFin Time,
   arbitro varchar,
   equipo1 integer,
   equipo2 integer,
   estadio integer)
AS
$$
BEGIN
	RETURN QUERY SELECT
	pa_id, pa_fecha, pa_horaInicio, pa_horaFin, pa_arbitro, fk_equipo1, fk_equipo2, fk_estadio
	FROM Partido
	WHERE pa_id=_idPartido;
END;
$$ LANGUAGE plpgsql;


-----------------------------------MODIFICAR PARTIDO-------------------------------------------
CREATE OR REPLACE FUNCTION ModificarPartido
(_idPartido integer, _fecha date, _horaInicio Time, _arbitro VARCHAR(30),
 _equipo1 integer, _equipo2 integer, _estadio integer)
RETURNS integer AS
$$
BEGIN

   UPDATE PARTIDO SET pa_fecha= _fecha, 
    pa_horaInicio= _horaInicio,  pa_arbitro= _arbitro, fk_equipo1 =_equipo1,
    fk_equipo2 =_equipo2, fk_estadio = _estadio
	WHERE (pa_id = _idPartido);
   RETURN currval('seq_Partido');

END;
$$ LANGUAGE plpgsql;