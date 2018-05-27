CREATE OR REPLACE FUNCTION m4_agregar_equipo
( descripcion VARCHAR(100), 
 grupo VARCHAR(1), id_pais INT) 
RETURNS void AS
$$
BEGIN

   INSERT INTO equipo ( eq_id, eq_descripcion, eq_grupo, eq_pa_id ) VALUES
    ( nextval('seq_equipo'), descripcion, grupo, id_pais );

END;
$$ LANGUAGE plpgsql;