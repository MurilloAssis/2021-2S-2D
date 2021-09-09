using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repository
{
    public class VeiculoRepository : IVeiculoRepositorycs
    {
        string stringConexao = @"Data Source=DESKTOP-CV21P6P\SQLEXPRESS; initial catalog=T_RENTAL; user Id=sa; pwd=#Murillo1#";
        public void Atualizar(int idVeiculo, VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE VEICULO SET placa = @placa, idModelo = @idModelo, idEmpresa = @idEmpresa WHERE idVeiculo = @idVeiculo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@placa", VeiculoAtualizado.placa);
                    cmd.Parameters.AddWithValue("@idModelo", VeiculoAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@idEmpresa", VeiculoAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            VeiculoDomain veiculoBuscar = new VeiculoDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idVeiculo, V.idEmpresa, V.idModelo, nomeMarca, nomeModelo, nomeEmpresa, placa, M.idMarca FROM VEICULO V INNER JOIN EMPRESA E ON V.idEmpresa = E.idEmpresa INNER JOIN MODELO M ON V.idModelo = M.idModelo INNER JOIN MARCA MA ON M.idMarca = MA.idMarca WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        veiculoBuscar.idVeiculo = Convert.ToInt32(rdr[0]);
                        veiculoBuscar.idEmpresa = Convert.ToInt32(rdr[1]);
                        veiculoBuscar.idModelo = Convert.ToInt32(rdr[2]);
                        veiculoBuscar.placa = rdr[6].ToString();
                        veiculoBuscar.modeloDomain = new ModeloDomain()
                        {
                            idModelo = Convert.ToInt32(rdr[2]),
                            idMarca = Convert.ToInt32(rdr[7]),
                            nomeModelo = rdr[4].ToString(),
                            marcaDomain = new MarcaDomain()
                            {
                                idMarca = Convert.ToInt32(rdr[7]),
                                nomeMarca = rdr[3].ToString()
                            }
                        };
                        veiculoBuscar.empresaDomain = new EmpresaDomain()
                        {
                            idEmpresa = Convert.ToInt32(rdr[1]),
                            nomeEmpresa = rdr[5].ToString()
                        };
                        return (veiculoBuscar);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Veiculo (PLACA, idModelo, idEmpresa) VALUES (@placa, @idModelo, @idEmpresa)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@placa", novoVeiculo.placa);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVEICULO = @idVeiculo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculo = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idVeiculo, V.idEmpresa, nomeEmpresa, V.idModelo, M.idMarca, nomeMarca, nomeModelo, placa FROM VEICULO V INNER JOIN EMPRESA E ON V.idEmpresa = E.idEmpresa INNER JOIN MODELO M ON V.idModelo = M.idModelo INNER JOIN MARCA MA ON M.idMarca = MA.idMarca";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain Veiculo = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            idEmpresa = Convert.ToInt32(rdr[1]),
                            idModelo = Convert.ToInt32(rdr[3]),
                            placa = rdr[7].ToString(),
                            empresaDomain = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr[1]),
                                nomeEmpresa = rdr[2].ToString()
                            },
                            modeloDomain = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(rdr[3]),
                                idMarca = Convert.ToInt32(rdr[4]),
                                nomeModelo = rdr[6].ToString(),
                                marcaDomain = new MarcaDomain()
                                {
                                    idMarca = Convert.ToInt32(rdr[4]),
                                    nomeMarca = rdr[5].ToString()
                                }
                            }
                        };
                        listaVeiculo.Add(Veiculo);
                    }
                        return listaVeiculo;
                    
                }


            }

        }
    }
}
