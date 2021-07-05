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
                // faz a chamada para o método
                _consultumRepository.Cadastrar(novaConsultum);

                // retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //retorna a exception w um status code 400 - Bad Request
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// atualiza uma consulta existente
        /// </summary>
        /// <param name="id"> id da consulta que será atualizada </param>
        /// <param name="consultumAtualizada"> objeto com as novas informações </param>
        /// <returns> um status code 204 - No Content </returns>
        [HttpPut("{id}")]

        public IActionResult Put(int id, Consultum consultumAtualizada)
        {
            try
            {
                //faz a chamada para o método
                _consultumRepository.Atualizar(id, consultumAtualizada);

                return StatusCode(204);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}