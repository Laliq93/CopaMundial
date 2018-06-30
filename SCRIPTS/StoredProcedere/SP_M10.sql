CREATE OR REPLACE FUNCTION public.cambiarcorreousuario(
	_id integer,
	_correo character varying)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN
	UPDATE usuario SET us_correo = _correo WHERE us_id = _id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.cambiarpasswordusuario(
	_id integer,
	_clave character varying)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN
	UPDATE usuario SET us_password = md5(_clave) WHERE us_id = _id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.consultarusuarioid(
	_id integer)
    RETURNS TABLE(idusuario integer, nombreusuario character varying, nombre character varying, apellido character varying, fechanacimiento date, correo character varying, genero character varying, foto character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	us_id, us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_fotoPath
	FROM usuario
	WHERE us_id=_id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.crearusuarioadministrador(
	_nombreusuario character varying,
	_nombre character varying,
	_apellido character varying,
	_fechanacimiento date,
	_correo character varying,
	_genero character varying,
	_password character varying)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN

INSERT INTO public.usuario(
	us_id, us_nombreusuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_password, us_esadmin)
	VALUES (nextval('seq_Usuario'), _nombreUsuario, _nombre, _apellido, _fechaNacimiento, _correo, _genero, md5(_password), true);

   RETURN currval('seq_Usuario');

END;

$BODY$;

CREATE OR REPLACE FUNCTION public.editarperfilusuario(
	_id integer,
	_nombre character varying,
	_apellido character varying,
	_fechanacimiento date,
	_genero character,
	_foto character varying)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
BEGIN
	UPDATE usuario SET us_nombre = _nombre, us_apellido = _apellido, us_fechaNacimiento = _fechaNacimiento, us_genero = _genero, us_fotoPath = _foto
	WHERE us_id = _id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.gestionaractivocuentausuario(
	_id integer,
	_activo boolean)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$

BEGIN
	UPDATE usuario SET us_activo = _activo WHERE us_id = _id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerusuario(
	_id integer)
    RETURNS TABLE(nombreusuario character varying, nombre character varying, apellido character varying, fechanacimiento date, correo character varying, genero character varying, clave character varying, foto character varying, esadmin boolean, activo boolean) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
		us_nombreusuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, 
		us_password, us_fotopath, us_esadmin, us_activo
	FROM usuario
	WHERE us_id=_id;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.obtenerusuariosactivos(
	)
    RETURNS TABLE(idusuario integer, nombreusuario character varying, nombre character varying, apellido character varying, fechanacimiento date, correo character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	us_id, us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo
	FROM usuario
	WHERE us_activo = true AND us_esAdmin = false order by us_nombre;
END;

$BODY$;


CREATE OR REPLACE FUNCTION public.obtenerusuariosnoactivos(
	)
    RETURNS TABLE(idusuario integer, nombreusuario character varying, nombre character varying, apellido character varying, fechanacimiento date, correo character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	us_id, us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo
	FROM usuario
	WHERE us_activo = false AND us_esAdmin = false order by us_nombre;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.verificarclaveusuario(
	_clave character varying,
	_idusuario integer)
    RETURNS TABLE(cantidadclave bigint) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_password = md5(_clave) AND us_id = _idUsuario;
END;

$BODY$;

CREATE OR REPLACE FUNCTION public.verificarcorreoexiste(
	correo character varying)
    RETURNS TABLE(cantidadcorreo bigint) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$

BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_correo = correo;
END;

$BODY$;
