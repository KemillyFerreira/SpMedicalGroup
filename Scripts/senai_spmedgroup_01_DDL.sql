--DDL, onde criamos as tabelas

CREATE DATABASE SpMedicalGroup
--criando banco de dados chamado SpMedicalGroup

USE SpMedicalGroup
--determinando qual banco de dados será usado

CREATE TABLE TipoUsuario
--criando a tabela TipoUsupario
(
	idTipoUsuario	INT PRIMARY KEY IDENTITY
	,TipoUsuario	VARCHAR (15) NOT NULL
);

CREATE TABLE Clinica
--criando a tabela Clinica
(
	idClinica			INT PRIMARY KEY IDENTITY
	,cnpj				CHAR	(14)  NOT NULL
	,razaoSocial		VARCHAR (20)  NOT NULL
	,enderecoClinica	VARCHAR	(250) NOT NULL
	,horario			VARCHAR (20)  NOT NULL
);

CREATE TABLE Especialidade
--criando a tabela Especialidade
(
	idEspecialidade		INT PRIMARY KEY IDENTITY
	,nomeEspecialidade	VARCHAR (250) NOT NULL
);

CREATE TABLE Usuario
--criando a tabela usuário
(
	idUsuario		INT PRIMARY KEY IDENTITY
	,idTipoUsuario	INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
	,email			VARCHAR (250) NOT NULL
	,senha			VARCHAR (250) NOT NULL
);

CREATE TABLE Paciente
--criando a tabela Prontuário
(
	idPaciente			INT PRIMARY KEY IDENTITY
	,idUsuario			INT FOREIGN KEY REFERENCES Usuario(idUsuario)
	,nomePaciente		VARCHAR (250) NOT NULL
	,rg					CHAR (9) NOT NULL
	,cpf				CHAR (11) NOT NULL
	,dataNascimento		DATE NOT NULL
	,telefonePaciente	VARCHAR (11)
	,enderecoPaciente	VARCHAR (250) NOT NULL	
);

CREATE TABLE Medico
--criando a table Médico
(
	idMedico			INT PRIMARY KEY IDENTITY
	,idClinica			INT FOREIGN KEY REFERENCES Clinica(idClinica)
	,idUsuario			INT FOREIGN KEY REFERENCES Usuario(idUsuario)
	,idEspecialidade	INT FOREIGN KEY REFERENCES Especialidade(idEspecialidade)
	,nomeMedico			VARCHAR (250) NOT NULL
	,crm				VARCHAR (7) NOT NULL
);

CREATE TABLE Consulta
--criando tabela Consulta
(
	idConsulta		INT PRIMARY KEY IDENTITY
	,idPaciente		INT FOREIGN KEY REFERENCES Paciente (idPaciente)
	,idMedico		INT FOREIGN KEY REFERENCES Medico(idMedico)
	,dataConsulta	DATETIME NOT NULL
	,situacao		VARCHAR(100) NOT NULL
	,descricao		VARCHAR (100)
);