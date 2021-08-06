USE PCLINICS;
GO

SELECT * FROM CLINICA
SELECT * FROM DONO
SELECT * FROM PET
SELECT * FROM VETERINARIO
SELECT * FROM CONSULTA

SELECT idVeterinario, nomeVET, CRMV, nomeClinica
FROM VETERINARIO
INNER JOIN CLINICA
ON VETERINARIO.idClinica = CLINICA.idClinica

SELECT idPet, nomePet, nomeDono
FROM PET
INNER JOIN DONO
ON PET.idDono = DONO.idDono

SELECT nomeVET, nomePet, nomeTipo, nomeRaca, nomeDono, nomeClinica
FROM CONSULTA
INNER JOIN VETERINARIO
ON CONSULTA.idVeterinario = VETERINARIO.idVeterinario
INNER JOIN PET 
ON CONSULTA.idPet = PET.idPet
INNER JOIN CLINICA
ON CONSULTA.idClinica = CLINICA.idClinica
INNER JOIN TIPO
ON CONSULTA.idPet = TIPO.idTipo
INNER JOIN RACA 
ON CONSULTA.idPet = RACA.idRaca
INNER JOIN DONO
ON CONSULTA.idPet = DONO.idDono

SELECT nomeRaca
FROM RACA
WHERE nomeRaca LIKE 'S%'

SELECT nomeTipo
FROM TIPO
WHERE nomeTipo LIKE '%O'

