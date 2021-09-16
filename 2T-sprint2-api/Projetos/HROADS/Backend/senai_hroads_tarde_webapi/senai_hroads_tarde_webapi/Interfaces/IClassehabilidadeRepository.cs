using senai_hroads_tarde_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Interfaces
{
    interface IClassehabilidadeRepository
    {
        List<Classehabilidade> ListarTodos();

        void Cadastrar();

        void Deletar();

        Classehabilidade BuscarPorId();

        void Atualizar();
    }
}
