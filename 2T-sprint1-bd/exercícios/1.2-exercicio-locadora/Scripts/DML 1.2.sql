USE LOCADORA
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Localiza'), ('Aluga');
GO

Select * FROM EMPRESA;
GO

INSERT INTO CLIENTE (nomeCliente)
VALUES ('Saulo'), ('João');
GO

Select * FROM CLIENTE;
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('VW'), ('TOYOTA');
GO

Select * FROM MARCA;
GO

INSERT INTO MODELO (idMarca, nomeModelo)
VALUES (1, 'Jetta'), (2, 'Corolla');
GO

Select * FROM MODELO;
GO

INSERT INTO VEICULO (idModelo, idEmpresa, PLACA)
VALUES (1, 1, '999'), (1, 2, '888'), (2, 1, '777');
GO

Select * FROM VEICULO;
GO

DELETE FROM VEICULO

INSERT INTO ALUGUEL (idVeiculo, idCliente, idEmpresa, DataDevol)
VALUES (3, 1, 1, '05-08-2021');
GO

SELECT * FROM ALUGUEL



