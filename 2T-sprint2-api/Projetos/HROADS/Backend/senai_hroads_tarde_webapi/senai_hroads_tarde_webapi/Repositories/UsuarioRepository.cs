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
        string stringConexao = @"Data Source=DESKTOP-CV21P6P\SQLEXPRESS; initial catalog=HROADS; user Id=sa; pwd=#Murillo1#;";
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
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT idUsuario, email, senha, idTipoUsuario
                                       FROM USUARIO 
                                       WHERE email = @email
                                       and senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@senha", Senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        Usuario usuarioBuscado = new Usuario()
                        {
                            IdUsuario = Convert.ToByte(rdr["idUsuario"]),
                            Email = rdr["email"].ToString(),
                            Senha = rdr["senha"].ToString(),
                            IdTipoUsuario = Convert.ToByte(rdr["idTipoUsuario"])
                        };
                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
