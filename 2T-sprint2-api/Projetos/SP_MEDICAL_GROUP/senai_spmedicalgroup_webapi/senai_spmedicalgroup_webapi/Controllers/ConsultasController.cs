using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webapi.Domains;
using senai_spmedicalgroup_webapi.Interfaces;
using senai_spmedicalgroup_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_consultaRepository.ListarTodas());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Consultum novaConsulta)
        {
            _consultaRepository.CadastrarConsulta(novaConsulta);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPatch("Cancelar/{id}")]
        public IActionResult Deletar(int id)
        {
            _consultaRepository.CancelarConsulta(id);

            return StatusCode(204);
        }

        [Authorize(Roles = "2")]
        [HttpGet("Lista/Paciente")]
        public IActionResult ListarTodosPaciente()
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(_consultaRepository.ListarConsultaPaciente(id));
        }

        [Authorize(Roles = "3")]
        [HttpGet("Lista/Medico")]
        public IActionResult ListarTodosMedico()
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(_consultaRepository.ListarConsultaMedico(id));
        }

        [Authorize(Roles = "3")]
        [HttpGet("AlterarDescricao/{id}")]
        public IActionResult AlterarDescricao(Consultum consultaAtt, int id)
        {
            _consultaRepository.AlterarDescricao(consultaAtt, id);
            return StatusCode(204);
        }
    }
}
