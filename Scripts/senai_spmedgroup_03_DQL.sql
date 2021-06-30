--SQL, aqui fazemos as consultas nas tabelas

USE SpMedicalGroup
--determinamos qual banco de dados usar

--mostrar todos os tipos de usuáios
SELECT * FROM TipoUsuario;

--mostrar todas as clínicas
SELECT * FROM Clinica;

--mostrar todos os tipos de especialidade
SELECT * FROM Especialidade;

--mostrar todos os usuários cadastrados
SELECT * FROM Usuario;

--mostrar todos os prontuários
SELECT * FROM Paciente;

--mostrar todos os médicos
SELECT * FROM Medico;

--mostrar todas as consultas e suas situações
SELECT * FROM Consulta;

--mostrar o paciente e sua consulta
SELECT		nomePaciente AS Nome, telefonePaciente AS Telefone, dataConsulta AS [Data], situacao AS Situação FROM Paciente
INNER JOIN	Consulta
ON			Consulta.idPaciente = Paciente.idPaciente;

--mostrar médicos e clinica onde trabalham
SELECT		crm AS CRM, nomeMedico AS Médico, email AS Email, nomeEspecialidade AS Especialidade, cnpj AS CNPJ, razaoSocial AS [Razão Social], enderecoClinica AS Endereço FROM Medico
INNER JOIN	Usuario
ON			Usuario.idUsuario = Medico.idUsuario

INNER JOIN	Especialidade
ON			Especialidade.idEspecialidade = Medico.idEspecialidade

INNER JOIN	Clinica
ON			Clinica.idClinica = Medico.idClinica;


--mostrar as consultas com nome do Paciente, médico que irá atende-lô e a situação da consulta
SELECT		nomePaciente, nomeMedico, dataConsulta, situacao FROM Consulta
INNER JOIN	Paciente
ON			Paciente.idPaciente = Consulta.idPaciente

INNER JOIN	Medico
ON			Medico.idMedico = Consulta.idMedico;


--mostrar os prontuários
SELECT		nomePaciente AS Nome, email AS Email, dataNascimento AS [Data de Nascimento], telefonePaciente AS Telefone, rg AS RG, cpf AS CPF, enderecoPaciente AS Endereço FROM Paciente
INNER JOIN	Usuario
ON			Usuario.idUsuario = Paciente.idUsuario;


--mostrar todas as especialidades
SELECT nomeEspecialidade AS Especialidade FROM Especialidade;