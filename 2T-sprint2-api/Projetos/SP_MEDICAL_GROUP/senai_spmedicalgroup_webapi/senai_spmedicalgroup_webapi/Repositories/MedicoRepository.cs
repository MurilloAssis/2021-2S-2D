using senai_spmedicalgroup_webapi.Contexts;
using senai_spmedicalgroup_webapi.Domains;
using senai_spmedicalgroup_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webapi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();
        public List<Medico> ListarTodos()
        {
           return ctx.Medicos.ToList();
        }
    }
}
