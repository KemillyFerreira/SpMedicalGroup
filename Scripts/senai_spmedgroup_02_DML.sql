--DML, onde inserimos os valores nas tabelas 

USE SpMedicalGroup
--determinamos qual banco de dados usar

--inserimos os valores que representam os tipos de usu�rio
INSERT INTO		TipoUsuario(TipoUsuario)
VALUES			('Administrador')
				,('M�dico')
				,('Paciente');

--inserimos os dados da Cl�nica
INSERT INTO		Clinica(cnpj, razaoSocial, enderecoClinica, horario)
VALUES			('86400902000130', 'SP Medical Group', 'Av. Bar�o Limeira, 532, S�o Paulo, SP', '12:00 at� 23:00');

--inserimos os nomes das especialidades
INSERT INTO		Especialidade(nomeEspecialidade)
VALUES			('Acupuntura')
				,('Anestesiologia')
				,('Angiologia')
				,('Cardiologia')
				,('Cirurgia Cardiovascular')
				,('Cirurgia de M�o')
				,('Cirurgia do Aparelho Digestivo')
				,('Cirurgia Geral')
				,('Cirurgia Pedi�trica')
				,('Cirurgia Pl�stica')
				,('Cirurgia Tor�cica')
				,('Cirurgia Vascular')
				,('Dermatologia')
				,('Radioterapia')
				,('Urologia')
				,('Pediatria')
				,('Psiquiatria');

--inserimos os usu�rios e seus dados
INSERT INTO		Usuario(idTipoUsuario, email, senha)
VALUES			(3,'ligia@gmail.com','12345')
				,(3,'alexandre@gmail.com','56789')
				,(3,'fernando@gmail.com','11111')
				,(3,'henrique@gmail.com','22222')
				,(3,'joao@hotmail.com','33333')
				,(3,'bruno@gmail.com','44444')
				,(3,'mariana@outlook.com','55555')
				,(2,'ricardo.lemos@spmedicalgroup.com.br','66666')
				,(2,'roberto.possarle@spmedicalgroup.com.br','77777')
				,(2,'helene.strada@spmedicalgroup.com.br','88888')
				,(1,'admin@admin.com.br','99999')

--inserimos as informa��es do prontu�rio
INSERT INTO		Paciente(idUsuario, nomePaciente, rg, cpf, dataNascimento, telefonePaciente, enderecoPaciente)
VALUES			(1,'Ligia','435225435','94839859000','13/10/1983', '1134567654', 'Rua Estado de Israel 240, S�o Paulo, Estado de S�o Paulo, 04022-000')
				,(2, 'Alexandre', '326543457', '73556944057','23/07/2001', '11987656543', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200')
				,(3,'Fernando','546365253','16839338002', '10/10/1978','11972084453', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200')
				,(4,'Henrique','543663625','14332654765', '13/10/1985','1134566543', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
				,(5,'Jo�o','325444441','91305348010', '27/08/1975','1176566377', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380') 
				,(6,'Bruno','545662667','79799299004', '21/03/1972','11954368769', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001')
				,(7,'Mariana','545662668','13771913039', '05/03/2018',  NULL, 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');

--inserimos as informa��es dos m�dicos
INSERT INTO		Medico(idUsuario, idClinica, idEspecialidade, nomeMedico,crm)
VALUES			(8, 1, 3, 'Ricardo Lemos', '54356SP')
				,(9, 1, 17,'Roberto Possarle','53452SP')
				,(10, 1, 16,'Helena Strada','65463SP');

--inserimos as informa��es das consultas
INSERT INTO		Consulta(idPaciente, idMedico, dataConsulta, situacao, descricao)
VALUES			(7, 3, '20/01/2020  15:00:00', 'Realizada', 'est� bem!')
				,(2, 2, '01/06/2020 10:00:00','Cancelada', NULL)
				,(3, 2,'02/07/2020  11:00:00','Realizada', 'est� bem!')
				,(2, 2,'02/06/2018  10:00:00','Realizada', 'est� bem!')
				,(4, 1,'02/07/2019  11:00:00','Cancelada', NULL)
				,(7, 3,'03/08/2020  15:00:00','Agendada', NULL)
				,(4, 1,'03/09/2020  11:00:00','Agendada', NULL);


