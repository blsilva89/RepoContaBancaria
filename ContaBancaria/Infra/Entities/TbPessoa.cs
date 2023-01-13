using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbPessoa
    {
        public TbPessoa()
        {
            TbConta = new HashSet<TbConta>();
        }

        public int CodPessoa { get; set; }
        public string Nome { get; set; } = null!;
        public string Cep { get; set; } = null!;

        public virtual TbEndereco CepNavigation { get; set; } = null!;
        public virtual TbPessoaFisica TbPessoaFisica { get; set; } = null!;
        public virtual TbPessoaJuridica TbPessoaJuridica { get; set; } = null!;
        public virtual ICollection<TbConta> TbConta { get; set; }
    }
}
