using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepositorycs
    {
        List<VeiculoDomain> ListarTodos();

        VeiculoDomain BuscarPorId(int idGenero);

        void Cadastrar(VeiculoDomain novoAlugel);

        void Atualizar(int idGenero, VeiculoDomain VeiculoAtualizado);

        void Deletar(int idGenero);
    }
}
