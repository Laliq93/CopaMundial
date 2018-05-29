
/* stored procedure que devuelve los paises filtrado por: 
idioma ( puede ser 'es' para español o 'en' para ingles)
Retorna:
iso (3 letras identificativas de cada pais)
nombre (nombre de del pais que corresponde al is)
pk (Es el identificativo de la tabla i18n_equipo)
id ( valor que junto con el idioma retorna el mensaje en el idioma deseado )*/
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

/* stored procedure para la creacion de un equipo recibe por parametro
descripcionES (descripcion en español que corresponde con el pais a crear)
descripcionEN (descripcion en ingles que corresponde con el pais a crear)
grupo (letra identificativa al que pertenece el equipo)
id_pais (son las letras identificativas (iso) del nombre pais) */

  CREATE OR REPLACE FUNCTION m4_agregar_equipo
( descripcionES VARCHAR(100), descripcionEN VARCHAR(100), 
 grupo VARCHAR(1), id_pais VARCHAR(3)) 
RETURNS void AS
$$
DECLARE
ultimo integer;
BEGIN
	
	ultimo = (SELECT max (i18n_id) FROM i18n_equipo);

	INSERT INTO I18N_EQUIPO ( i18n_pk, i18n_id, i18n_idioma, i18n_mensaje) VALUES
    ( nextval('seq_i18N_equipo'), ultimo+1 , 'en', descripcionEN );

    INSERT INTO I18N_EQUIPO ( i18n_pk, i18n_id, i18n_idioma, i18n_mensaje) VALUES
    ( nextval('seq_i18N_equipo'), ultimo+1 , 'es', descripcionES );

   INSERT INTO equipo ( eq_id, eq_i18n_descripcion, eq_status,
   	eq_grupo, eq_pa_id, eq_habilitado) VALUES
    ( nextval('seq_equipo'), ultimo+1 , true, grupo, id_pais, false);

END;
$$ LANGUAGE plpgsql;


/* stored procedure que devuelve los paises filtrado por:
ISO (3 letras identificativas de cada pais)
Retorna:
ISO (3 letras identificativas de cada pais)
nombreES (nombre en español de del pais que corresponde al iso)
nombreEN (nombre en ingles de del pais que corresponde al iso)
descripcionES (descripcion en español que corresponde con el pais a crear)
descripcionEN (descripcion en ingles que corresponde con el pais a crear)
grupo (letra identificativa al que pertenece el equipo)
status ( es un boolean para determinar si el equipo esta participando o no)
pk (Es el identificativo de la tabla i18n_equipo)
id ( valor que junto con el idioma retorna el mensaje en el idioma deseado )*/

CREATE OR REPLACE FUNCTION m4_busca_equipo_iso
(id_pais VARCHAR(3)) 
RETURNS TABLE(iso VARCHAR(3), nombreES text, nombreEN text, descripcionES VARCHAR(100),
 descripcionEN VARCHAR(100), grupo VARCHAR(1), status boolean, id integer, pk integer)
AS
$$
DECLARE
   var_r record;
BEGIN
	
	FOR var_r IN ( Select eq_pa_id, (select i18n_mensaje from i18n_equipo
					where i18n_idioma = 'es' and i18n_id = p.pa_i18n_nombre 
					and pa_iso = id_pais and pa_iso = eq_pa_id) as NombreES,
				(select i18n_mensaje from i18n_equipo
					where i18n_idioma = 'en' and i18n_id = p.pa_i18n_nombre 
					and pa_iso = id_pais and pa_iso = eq_pa_id) as NombreEn, 
				(Select i18n_mensaje from i18n_equipo
				where i18n_idioma = 'es' and i18n_id = eq_i18n_descripcion 
				and pa_iso = id_pais and pa_iso = eq_pa_id) as DescripcionEs, 
				(Select i18n_mensaje from i18n_equipo
				where i18n_idioma = 'en' and i18n_id = eq_i18n_descripcion 
				and pa_iso = id_pais and pa_iso = eq_pa_id) as DescripcionEn, 
	eq_grupo, eq_status, e.eq_i18n_descripcion as i18n_id, p.pa_i18n_nombre as i18n_pk
	from equipo e
	join pais p on eq_pa_id = pa_iso
	where eq_pa_id = id_pais and eq_habilitado = true )

	LOOP

	iso = var_r.eq_pa_id;
	nombreES = var_r.NombreES;
	nombreEN = var_r.NombreEN;
	descripcionEn = var_r.DescripcionEn;
	descripcionES = var_r.DescripcionEs;
	grupo = var_r.eq_grupo;
	status = var_r.eq_status;
	id = var_r.i18n_id;
	pk = var_r.i18n_pk;

	RETURN NEXT;
   END LOOP;

END;
$$ LANGUAGE plpgsql;


/* stored procedure que modifica equipo se envia por parametro:
descripcionES (descripcion en español que corresponde con el pais a crear)
descripcionEN (descripcion en ingles que corresponde con el pais a crear)
grupo (letra identificativa al que pertenece el equipo)
ISO (3 letras identificativas de cada pais)
status ( es un boolean para determinar si el equipo esta participando o no)
habilitado ( atributo para saber si esta correctamente agregado )*/
CREATE OR REPLACE FUNCTION m4_modificar_equipo
( descripcionES VARCHAR(100), descripcionEN VARCHAR(100), 
grupo VARCHAR(1), id_pais VARCHAR(3), status boolean, habilitado boolean) 
RETURNS void AS
$$
DECLARE
id_i18n integer;


BEGIN

  id_i18n = (select eq_i18n_descripcion from equipo where eq_pa_id = id_pais);

  UPDATE I18N_EQUIPO SET i18n_mensaje = descripcionEN
  WHERE ( i18n_id = id_i18n and i18n_idioma = 'en');

  UPDATE I18N_EQUIPO SET i18n_mensaje = descripcionES
  WHERE ( i18n_id = id_i18n and i18n_idioma = 'es');

  UPDATE equipo SET eq_status = status, eq_grupo = grupo, eq_habilitado = habilitado
  WHERE (eq_pa_id = id_pais);


END;
$$ LANGUAGE plpgsql;


/* stored procedure que devuelve los equipos agregados filtrado por:
idioma ( puede ser 'es' para español o 'en' para ingles)
Retorna:
ISO (3 letras identificativas de cada pais)
nombre (nombre del pais que corresponde al iso)
descripcion (descripcion que corresponde con el pais a crear)
grupo (letra identificativa al que pertenece el equipo)
status ( es un boolean para determinar si el equipo esta participando o no)
pk (Es el identificativo de la tabla i18n_equipo)
id ( valor que junto con el idioma retorna el mensaje en el idioma deseado )
habilitado ( atributo para saber si esta correctamente agregado )*/

CREATE OR REPLACE FUNCTION m4_busca_equipos(idioma VARCHAR(2) ) 
RETURNS TABLE(iso VARCHAR(3), nombre text, descripcion VARCHAR(100), grupo VARCHAR(1), 
	status boolean, id integer, pk integer, habilitado boolean)
AS $$
DECLARE
   var_r record;
BEGIN
	
	FOR var_r IN ( SELECT e.eq_status, e.eq_grupo, e.eq_habilitado, m.i18n_id as idioma_id, m.i18n_idioma as idioma_idioma, m.i18n_mensaje as idioma_mensaje,
pais.pa_iso, pais.idioma_id as pais_idioma_id, pais.idioma_idioma as pais_idioma_idioma, pais.idioma_mensaje as pais_idioma_mensaje
FROM equipo as e
JOIN i18n_equipo m ON e.eq_i18n_descripcion = m.i18n_id AND m.i18n_idioma = idioma
JOIN (SELECT pa.pa_iso, meq.i18n_id as idioma_id, meq.i18n_idioma as idioma_idioma, meq.i18n_mensaje as idioma_mensaje
from pais as pa JOIN i18n_equipo meq ON pa.pa_i18n_nombre = meq.i18n_id AND meq.i18n_idioma = idioma) as pais ON pais.pa_iso = e.eq_pa_id
Where eq_habilitado = true )

	LOOP

	status = var_r.eq_status;	
	grupo = var_r.eq_grupo;
	habilitado = var_r.eq_habilitado;
	descripcion = var_r.idioma_mensaje;
	nombre = var_r.pais_idioma_mensaje;
	iso = var_r.pa_iso;
	id = var_r.pais_idioma_id;
	pk = var_r.idioma_id;


	RETURN NEXT;
   END LOOP;

END;
$$ LANGUAGE plpgsql;