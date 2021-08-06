USE CATALOGO

SELECT * FROM GENERO
SELECT * FROM FILME

SELECT tituloFilme, nomeGenero, idFilme
FROM GENERO
LEFT JOIN FILME
ON GENERO.idGenero = FILME.idGenero;

SELECT tituloFilme, nomeGenero, idFilme
FROM GENERO
RIGHT JOIN FILME
ON GENERO.idGenero = FILME.idGenero;

SELECT tituloFilme, nomeGenero, idFilme
FROM GENERO
INNER JOIN FILME
ON GENERO.idGenero = FILME.idGenero;

