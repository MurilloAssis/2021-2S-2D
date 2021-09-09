using senai_filme_webAPI.Domains;
using senai_filme_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-CV21P6P\SQLEXPRESS; initial catalog=CATALOGO; user Id=sa; pwd=#Murillo1#";

        public void AtualizarIdCorpo(FilmeDomain filmeAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdBody = "UPDATE FILME SET tituloFilme = @novoNome WHERE idFilme = @idFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", filmeAtualizado.tituloFilme);
                    cmd.Parameters.AddWithValue("@idFilme", filmeAtualizado.idFilme);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdURL = "UPDATE FILME SET tituloFilme = @novoNome WHERE idFilme = @idFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdURL, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", filmeAtualizado.tituloFilme);
                    cmd.Parameters.AddWithValue("@idFilme", idFilme);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int idFilme)
        {
            FilmeDomain buscarFilme = new FilmeDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idFilme, tituloFilme, F.idGenero, nomeGenero FROM FILME F INNER JOIN GENERO G ON F.idGenero = G.idGenero WHERE idFilme = @idFilme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idFilme", idFilme);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        buscarFilme.idFilme = Convert.ToInt32(rdr[0]);
                        buscarFilme.tituloFilme = rdr[1].ToString();
                        buscarFilme.idGenero = Convert.ToInt32(rdr[2]);
                        buscarFilme.genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[2]),
                            nomeGenero = rdr[3].ToString()
                        };
                        return (buscarFilme);
                    }
                    else
                    {
                        return null;
                    }
                   
                }
            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"Insert Into filme(idGenero, tituloFilme) values ('@idGenero, @tituloFilme')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", novoFilme.idGenero);
                    cmd.Parameters.AddWithValue("@tituloFilme", novoFilme.tituloFilme);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeleteById = "DELETE FROM FILME WHERE idFilme = @idFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDeleteById, con))
                {
                    cmd.Parameters.AddWithValue("@idFilme", idFilme);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listarFilme = new List<FilmeDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idFilme, ISNULL(FILME.idGenero,0), tituloFilme, nomeGenero FROM FILME LEFT JOIN GENERO ON FILME.idGenero = GENERO.idGenero";
                    


                con.Open();

                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain FILME = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            idGenero = Convert.ToInt32(rdr[1]),
                            tituloFilme = rdr[2].ToString(),
                            genero = new GeneroDomain()
                            {
                                idGenero = Convert.ToInt32(rdr[1]),
                                nomeGenero = rdr[3].ToString()
                            }
                    };

                        listarFilme.Add(FILME);

                    }
                }
            }
            return listarFilme;
        }
    }
}
