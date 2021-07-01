using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O campo e-mail deve ser preenchido para cadastrar um usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha deve ser preenchido para cadastrar um usuário!")]
        

        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
