using Microsoft.EntityFrameworkCore;
using senai_hroads_tarde_webapi.Contexts;
using senai_hroads_tarde_webapi.Domains;
using senai_hroads_tarde_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        
        InLockContext ctx = new InLockContext();
        public void Atualizar(byte id, Usuario usuarioAtt)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);
            if (usuarioAtt.Email != null || usuarioAtt.Senha != null || usuarioAtt.IdTipoUsuario != null)
            {
                usuarioBuscado.Email = usuarioAtt.Email;
                usuarioBuscado.Senha = usuarioAtt.Senha;
                usuarioBuscado.IdTipoUsuario = usuarioAtt.IdTipoUsuario;

                ctx.Usuarios.Update(usuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(byte id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.Include(h => h.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
          
            return ctx.Usuarios.FirstOrDefault(e => e.Email == Email && e.Senha == Senha);



        }
    }
}
