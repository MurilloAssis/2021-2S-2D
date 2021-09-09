using Microsoft.AspNetCore.Authorization;
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
    //Define que o tipo de resposta de API sera no formato Json
    [Produces("application/json")]

    //Define que a rota de requisicao será no formato domino/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    [Authorize]
    public class GeneroController : ControllerBase
    {
        private IGeneroRepository _generoRepository { get; set; }

        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GeneroDomain> listaGenero = _generoRepository.ListarTodos();

            return Ok(listaGenero);
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            _generoRepository.Cadastrar(novoGenero);
            return StatusCode(201);
        }

        [HttpDelete]
        public IActionResult Delete(GeneroDomain deleteGenero)
        {
            _generoRepository.Deletar(deleteGenero.idGenero);
            return StatusCode(204);
        }

        [HttpDelete("{idGenero}")]
        public IActionResult Delete(int idGenero)
        {
            _generoRepository.Deletar(idGenero);
            return StatusCode(204);

        }

        
        [Authorize(Roles = "Admin")]
        [HttpGet("{idGenero}")]
        public IActionResult SearchById(int idGenero)
        {
            GeneroDomain genero = _generoRepository.BuscarPorId(idGenero);
            if (genero == null)
            {
                return NotFound("Gênero não encontado");
            }
            return Ok(genero);
        }

        [HttpPut("Atualizar/{idGenero}")]
        public IActionResult UpdateByIdURL(int idGenero, GeneroDomain novoGenero)
        {
            if (_generoRepository.BuscarPorId(idGenero) == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    }
                    );
            }
            try
            {

                _generoRepository.AtualizarIdUrl(idGenero, novoGenero);
                return StatusCode(204);
            }
            catch (Exception erro )
            {
                return BadRequest(erro);
            }
 
           
        }

        [HttpPut("Atualizar")]
        public IActionResult UpdateByIdBody(GeneroDomain novoGenero)
        {
            if (_generoRepository.BuscarPorId(novoGenero.idGenero) == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    }
                    );
            }
            try
            {

                _generoRepository.AtualizarIdCorpo(novoGenero);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
