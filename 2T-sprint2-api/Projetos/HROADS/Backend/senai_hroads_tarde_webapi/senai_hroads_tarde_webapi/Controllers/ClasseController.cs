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
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }

        public IActionResult ListarTodos()
        {
            List<Classe> lista = _classeRepository.ListarTodos();

            return Ok(lista);
        }

        public IActionResult Cadastrar(Classe novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);
            return StatusCode(201);
        }

        public IActionResult BuscarPorId(byte id)
        {
            Classe classe = _classeRepository.BuscarPorId(id);
            return Ok(classe);
        }

        public IActionResult Deletar(byte id)
        {
            _classeRepository.Deletar(id);
            return StatusCode(204);
        }

        public IActionResult Atualizar(byte id, Classe classeAtualizada)
        {
            _classeRepository.Atualizar(id, classeAtualizada);

            return StatusCode(204);
        }
    }
}
