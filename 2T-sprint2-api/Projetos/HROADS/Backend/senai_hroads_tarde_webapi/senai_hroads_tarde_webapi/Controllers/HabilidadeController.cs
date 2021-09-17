using Microsoft.AspNetCore.Authorization;
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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<Habilidade> lista = _habilidadeRepository.ListarTodos();

            return Ok(lista);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novaHabilidade)
        {
            _habilidadeRepository.Cadastrar(novaHabilidade);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(byte id)
        {
            Habilidade habilidade = _habilidadeRepository.BuscarPorId(id);
            return Ok(habilidade);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(byte id)
        {
            try
            {
                _habilidadeRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(byte id, Habilidade habilidadeAtualizada)
        {
            _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

            return StatusCode(204);
        }
    }
}
