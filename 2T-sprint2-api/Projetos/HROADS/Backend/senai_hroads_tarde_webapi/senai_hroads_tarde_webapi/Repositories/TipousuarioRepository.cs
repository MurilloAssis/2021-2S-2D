using senai_hroads_tarde_webapi.Contexts;
using senai_hroads_tarde_webapi.Domains;
using senai_hroads_tarde_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Repositories
{
    public class TipousuarioRepository : ITipousuarioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(byte id, Tipousuario tipousuarioAtt)
        {
            Tipousuario tipousuarioBuscado = ctx.Tipousuarios.Find(id);

            if (tipousuarioAtt.Titulo != null)
            {
                tipousuarioBuscado.Titulo = tipousuarioAtt.Titulo;

                ctx.Tipousuarios.Update(tipousuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Tipousuario BuscarPorId(byte id)
        {
            return ctx.Tipousuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(Tipousuario novotipoUsuario)
        {
            ctx.Tipousuarios.Add(novotipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            ctx.Tipousuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Tipousuario> ListarTodos()
        {
            return ctx.Tipousuarios.ToList();
        }
    }
}
