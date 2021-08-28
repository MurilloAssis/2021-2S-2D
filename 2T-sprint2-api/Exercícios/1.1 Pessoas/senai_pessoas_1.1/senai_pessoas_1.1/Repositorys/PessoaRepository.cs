using senai_pessoas_1._1.Domains;
using senai_pessoas_1._1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_1._1.Repositorys
{
    public class PessoaRepository : IPessoaRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-VN6G9JR\SQLEXPRESS; initial catalog=EMPRESA; user Id=sa; pwd=#Murillo1#";
        public void AtualizarIdCorpo(PessoaDomain PessoaAtualizada)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(PessoaDomain PessoaAtualizada)
        {
            throw new NotImplementedException();
        }

        public PessoaDomain BuscarPorId(int idPessoa)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(PessoaDomain novaPessoa)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"INSERT INTO PESSOA (nomePessoa) VALUES ('{novaPessoa.nomePessoa}')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }


        }

        public void Deletar(int idPessoa)
        {
            throw new NotImplementedException();
        }

        public List<PessoaDomain> ListarTodos()
        {
            List<PessoaDomain> listarPessoa = new List<PessoaDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectAll = "SELECT P.idPessoa id, nomePessoa nome, ISNULL(idTelefone, 0) idTel, ISNULL(numeroTelefone, 'Não Cadastrado') Telefone, ISNULL(idEmail, 0) idEmail, ISNULL(enderecoEmail, 'Não Cadastrado') email, ISNULL(idCnh, 0), ISNULL(descricao, 'Não Cadastrado') FROM PESSOA P INNER JOIN TELEFONE T ON P.idPessoa = T.idTelefone INNER JOIN EMAIL E ON P.idPESSOA = E.idPessoa INNER JOIN CNH C ON P.idPessoa = C.idPessoa";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        PessoaDomain PESSOA = new PessoaDomain()
                        {
                            idPessoa = Convert.ToInt32(rdr[0]),
                            nomePessoa = rdr[1].ToString(),
                            telefone = new TelefoneDomain()
                            {
                                idTelefone = Convert.ToInt32(rdr[2]),
                                idPessoa = Convert.ToInt32(rdr[0]),
                                numTelefone = rdr[3].ToString()
                            },
                            email = new EmailDomain()
                            {
                                idEmail = Convert.ToInt32(rdr[4]),
                                idPessoa = Convert.ToInt32(rdr[0]),
                                endEmail = rdr[5].ToString()
                            },
                            cnh = new CnhDomain()
                            {
                                idCnh = Convert.ToInt32(rdr[6]),
                                idPessoa = Convert.ToInt32(rdr[0]),
                                numCNH = rdr[7].ToString()
                            }
                        };

                        listarPessoa.Add(PESSOA);
                    }
                }

            }
            return listarPessoa;
        }
    }
}
