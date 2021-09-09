using senai_filme_webAPI.Domains;
using senai_filme_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Repositories
{

    /// <summary>
    /// Classe reponsavel pelo repositorio dos GENEROS
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// 
        /// </summary>

        private string stringConexao = @"Data Source=DESKTOP-CV21P6P\SQLEXPRESS; initial catalog=CATALOGO; user Id=sa; pwd=#Murillo1#";

        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdBody = "UPDATE GENERO SET nomeGenero = @novoNome WHERE idGenero = @idGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", generoAtualizado.nomeGenero);
                    cmd.Parameters.AddWithValue("@idGenero", generoAtualizado.idGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            if (generoAtualizado.nomeGenero != null)
            {

                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateIdURL = "UPDATE GENERO SET nomeGenero = @novoNome WHERE idGenero = @idGenero";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUpdateIdURL, con))
                    {
                        cmd.Parameters.AddWithValue("@novoNome", generoAtualizado.nomeGenero);
                        cmd.Parameters.AddWithValue("@idGenero", idGenero);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            GeneroDomain generoBuscar = new GeneroDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySerchById = "SELECT idGenero, nomeGenero FROM GENERO WHERE idGenero = @idGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySerchById, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        generoBuscar.idGenero = Convert.ToInt32(rdr[0]);
                        generoBuscar.nomeGenero = rdr[1].ToString();
                        return generoBuscar;
                    }
                    else
                    {
                        return null;
                    }
                    
                }
                    
            }
        }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="novoGenero">Objeto nomeGenero com as informações a serem cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"Insert Into genero(nomeGenero) values (@nomeGenero)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeGenero", novoGenero.nomeGenero);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeleteById = "DELETE FROM GENERO WHERE idGenero = @idGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDeleteById, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Listar todos os generos
        /// </summary>
        /// <returns>Uma Lista de Generos</returns>

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            //
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idGenero,nomeGenero FROM GENERO";

                //ABRE A CONEXAO COM O BANCO DE DADOS
                con.Open();

                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexao com parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        //

                        GeneroDomain GENERO = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            nomeGenero = rdr[1].ToString()
                        };

                        listaGenero.Add(GENERO);

                    }
                       
                }
            }
            return listaGenero;
        }
    }
}
