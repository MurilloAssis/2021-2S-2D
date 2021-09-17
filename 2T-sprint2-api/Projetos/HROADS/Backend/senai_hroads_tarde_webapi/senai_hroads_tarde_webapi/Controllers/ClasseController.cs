using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_hroads_tarde_webapi.Domains;
using senai_hroads_tarde_webapi.Interfaces;
using senai_hroads_tarde_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<Classe> lista = _classeRepository.ListarTodos();

            return Ok(lista);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Classe novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(byte id)
        {
            Classe classe = _classeRepository.BuscarPorId(id);
            return Ok(classe);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(byte id)
        {

            try
            {
                _classeRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(byte id, Classe classeAtualizada)
        {
            _classeRepository.Atualizar(id, classeAtualizada);

            return StatusCode(204);
        }
    }
}
