USE EMPRESA;
GO

INSERT INTO PESSOA (nomePessoa)
VALUES ('SAULO'),('LUCAS');
GO

SELECT * FROM PESSOA

INSERT INTO TELEFONE (idPessoa,numeroTelefone)
VALUES (1,'999'), (2,'888');
GO

SELECT * FROM TELEFONE

INSERT INTO EMAIL (idPessoa,enderecoEmail)
VALUES (1,'s.santos@email.com'), (2,'l.castro@email.com');
GO

SELECT * FROM EMAIL

INSERT INTO CNH (idPessoa,descricao)
VALUES (1,'1212'), (2,'3443');
GO
