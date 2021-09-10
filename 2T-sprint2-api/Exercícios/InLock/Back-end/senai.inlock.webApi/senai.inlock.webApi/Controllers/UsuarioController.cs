﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            List<UsuarioDomain> listaUsuario = _usuarioRepository.ListarTodos();
            return Ok(listaUsuario);
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult SerachById(int id)
        {
            UsuarioDomain user = _usuarioRepository.BuscarPorId(id);
            return Ok(user);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, UsuarioDomain attUser)
        {
            _usuarioRepository.AtualizarId(id, attUser);
            return StatusCode(200);
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuario = _usuarioRepository.Login(login.email, login.senha);

            if (usuario == null)
            {
                return NotFound("Email ou senha estão inválidos");
            }

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.idTipoUsuario.ToString()),
            };

            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Autenticacaoparausuariojogos"));

            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(issuer: "inlock.WebApi", audience: "inlock.WebApi", claims: Claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: Creds);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token)
            }); ;
                
        }
    }
}
