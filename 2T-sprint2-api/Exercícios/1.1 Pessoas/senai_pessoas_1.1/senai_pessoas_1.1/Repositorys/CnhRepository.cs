using senai_Cnhs_1._1.Interfaces;
using senai_pessoas_1._1.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_1._1.Repositorys
{
    public class CnhRepository : ICnhRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-VN6G9JR\SQLEXPRESS; initial catalog=EMPRESA; user Id=sa; pwd=#Murillo1#";
        public void AtualizarIdCorpo(CnhDomain CnhAtualizada)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(CnhDomain CnhAtualizada)
        {
            throw new NotImplementedException();
        }

        public CnhDomain BuscarPorId(int idCnh)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CnhDomain Cnh)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"INSERT INTO CNH (idPessoa, descricao) VALUES ({Cnh.idPessoa}, {Cnh.numCNH})";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCnh)
        {
            throw new NotImplementedException();
        }

        public List<CnhDomain> ListarTodos()
        {
            List<CnhDomain> listarCnh = new List<CnhDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idCnh id, descricao Cnh, idPessoa 'ID Dono' FROM Cnh";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        CnhDomain Cnh = new CnhDomain()
                        {
                            idPessoa = Convert.ToInt32(rdr[2]),
                            idCnh = Convert.ToInt32(rdr[0]),
                            numCNH = rdr[1].ToString()
                        };

                        listarCnh.Add(Cnh);
                    }



                }


            }

            return listarCnh;
        }
    }
}
