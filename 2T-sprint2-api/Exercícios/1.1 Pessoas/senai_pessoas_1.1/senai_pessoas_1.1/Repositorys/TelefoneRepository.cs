using senai_pessoas_1._1.Domains;
using senai_Telefones_1._1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_1._1.Repositorys
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-VN6G9JR\SQLEXPRESS; initial catalog=EMPRESA; user Id=sa; pwd=#Murillo1#";
        public void AtualizarIdCorpo(TelefoneDomain TelefoneAtualizada)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(TelefoneDomain TelefoneAtualizada)
        {
            throw new NotImplementedException();
        }

        public TelefoneDomain BuscarPorId(int idTelefone)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TelefoneDomain Telefone)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"INSERT INTO TELEFONE (idPessoa, numeroTelefone) VALUES ({Telefone.idPessoa}, {Telefone.numTelefone})";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idTelefone)
        {
            throw new NotImplementedException();
        }

        public List<TelefoneDomain> ListarTodos()
        {
            List<TelefoneDomain> listarTelefone = new List<TelefoneDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idTelefone id, numeroTelefone Telefone, idPessoa 'ID Dono' FROM TELEFONE";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TelefoneDomain TELEFONE = new TelefoneDomain()
                        {
                            idPessoa = Convert.ToInt32(rdr[2]),
                            idTelefone = Convert.ToInt32(rdr[0]),
                            numTelefone = rdr[1].ToString()
                        };

                        listarTelefone.Add(TELEFONE);
                    }


                    
                }


            }

            return listarTelefone;
        }
    }
}
