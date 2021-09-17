using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_hroads_tarde_webapi.Domains;
using senai_hroads_tarde_webapi.Interfaces;
using senai_hroads_tarde_webapi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai_hroads_tarde_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuario _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        
        [HttpPost]
        public IActionResult Login(Usuario Login)
        {
            Usuario usuarioBuscado = _usuarioRepository.Login(Login.Email, Login.Senha);

            if (usuarioBuscado != null)
            {
                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    
                    
                };

                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroadstokenloginwebapi"));

                var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "HROADS.webApi",
                        audience: "HROADS.webApi",
                        claims: Claims,
                        expires : DateTime.Now.AddMinutes(40),
                        signingCredentials : Creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                }); ;
            }

            return NotFound("Email ou Senha Inválido");
        }
    }
}
