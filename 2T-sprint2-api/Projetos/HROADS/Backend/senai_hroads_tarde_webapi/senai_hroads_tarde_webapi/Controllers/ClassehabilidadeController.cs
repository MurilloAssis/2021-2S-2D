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
    public class ClassehabilidadeController : ControllerBase
    {
        private IClassehabilidadeRepository _classehabilidadeRepository { get; set; }

        public ClassehabilidadeController()
        {
            _classehabilidadeRepository = new ClassehabilidadeRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<Classehabilidade> lista = _classehabilidadeRepository.ListarTodos();

            return Ok(lista);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Classehabilidade novaClassehabilidade)
        {
            _classehabilidadeRepository.Cadastrar(novaClassehabilidade);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(byte id)
        {
            Classehabilidade classehabilidade = _classehabilidadeRepository.BuscarPorId(id);
            return Ok(classehabilidade);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(byte id)
        {
            try
            {
                _classehabilidadeRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(short id, Classehabilidade classehabilidadeAtualizada)
        {
            _classehabilidadeRepository.Atualizar(id, classehabilidadeAtualizada);

            return StatusCode(204);
        }
    }
}
