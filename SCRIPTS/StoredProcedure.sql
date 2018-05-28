/**
Procedimientos del Modulo_1 de autoregistro, inicio de sesión, recuperación de contraseña y home
Autores:
  Sabina Quiroga 
  Laura Quiñones
**/

/*INSERT*/
-- Inserta el Usuario
-- devuelve el id del usuario
CREATE OR REPLACE FUNCTION AgregarUsuario
(_nombreUsuario VARCHAR(20), _nombre VARCHAR(30),
 _apellido VARCHAR(30), _fechaNacimiento date,
_correo VARCHAR(30),  _genero VARCHAR(1),
 _password VARCHAR(20))
RETURNS integer AS
$$
BEGIN

   INSERT INTO usuario VALUES
    (nextval('seq_Usuario'), _nombreUsuario, _nombre, _apellido, _fechaNacimiento, _correo, _genero, md5(_password), null, false, true, null);

   RETURN currval('seq_Usuario');

END;
$$ LANGUAGE plpgsql;


--inicia sesion con el nombre del usuario y retorna su id
CREATE OR REPLACE FUNCTION IniciarSesionUsuario(_nombreUsuario varchar, _password varchar)
RETURNS TABLE
  (id integer)
AS
$$
BEGIN
	RETURN QUERY SELECT
	us_id
	FROM usuario
	WHERE us_nombreUsuario=_nombreUsuario AND md5(_password) = us_password AND us_activo = true;
END;
$$ LANGUAGE plpgsql;

--inicia sesion con el correo del usuario y retorna su id
CREATE OR REPLACE FUNCTION IniciarSesionCorreo(_correo varchar, _password varchar)
RETURNS TABLE
  (id integer)
AS
$$
BEGIN
	RETURN QUERY SELECT
	us_id
	FROM usuario
	WHERE us_correo=_correo AND md5(_password) = us_password AND us_activo = true;
END;
$$ LANGUAGE plpgsql;

-- Consulta un usuario por su correo y clave
-- devuelve un contador de cuantos registros contiene la bd con esos datos
CREATE OR REPLACE FUNCTION ConsultarCorreoPassword(_correo varchar, _password varchar)
RETURNS TABLE
  (contador bigint)
AS
$$
BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_correo=_correo AND  us_password=md5(_password);
END;
$$ LANGUAGE plpgsql;

-- Consulta un usuario por su correo y clave
-- devuelve un contador de cuantos registros contiene la bd con esos datos
CREATE OR REPLACE FUNCTION ConsultarUsuarioPassword(_nombreUsuario varchar, _password varchar)
RETURNS TABLE
  (contador bigint)
AS
$$
BEGIN
  RETURN QUERY SELECT
  count(us_id)
  FROM usuario
  WHERE us_nombreUsuario=_nombreUsuario AND  us_password=md5(_password);
END;
$$ LANGUAGE plpgsql;


--Consulta el usuario por su nombre de usuario sin clave
CREATE OR REPLACE FUNCTION ConsultarNombreUsuario(_nombreUsuario varchar)
RETURNS TABLE
  (contadorUsuario bigint)
AS
$$
BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_nombreUsuario=_nombreUsuario;
END;
$$ LANGUAGE plpgsql;

--Consulta el usuario por su correo sin clave
CREATE OR REPLACE FUNCTION ConsultarCorreoUsuario(_correo varchar)
RETURNS TABLE
  (contadorCorreo bigint)
AS
$$
BEGIN
	RETURN QUERY SELECT
	count(us_id)
	FROM usuario
	WHERE us_correo=_correo;
END;
$$ LANGUAGE plpgsql;

--Consulta los usuarios activos por el nombre de usuario
CREATE OR REPLACE FUNCTION ConsultarNombreUsuarioActivo(_nombreUsuario varchar)
RETURNS TABLE
  (contador bigint)
AS
$$
BEGIN
  RETURN QUERY SELECT
  count(us_id)
  FROM usuario
  WHERE us_nombreUsuario = _nombreUsuario AND us_activo = true;
END;
$$ LANGUAGE plpgsql;


--Consulta los usuarios activos por el correo
CREATE OR REPLACE FUNCTION ConsultarCorreoActivo(_correo varchar)
RETURNS TABLE
  (contador bigint)
AS
$$
BEGIN
  RETURN QUERY SELECT
  count(us_id)
  FROM usuario
  WHERE us_correo = _correo AND us_activo = true;
END;
$$ LANGUAGE plpgsql;



--Consulta el codigo de recuperacion de contraseña
CREATE OR REPLACE FUNCTION ConsultarToken(_token varchar)
RETURNS TABLE
  (contador bigint)
AS
$$
BEGIN
  RETURN QUERY SELECT
  count(us_id)
  FROM usuario
  WHERE us_token = _token;
END;
$$ LANGUAGE plpgsql;



/*UPDATES*/


--Cambia la contraseña del usuario, recibe el token(o codigo random), e correo y la nueva contraseña

CREATE OR REPLACE FUNCTION CambiarPassword(_token varchar, _correo varchar, _password varchar)
RETURNS void
AS $$
BEGIN
  
  UPDATE usuario SET us_password = md5(_password)
  WHERE us_token = _token AND us_correo = _correo;

END;
$$ LANGUAGE plpgsql;

--setea el token con el codigo generado para la recuperacion de contrasena

CREATE OR REPLACE FUNCTION SetearToken(_token varchar, _correo varchar)
RETURNS void
AS $$
BEGIN
  
  UPDATE usuario SET us_token = _token
  WHERE us_correo = _correo;

END;
$$ LANGUAGE plpgsql;