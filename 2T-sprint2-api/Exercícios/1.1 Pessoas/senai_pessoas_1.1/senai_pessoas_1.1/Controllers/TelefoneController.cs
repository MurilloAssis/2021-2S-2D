using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_pessoas_1._1.Domains;
using senai_pessoas_1._1.Repositorys;
using senai_Telefones_1._1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_1._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private ITelefoneRepository _TelefoneRepository { get; set; }

        public TelefoneController()
        {
            _TelefoneRepository = new TelefoneRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TelefoneDomain> listaTelefone = _TelefoneRepository.ListarTodos();

            return Ok(listaTelefone);
        }

        [HttpPost]
        public IActionResult Post(TelefoneDomain novoTelefone)
        {
            _TelefoneRepository.Cadastrar(novoTelefone);
            return StatusCode(201);
        }
    }
}
