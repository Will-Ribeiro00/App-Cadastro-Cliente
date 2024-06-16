namespace AppCliente_R.Entidades
{
    public class Clientes
    {
        public int ID { get; set; }
        public string NOME { get; set; } = string.Empty;
        public DateTime DATANASCIMENTO { get; set; }
        public decimal DESCONTO { get; set; }
        public string EMAIL { get; set; } = string.Empty;
        public string TELEFONE { get; set; } = string.Empty;
        public DateTime DATACADASTRO { get; set; }
    }
}
