Use StellarMinds;
Go

/* =========================================
   USUARIOS
========================================= */

INSERT INTO Usuarios
(UserName, Name, Email, Calle, NumeroPuerta, Apartamento, Password, Discriminator)
VALUES
('admin1','Juan Perez','admin1@stellarminds.com','18 de Julio',1234,101,'Admin123#','Administrador'),
('admin2','Maria Gonzalez','admin2@stellarminds.com','Rivera',2345,202,'Admin456#','Administrador'),
('admin3','Pedro Lopez','admin3@stellarminds.com','Colonia',1111,101,'Admin789#','Administrador'),
('admin4','Lucia Suarez','admin4@stellarminds.com','Mercedes',2222,202,'AdminABC#1','Administrador'),

('coord1','Carlos Rodriguez','coord1@stellarminds.com','Bvar Artigas',3456,301,'Coord123#','Coordinador'),
('coord2','Laura Fernandez','coord2@stellarminds.com','Agraciada',4567,401,'Coord456#','Coordinador'),
('coord3','Martin Sosa','coord3@stellarminds.com','Yi',500,1,'Coord789#','Coordinador'),
('coord4','Valentina Diaz','coord4@stellarminds.com','Durazno',800,2,'CoordABC#1','Coordinador'),

('socio1','Diego Silva','socio1@gmail.com','Colonia',5678,501,'Socio123#','Socio'),
('socio2','Ana Martinez','socio2@gmail.com','Paysandu',6789,601,'Socio456#','Socio'),
('socio3','Fernando Costa','socio3@gmail.com','Rivera',7890,701,'Socio789#','Socio'),
('socio4','Paula Ramos','socio4@gmail.com','Maldonado',8901,801,'SocioABC#1','Socio');

go
/* =========================================
   EQUIPOS
========================================= */

/* TELESCOPIOS */

INSERT INTO Equipos
(Marca,Modelo,StockSinUSo,CantidadDisponible,Apertura,RelacionFocal,Peso,DistanciaFocal,Discriminator)
VALUES
('SkyWatcher','Evostar 80ED',2,4,80,'f/7.5',4.5,600,'Telescopio'),
('Celestron','NexStar 8SE',3,5,203,'f/10',12,2032,'Telescopio'),
('Meade','LX90',2,4,200,'f/10',10,2000,'Telescopio'),
('Orion','StarBlast',4,6,114,'f/4',3,450,'Telescopio');
go
/* MONTURAS */

INSERT INTO Equipos
(Marca,Modelo,StockSinUSo,CantidadDisponible,CargaUtil,EsComputarizado,TipoMontura,Discriminator)
VALUES
('SkyWatcher','EQ5',2,4,10,1,1,'Montura'),
('SkyWatcher','EQ6-R',2,4,20,1,1,'Montura'),
('Celestron','AVX',2,4,13,1,2,'Montura'),
('Orion','AZ Mount',3,5,8,0,0,'Montura');
go
/* CAMARAS */

INSERT INTO Equipos
(Marca,Modelo,StockSinUSo,CantidadDisponible,TipoSensor,Resolucion,TamañoPixel,Discriminator)
VALUES
('ZWO','ASI224MC',2,3,0,1920,4,'Camara'),
('QHY','QHY163M',2,3,1,4656,3,'Camara'),
('ZWO','ASI585MC',2,4,0,3840,2,'Camara'),
('PlayerOne','Mars-C',2,4,0,4144,2,'Camara');
go
/* OCULARES */

INSERT INTO Equipos
(Marca,Modelo,StockSinUSo,CantidadDisponible,Diametro,AnguloVision,Discriminator)
VALUES
('Baader','Hyperion 13mm',4,6,13,68,'Ocular'),
('Explore Scientific','20mm 68',3,5,20,68,'Ocular'),
('Celestron','X-Cel LX 9mm',3,4,9,60,'Ocular'),
('TeleVue','Nagler 7mm',2,3,7,82,'Ocular');
go
/* =========================================
   OBJETOS CELESTES
========================================= */

INSERT INTO ObjetosCeleste
(Nombre,MagnitudAparente,TipoCeleste)
VALUES
('Jupiter',-2.94,'Planeta'),
('Saturno',0.46,'Planeta'),
('Marte',-1.20,'Planeta'),
('Venus',-4.20,'Planeta'),
('Polaris',1.98,'Estrella'),
('Sirio',-1.46,'Estrella'),
('Betelgeuse',0.42,'Estrella'),
('Nebulosa de Orion',4.00,'Nebulosa'),
('Nebulosa Laguna',6.00,'Nebulosa'),
('Galaxia Andromeda',3.44,'Galaxia'),
('Galaxia del Triangulo',5.72,'Galaxia'),
('Cumulo de Hercules',5.80,'Cumulo');

go
/* =========================================
   PRESTAMOS
========================================= */

INSERT INTO Prestamos
(UsuarioId,FechaInicio,FechaFin,Estado)
VALUES
(9,'2026-01-01','2026-01-10',0),
(10,'2026-01-15','2026-01-25',0),
(11,'2026-02-01','2026-02-10',0),
(12,'2026-02-15','2026-02-25',0),
(9,'2026-03-01','2026-03-15',0),
(10,'2026-03-10','2026-03-20',0),

(11,'2026-05-01','2026-05-15',1), -- atrasado
(12,'2026-05-10','2026-05-20',1), -- atrasado
(9,'2026-06-01','2026-06-15',1),
(10,'2026-06-05','2026-06-20',1),
(11,'2026-06-10','2026-06-25',1),
(12,'2026-06-15','2026-06-30',1);

go
/* =========================================
   DETALLE PRESTAMOS
========================================= */

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (1,1);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (1,5);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (1,9);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (2,2);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (2,6);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (2,13);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (3,3);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (3,7);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (3,10);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (4,4);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (4,8);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (4,14);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (5,1);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (5,6);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (5,11);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (6,2);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (6,7);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (6,15);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (7,3);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (7,5);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (7,12);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (8,4);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (8,8);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (8,16);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (9,1);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (9,7);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (9,9);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (10,2);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (10,5);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (10,10);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (11,3);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (11,6);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (11,13);

INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (12,4);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (12,8);
INSERT INTO PrestamoDetalles (PrestamoId,EquipoId) VALUES (12,11);



go
/* =========================================
   OBSERVACIONES
========================================= */

INSERT INTO Observaciones
(FechaObs,PrestamoId,Indicador,Detalle,ObjetoCelesteId)
VALUES
('2026-06-01',7,'Ideal','',1),
('2026-06-02',7,'Adecuado','Adecuado.',2),
('2026-06-03',8,'Ideal.','',1),
('2026-06-04',8,'No recomendable.','No recomendable.',10),
('2026-06-05',9,'Ideal.','',1),
('2026-06-06',9,'Adecuado.','Adecuado.',3),
('2026-06-07',10,'Ideal.','',10),
('2026-06-08',10,'Ideal.','',10),
('2026-06-09',11,'Ideal.','',8),
('2026-06-10',11,'Ideal.','',8),
('2026-06-11',12,'Ideal.','',1),
('2026-06-12',12,'Adecuado.','Adecuado.',5);