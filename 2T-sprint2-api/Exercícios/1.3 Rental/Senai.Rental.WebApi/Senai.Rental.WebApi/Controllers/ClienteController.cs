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
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository { get; set; }
        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult GET()
        {
            List<ClienteDomain> listaCliente = _clienteRepository.ListarTodos();

            return Ok(listaCliente);
        }

        [HttpPost]
        public IActionResult POST(ClienteDomain novoCliente)
        {
            _clienteRepository.Cadastrar(novoCliente);
            return StatusCode(201);
        }

        [HttpDelete("{idGenero}")]
        public IActionResult Delete(int idGenero)
        {
            _clienteRepository.Deletar(idGenero);
            return StatusCode(204);
        }

        [HttpGet("{idCliente}")]
        public IActionResult SearchById(int idCliente)
        {
            ClienteDomain cliente = _clienteRepository.BuscarPorId(idCliente);
            return Ok(cliente);
        }

        [HttpPut("{idCliente}")]
        public IActionResult Update(int idCliente, ClienteDomain clienteAtualizar)
        {
            _clienteRepository.Atualizar(idCliente, clienteAtualizar);
            return StatusCode(204);
        }
    }
}
