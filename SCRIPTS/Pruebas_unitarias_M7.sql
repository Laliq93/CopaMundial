DELETE FROM logro_partido;

DELETE FROM partido where pa_id  IN (11, 14, 15 , 16, 18, 54);
---------------------------------INSERTS DE PARTIDOS------------------------------------
----pa_id = 11
INSERT INTO public.partido(
	pa_id, pa_fechainicio, pa_fechafin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id)
	VALUES (11, '10-10-2015 20:00:00', '10-10-2020 22:00:00','PruebaLogros id 14', 1, 2, 1);	

----pa_id = 14
INSERT INTO public.partido(
	pa_id, pa_fechainicio, pa_fechafin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id)
	VALUES (14, '10-10-2015 20:00:00', '10-10-2020 22:00:00','PruebaLogros', 1, 2, 1);	
    
----pa_id = 15
INSERT INTO public.partido(
	pa_id, pa_fechainicio, pa_fechafin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id)
	VALUES (15, '10-10-2016 20:00:00', '10-10-2020 22:00:00','PruebaLogros', 1, 2, 1);	

----pa_id = 16
INSERT INTO public.partido(
	pa_id, pa_fechainicio, pa_fechafin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id)
	VALUES (16, '10-10-2019 20:00:00', '10-10-2020 22:00:00','PruebaLogros', 1, 2, 1);	
	
----pa_id = 18
INSERT INTO public.partido(
	pa_id, pa_fechainicio, pa_fechafin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id)
	VALUES (18, '10-10-2019 20:00:00', '10-10-2020 22:00:00','PruebaLogros', 1, 2, 1);
    
----pa_id = 54
INSERT INTO public.partido(
	pa_id, pa_fechainicio, pa_fechafin, pa_arbitro, pa_eq1_id, pa_eq2_id, pa_es_id)
	VALUES (54, '10-10-2019 20:00:00', '10-10-2020 22:00:00','PruebaLogros', 1, 2, 1);	
	
------------------------------------INSERTS DE LOGRO_PARTIDO---------------------------------------    

-------------------------------INSERTS PU LOGRO CANTIDAD --------------------------------------------
------lo_id = 3
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (3, 'cantidad',null, true, 1,14, null,null, null);

-----lo_id = 4
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (4, 'cantidad',null, true, 1,14, null,null, null);
----lo_id = 7 
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (7, 'cantidad',null, true, 1,14, null,null, null);
----lo_id = 8 
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (8, 'cantidad',10, true, 1,14, null,null, null);
    
-------------------------------------------PU LOGRO JUGADOR -------------------------------------
-----lo_id = 90
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (90, 'jugador',null, true, 2,14, null,1, null);
 
------------------------------------------PU LOGRO EQUIPO ----------------------------------------
-----lo_id = 9
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (9, 'equipo',null, true, 3,14, null,null, null);
-----lo_id = 45
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (45, 'equipo',null, true, 3,14, null,null, null);
-----lo_id = 46
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (46, 'equipo',null, true, 3,14, null,null, null);
------------------------------------------PU LOGRO VF ----------------------------------------------
-----lo_id =  52
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (52, 'vf',null, true, 4,14, null,null, null);

-----lo_id =  77
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (77, 'vf',null, true, 4,14, null,null, null);

-----lo_id =  53
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (53, 'vf',null, true, 4,14, null,null, null);
    
----- lo_id = 98
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (98, 'vf',null, true, 4,54, null,null, null);
    
----- lo_id = 99
INSERT INTO public.logro_partido(
	lo_id, lo_nombre, lo_cantidad, lo_status, lo_fg_tipologro, lo_resultado_pa, lo_resultado_eq, 
	lo_resultado_ju, lo_resultado_vf)
	VALUES (99, 'vf',null, true, 4,16, null,null, null);