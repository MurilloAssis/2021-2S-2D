using senai_filmes_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebAPI.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme através de seu id
        /// </summary>
        /// <param name="IdFilme">id do filme que será buscado</param>
        /// <returns>Um filme buscado</returns>
        FilmeDomain BuscarPorId(int IdFilme);

        void Cadastrar(FilmeDomain novoGenero);


        /// <summary>
        /// Atualiza um filme existente
        /// </summary>
        /// <param name="generoAtualizado">Objetos com novos dados Atualizados</param>
        void AtualizarIdCorpo(FilmeDomain generoAtualizado);

        /// <summary>
        /// Atualiza um filme existente
        /// </summary>
        /// <param name="IdFilme"></param>
        /// <param name="filmeAtualizado">Objeto generoAtualizado com novos dados</param>
        void AtualizarIdUrl(int IdFilme, FilmeDomain filmeAtualizado);

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="IdFilme"></param>
        void Deletar(int IdFilme);
    }
}
