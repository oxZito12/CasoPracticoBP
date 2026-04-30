--JONATHAN DANILO GALARZA PICHUCHO
--CI: 0401579826


INSERT INTO Cliente (
    codigoEmpresaCedente,
    identificacionCliente,
    tipoIdentificacion,
    nombreCompleto,
    codigoCliente
)
VALUES
('ECPSBL','00001900868728','CI','JEAN CARLOS ROMERO ARMIJOS',1),
('GFP','00001103362722','PA','CARLOS ROMERO',2),
('ECPSBL','00001988868327','PA','EDGAR ROMER',3),
('GFP','00001777868425','CI','JUAN ROMERO',5),
('ECPSBL','00001598868529','PA','LUCIA ROMERO',6),
('GFP','00001412868521','CI','LUIS ROMERO',7);



INSERT INTO ClienteTipoIdentificacion (
    codigoEmpresaCedente,
    identificacionCliente,
    Fecha,
    tipoIdentificacion
)
VALUES
('ECPSBL','00001900868728','2024-01-18','CI'),
('GFP','00001103362722','2024-01-18','CI'),
('ECPSBL','00001988868327','2024-01-18','CI'),
('GFP','00001777868425','2024-01-18','CI'),
('ECPSBL','00001598868529','2024-01-18','PA'),
('GFP','00001412868521','2024-01-18','CI');

INSERT INTO Operaciones (
    Operacion,
    codigoCliente,
    Mora,
    Estado
)
VALUES
(1236,1,90,'Castigada'),
(4567,2,33,'Mora'),
(9877,3,60,'Mora'),
(4444,5,-50,'Al día'),
(5555,6,16,'Mora'),
(7777,7,91,'Mora'),
(9991,1,12,'Mora'),
(9992,2,5,'Mora'),
(9993,2,60,'Mora'),
(9994,3,-50,'Al día'),
(9995,6,16,'Mora');

--1.	Para el caso se necesita actualizar los tipos de identificación de la Tabla 1 con los datos de tipo Identificación de la Tabla 2 ya que el tipo de identificación en la Tabla 1 tiene datos incorrectos

UPDATE c
SET c.tipoIdentificacion = t.tipoIdentificacion
FROM Cliente c
INNER JOIN ClienteTipoIdentificacion t
    ON c.codigoEmpresaCedente = t.codigoEmpresaCedente
    AND c.identificacionCliente = t.identificacionCliente;
	
	
--2.	Obtener la operación de mayor mora por cliente y devolver el numero de operaciones que tiene cada cliente , mostrar su numero de cedula

WITH OperacionesMora AS (
    SELECT 
        codigoCliente,
        Operacion,
        Mora,
        ROW_NUMBER() OVER (
            PARTITION BY codigoCliente
            ORDER BY Mora DESC
        ) AS OperacionCritica,
        COUNT(*) OVER (
            PARTITION BY codigoCliente
        ) AS totalOperaciones
    FROM Operaciones
)

SELECT 
    c.identificacionCliente,
    o.codigoCliente,
    o.Operacion AS operacionMayorMora,
    o.Mora AS mayorMora,
    o.totalOperaciones
FROM OperacionesMora o
INNER JOIN Cliente c 
    ON o.codigoCliente = c.codigoCliente
WHERE o.OperacionCritica = 1;

--3.	Cambiar el estado de las operaciones con más de 15 días de mora únicamente a los clientes con pasaporte a inactivo 

UPDATE o
SET o.Estado = 'Inactivo'
FROM Operaciones o
INNER JOIN Cliente c 
    ON o.codigoCliente = c.codigoCliente
WHERE 
    o.Mora > 15
    AND c.tipoIdentificacion = 'PA';