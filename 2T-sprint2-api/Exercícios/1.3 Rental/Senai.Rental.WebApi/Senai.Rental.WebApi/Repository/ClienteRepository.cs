using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        string stringConexao = @"Data Source=DESKTOP-CV21P6P\SQLEXPRESS; initial catalog=T_RENTAL; user Id=sa; pwd=#Murillo1#";
        public void Atualizar(int idGenero, ClienteDomain ClienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE CLIENTE SET nomeCliente = @nomeCliente, sobrenomeCliente = @sobrenomeCliente WHERE idCliente = @idCliente";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", ClienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", ClienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@idCliente", idGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            ClienteDomain clienteBuscar = new ClienteDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idCliente, nomeCliente, sobrenomeCliente FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        clienteBuscar.idCliente = Convert.ToInt32(rdr[0]);
                        clienteBuscar.nomeCliente = rdr[1].ToString();
                        clienteBuscar.sobrenomeCliente = rdr[2].ToString();
                    }
                        return clienteBuscar;
                    
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO CLIENTE (nomeCliente,sobrenomeCliente) VALUES (@nomeCliente, @sobrenomeCliente)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue(@"idCliente", idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaCliente = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idCliente, nomeCliente, sobrenomeCliente FROM CLIENTE";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain CLIENTE = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            sobrenomeCliente = rdr[2].ToString()
                        };
                        listaCliente.Add(CLIENTE);
                    }
                        return listaCliente;
                           
                }

               
            }

            
        }
    }
}
