USE GUFI_TARDE;
GO

SELECT * FROM usuario
SELECT * FROM evento
Select * from situacao


INSERT INTO tipoUsuario(tituloTipoUsuario)
VALUES ('Admin'), ('Comum');
GO

INSERT INTO usuario(idTipoUsuario, nomeUsuario, email, senha)
VALUES (1, 'ADMINISTRADOR', 'ADM@ADM.COM', 'ADM123456'), (2, 'Lucas', 'Lucas@email.com', 'lucas12345'),(2, 'Saulo', 'Saulo@email.com', 'saulo12345');
GO

INSERT INTO instituicao (CNPJ, nomeFantasia, Endereco)
VALUES ('999999999999999999', 'Escola SENAI de Informática', 'Al. Barão de Limeira, 539')

INSERT INTO tipoEvento(tituloTipoEvento)
VALUES ('C#'), ('ReactJS'), ('SQL');
GO

INSERT INTO evento(idTipoEvento, idInstituicao, nomeEvento, descricao, dataEvento, acessoLivre)
VALUES (1,1,'Orientação a Objetos', 'Conceitos sobre os pilares da programção orientada a objetos', '18/08/2021 18:00', 1),
	   (2,1, 'Ciclo de Vida', 'Conceitos sobre ciclo de vida','19/08/2021 10:00', 2);
GO

INSERT INTO situacao(descricao)
VALUES ('APROVADO'), ('Recusado'), ('Aguardando');
GO

INSERT INTO presenca (idUsuario, idEvento, idSituacao)
VALUES (2, 4, 3), (3, 3, 1);
GO
