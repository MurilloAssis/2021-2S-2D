using senai_filme_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// </summary>
    interface IFilmeRepository
    {
        //Estrutura dos métodos
        //TipoRetorno NomeMetodo(TipoParametro NomeParametro);
        //Ex: FilmeDomain Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os Filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Buscar um filme atráves por um id
        /// </summary>
        /// <param name="idFilme">id do filme será buscado</param>
        /// <returns>Um filme buscado</returns>
        FilmeDomain BuscarPorId(int idFilme);

        /// <summary>
        /// Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme com os novos dados</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualizar um filme existente
        /// </summary>
        /// <param name="filmeAtualizado">Objeto filmeAtualizado com os novos dados atualizados</param>
        void AtualizarIdCorpo(FilmeDomain filmeAtualizado);

        /// <summary>
        /// Atualizar um filme existente
        /// </summary>
        /// <param name="idFilme">id do filme que será atualizado</param>
        /// <param name="filmeAtualizado">Objeto filmeAtualizado com os novos dados atualizados</param>
        void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado);

        /// <summary>
        /// Deletar um filme existente
        /// </summary>
        /// <param name="idFilme">id do filme que sera deletado</param>
        void Deletar(int idFilme);

    }
}
