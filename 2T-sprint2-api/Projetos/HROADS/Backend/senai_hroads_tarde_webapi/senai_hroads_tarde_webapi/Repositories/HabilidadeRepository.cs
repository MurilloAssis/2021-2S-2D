using senai_hroads_tarde_webapi.Contexts;
using senai_hroads_tarde_webapi.Domains;
using senai_hroads_tarde_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(byte id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            if (habilidadeAtualizada.NomeHabilidade != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;

                ctx.Habilidades.Update(habilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public Habilidade BuscarPorId(byte id)
        {
            return ctx.Habilidades.FirstOrDefault(e => e.IdHabilidade == id);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            ctx.Habilidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTodos()
        {
            return ctx.Habilidades.ToList();
        }
    }
}
