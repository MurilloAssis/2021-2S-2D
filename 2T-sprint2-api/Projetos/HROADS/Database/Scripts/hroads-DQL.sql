USE HROADS;
GO


-- 6 - Selecionar todos os personagens

SELECT * FROM PERSONAGEM
GO

-- 7 - Selecionar todos as classes
SELECT * FROM CLASSE
GO

-- 8 - Selecionar somente o nome das classes
SELECT nomeClasse FROM CLASSE
GO

-- 9 - Selecionar todas as habilidades
SELECT * FROM HABILIDADE
GO

-- 10 - Realizar a contagem de quantas habilidades estão cadastradas
SELECT COUNT(*) FROM HABILIDADE
GO

-- 11 - Selecionar somente os id’s das habilidades classificando-os por ordem crescente
SELECT idHabilidade FROM HABILIDADE
ORDER BY idHabilidade ASC
GO

-- 12 - Selecionar todos os tipos de habilidades
SELECT * FROM TIPOHABILIDADE
GO

-- 13 - Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte
SELECT nomeHabilidade Habilidade, nomeTipoHabilidade [Tipo Habilidade] FROM HABILIDADE H
LEFT JOIN TIPOHABILIDADE TH
ON H.idTipoHabilidade = TH.idTipoHabilidade
GO

-- 14 - Selecionar todos os personagens e suas respectivas classes
SELECT nomePersonagem Personagem, nomeClasse Classe FROM PERSONAGEM P
LEFT JOIN CLASSE C
ON P.idClasse = C.idClasse
GO

/* 15 - Selecionar todos os personagens e as classes (mesmo que elas não tenham
correspondência em personagens) */
SELECT nomePersonagem Personagem, nomeClasse Classe FROM PERSONAGEM P
RIGHT JOIN CLASSE C
ON P.idClasse = C.idClasse
GO

-- 16 - Selecionar todas as classes e suas respectivas habilidades
SELECT nomeClasse Classe, nomeHabilidade Habilidade FROM CLASSE C
LEFT JOIN CLASSEHABILIDADE CH
ON C.idClasse = CH.idClasse
LEFT JOIN HABILIDADE H
ON CH.idHabilidade = H.idHabilidade
GO

/* 17 - Selecionar todas as habilidades e suas classes (somente as que possuem
correspondência); */
SELECT nomeHabilidade Habilidade, nomeClasse Classe FROM CLASSE C
LEFT JOIN CLASSEHABILIDADE CH
ON C.idClasse = CH.idClasse
INNER JOIN HABILIDADE H
ON CH.idHabilidade = H.idHabilidade
GO

/* 
Selecionar todas as habilidades e suas classes (mesmo que elas não tenham
correspondência).
*/
SELECT nomeHabilidade Habilidade, nomeClasse Classe FROM CLASSE C
FULL OUTER JOIN CLASSEHABILIDADE CH
ON C.idClasse = CH.idClasse
FULL OUTER JOIN HABILIDADE H
ON CH.idHabilidade = H.idHabilidade
GO