using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_Emails_1._1.Interfaces;
using senai_pessoas_1._1.Domains;
using senai_pessoas_1._1.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_1._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailRepository _emailRepository { get; set; }

        public EmailController()
        {
            _emailRepository = new EmailRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EmailDomain> listaEmail = _emailRepository.ListarTodos();

            return Ok(listaEmail);
        }

        [HttpPost]
        public IActionResult Post(EmailDomain novoEmail)
        {
            _emailRepository.Cadastrar(novoEmail);
            return StatusCode(201);
        }
    }
}
