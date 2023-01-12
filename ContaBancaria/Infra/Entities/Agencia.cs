namespace ContaBancaria.Infra.Entities
{
    public class Agencia
    {
        public int CodAgencia { get; set; }
        public Pessoa Gerente { get; set; }
    }
    
}