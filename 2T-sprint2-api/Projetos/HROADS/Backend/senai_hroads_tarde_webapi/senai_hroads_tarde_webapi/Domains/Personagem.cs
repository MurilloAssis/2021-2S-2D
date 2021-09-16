using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_tarde_webapi.Domains
{
    public partial class Personagem
    {
        public short IdPersonagem { get; set; }
        public byte? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public byte? CapacidadeMaxVida { get; set; }
        public byte? CapacidadeMaxMana { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
