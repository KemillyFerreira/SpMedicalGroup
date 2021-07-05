using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "O campo situação é obrigatório!")]
        public string Situacao { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
