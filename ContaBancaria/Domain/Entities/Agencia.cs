using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancaria.Domain.Entities
{
    public class Agencia
    {
        public int CodAgencia { get; set; }
        public Pessoa Gerente { get; set; }
    }
}