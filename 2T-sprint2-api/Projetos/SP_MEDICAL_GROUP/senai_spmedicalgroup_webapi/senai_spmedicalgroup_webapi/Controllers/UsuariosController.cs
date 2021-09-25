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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public string JwtRegisteredClaimTypes { get; private set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.ListarUsuarios());           
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUser)
        {
            _usuarioRepository.Cadastrar(novoUser);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPost("imagem/bd/{idUsuario}")]
        public IActionResult postBD(IFormFile arquivo, short idUsuario)
        {
            try
            {
                if (arquivo == null)
                {
                    return BadRequest(new { mensagem = "É necessario enviar uma foto .png" });
                }
                if (arquivo.Length > 5000)
                {
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem é de 5mb" });
                }

                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "png")
                {
                    return BadRequest(new { mensagem = "Apenas arquivos .png são permitidos" });
                }

                

                _usuarioRepository.SalvarPerfilBD(arquivo, idUsuario);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

            
        }
        [Authorize(Roles = "1")]
        [HttpGet("imagem/bd/{idUsuario}")]
        public IActionResult getBd(short idUsuario)
        {
            try
            {
                string base64 = _usuarioRepository.ConsultarPerfilBD(idUsuario);
                return Ok(base64);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
