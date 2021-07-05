using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.ViewModels
{
    /// <summary>
    /// classe responsável pelo modelo login
    /// </summary>
    public class LoginViewModel
    {
        // required -> define que a propriedade é obrigatória
        
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }

        
    }
}
