using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_1._1.Domains
{
    public class PessoaDomain
    {
        public int idPessoa { get; set; }
        public string nomePessoa { get; set; }

        public TelefoneDomain telefone { get; set; }
        public EmailDomain email { get; set; }
        public CnhDomain cnh { get; set; }

    }
}
