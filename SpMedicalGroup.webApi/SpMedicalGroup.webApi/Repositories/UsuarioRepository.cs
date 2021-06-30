using SpMedicalGroup.webApi.Contexts;
using SpMedicalGroup.webApi.Domains;
using SpMedicalGroup.webApi.Interfaces;
using System.Linq;

namespace SpMedicalGroup.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// validação do usuário
        /// </summary>
        /// <param name="email"> e-mail do usuário </param>
        /// <param name="senha"> senha do usuário </param>
        /// <returns></returns>
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
