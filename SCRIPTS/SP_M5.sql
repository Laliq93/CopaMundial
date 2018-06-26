-- Agrega al jugador en la base de datos

CREATE OR REPLACE FUNCTION insertarJugador
(_nombre varchar,
 _apellido varchar,
 _fechaNacimiento date,
 _lugarNacimiento varchar, 
 _peso decimal(5,2),
 _altura decimal(5,2), 
 _posicion varchar, 
 _numero decimal(2),
 _equipo varchar)
RETURNS integer AS
$$
BEGIN
    INSERT INTO jugador
    VALUES
        (nextval('seq_Jugador'), _nombre, _apellido, _fechaNacimiento, _lugarNacimiento, _peso, _altura, 
            _posicion, _numero,  _equipo, false, true);
    RETURN currval('seq_Jugador');
END;
$$ LANGUAGE plpgsql;


-- edita todos los campos de jugador 

CREATE OR REPLACE FUNCTION editarJugador(
    _id integer,
    _nombre varchar,
    _apellido varchar,
    _fechaNacimiento date,
    _lugarNacimiento varchar,  
    _peso decimal(5,2),
    _altura decimal(5,2), 
    _posicion varchar, 
    _numero decimal(2),
    _capitan boolean)

RETURNS void
AS $$
BEGIN
    UPDATE jugador SET ju_nombre = _nombre, ju_apellido = _apellido, ju_fechaNacimiento = _fechaNacimiento, 
    ju_lugarNacimiento = _lugarNacimiento, ju_peso = _peso, ju_altura = _altura, ju_posicion = _posicion,
    ju_numero = _numero, ju_capitan = _capitan
    WHERE ju_id = _id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadorId(_id integer)
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal, 
    capitan boolean, equipo varchar)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_capitan, ju_equipo
    FROM jugador
    WHERE ju_id=_id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadores()
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal,
    equipo varchar, capitan boolean)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_equipo, ju_capitan
    FROM jugador;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadorNombre(_nombre varchar)
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal,
    capitan boolean, equipo varchar)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_capitan, ju_equipo
    FROM jugador
    WHERE ju_nombre = _nombre;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadorPosicion(_posicion varchar)
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal,
    capitan boolean, equipo varchar)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_capitan, ju_equipo
    FROM jugador
    WHERE ju_posicion = _posicion;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION desactivarJugador(_id integer)
RETURNS void
AS $$
BEGIN
    UPDATE jugador SET ju_activo = false
    WHERE ju_id = _id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION activarJugador(_id integer)
RETURNS void
AS $$
BEGIN
    UPDATE jugador SET ju_activo = true
    WHERE ju_id = _id;
END;
$$ LANGUAGE plpgsql;