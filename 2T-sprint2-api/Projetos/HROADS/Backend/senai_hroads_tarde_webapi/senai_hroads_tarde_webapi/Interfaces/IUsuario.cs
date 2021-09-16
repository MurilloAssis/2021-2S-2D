using senai_hroads_tarde_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Interfaces
{
    interface IUsuario
    {
        List<Usuario> ListarTodos();

        void Cadastrar(Usuario novoUsuario);

        void Deletar(byte id);

        Usuario BuscarPorId(byte id);

        void Atualizar(byte id, Usuario usuarioAtt);

        Usuario Login(string Email, string Senha);
    }
}
