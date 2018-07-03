-- Querys para las Pruebas unitarias

DELETE FROM apuesta WHERE idlogro > 99 AND idusuario > 99;

DELETE FROM logro_partido where lo_id > 99;

DELETE FROM partido where pa_id > 99;

DELETE FROM jugador WHERE ju_id > 99;

DELETE FROM usuario WHERE us_id > 99;

INSERT INTO public.usuario(
	us_id, us_nombreusuario, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_password, us_fotopath, us_esadmin, us_activo, us_token)
	VALUES (100, 'test100','test','test','13-12-1995','testing2@hotmail.com','M', 'test', null, true, true, null);

INSERT INTO public.partido(
	pa_id, pa_fechainicio, pa_fechafin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id)
	VALUES (100, '10-10-2015 20:00:00', '10-10-2020 22:00:00','test', 1, 2, 1);	
	
INSERT INTO public.jugador(
	ju_id, ju_nombre, ju_apellido, ju_fechanacimiento, ju_lugarnacimiento, ju_peso, ju_altura, ju_posicion, ju_numero, ju_equipo, ju_capitan, ju_activo)
	VALUES (100, 'test', 'test', '12-12-1995', 'test',62, 1.74,'DELANTERO', 10, 'test', true, true);

INSERT INTO public.jugador(
	ju_id, ju_nombre, ju_apellido, ju_fechanacimiento, ju_lugarnacimiento, ju_peso, ju_altura, ju_posicion, ju_numero, ju_equipo, ju_capitan, ju_activo)
	VALUES (101, 'test2', 'test2', '12-12-1995', 'test2',62, 1.74,'DELANTERO', 7, 'test', true, true);	
	
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (100, 'cantidad',null, true, 1,100, null,null, null);
	
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (101, 'jugador',null, true, 2,100, null,null, null);
	
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (102, 'equipo',null, true, 3,100, null,null, null);
	
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (103, 'vof',null, true, 4,100, null,null, null);