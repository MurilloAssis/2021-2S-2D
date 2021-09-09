using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_filme_webAPI.Domains;
using senai_filme_webAPI.Interfaces;
using senai_filme_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuario = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuario == null)
            {
                return NotFound("Email ou senha estão inválidos");
            }
            //return Ok(usuario);

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.permissao),
                new Claim("Claim personalizada", "Valor Teste")
            };

            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Filmes-Chave-Autenticacao"));

            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: "Filme.WebAPI", audience: "Filme.WebAPI", claims: Claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: Creds );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
                
        }
    }
}
