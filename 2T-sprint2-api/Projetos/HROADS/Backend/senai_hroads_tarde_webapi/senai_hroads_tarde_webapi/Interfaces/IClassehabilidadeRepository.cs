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

        void Cadastrar(Classehabilidade novaClasseHabilidade);

        void Deletar(byte id);

        Classehabilidade BuscarPorId(byte id);

        void Atualizar(short id, Classehabilidade classeHabilidadeAtualizada);
    }
}
