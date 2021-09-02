using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    
    public class AluguelController : ControllerBase
    {
        private IAluguelRepository _aluguelRepository;
        public AluguelController()
        {
            _aluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult GET()
        {
            List<AluguelDomain> listaAluguel = _aluguelRepository.ListarTodos();
            return Ok(listaAluguel);
        }

        [HttpGet("{idAluguel}")]
        public IActionResult GETBYID(int idAluguel)
        {
            AluguelDomain aluguelBuscado = _aluguelRepository.BuscarPorId(idAluguel);
            return Ok(aluguelBuscado);
        }

        [HttpPost]
        public IActionResult POST(AluguelDomain novoAluguel)
        {
            _aluguelRepository.Cadastrar(novoAluguel);
            return StatusCode(201);
        }

        [HttpDelete("{idAluguel}")]
        public IActionResult DELETE(int idAluguel)
        {
            _aluguelRepository.Deletar(idAluguel);
            return StatusCode(204);
        }
        [HttpPut("{idAluguel}")]
        public IActionResult UPDATE(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            _aluguelRepository.Atualizar(idAluguel, aluguelAtualizado);
            return StatusCode(200);

        }
    }
}
