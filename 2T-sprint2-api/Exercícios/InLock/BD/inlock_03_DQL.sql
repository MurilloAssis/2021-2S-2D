USE inlock_games_tarde;
GO

SELECT * FROM ESTUDIO;
SELECT * FROM JOGO;
SELECT * FROM TIPOUSUARIO;
SELECT * FROM USUARIO;

SELECT * FROM JOGO
LEFT JOIN ESTUDIO
ON JOGO.idEstudio = ESTUDIO.idEstudio;

SELECT * FROM ESTUDIO
LEFT JOIN JOGO
ON ESTUDIO.idEstudio = JOGO.idEstudio;

SELECT * FROM USUARIO WHERE email = 'admin@admin.com' AND senha = 'admin';

SELECT * FROM JOGO WHERE idJogo = 2;

SELECT * FROM ESTUDIO WHERE idEstudio = 2;