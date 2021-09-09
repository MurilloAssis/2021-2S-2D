using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo de senha é obrigatório")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O campo de senha deve conter no mínimo 3 caracteres e no máximo 10 caracteres")]
        public string senha { get; set; }
        public string permissao { get; set; }
    }
}
