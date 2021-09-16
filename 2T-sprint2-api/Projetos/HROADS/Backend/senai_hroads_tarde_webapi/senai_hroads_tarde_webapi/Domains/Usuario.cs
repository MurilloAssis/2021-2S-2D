using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_tarde_webapi.Domains
{
    public partial class Usuario
    {
        public byte IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte? IdTipoUsuario { get; set; }

        public virtual Tipousuario IdTipoUsuarioNavigation { get; set; }
    }
}
