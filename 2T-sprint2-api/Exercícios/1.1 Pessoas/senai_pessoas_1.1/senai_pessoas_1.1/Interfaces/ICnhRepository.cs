using senai_pessoas_1._1.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Cnhs_1._1.Interfaces
{
    interface ICnhRepository
    {
        void Cadastrar(CnhDomain Cnh);

        List<CnhDomain> ListarTodos();

        CnhDomain BuscarPorId(int idCnh);

        void AtualizarIdCorpo(CnhDomain CnhAtualizada);

        void AtualizarIdUrl(CnhDomain CnhAtualizada);

        void Deletar(int idCnh);
    }
}
