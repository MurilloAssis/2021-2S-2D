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
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<Usuario> lista = _usuarioRepository.ListarTodos();

            return Ok(lista);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(byte id, Usuario usuarioAtt)
        {
            _usuarioRepository.Atualizar(id, usuarioAtt);
            return StatusCode(204);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(byte id)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            return Ok(usuarioBuscado);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(byte id)
        {
            _usuarioRepository.Deletar(id);
            return StatusCode(204);
        }

    }
}
