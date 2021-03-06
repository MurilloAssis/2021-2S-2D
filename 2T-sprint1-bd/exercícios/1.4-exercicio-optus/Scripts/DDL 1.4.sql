CREATE DATABASE OPTUS;
GO

USE OPTUS;
GO


CREATE TABLE USUARIO(
	nomeUsuario VARCHAR(20) NOT NULL,
	emailUsuario VARCHAR(35) NOT NULL UNIQUE,
	senhaUsuario VARCHAR (35) NOT NULL,
	tipoUsuario char(5) NOT NULL
);
GO

CREATE TABLE ARTISTA (
	idArtista SMALLINT PRIMARY KEY IDENTITY(1,1),
	nomeArtista VARCHAR(30) NOT NULL
);
GO

CREATE TABLE ESTILO (
	idEstilo SMALLINT PRIMARY KEY IDENTITY(1,1),
	nomeEstilo VARCHAR(30) NOT NULL
);
GO

CREATE TABLE ALBUM (
	idAlbum SMALLINT PRIMARY KEY IDENTITY(1,1),
	idArtista SMALLINT FOREIGN KEY REFERENCES ARTISTA(idArtista),
	nomeAlbum VARCHAR(30) NOT NULL,
	dataLancamento SMALLDATETIME 
);
GO



CREATE TABLE ESTILOALBUM (
	idEstiloAlbum SMALLINT PRIMARY KEY IDENTITY(1,1),
	idAlbum SMALLINT FOREIGN KEY REFERENCES ALBUM(idAlbum),
	idEstilo SMALLINT FOREIGN KEY REFERENCES ESTILO(idEstilo)
);
GO


