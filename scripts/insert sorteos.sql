USE `proyecto`;

/*Insertar en TIPOJUEGO*/
INSERT INTO TB_TIPOJUEGO values (1,'a','b',1);

/*Insertar en JUEGO*/
INSERT INTO TB_JUEGO values (1,1,'juego 1',1,1,1);
INSERT INTO TB_JUEGO values (2,1,'juego 2',1,1,1);
INSERT INTO TB_JUEGO values (3,1,'juego 3',1,1,1);

/*Insertar en CONJUNTO*/
INSERT INTO TB_CONJUNTO values (1,1,'conjunto 1',20,1);
INSERT INTO TB_CONJUNTO values (2,2,'conjunto 2',50,1);

/*Insertar en DOMINIO*/
INSERT INTO TB_DOMINIO values (1,'algo','1',1,'algo','1',1,1);

/*Insertar en TIPOUSUARIO*/
INSERT INTO TB_TIPOUSUARIO values (1,'algo',1);

/*Insertar en USUARIO*/
INSERT INTO TB_USUARIO values(1,1,1,1,'algo','algo','algo','algo','algo',1,1,'algo');

/*Insertar en TICKET*/
INSERT INTO TB_TICKET values(1,1,'algo','2019-1-10',1,20,'2019-1-10',20);

/*Insertar en ITEM*/
INSERT INTO TB_ITEM values(1,1,'algo','algo',1,20,1);
INSERT INTO TB_ITEM values(2,2,'algo','algo',2,50,1);

/*Insertar DIA*/
INSERT INTO TB_DIA values(1,'LUNES',1);
INSERT INTO TB_DIA values(2,'MARTES',1);
INSERT INTO TB_DIA values(3,'MIÉRCOLES',1);
INSERT INTO TB_DIA values(4,'JUEVES',1);
INSERT INTO TB_DIA values(5,'VIERNES',1);
INSERT INTO TB_DIA values(6,'SÁBADO',1);
INSERT INTO TB_DIA values(7,'DOMINGO',1);

/*Insertar en SORTEO*/
INSERT INTO TB_SORTEO values(1,1,'01:00:00',1);
INSERT INTO TB_SORTEO values(2,1,'02:00:00',1);
INSERT INTO TB_SORTEO values(3,2,'03:00:00',1);
INSERT INTO TB_SORTEO values(4,2,'04:00:00',1);
INSERT INTO TB_SORTEO values(5,2,'06:30:00',1);

/*Insertar en SORTEO_ITEM*/
INSERT INTO TB_SORTEO_ITEM values(1,1,1,1,20,1);
INSERT INTO TB_SORTEO_ITEM values(2,2,2,2,50,1);
INSERT INTO TB_SORTEO_ITEM values(3,1,3,2,20,1);
INSERT INTO TB_SORTEO_ITEM values(4,2,4,2,50,1);
INSERT INTO TB_SORTEO_ITEM values(5,2,5,2,50,1);

/*Insertar en DIA_SORTEO*/
INSERT INTO TB_DIA_SORTEO values (1,1,1,1);
INSERT INTO TB_DIA_SORTEO values (2,2,2,1);
INSERT INTO TB_DIA_SORTEO values (3,3,3,1);
INSERT INTO TB_DIA_SORTEO values (4,3,4,1);
INSERT INTO TB_DIA_SORTEO values (5,4,5,1);

/*Insertar en JUGADA*/
INSERT INTO TB_JUGADA values(1,1,1,1,1,1,'500',1);
INSERT INTO TB_JUGADA values(2,1,3,1,1,1,'600',1);