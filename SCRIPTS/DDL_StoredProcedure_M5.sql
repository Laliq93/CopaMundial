CREATE TABLE JUGADOR
(
    ju_id integer,
    ju_nombre varchar(40) NOT NULL,
    ju_apellido varchar(20) NOT NULL,
    ju_fechaNacimiento date,
    ju_lugarNacimiento varchar(40) NOT NULL,
    ju_peso decimal(5,2) NOT NULL,
    ju_altura decimal(5,2) NOT NULL,
    ju_posicion varchar(20) CHECK (ju_posicion ='PORTERO' OR ju_posicion='LATERAL DERECHO' OR ju_posicion='LATERAL IZQUIERDO' OR ju_posicion='CENTRAL' OR ju_posicion='DEFENSA' OR ju_posicion='DELANTERO' OR ju_posicion='CENTROCAMPISTA'),
    ju_numero decimal(2),
    ju_capitan boolean default false not null,
    ju_activo boolean default true not null,
    ju_equipo varchar(20) NOT NULL,
    CONSTRAINT primaria_jugador PRIMARY KEY (ju_id)
    );

CREATE SEQUENCE SEQ_Jugador
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;

CREATE SEQUENCE SEQ_Equipo
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;

CREATE SEQUENCE SEQ_Pais
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;


-- Agrega al jugador en la base de datos

CREATE OR REPLACE FUNCTION AgregarJugador
(_nombre VARCHAR(40),
 _apellido VARCHAR(20),
 _fechaNacimiento date,
 _lugarNacimiento VARCHAR(40), 
 _peso decimal(5,2),
 _altura decimal(5,2), 
 _posicion varchar(20), 
 _numero decimal(2),
 _equipo integer)
RETURNS integer AS
$$
BEGIN
    INSERT INTO jugador
    VALUES
        (nextval('seq_Jugador'), _nombre, _apellido, _fechaNacimiento, _lugarNacimiento, _peso, _altura, 
            _posicion, _numero, false, true, _equipo);
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
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal, capitan boolean)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero, ju_capitan
    FROM jugador
    WHERE ju_id=_id;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadores()
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero
    FROM jugador;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadorNombre(_nombre varchar)
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero
    FROM jugador
    WHERE ju_nombre = _nombre;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION consultarJugadorPosicion(_posicion varchar)
RETURNS TABLE
  (id integer, nombre varchar, apellido varchar, fechaNacimiento date, 
    lugarNacimiento varchar, peso decimal, altura decimal, posicion varchar, numero decimal)
AS
$$
BEGIN
    RETURN QUERY SELECT
    ju_id, ju_nombre, ju_apellido, ju_fechaNacimiento, ju_lugarNacimiento, ju_peso, ju_altura,
    ju_posicion, ju_numero
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