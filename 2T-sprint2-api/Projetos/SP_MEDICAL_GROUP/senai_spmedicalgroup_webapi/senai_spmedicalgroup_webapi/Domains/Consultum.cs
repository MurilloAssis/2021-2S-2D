﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webapi.Domains
{
    public partial class Consultum
    {
        public short IdConsulta { get; set; }
        public short? IdMedico { get; set; }
        public short? IdSituacao { get; set; }
        public short? IdPaciente { get; set; }
        public DateTime DataConsulta { get; set; }
        public string? DescricaoConsulta { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
