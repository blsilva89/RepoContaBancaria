using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbTipoMovimento
    {
        public TbTipoMovimento()
        {
            TbMovimentos = new HashSet<TbMovimento>();
        }

        public int CodTipoMovimento { get; set; }
        public string Descricao { get; set; } = null!;

        public virtual ICollection<TbMovimento> TbMovimentos { get; set; }
    }
}
