using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.webApi.Interfaces;

namespace SpMedicalGroup.webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]


    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]


    // Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    [Authorize(Roles = "2")]

    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IuUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

    }
}
