using senai_spmedicalgroup_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webapi.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();
    }
}
