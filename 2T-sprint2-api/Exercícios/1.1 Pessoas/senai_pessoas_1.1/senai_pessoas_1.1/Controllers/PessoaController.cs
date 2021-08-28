using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_pessoas_1._1.Domains;
using senai_pessoas_1._1.Interfaces;
using senai_pessoas_1._1.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_1._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaRepository _pessoaRepository { get; set; }

        public PessoaController()
        {
            _pessoaRepository = new PessoaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<PessoaDomain> listaPessoa = _pessoaRepository.ListarTodos();

            return Ok(listaPessoa);
        }

        [HttpPost]
        public IActionResult Post(PessoaDomain novaPessoa)
        {
            _pessoaRepository.Cadastrar(novaPessoa);
            return StatusCode(201);
        }
    }
}
