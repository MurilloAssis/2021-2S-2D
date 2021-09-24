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
    public class PersonagemController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository;

        public PersonagemController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Personagem> lista = _personagemRepository.ListarTodos();

                return Ok(lista);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPerso)
        {
            try
            {
                _personagemRepository.Cadastrar(novoPerso);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(byte id, Personagem persoAtt)
        {
            try
            {
                _personagemRepository.Atualizar(id, persoAtt);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(byte id)
        {
            try
            {
                _personagemRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(byte id)
        {
           
            try
            {
                Personagem personagem = _personagemRepository.BuscarPorId(id);

                return Ok(personagem);
            }
            catch (Exception erro )
            {

                return BadRequest(erro);
            }
        }
    }
}
