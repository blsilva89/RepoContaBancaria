using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbEndereco
    {
        public TbEndereco()
        {
            TbAgencia = new HashSet<TbAgencia>();
            TbPessoas = new HashSet<TbPessoa>();
        }

        public string Cep { get; set; } = null!;
        public string Rua { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual ICollection<TbAgencia> TbAgencia { get; set; }
        public virtual ICollection<TbPessoa> TbPessoas { get; set; }
    }
}
