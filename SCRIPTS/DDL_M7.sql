
--================================================DROPS==========================================================
DROP TABLE IF EXISTS TIPO_LOGRO CASCADE;
DROP TABLE IF EXISTS LOGRO_PARTIDO CASCADE;
DROP SEQUENCE IF EXISTS SEQ_TipoLogro;
DROP SEQUENCE IF EXISTS SEQ_LogroPartido;

--================================================CREATE TABLES==================================================

CREATE TABLE TIPO_LOGRO(
    ti_id integer,
    ti_nombre varchar(35) UNIQUE NOT NULL,  
    ti_status bool,
    constraint primaria_tipo_logros PRIMARY KEY (ti_id)
);

CREATE TABLE LOGRO_PARTIDO(
	lo_id integer,
	lo_nombre varchar(100) not null,
        lo_cantidad integer check(lo_cantidad >=0),
        lo_status bool,
        lo_fg_tipoLogro integer,
	lo_resultado_pa integer,
        lo_resultado_eq integer,
	lo_resultado_ju integer,
	lo_resultado_vf bool,
	constraint primaria_logros_partido PRIMARY KEY (lo_id)
);
--================================================ALTER TABLE====================================================

ALTER TABLE LOGRO_PARTIDO ADD CONSTRAINT lo_fg_tipoLogro foreign key (lo_fg_tipoLogro) references TIPO_LOGRO(ti_id);
ALTER TABLE LOGRO_PARTIDO ADD CONSTRAINT lo_resultado_pa foreign key (lo_resultado_pa) references PARTIDO(pa_id);
ALTER TABLE LOGRO_PARTIDO ADD CONSTRAINT lo_resultado_jug foreign key (lo_resultado_ju) references JUGADOR(ju_id);

--================================================SECUENCIAS=====================================================
CREATE SEQUENCE SEQ_TipoLogro
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;

CREATE SEQUENCE SEQ_LogroPartido
  START WITH 1
  INCREMENT BY 1
  NO MINVALUE
  NO MAXVALUE
  CACHE 1;





