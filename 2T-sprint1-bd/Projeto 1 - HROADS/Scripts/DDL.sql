CREATE DATABASE HROADS;
GO

USE HROADS;
GO

CREATE TABLE tipoHabilidade(
	idTipoHabilidade TINYINT PRIMARY KEY IDENTITY,
	nomeTipoHabilidade VARCHAR(20) NOT NULL
);
GO

CREATE TABLE classe(
	idClasse TINYINT PRIMARY KEY IDENTITY,
	nomeClasse VARCHAR(20) NOT NULL
);
GO

CREATE TABLE habilidade(
	idHabilidade TINYINT PRIMARY KEY IDENTITY,
	idTipoHabilidaDe TINYINT FOREIGN KEY REFERENCES tipoHabilidade(idTipoHabilidade),
	nomeHabilidade VARCHAR(20) NOT NULL
);
GO


CREATE TABLE classeHabilidade(
	idClasseHabilidade TINYINT PRIMARY KEY IDENTITY,
	idClasse TINYINT FOREIGN KEY REFERENCES classe(idClasse),
	nomeClasseHabilidade VARCHAR(20) NOT NULL
);
GO

CREATE TABLE personagem(
	idPersonagem TINYINT PRIMARY KEY IDENTITY,
	idClasse TINYINT FOREIGN KEY REFERENCES classe(idClasse),
	nomePersonagem VARCHAR(20) NOT NULL,
	capacidadeMaxVida VARCHAR(20) NOT NULL,
	capacidadeMaxMana VARCHAR(20) NOT NULL,
	dataAtualizacao Datetime NOT NULL,
	dataCriacao Datetime NOT NULL,
);


