using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancaria.Domain.Entities
{
    public class Fisica : Pessoa
    {
        public DateTime DataNascimento { get; }
        public string Rg { get; set; }

        public Fisica(string nome, string cep, string cpf, string rg, DateTime dataNascimento) : base(nome, cep, cpf)
        {
            this.DataNascimento = dataNascimento;
            this.Rg = rg;
        }

        protected override void ValidarDocumento(string numeroDocumento)
        {
            if (numeroDocumento.Length != 11)
            {
                throw new ArgumentException(this.mensagemDocumentoInvalido);
            }
        }
    }
}