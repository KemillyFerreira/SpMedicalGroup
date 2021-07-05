using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.webApi.Interfaces;
using SpMedicalGroup.webApi.Repositories;
using SpMedicalGroup.webApi.ViewModels;
using SpMedicalGroup.webApi.Domains;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;

namespace SpMedicalGroup.webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// cria o objeto _usuarioRepository para receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }


        /// <summary>
        /// instancia esse objeto para que haja referência aos métodos do repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post (LoginViewModel login)
        {
            try
            {
                //busca o usuário pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                //caso não encontre nenhum usuário com o e-mail e senha informados
                if (usuarioBuscado == null)
                {
                    //retorna NotFound com uma mensagem de erro
                    return NotFound("E-mail ou senha inválidos!");
                }

                //se o usuário for encontrado, segue para a criação do Token


                //define os dados que serão fornecidos no token
                var claims = new[]
                {
                    // armazena na Claim o E-mail do usuario do autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // armazena na Claim o id do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // armazena na claim o tipo de usuário que foi autenticado (administrador ou comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    // armazena na Claim o tipo de usuário que foi autenticado (adminsitrador ou comum) de forma personalizada
                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),
                };

                // define a chave de acesso ao Token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("med-chave-autenticacao"));

                // define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // gera o token
                var token = new JwtSecurityToken(
                    issuer: "SpMedicalGroup.webApi",             // emissor do token
                    audience: "SpMedicalGroup.webApi",          //destinatário do token
                    claims: claims,                             //dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),   // tempo de expiração
                    signingCredentials: creds                   // credenciais do token
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            }
        }     
    }

