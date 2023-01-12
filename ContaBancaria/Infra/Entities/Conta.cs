namespace ContaBancaria.Infra.Entities
{
    public class Conta
    {
        public int CodConta { get; set; }
        public decimal Saldo { get; set; }
        public Pessoa Titular { get; set; }
        public Agencia Agencia { get; set; }
    }
}