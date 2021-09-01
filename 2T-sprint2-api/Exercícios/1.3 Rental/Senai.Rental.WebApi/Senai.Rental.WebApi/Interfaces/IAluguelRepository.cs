using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> ListarTodos();

        AluguelDomain BuscarPorId(int idGenero);

        void Cadastrar(AluguelDomain novoAlugel);

        void Atualizar(int idGenero, AluguelDomain aluguelAtualizado);

        void Deletar(int idGenero);
    }
}
