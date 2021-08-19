USE GUFI_TARDE;
GO

SELECT idTipoEvento, tituloTipoEvento as Evento
FROM tipoEvento

SELECT * FROM presenca

SELECT idUsuario, tituloTipoUsuario 'Tipo do usuario', nomeUsuario 'nome'
FROM usuario
INNER JOIN tipoUsuario
ON usuario.idTipoUsuario = tipoUsuario.idTipoUsuario;

--SELECT *
SELECT idEvento, nomeEvento 'Nome do evento', dataEvento 'Data', nomeFantasia as 'Instituição', tituloTipoEvento as 'Tipo do Evento'
FROM evento
INNER JOIN instituicao
ON evento.idInstituicao = instituicao.idInstituicao
INNER JOIN tipoEvento
ON evento.idTipoEvento = tipoEvento.idTipoEvento;
GO

SELECT evento.idEvento, nomeEvento 'Nome do Evento', CONVERT(VARCHAR(20), dataEvento, 106) 'Data', nomeFantasia 'Instituição', tituloTipoEvento 'Tipo do evento', nomeUsuario 'Nome do Usuário presente'
FROM evento
INNER JOIN instituicao
ON evento.idInstituicao = instituicao.idInstituicao
INNER JOIN tipoEvento te 
ON evento.idTipoEvento = te.idTipoEvento
INNER JOIN presenca 
ON evento.idEvento = presenca.idEvento
INNER JOIN usuario
ON usuario.idUsuario = presenca.idUsuario


SELECT *
FROM usuario
WHERE email = 'Lucas@email.com'
AND senha = 'lucas12345'
