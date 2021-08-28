using senai_pessoas_1._1.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_1._1.Interfaces
{
    interface IPessoaRepository
    {
        void Cadastrar(PessoaDomain pessoa);

        List<PessoaDomain> ListarTodos();

        PessoaDomain BuscarPorId(int idPessoa);

        void AtualizarIdCorpo(PessoaDomain PessoaAtualizada);

        void AtualizarIdUrl(PessoaDomain PessoaAtualizada);

        void Deletar(int idPessoa);
    }
}
