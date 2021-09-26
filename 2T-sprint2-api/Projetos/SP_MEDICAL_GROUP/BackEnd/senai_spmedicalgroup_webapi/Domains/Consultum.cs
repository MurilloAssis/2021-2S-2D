using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmedicalgroup_webapi.Domains
{
    public partial class Consultum
    {
        [Key]
        public short IdConsulta { get; set; }
        [Required(ErrorMessage = "O Id do médico é necessário!")]
        public short? IdMedico { get; set; }
        public short? IdSituacao { get; set; }
        [Required(ErrorMessage = "O Id do paciente é necessário!")]
        public short? IdPaciente { get; set; }
        [Required(ErrorMessage = "A data da consulta")]
        public DateTime DataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
