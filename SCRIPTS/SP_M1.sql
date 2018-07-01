----SP_M1
-- Camilo Perez
---------
DROP FUNCTION IF EXISTS AgregarUsuario(
	_nombreUsuario VARCHAR(20), 
	_nombre VARCHAR(30),
 	_apellido VARCHAR(30), 
 	_fechaNacimiento VARCHAR(30),
	_correo VARCHAR(30),  
	_genero VARCHAR(1),
 	_password VARCHAR(20)
 );

CREATE OR REPLACE FUNCTION AgregarUsuario(
	_nombreUsuario VARCHAR(20), 
	_nombre VARCHAR(30),
 	_apellido VARCHAR(30), 
 	_fechaNacimiento VARCHAR(30),
	_correo VARCHAR(30),  
	_genero VARCHAR(1),
 	_password VARCHAR(20)
 	) RETURNS integer
	LANGUAGE 'plpgsql'

AS $BODY$

BEGIN

   INSERT INTO usuario VALUES
    (nextval('seq_Usuario'), _nombreUsuario, _nombre, _apellido, to_date(_fechaNacimiento, 'YYYY-MM-DD'), _correo, _genero, md5(_password), null, false, true, null);

   RETURN currval('seq_Usuario');

END;
$BODY$;
---------
----FIN SP_M1