USE SP_MEDICAL_GROUP;
GO


--Listagem simples de todos os paciente do sistema
SELECT nomeUsuario 'Nome do Paciente', emailUsuario 'Email do paciente', titulotipoUsuario 'tipo de usu�rio', RG
FROM usuario u
INNER JOIN paciente p
ON u.idUsuario = p.idUsuario
INNER JOIN tipoUsuario tu
ON tu.idTipoUsuario = u.idTipoUsuario

--Listagem simples de todos os m�dicos cadastrados
SELECT *
FROM usuario u
INNER JOIN medico m
ON u.idUsuario = m.idUsuario

--Listagem dos pacientes cadastrados no sistema
SELECT nomeUsuario, emailUsuario, RG, ISNULL (Telefone, 'N�o cadastrado') Telefone, enderecoPaciente
FROM usuario u
INNER JOIN paciente
ON u.idUsuario = paciente.idUsuario
