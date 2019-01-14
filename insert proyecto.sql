USE `proyecto` ;
/*PRIMER METODO DE PRUEBA (ConsultarApuesta)*/
/*Insertar en TIPOJUEGO algo para probar*/
INSERT INTO TB_TIPOJUEGO values (1,'a','a',1);

/*Insertar en JUEGO el TIPOJUEGO*/
INSERT INTO TB_JUEGO values (1,1,'primero',1,1,1);

/*Insertar en CONJUNTO el JUEGO y TIPOJUEGO */
INSERT INTO TB_CONJUNTO values (1,1,'conjunto 1',20,1);

/*---------------------------------------------------------*/

/*Insertar en DOMINIO*/
INSERT INTO TB_DOMINIO values (1,'algo','1',1,'algo','1',1,1);

/*Insertar en TIPOUSUARIO*/
INSERT INTO TB_TIPOUSUARIO values (1,'algo',1);

/*Insertar en USUARIO el TIPOUSUARIO, DOMINIO*/
INSERT INTO TB_USUARIO values(1,1,1,1,'algo','algo','algo','algo','algo',1,1,'algo');

/*Insertar en TICKET el USUARIO*/
INSERT INTO TB_TICKET values(1,1,'algo','2019-1-10',1,20,'2019-1-10',20);

/*------------------------------------------------------------*/

/*Insertar en SORTEO el JUEGO*/
INSERT INTO TB_SORTEO values(1,1,'7:29',1);

INSERT INTO TB_SORTEO_ITEM values(1,1,1,1,20,1);

/*------------------------------------------------------------*/

/*Insertar en ITEM el JUEGO*/
INSERT INTO TB_ITEM values(1,1,'algo','algo',1,20,1);

/*------------------------------------------------------------*/

/*Insertar en JUGADA el TICKET, SORTEO, JUEGO, ITEM y CONJUNTO*/
INSERT INTO TB_JUGADA values(1,1,1,1,1,1,'500',1);

/*SEGUNDO METODO DE PRUEBA (ConsultarDia)*/
/*Insertar DIA*/
INSERT INTO TB_DIA values(1,'Martes',1);
INSERT INTO TB_DIA values(2,'Lunes',1);

/*Insertar en DIA_SORTEO el DIA*/
INSERT INTO TB_DIA_SORTEO values (1,1,1,1);
