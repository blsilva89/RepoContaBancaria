namespace ContaBancaria.Infra.Entities
{
    public abstract class Pessoa
    {
        protected Pessoa(string nome, string numeroDocumento)
        {
            this.Nome = nome;
            this.NumeroDocumento = numeroDocumento;

            this.ValidarDocumento();
        }

        protected string mensagemDocumentoInvalido = "Número de documento inválido";

        public string Nome { get; private set; }

        public string NumeroDocumento { get; private set; }

        protected abstract void ValidarDocumento();
    }
}
