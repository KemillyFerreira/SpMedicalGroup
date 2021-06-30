using SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// validação do usuário
        /// </summary>
        /// <param name="email"> e-mail do usuario </param>
        /// <param name="senha"> senha do usuario </param>
        /// <returns></returns>
        Usuario Login(string email, string senha);
    }
}
