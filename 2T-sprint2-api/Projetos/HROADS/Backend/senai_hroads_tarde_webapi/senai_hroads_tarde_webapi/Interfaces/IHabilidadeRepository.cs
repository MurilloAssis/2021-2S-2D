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

        void Cadastrar(Habilidade novaHabilidade);

        void Deletar(byte id);

        Habilidade BuscarPorId(byte id);

        void Atualizar(byte id, Habilidade habilidadeAtualizada);
    }
}
