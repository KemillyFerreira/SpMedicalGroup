--SQL, aqui fazemos as consultas nas tabelas

USE SpMedicalGroup
--determinamos qual banco de dados usar

--mostrar todos os tipos de usu�ios
SELECT * FROM TipoUsuario;

--mostrar todas as cl�nicas
SELECT * FROM Clinica;

--mostrar todos os tipos de especialidade
SELECT * FROM Especialidade;

--mostrar todos os usu�rios cadastrados
SELECT * FROM Usuario;

--mostrar todos os prontu�rios
SELECT * FROM Paciente;

--mostrar todos os m�dicos
SELECT * FROM Medico;

--mostrar todas as consultas e suas situa��es
SELECT * FROM Consulta;

--mostrar o paciente e sua consulta
SELECT		nomePaciente AS Nome, telefonePaciente AS Telefone, dataConsulta AS [Data], situacao AS Situa��o FROM Paciente
INNER JOIN	Consulta
ON			Consulta.idPaciente = Paciente.idPaciente;

--mostrar m�dicos e clinica onde trabalham
SELECT		crm AS CRM, nomeMedico AS M�dico, email AS Email, nomeEspecialidade AS Especialidade, cnpj AS CNPJ, razaoSocial AS [Raz�o Social], enderecoClinica AS Endere�o FROM Medico
INNER JOIN	Usuario
ON			Usuario.idUsuario = Medico.idUsuario

INNER JOIN	Especialidade
ON			Especialidade.idEspecialidade = Medico.idEspecialidade

INNER JOIN	Clinica
ON			Clinica.idClinica = Medico.idClinica;


--mostrar as consultas com nome do Paciente, m�dico que ir� atende-l� e a situa��o da consulta
SELECT		nomePaciente, nomeMedico, dataConsulta, situacao FROM Consulta
INNER JOIN	Paciente
ON			Paciente.idPaciente = Consulta.idPaciente

INNER JOIN	Medico
ON			Medico.idMedico = Consulta.idMedico;


--mostrar os prontu�rios
SELECT		nomePaciente AS Nome, email AS Email, dataNascimento AS [Data de Nascimento], telefonePaciente AS Telefone, rg AS RG, cpf AS CPF, enderecoPaciente AS Endere�o FROM Paciente
INNER JOIN	Usuario
ON			Usuario.idUsuario = Paciente.idUsuario;


--mostrar todas as especialidades
SELECT nomeEspecialidade AS Especialidade FROM Especialidade;