using senai_hroads_tarde_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagem> ListarTodos();

        void Cadastrar(Personagem novoPerso);

        void Deletar(byte id);

        Personagem BuscarPorId(byte id);

        void Atualizar(byte id, Personagem persoAtt);
    }
}
