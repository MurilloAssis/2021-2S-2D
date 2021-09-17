using Microsoft.EntityFrameworkCore;
using senai_hroads_tarde_webapi.Contexts;
using senai_hroads_tarde_webapi.Domains;
using senai_hroads_tarde_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Repositories
{
    public class TipoHabilidadeRepository : ITipohabilidadeRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(byte id, Tipohabilidade tipoHabAtt)
        {
            Tipohabilidade tipoHabBuscado = BuscarPorId(id);

            if (tipoHabAtt.NomeTipoHabilidade != null || id > 0)
            {
                tipoHabBuscado.NomeTipoHabilidade = tipoHabAtt.NomeTipoHabilidade;
                

                ctx.Tipohabilidades.Update(tipoHabBuscado);

                ctx.SaveChanges();
            }

        }

        public Tipohabilidade BuscarPorId(byte id)
        {
            return ctx.Tipohabilidades.FirstOrDefault(e => e.IdTipoHabilidade == id);
        }

        public void Cadastrar(Tipohabilidade novoTipoHab)
        {
            ctx.Tipohabilidades.Add(novoTipoHab);

            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            ctx.Tipohabilidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Tipohabilidade> ListarTodos()
        {
            return ctx.Tipohabilidades.Include(e => e.Habilidades).ToList();
        }
    }
}
