using senai_hroads_tarde_webapi.Contexts;
using senai_hroads_tarde_webapi.Domains;
using senai_hroads_tarde_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(byte id, Classe classeAtualizada)
        {
            Classe classeBuscada = ctx.Classes.Find(id);

            if (classeAtualizada.NomeClasse != null)
            {
                classeBuscada.NomeClasse = classeAtualizada.NomeClasse;

                ctx.Classes.Update(classeBuscada);

                ctx.SaveChanges();
            }
        }

        public Classe BuscarPorId(byte id)
        {
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == id);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);
            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            ctx.Classes.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Classe> ListarTodos()
        {
            return ctx.Classes.ToList();
        }
    }
}
