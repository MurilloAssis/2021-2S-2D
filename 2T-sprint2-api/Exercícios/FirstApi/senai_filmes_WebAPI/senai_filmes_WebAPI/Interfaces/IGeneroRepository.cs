using senai_filmes_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebAPI.Interfaces
{
    interface IGeneroRepository
    {
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero através de seu id
        /// </summary>
        /// <param name="idGenero">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado</returns>
        GeneroDomain BuscarPorId(int idGenero);

        void Cadastrar(GeneroDomain novoGenero);


        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="generoAtualizado">Objetos com novos dados Atualizados</param>
        void AtualizarIdCorpo(GeneroDomain generoAtualizado);

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="IdGenero"></param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com novos dados</param>
        void AtualizarIdUrl(int IdGenero, GeneroDomain generoAtualizado);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="idGenero"></param>
        void Deletar(int idGenero);
    }
}
