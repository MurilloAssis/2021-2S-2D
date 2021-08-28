using senai_pessoas_1._1.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Telefones_1._1.Interfaces
{
    interface ITelefoneRepository
    {
        void Cadastrar(TelefoneDomain Telefone);

        List<TelefoneDomain> ListarTodos();

        TelefoneDomain BuscarPorId(int idTelefone);

        void AtualizarIdCorpo(TelefoneDomain TelefoneAtualizada);

        void AtualizarIdUrl(TelefoneDomain TelefoneAtualizada);

        void Deletar(int idTelefone);
    }
}
