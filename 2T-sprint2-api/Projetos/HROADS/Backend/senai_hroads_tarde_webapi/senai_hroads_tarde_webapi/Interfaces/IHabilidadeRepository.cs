using senai_hroads_tarde_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> ListarTodos();

        void Cadastrar();

        void Deletar();

        Habilidade BuscarPorId();

        void Atualizar();
    }
}
