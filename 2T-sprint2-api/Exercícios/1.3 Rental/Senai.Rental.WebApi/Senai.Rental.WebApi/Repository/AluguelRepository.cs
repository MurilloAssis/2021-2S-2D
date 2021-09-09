using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repository
{

    public class AluguelRepository : IAluguelRepository
    {
        string stringConexao = @"Data Source=DESKTOP-CV21P6P\SQLEXPRESS; initial catalog=T_RENTAL; user Id=sa; pwd=#Murillo1#";

        public void Atualizar(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE ALUGUEL SET idVeiculo = @idVeiculo, idEmpresa = @idEmpresa, idCliente = @idCliente WHERE idAluguel = @idAluguel";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@idEmpresa", aluguelAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            AluguelDomain aluguelBuscado = new AluguelDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, A.idCliente, nomeCliente, A.idVeiculo, V.idModelo, nomeModelo, M.idMarca, nomeMarca, A.idEmpresa, nomeEmpresa, dataAluguel, dataDevol, sobrenomeCliente, placa FROM ALUGUEL A INNER JOIN CLIENTE C ON A.idCliente = C.idCliente INNER JOIN VEICULO V ON A.idVeiculo = V.idVeiculo INNER JOIN MODELO M ON V.idModelo = M.idModelo INNER JOIN MARCA MA ON M.idMarca = MA.idMarca INNER JOIN EMPRESA E ON A.idEmpresa = E.idEmpresa WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        aluguelBuscado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            idVeiculo = Convert.ToInt32(rdr[3]),
                            idEmpresa = Convert.ToInt32(rdr[8]),
                            DataAluguel = Convert.ToDateTime(rdr[10]),
                            DataDev = Convert.ToDateTime(rdr[11]),
                            ClienteDomain = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(rdr[1]),
                                nomeCliente = rdr[2].ToString(),
                                sobrenomeCliente = rdr[12].ToString()
                            },
                            VeiculoDomain = new VeiculoDomain()
                            {
                                idVeiculo = Convert.ToInt32(rdr[3]),
                                idModelo = Convert.ToInt32(rdr[4]),
                                idEmpresa = Convert.ToInt32(rdr[8]),
                                placa = rdr[13].ToString(),
                                modeloDomain = new ModeloDomain()
                                {
                                    idModelo = Convert.ToInt32(rdr[4]),
                                    nomeModelo = rdr[5].ToString(),
                                    idMarca = Convert.ToInt32(rdr[6]),
                                    marcaDomain = new MarcaDomain()
                                    {
                                        idMarca = Convert.ToInt32(rdr[6]),
                                        nomeMarca = rdr[7].ToString()
                                    }
                                },
                                empresaDomain = new EmpresaDomain()
                                {
                                    idEmpresa = Convert.ToInt32(rdr[8]),
                                    nomeEmpresa = rdr[9].ToString()
                                }
                            },
                            EmpresaDomain = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr[8]),
                                nomeEmpresa = rdr[9].ToString()
                            }
                        };
                    }
                        return aluguelBuscado;
                    
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAlugel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idVeiculo, idCliente, idEmpresa, DataAluguel, DataDevol) VALUES (@idVeiculo, @idCliente, @idEmpresa, @DataAluguel, @DataDevol)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAlugel.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", novoAlugel.idCliente);
                    cmd.Parameters.AddWithValue("@idEmpresa", novoAlugel.idEmpresa);
                    cmd.Parameters.AddWithValue("@DataAluguel", novoAlugel.DataAluguel);
                    cmd.Parameters.AddWithValue("@DataDevol", novoAlugel.DataDev);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAluguel = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idAluguel, A.idCliente, nomeCliente, A.idVeiculo, V.idModelo, nomeModelo, M.idMarca, nomeMarca, A.idEmpresa, nomeEmpresa, dataAluguel, dataDevol, sobrenomeCliente, placa FROM ALUGUEL A INNER JOIN CLIENTE C ON A.idCliente = C.idCliente INNER JOIN VEICULO V ON A.idVeiculo = V.idVeiculo INNER JOIN MODELO M ON V.idModelo = M.idModelo INNER JOIN MARCA MA ON M.idMarca = MA.idMarca INNER JOIN EMPRESA E ON A.idEmpresa = E.idEmpresa";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain ALUGUEL = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            idVeiculo = Convert.ToInt32(rdr[3]),
                            idEmpresa = Convert.ToInt32(rdr[8]),
                            DataAluguel = Convert.ToDateTime(rdr[10]),
                            DataDev = Convert.ToDateTime(rdr[11]),
                            ClienteDomain = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(rdr[1]),
                                nomeCliente = rdr[2].ToString(),
                                sobrenomeCliente = rdr[12].ToString()
                            },
                            VeiculoDomain = new VeiculoDomain()
                            {
                                idVeiculo = Convert.ToInt32(rdr[3]),
                                idModelo = Convert.ToInt32(rdr[4]),
                                idEmpresa = Convert.ToInt32(rdr[8]),
                                placa = rdr[13].ToString(),
                                modeloDomain = new ModeloDomain()
                                {
                                    idModelo = Convert.ToInt32(rdr[4]),
                                    nomeModelo = rdr[5].ToString(),
                                    idMarca = Convert.ToInt32(rdr[6]),
                                    marcaDomain = new MarcaDomain()
                                    {
                                        idMarca = Convert.ToInt32(rdr[6]),
                                        nomeMarca = rdr[7].ToString()
                                    }
                                },
                                empresaDomain = new EmpresaDomain()
                                {
                                    idEmpresa = Convert.ToInt32(rdr[8]),
                                    nomeEmpresa = rdr[9].ToString()
                                }
                            },
                            EmpresaDomain = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr[8]),
                                nomeEmpresa = rdr[9].ToString()
                            }

                        };
                        listaAluguel.Add(ALUGUEL);
                        return listaAluguel;
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
