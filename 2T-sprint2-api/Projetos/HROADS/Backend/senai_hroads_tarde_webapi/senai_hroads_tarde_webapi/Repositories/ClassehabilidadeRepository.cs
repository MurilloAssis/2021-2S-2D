using senai_hroads_tarde_webapi.Contexts;
using senai_hroads_tarde_webapi.Domains;
using senai_hroads_tarde_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Repositories
{
    public class ClassehabilidadeRepository : IClassehabilidadeRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(short id, Classehabilidade classeHabilidadeAtualizada)
        {
            Classehabilidade classeHabilidadeBuscada = ctx.Classehabilidades.Find(id);

            if (classeHabilidadeAtualizada.IdClasse != null)
            {
                classeHabilidadeBuscada.IdClasse = classeHabilidadeAtualizada.IdClasse;
                classeHabilidadeBuscada.IdHabilidade = classeHabilidadeAtualizada.IdHabilidade;

                ctx.Classehabilidades.Update(classeHabilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public Classehabilidade BuscarPorId(byte id)
        {
            return ctx.Classehabilidades.FirstOrDefault(e => e.IdClasseHabilidade == id);
        }

        public void Cadastrar(Classehabilidade novaClasseHabilidade)
        {
            ctx.Classehabilidades.Add(novaClasseHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            ctx.Classehabilidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Classehabilidade> ListarTodos()
        {
            return ctx.Classehabilidades.ToList();
        }
    }
}
