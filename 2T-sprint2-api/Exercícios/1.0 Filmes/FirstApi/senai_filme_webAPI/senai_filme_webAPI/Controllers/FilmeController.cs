using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filme_webAPI.Domains;
using senai_filme_webAPI.Interfaces;
using senai_filme_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Controllers
{
    //Define que o Tipo de resposta de API sera no formato Json
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();

        }

        [HttpGet]

        public IActionResult Get()
        {
            List<FilmeDomain> listaFilme = _filmeRepository.ListarTodos();

            return Ok(listaFilme);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);
            return StatusCode(201);
        }

        [HttpDelete("{idFilme}")]
        public IActionResult Delete(int idFilme)
        {
            _filmeRepository.Deletar(idFilme);
            return StatusCode(204);
        }

        [HttpGet("{idFilme}")]
        public IActionResult SearchById(int idFilme)
        {
            FilmeDomain filme = _filmeRepository.BuscarPorId(idFilme);
            if (filme == null)
            {
                return NotFound("Filme não encontrado");
            }
            return Ok(filme);
        }

        [HttpPatch("Atualizar/{idFilme}")]
        public IActionResult UpdateByIdURL(int idFilme, FilmeDomain novoFilme)
        {
            _filmeRepository.AtualizarIdUrl(idFilme, novoFilme);
            return StatusCode(200);
        }

        [HttpPatch("Atualizar")]
        public IActionResult UpdateByIdBody(FilmeDomain novoFilme)
        {
            _filmeRepository.AtualizarIdCorpo(novoFilme);
            return StatusCode(200);
        }

    }
}
