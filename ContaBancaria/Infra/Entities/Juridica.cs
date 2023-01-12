using System;

namespace ContaBancaria.Infra.Entities
{
    public class Juridica : Pessoa
    {
        public Juridica(string nome, string cnpj) : base(nome, cnpj) { 
            
        }

        public string? NomeFantasia { get; set; }

        protected override void ValidarDocumento()
        {
            if (this.NumeroDocumento.Length != 14)
            {
                throw new ArgumentException(this.mensagemDocumentoInvalido);
            }
        }
    }
}
