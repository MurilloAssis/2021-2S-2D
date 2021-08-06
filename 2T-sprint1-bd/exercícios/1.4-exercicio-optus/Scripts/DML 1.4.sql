USE OPTUS;
GO

INSERT INTO USUARIO(nomeUsuario, emailUsuario, senhaUsuario, tipoUsuario)
VALUES ('ALBERTO', 'alberto@email.com', '1234', 'Admin');

INSERT INTO ARTISTA (nomeArtista)
VALUES ('CantorLoco'), ('Roberto Barros');
GO 

INSERT INTO ESTILO (nomeEstilo)
VALUES ('Rap'), ('FUNK');
GO 

INSERT INTO ALBUM (idArtista, nomeAlbum, dataLancamento)
VALUES (1, 'RAPGANG', '10-07-2019'), (2, 'MANDELA', '20-07-2021');
GO 

INSERT INTO ESTILOALBUM (idAlbum, idEstilo)
VALUES (1, 1), (2, 2);
GO 