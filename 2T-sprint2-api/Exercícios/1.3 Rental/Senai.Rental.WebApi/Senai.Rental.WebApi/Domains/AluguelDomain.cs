using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idEmpresa { get; set; }
        public int idCliente { get; set; }
        public int idVeiculo { get; set; }
        public EmpresaDomain EmpresaDomain { get; set; }
        public ClienteDomain ClienteDomain { get; set; }
        public VeiculoDomain VeiculoDomain { get; set; }
        public DateTime DataDev { get; set; }
        public DateTime DataAluguel { get; set; }
    }
}
