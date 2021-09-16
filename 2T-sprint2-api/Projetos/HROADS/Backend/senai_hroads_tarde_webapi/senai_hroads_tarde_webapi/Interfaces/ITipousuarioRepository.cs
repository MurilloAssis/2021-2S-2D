using senai_hroads_tarde_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Interfaces
{
    interface ITipousuarioRepository
    {
        List<Tipousuario> ListarTodos();

        void Cadastrar(Tipousuario novoUsuario);

        void Deletar(byte id);

        Tipousuario BuscarPorId(byte id);

        void Atualizar(byte id, Tipousuario usuarioAtt);
    }
}
