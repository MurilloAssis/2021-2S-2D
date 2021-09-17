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
    public class TipousuarioController : ControllerBase
    {
        private ITipousuarioRepository _tipousuarioRepository { get; set; }

        public TipousuarioController()
        {
            _tipousuarioRepository = new TipousuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<Tipousuario> lista = _tipousuarioRepository.ListarTodos();

            return Ok(lista);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Tipousuario novoUsuario)
        {
            _tipousuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(byte id)
        {
            Tipousuario tipousuario = _tipousuarioRepository.BuscarPorId(id);
            return Ok(tipousuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(byte id)
        {
            _tipousuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(byte id, Tipousuario usuarioAtt)
        {
            _tipousuarioRepository.Atualizar(id, usuarioAtt);

            return StatusCode(204);
        }


    }
}
