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
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipohabilidadeRepository _tipoHabilidadeRepository { get; set; }

        public TipoHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<Tipohabilidade> lista = _tipoHabilidadeRepository.ListarTodos();

            return Ok(lista);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Tipohabilidade novoTipoHab)
        {
            _tipoHabilidadeRepository.Cadastrar(novoTipoHab);
            return StatusCode(201);
        }
        
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(byte id)
        {
            Tipohabilidade tipoHab = _tipoHabilidadeRepository.BuscarPorId(id);
            return Ok(tipoHab); 
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(byte id)
        {
            try
            {

                _tipoHabilidadeRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Atualizat(byte id, Tipohabilidade tipoHabAtt)
        {
            _tipoHabilidadeRepository.Atualizar(id, tipoHabAtt);
            return StatusCode(204);
        }
    }
}
