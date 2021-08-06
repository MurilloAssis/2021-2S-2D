USE PCLINICS
GO

SELECT * FROM TIPO

INSERT INTO CLINICA(nomeClinica, enderecoClinica)
VALUES ('PetMed', 'rua Andrade')

INSERT INTO DONO(nomeDono)
VALUES('Paulo');

INSERT INTO RACA(nomeRaca)
VALUES ('Sírio')

INSERT INTO TIPO(nomeTipo, idRaca)
VALUES ('Hamster', 2)

INSERT INTO PET(idDono, idTipo, nomePet, DataNasc)
VALUES (3, 1, 'THOR', '04-09-2019')

INSERT INTO VETERINARIO (idClinica, nomeVET, CRMV)
VALUES (1, 'Alberto', '99999')

INSERT INTO CONSULTA(idPet, idClinica, idVeterinario, DataCONS, Descricao)
VALUES(1, 1, 1, '06-08-2021', 'Animal estava com diarreia')