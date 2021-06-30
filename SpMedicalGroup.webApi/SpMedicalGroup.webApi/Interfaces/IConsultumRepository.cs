using SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Interfaces
{
    interface IConsultumRepository 
    {
        /// <summary>
        /// lista todos as consultas
        /// </summary>
        /// <returns> lista de consultas </returns>
        List<Consultum> Listar();


        /// <summary>
        /// cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsultum"> novaConsultum será o novo objeto cadastrado </param>
        void Cadastrar(Consultum novaConsultum);


        /// <summary>
        /// atualiza a descrição de uma determinada consulta 
        /// </summary>
        /// <param name="id"> busca uma consulta pelo id e atualiza </param>
        /// <param name="consultumAtualizada"> consulta com a nova descrição </param>
        void Atualizar(int id, Consultum consultumAtualizada);


        /// <summary>
        /// lista apenas as consultas de um determinado usuário
        /// </summary>
        /// <param name="id"> id do usuário que terá suas consultas listadas </param>
        /// <returns> retorna apenas as consultas do usuário buscado </returns>
        List<Consultum> ListarMinhasConsultas(int id);
    }
}
