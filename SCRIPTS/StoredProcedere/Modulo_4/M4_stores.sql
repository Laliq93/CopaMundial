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


  CREATE OR REPLACE FUNCTION m4_agregar_equipo
( descripcionES VARCHAR(100), descripcionEN VARCHAR(100), 
 grupo VARCHAR(1), id_pais VARCHAR(3)) 
RETURNS void AS
$$
ultimo
BEGIN
	
	ultimo = SELECT max (i18n_id) FROM i18n_equipo

	INSERT INTO I18N_EQUIPO ( i18n_pk, i18n_id, i18n_idioma, i18n_mensaje) VALUES
    ( nextval('seq_equipo'), ultimo+1 , 'en', descripcionEN );

    INSERT INTO I18N_EQUIPO ( i18n_pk, i18n_id, i18n_idioma, i18n_mensaje) VALUES
    ( nextval('seq_equipo'), ultimo+1 , 'es', descripcionES );

   INSERT INTO equipo ( eq_id, eq_i18n_descripcion, eq_status,
   	eq_grupo, eq_pa_id, eq_habilitado) VALUES
    ( nextval('seq_equipo'), ultimo+1 , true, grupo, id_pais, false);

END;
$$ LANGUAGE plpgsql;
*/



  CREATE OR REPLACE FUNCTION m4_busca_equipo_iso
(id_pais VARCHAR(3), idioma VARCHAR(2)) 
RETURNS void AS
$$
BEGIN
	
	Select pa_iso, (select i18n_mensaje from pais, i18n_equipo
					where i18n_idioma = idioma and i18n_id = pa_i18n_nombre 
					and pa_iso = id_pais) as nombre, 
	i18n_mensaje as Descripcion , eq_grupo, eq_status
	from equipo, pais, i18n_equipo
	where i18n_idioma = idioma and i18n_id = eq_i18n_descripcion and pa_iso = id_pais 
	and pa_iso = eq_pa_id

END;
$$ LANGUAGE plpgsql;
*/
