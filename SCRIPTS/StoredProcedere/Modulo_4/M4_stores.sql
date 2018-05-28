/*CREATE OR REPLACE FUNCTION m4_agregar_equipo
( descripcionES VARCHAR(100), descripcionEN VARCHAR(100), 
 grupo VARCHAR(1), id_pais VARCHAR(3)) 
RETURNS void AS
$$
BEGIN

   INSERT INTO equipo ( eq_id, eq_descripcion, eq_grupo, eq_pa_id ) VALUES
    ( nextval('seq_equipo'), descripcion, grupo, id_pais );

END;
$$ LANGUAGE plpgsql;
*/


CREATE OR REPLACE FUNCTION m4_traer_pais(idioma VARCHAR(2))
RETURNS TABLE (iso VARCHAR(3), nombre text)

AS $$
DECLARE
   var_r    record;
BEGIN
	FOR var_r IN(SELECT pa_iso, pa_i18n_nombre, i18n_mensaje
		FROM PAIS, I18N_EQUIPO
		WHERE pa_i18n_nombre = i18n_id and i18n_idioma = idioma)

	LOOP

	iso = pa_iso;
	nombre = i18n_idioma;

	RETURN NEXT;
   END LOOP;
END; $$
  LANGUAGE plpgsql;