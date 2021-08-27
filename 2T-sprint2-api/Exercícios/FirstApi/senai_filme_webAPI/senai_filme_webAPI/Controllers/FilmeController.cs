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
    }
}
