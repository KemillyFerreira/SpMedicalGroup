using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.webApi.Domains;
using SpMedicalGroup.webApi.Interfaces;
using SpMedicalGroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class ConsultumController : ControllerBase
    {
        /// <summary>
        /// o objeto _consultumRepository vai receber todos os métodos definidos na interface 
        /// </summary>
        private IConsultumRepository _consultumRepository { get; set; }

        /// <summary>
        ///  instancia o objeto _consultumRepository para ter referência aos métodos do repositório
        /// </summary>
        public ConsultumController()
        {
            _consultumRepository = new ConsultumRepository();
        }


        /// <summary>
        /// lista todas as consultas
        /// </summary>
        /// <returns> uma lista de consultas e um status code 200 - Ok </returns>
        [HttpGet]
        
        public IActionResult Get()
        {
            //se tudo dar certo
            try
            {
                // retorna a repsosta da requisiçlão fazendo a chamada para o método
                return Ok(_consultumRepository.Listar());
            }
            // caso haja algum erro
            catch (Exception ex)
            {
                // retorna a exception e um status code 400 - Bad Request
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsultum"> é o objeto novaConsultum que será cadastrado</param>
        /// <returns> um status code -Created</returns>
        [HttpPost]
        
        public IActionResult Post(Consultum novaConsultum)
        {
            try
            {
                _consultumRepository.Cadastrar(novaConsultum);

                return StatusCode(201);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
