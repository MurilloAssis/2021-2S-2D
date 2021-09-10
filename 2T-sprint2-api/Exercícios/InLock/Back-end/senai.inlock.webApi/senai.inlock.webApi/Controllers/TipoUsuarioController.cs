using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuario;

        public TipoUsuarioController()
        {
            _tipoUsuario = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> listaTipo = _tipoUsuario.ListarTodos();
            return Ok(listaTipo);
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain novoTipoUser)
        {
            _tipoUsuario.Cadastrar(novoTipoUser);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult SearchById(int id)
        {
            TipoUsuarioDomain TipoUser = _tipoUsuario.BuscarPorId(id);
            return Ok(TipoUser);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TipoUsuarioDomain attTipoUser)
        {
            _tipoUsuario.AtualizarId(id, attTipoUser);
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoUsuario.Deletar(id);
            return StatusCode(204);
        }

    }
}
