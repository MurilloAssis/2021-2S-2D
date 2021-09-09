using senai_filme_webAPI.Domains;
using senai_filme_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        string stringConexao = @"Data Source=DESKTOP-CV21P6P\SQLEXPRESS; initial catalog=CATALOGO; user Id=sa; pwd=#Murillo1#";
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            UsuarioDomain usuarioBuscado = new UsuarioDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySerchById = "SELECT * FROM USUARIOS WHERE email = @email and senha = @senha;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySerchById, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        usuarioBuscado.idUsuario = Convert.ToInt32(rdr[0]);
                        usuarioBuscado.email = rdr[1].ToString();
                        usuarioBuscado.senha = rdr[2].ToString();
                        usuarioBuscado.permissao = rdr[3].ToString();
                        return usuarioBuscado;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }
    }
}
