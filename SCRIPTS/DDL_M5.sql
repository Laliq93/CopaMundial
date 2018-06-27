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
    ju_numero integer,
    ju_equipo varchar(20) NOT NULL,
    ju_capitan boolean default false not null,
    ju_activo boolean default true not null,
    CONSTRAINT primaria_jugador PRIMARY KEY (ju_id)
    );

CREATE SEQUENCE SEQ_Jugador
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;