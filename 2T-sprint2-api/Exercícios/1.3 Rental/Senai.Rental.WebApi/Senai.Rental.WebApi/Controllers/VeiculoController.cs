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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private IVeiculoRepositorycs _veiculoRepository { get; set; }
        public VeiculoController()
        {
            _veiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult GET()
        {
            List<VeiculoDomain> listaVeiculo = _veiculoRepository.ListarTodos();

            return Ok(listaVeiculo);
        }

        [HttpPost]
        public IActionResult POST(VeiculoDomain novoVeiculo)
        {
            _veiculoRepository.Cadastrar(novoVeiculo);
            return StatusCode(201);
        }

        [HttpDelete("{idVeiculo}")]
        public IActionResult Delete(int idVeiculo)
        {
            _veiculoRepository.Deletar(idVeiculo);
            return StatusCode(204);
        }

        [HttpGet("{id}")]
        public IActionResult SearchByID(int id)
        {
            VeiculoDomain veiculo = _veiculoRepository.BuscarPorId(id);
            return Ok(veiculo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, VeiculoDomain veiculoAtualizado)
        {
            _veiculoRepository.Atualizar(id, veiculoAtualizado);
            return StatusCode(200);
        }

    }
}
