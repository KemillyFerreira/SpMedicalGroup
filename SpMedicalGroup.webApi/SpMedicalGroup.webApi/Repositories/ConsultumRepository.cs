using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.webApi.Contexts;
using SpMedicalGroup.webApi.Domains;
using SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpMedicalGroup.webApi.Repositories
{
    public class ConsultumRepository : IConsultumRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// busca e atualiza as informações das consultas
        /// </summary>
        /// <param name="id"> id da consulta requisitada </param>
        /// <param name="consultumAtualizada"> consulta com as novas informações </param>
        public void Atualizar(int id, Consultum consultumAtualizada)
        {
            // busca uma consulta através do id
            Consultum consultaBuscada = ctx.Consulta.Find(id);

            // verifica se o id do usuario foi informado
            if (consultumAtualizada.IdPaciente != null)
            {
                consultaBuscada.IdPaciente = consultumAtualizada.IdPaciente;
            }

            // verifica se o id do médico foi informado
            if (consultumAtualizada.IdMedico != null)
            {
                consultaBuscada.IdMedico = consultumAtualizada.IdMedico;
            }      

            // verifica se a situação da consulta foi informada
            if (consultumAtualizada.Situacao != null )
            {
                consultaBuscada.Situacao = consultumAtualizada.Situacao;      
            }

            // verifica se a descrição da consulta foi informada
            if(consultumAtualizada.Descricao !=null)
            {
                consultaBuscada.Descricao = consultumAtualizada.Descricao;
            }

            // verifica se a data da consulta foi informada
            if(consultumAtualizada.DataConsulta > DateTime.Now)
            {
                consultaBuscada.DataConsulta = consultumAtualizada.DataConsulta;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }


        /// <summary>
        /// cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsultum"></param>
        public void Cadastrar(Consultum novaConsultum)
        {
            // adicionando uma nova consulta
            ctx.Consulta.Add(novaConsultum);

            //salva as novas informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }


        /// <summary>
        ///  lista todas as consultas, sem exceção
        /// </summary>
        /// <returns></returns>
        public List<Consultum> Listar() 
        {
            return ctx.Consulta.ToList();
        }


        /// <summary>
        /// vai listar apenas as consultas de um determinado usuário
        /// </summary>
        /// <param name="id"> id do usuário que terá as consultas listadas</param>
        /// <returns> lista de consultas </returns>
        public List<Consultum> ListarMinhasConsultas(int id)
        {
            return ctx.Consulta
                
                //include -> "entra" nas tabelas 

                // traz as informações da tabela paciente
                .Include(p => p.IdPacienteNavigation)

                // traz as informações da tabela medico
                .Include(p => p.IdMedicoNavigation)

                // traz as informações da tabela medico e "filtra" para as informações do usuário
                .Include(p => p.IdMedicoNavigation.IdUsuarioNavigation)

                // traz as informações da tabela paciente mais o id do usuario
                .Include(p => p.IdPacienteNavigation.IdUsuarioNavigation)

                // estabelece o id como parâmetro 
                .Where(p => p.IdConsulta == id)
                .ToList(); 
        }
    }
}
