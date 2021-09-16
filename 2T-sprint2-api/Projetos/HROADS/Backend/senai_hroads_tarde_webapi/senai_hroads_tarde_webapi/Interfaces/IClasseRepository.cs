using senai_hroads_tarde_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Interfaces
{
    interface IClasseRepository
    {
        List<Classe> ListarTodos();

        void Cadastrar(Classe novaClasse);

        void Deletar(byte id);

        Classe BuscarPorId(byte id);

        void Atualizar(byte id, Classe classeAtualizada);
    }
}
