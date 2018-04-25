/**
Procedimientos del Modulo_1 de autoregistro, inicio de sesión, recuperación de contraseña y home
Autores:
  Sabina Quiroga 
  Laura Quiñones
  Oswaldo Bracho
**/

/*INSERT*/
-- Inserta el Usuario
-- devuelve el id del usuario
CREATE OR REPLACE FUNCTION InsertarUsuario
(_nombreUsuario VARCHAR(20), _nombre VARCHAR(30),
 _apellido VARCHAR(30), _fechaNacimiento date,
_correo VARCHAR(30),  _genero VARCHAR(1),
 _clave VARCHAR(20), _foto VARCHAR(100))
RETURNS integer AS
$$
BEGIN

   INSERT INTO usuario VALUES
    (nextval('seq_Usuario'), _nombreUsuario, _nombre, _apellido, _fechaNacimiento, _correo, _genero, _clave, _foto, false);

   RETURN currval('seq_Usuario');

END;
$$ LANGUAGE plpgsql;

-- Consulta un usuario por su nombre de usuario y clave
-- devuelve los datos del usuario
CREATE OR REPLACE FUNCTION ConsultarNombreUsuario(_nombreUsuario varchar, _clave varchar)
RETURNS TABLE
  (id integer,
   nombreUsuario varchar,
   nombre varchar,
   apellido varchar,
   fechaNacimiento date,
   correo varchar,
   genero varchar,
   foto varchar)
AS
$$
BEGIN
	RETURN QUERY SELECT
	us_id, us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_foto
	FROM usuario
	WHERE us_nombreusuario=_nombreUsuario AND _clave = us_password AND us_validacion=true;
END;
$$ LANGUAGE plpgsql;

-- Consulta un usuario por su correo y clave
-- devuelve los datos del usuario
CREATE OR REPLACE FUNCTION ConsultarUsuarioCorreo(_correo varchar, _clave varchar)
RETURNS TABLE
  (id integer,
   nombreUsuario varchar,
   nombre varchar,
   apellido varchar,
   fechaNacimiento date,
   correo varchar,
   genero varchar,
   foto varchar)
AS
$$
BEGIN
	RETURN QUERY SELECT
	us_id, us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_foto
	FROM usuario
	WHERE us_correo=_correo AND  us_password=_clave  AND us_validacion= true;
END;
$$ LANGUAGE plpgsql;


--Consulta el usuario por su nombre de usuario sin clave
CREATE OR REPLACE FUNCTION ConsultarSoloNombreUsuario(_nombreUsuario varchar)
RETURNS TABLE
  (id integer,
   nombreUsuario varchar,
   nombre varchar,
   apellido varchar,
   fechaNacimiento date,
   correo varchar,
   genero varchar,
   foto varchar,
   validacion boolean)
AS
$$
BEGIN
	RETURN QUERY SELECT
	us_id, us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_foto, us_validacion
	FROM usuario
	WHERE us_nombreUsuario=_nombreUsuario;
END;
$$ LANGUAGE plpgsql;

--Consulta el usuario por su id de usuario sin clave
CREATE OR REPLACE FUNCTION ConsultarUsuarioId(_id integer)
RETURNS TABLE
  (nombreUsuario varchar,
   nombre varchar,
   apellido varchar,
   fechaNacimiento date,
   correo varchar,
   genero varchar,
   foto varchar)
AS
$$
BEGIN
	RETURN QUERY SELECT
	us_nombreUsuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_foto
	FROM usuario
	WHERE us_id=_id;
END;
$$ LANGUAGE plpgsql;

--Recupera la contrasena de un usuario con su correo
-- devuelve la clave del usuario
CREATE OR REPLACE FUNCTION RecuperarContrasena(_correo varchar)
RETURNS TABLE(clave varchar)
AS $$
DECLARE clave VARCHAR(20);
BEGIN

	RETURN QUERY SELECT
  us_password
	FROM usuario WHERE us_email = _correo AND us_validacion=true;

END;
$$ LANGUAGE plpgsql;

/*UPDATES*/

--Valida un usuario que no este validado
CREATE OR REPLACE FUNCTION ValidarUsuario(_correo varchar, _id integer)
RETURNS void AS
$$
BEGIN
	UPDATE usuario SET us_validacion=true
	WHERE us_correo=_correo AND us_id = _id;
END;
$$ LANGUAGE plpgsql;