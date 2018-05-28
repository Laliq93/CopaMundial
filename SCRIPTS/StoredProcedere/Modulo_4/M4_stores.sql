


CREATE OR REPLACE FUNCTION m4_traer_pais(idioma VARCHAR(2))
RETURNS TABLE (iso VARCHAR(3), nombre text, pk integer, id integer)

AS $$
DECLARE
   var_r    record;
BEGIN
	FOR var_r IN(SELECT pa_iso, pa_i18n_nombre, i18n_mensaje, i18n_pk, i18n_id
		FROM PAIS, I18N_EQUIPO
		WHERE pa_i18n_nombre = i18n_id and i18n_idioma = idioma)

	LOOP

	iso = var_r.pa_iso;
	nombre = var_r.i18n_mensaje;
	pk = var_r.i18n_pk;
	id = var_r.i18n_id;
	


	RETURN NEXT;
   END LOOP;
END; $$
  LANGUAGE plpgsql;


  CREATE OR REPLACE FUNCTION m4_agregar_equipo
( descripcionES VARCHAR(100), descripcionEN VARCHAR(100), 
 grupo VARCHAR(1), id_pais VARCHAR(3)) 
RETURNS void AS
$$
DECLARE
ultimo record;
BEGIN
	
	ultimo = (SELECT max (i18n_id) FROM i18n_equipo);

	INSERT INTO I18N_EQUIPO ( i18n_pk, i18n_id, i18n_idioma, i18n_mensaje) VALUES
    ( nextval('seq_equipo'), ultimo+1 , 'en', descripcionEN );

    INSERT INTO I18N_EQUIPO ( i18n_pk, i18n_id, i18n_idioma, i18n_mensaje) VALUES
    ( nextval('seq_equipo'), ultimo+1 , 'es', descripcionES );

   INSERT INTO equipo ( eq_id, eq_i18n_descripcion, eq_status,
   	eq_grupo, eq_pa_id, eq_habilitado) VALUES
    ( nextval('seq_equipo'), ultimo+1 , true, grupo, id_pais, false);

END;
$$ LANGUAGE plpgsql;




  CREATE OR REPLACE FUNCTION m4_busca_equipo_iso
(id_pais VARCHAR(3)) 
RETURNS RETURNS TABLE(iso VARCHAR(3), nombreES text, nombreEN text, descripcionES VARCHAR(100),
 descripcionEN VARCHAR(100), grupo VARCHAR(1), status boolean, id integer, pk integer)

AS$$
DECLARE
   var_r;
BEGIN
	
	FOR var_r IN ( Select pa_iso, (select i18n_mensaje from pais, i18n_equipo
					where i18n_idioma = 'es' and i18n_id = pa_i18n_nombre 
					and pa_iso = id_pais and pa_iso = eq_pa_id) as NombreES,
				(select i18n_mensaje from pais, i18n_equipo
					where i18n_idioma = 'en' and i18n_id = pa_i18n_nombre 
					and pa_iso = id_pais and pa_iso = eq_pa_id) as NombreEn, 
				(Select i18n_mensaje from equipo, pais, i18n_equipo
				where i18n_idioma = 'es' and i18n_id = eq_i18n_descripcion 
				and pa_iso = id_pais and pa_iso = eq_pa_id) as DescripcionEs, 
				(Select i18n_mensaje from equipo, pais, i18n_equipo
				where i18n_idioma = 'en' and i18n_id = eq_i18n_descripcion 
				and pa_iso = id_pais and pa_iso = eq_pa_id) as DescripcionEn, 
	eq_grupo, eq_status, i18n_id, i18n_pk
	from equipo, pais, i18n_equipo
	where i18n_id = eq_i18n_descripcion and pa_iso = id_pais 
	and pa_iso = eq_pa_id and eq_habilitado = true)

	LOOP

	iso = var_r.pa_iso;
	nombreES = var_r.NombreES;
	nombreEN = var_r.NombreEN;
	descripcionEn = var_r.DescripcionEn;
	descripcionES = var_r.DescripcionEs;
	grupo = var_r.eq_grupo;
	status = var_r.eq_status
	id = var_r.i18n_id;
	pk = var_r.i18n_pk;

	RETURN NEXT;
   END LOOP;

END;
$$ LANGUAGE plpgsql;




CREATE OR REPLACE FUNCTION m4_modificar_equipo
( descripcionES VARCHAR(100), descripcionEN VARCHAR(100), 
 grupo VARCHAR(1), id_pais VARCHAR(3), status boolean, grupo VARCHAR(1),
 habilitado boolean) 
RETURNS void AS
$$
BEGIN
	
	UPDATE I18N_EQUIPO SET (i18n_mensaje = descripcionEN)
    WHERE (eq_i18n_descripcion = i18n_id and pa_iso = eq_pa_id and eq_pa_id = id_pais
    and i18n_idioma = 'en');

    UPDATE I18N_EQUIPO SET (i18n_mensaje = descripcionES)
    WHERE (eq_i18n_descripcion = i18n_id and pa_iso = eq_pa_id and eq_pa_id = id_pais
    and i18n_idioma = 'es');

    UPDATE equipo SET (eq_grupo = grupo and eq_status = status and eq_grupo = grupo 
    and eq_habilitado = habilitado )
    WHERE (pa_iso = eq_pa_id and eq_pa_id = id_pais);


END;
$$ LANGUAGE plpgsql;


/*CREATE OR REPLACE FUNCTION m4_busca_equipos() 
RETURNS RETURNS TABLE(iso VARCHAR(3), nombreES text, nombreEN text, descripcionES VARCHAR(100),
 descripcionEN VARCHAR(100), grupo VARCHAR(1), status boolean, id integer, pk integer)

AS$$
DECLARE
   var_r;
BEGIN
	
	FOR var_r IN ( Select pa_iso, (select i18n_mensaje from pais, i18n_equipo
					where i18n_idioma = 'es' and i18n_id = pa_i18n_nombre 
					and pa_iso = eq_pa_id) as NombreES,
				(select i18n_mensaje from pais, i18n_equipo
					where i18n_idioma = 'en' and i18n_id = pa_i18n_nombre
					and pa_iso = eq_pa_id) as NombreEN, 
				(Select i18n_mensaje from equipo, pais, i18n_equipo
				where i18n_idioma = 'es' and i18n_id = eq_i18n_descripcion 
				and pa_iso = eq_pa_id) as DescripcionEs, 
				(Select i18n_mensaje from equipo, pais, i18n_equipo
				where i18n_idioma = 'en' and i18n_id = eq_i18n_descripcion 
				and pa_iso = eq_pa_id) as DescripcionEn, 
	eq_grupo, eq_status, i18n_id, i18n_pk
	from equipo, pais, i18n_equipo
	where i18n_id = eq_i18n_descripcion and pa_iso = id_pais 
	and pa_iso = eq_pa_id and eq_habilitado = true)

	LOOP

	iso = var_r.pa_iso;	
	nombreES = var_r.NombreES;
	nombreEN = var_r.NombreEN;
	descripcionEn = var_r.DescripcionEn;
	descripcionES = var_r.DescripcionEs;
	grupo = var_r.eq_grupo;
	status = var_r.eq_status
	id = var_r.i18n_id;
	pk = var_r.i18n_pk;

	RETURN NEXT;
   END LOOP;

END;
$$ LANGUAGE plpgsql; */