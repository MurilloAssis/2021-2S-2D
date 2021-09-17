using senai_hroads_tarde_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Interfaces
{
    interface ITipohabilidadeRepository
    {
        List<Tipohabilidade> ListarTodos();

        void Cadastrar(Tipohabilidade novoTipoHab);

        void Deletar(byte id);

        Tipohabilidade BuscarPorId(byte id);

        void Atualizar(byte id, Tipohabilidade tipoHabAtt);
    }
}
