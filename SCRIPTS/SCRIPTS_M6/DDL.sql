--Modulo 6
--DROPS

Drop table PARTIDO;
Drop table ALINEACION;
Drop SEQUENCE SEQ_Partido;
Drop SEQUENCE SEQ_Alineacion

--Creates Tables

--Modulo 6
----CREATE TABLES-------------------------------------
CREATE TABLE PARTIDO(
	pa_id integer,
    pa_fecha Date NOT NULL,
    pa_horaInicio Time NOT NULL,
    pa_horaFin Time,
    pa_arbitro varchar(30) NOT NULL,
    pa_status boolean NOT NULL,
    fk_equipo1 integer NOT NULL,
    fk_equipo2 integer NOT NULL,
    fk_estadio integer NOT NULL,
    
    CONSTRAINT pk_partido PRIMARY KEY(pa_id)
);

CREATE TABLE ALINEACION(
	al_id integer,
    al_capitan boolean NOT NULL,
    al_posicion varchar(30) NOT NULL,
    al_titular boolean NOT NULL,
    fk_jugador integer NOT NULL,
    fk_equipo integer NOT NULL,
    fk_partido integer NOT NULL,
    CONSTRAINT pk_alineacion PRIMARY KEY(al_id)
);


--Fin de modulo

--ALTERS
--Modulo 6
ALTER TABLE PARTIDO ADD CONSTRAINT fk_partido_equipo1 FOREIGN KEY (fk_equipo1) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE
ALTER TABLE PARTIDO ADD CONSTRAINT fk_partido_equipo2 FOREIGN KEY (fk_equipo2) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE
ALTER TABLE PARTIDO ADD CONSTRAINT fk_partido_estadio FOREIGN KEY (fk_estadio) REFERENCES ESTADIO(es_id) ON DELETE CASCADE ON UPDATE CASCADE


ALTER TABLE ALINEACION ADD CONSTRAINT fk_alineacion_jugador FOREIGN KEY (fk_jugador) REFERENCES JUGADOR(ju_id) ON DELETE CASCADE ON UPDATE CASCADE
ALTER TABLE ALINEACION ADD CONSTRAINT fk_alineacion_equipo FOREIGN KEY (fk_equipo) REFERENCES EQUIPO(eq_id) ON DELETE CASCADE ON UPDATE CASCADE
ALTER TABLE ALINEACION ADD CONSTRAINT fk_alineacion_partido FOREIGN KEY (fk_partido) REFERENCES PARTIDO(pa_id) ON DELETE CASCADE ON UPDATE CASCADE


--Fin de modulo

--SEQUENCES
--Modulo 6
CREATE SEQUENCE SEQ_Partido
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;


CREATE SEQUENCE SEQ_Alineacion
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;


--Fin de modulo

--INDEX
--Modulo 6
--Fin de modulo
GRANT ALL PRIVILEGES ON TABLE PARTIDO TO admin_copamundial;
GRANT ALL PRIVILEGES ON TABLE ALINEACION TO admin_copamundial;
--Fin Creates tables
