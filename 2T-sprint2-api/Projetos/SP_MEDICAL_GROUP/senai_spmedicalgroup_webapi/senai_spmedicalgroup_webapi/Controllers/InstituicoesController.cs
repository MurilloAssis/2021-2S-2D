using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webapi.Domains;
using senai_spmedicalgroup_webapi.Interfaces;
using senai_spmedicalgroup_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicoesController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        public InstituicoesController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Instituicao novaClinica)
        {
            _instituicaoRepository.CadastrarClinica(novaClinica);
            return StatusCode(201);
        }
    }
}
