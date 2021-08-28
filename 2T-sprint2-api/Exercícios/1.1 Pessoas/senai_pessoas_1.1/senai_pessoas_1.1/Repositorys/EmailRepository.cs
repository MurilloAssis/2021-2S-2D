using senai_Emails_1._1.Interfaces;
using senai_pessoas_1._1.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_1._1.Repositorys
{
    public class EmailRepository : IEmailRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-VN6G9JR\SQLEXPRESS; initial catalog=EMPRESA; user Id=sa; pwd=#Murillo1#";
        public void AtualizarIdCorpo(EmailDomain EmailAtualizada)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(EmailDomain EmailAtualizada)
        {
            throw new NotImplementedException();
        }

        public EmailDomain BuscarPorId(int idEmail)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(EmailDomain Email)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"INSERT INTO EMAIL (idPessoa, enderecoEmail) VALUES ({Email.idPessoa}, '{Email.endEmail}')";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idEmail)
        {
            throw new NotImplementedException();
        }

        public List<EmailDomain> ListarTodos()
        {
            List<EmailDomain> listarEmail = new List<EmailDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEmail id, enderecoEmail, idPessoa FROM EMAIL";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EmailDomain EMAIL = new EmailDomain()
                        {
                            idPessoa = Convert.ToInt32(rdr[2]),
                            idEmail = Convert.ToInt32(rdr[0]),
                            endEmail = rdr[1].ToString()
                        };

                        listarEmail.Add(EMAIL);
                    }



                }


            }

            return listarEmail;
        }
    }
}
