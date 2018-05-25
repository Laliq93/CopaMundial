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

-- Consulta un usuario por su nombre de usuario y clave
-- devuelve los datos del usuario
CREATE OR REPLACE FUNCTION ConsultarUsuarioPassword(_nombreUsuario varchar, _password varchar)
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
	count(us_id)
	FROM usuario
	WHERE us_nombreusuario=_nombreUsuario AND md5(_password) = us_password;
END;
$$ LANGUAGE plpgsql;

-- Consulta un usuario por su correo y clave
-- devuelve los datos del usuario
CREATE OR REPLACE FUNCTION ConsultarCorreoPassword(_correo varchar, _password varchar)
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
	count(us_id)
	FROM usuario
	WHERE us_correo=_correo AND  us_password=md5(_password);
END;
$$ LANGUAGE plpgsql;


--Consulta el usuario por su nombre de usuario sin clave
CREATE OR REPLACE FUNCTION ConsultarNombreUsuario(_nombreUsuario varchar)
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
	count(us_id)
	FROM usuario
	WHERE us_nombreUsuario=_nombreUsuario;
END;
$$ LANGUAGE plpgsql;

--Consulta el usuario por su correo sin clave
CREATE OR REPLACE FUNCTION ConsultarCorreoUsuario(_correo varchar)
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
	count(us_id)
	FROM usuario
	WHERE us_correo=_correo;
END;
$$ LANGUAGE plpgsql;


/*UPDATES*/


--Cambia la contraseña del usuario, recibe el correo y la nueva contraseña

CREATE OR REPLACE FUNCTION CambiarPassword(_correo varchar, _password varchar)
RETURNS BOOLEAN
AS $$
BEGIN
  
  UPDATE usuario SET us_password = md5(_password)
  WHERE us_correo = _correo;

END;
$$ LANGUAGE plpgsql;