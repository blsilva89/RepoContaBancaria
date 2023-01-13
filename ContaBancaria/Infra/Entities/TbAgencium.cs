using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbAgencia
    {
        public TbAgencia()
        {
            TbConta = new HashSet<TbConta>();
        }

        public int CodAgencia { get; set; }
        public string Cep { get; set; } = null!;

        public virtual TbEndereco CepNavigation { get; set; } = null!;
        public virtual ICollection<TbConta> TbConta { get; set; }
    }
}
