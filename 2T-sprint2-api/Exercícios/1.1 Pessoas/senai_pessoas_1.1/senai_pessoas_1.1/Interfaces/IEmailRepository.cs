using senai_pessoas_1._1.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Emails_1._1.Interfaces
{
    interface IEmailRepository
    {
        void Cadastrar(EmailDomain Email);

        List<EmailDomain> ListarTodos();

        EmailDomain BuscarPorId(int idEmail);

        void AtualizarIdCorpo(EmailDomain EmailAtualizada);

        void AtualizarIdUrl(EmailDomain EmailAtualizada);

        void Deletar(int idEmail);
    }
}
