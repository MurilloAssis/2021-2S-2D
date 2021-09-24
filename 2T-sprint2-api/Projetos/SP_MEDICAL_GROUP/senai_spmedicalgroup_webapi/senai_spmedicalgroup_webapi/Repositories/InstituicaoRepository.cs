using senai_spmedicalgroup_webapi.Contexts;
using senai_spmedicalgroup_webapi.Domains;
using senai_spmedicalgroup_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webapi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();
        public Instituicao BuscarClinica()
        {
            throw new NotImplementedException();
        }

        public void CadastrarClinica(Instituicao novaClinica)
        {
            ctx.Instituicaos.Add(novaClinica);

            ctx.SaveChanges();
        }
    }
}
