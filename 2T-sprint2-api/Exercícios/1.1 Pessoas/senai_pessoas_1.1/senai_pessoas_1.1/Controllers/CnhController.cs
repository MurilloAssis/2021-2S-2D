using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_Cnhs_1._1.Interfaces;
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
    public class CnhController : ControllerBase
    {
        private ICnhRepository _CnhRepository { get; set; }

        public CnhController()
        {
            _CnhRepository = new CnhRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<CnhDomain> listaCnh = _CnhRepository.ListarTodos();

            return Ok(listaCnh);
        }

        [HttpPost]
        public IActionResult Post(CnhDomain novoCnh)
        {
            _CnhRepository.Cadastrar(novoCnh);
            return StatusCode(201);
        }
    }
}
