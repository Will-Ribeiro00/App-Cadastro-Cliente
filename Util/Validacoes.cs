using System.Text.RegularExpressions;

namespace AppCliente_R.Util
{
    public class Validacoes
    {
        Regex verificarTelefone = new(@"^\(\d{2}\) \d{5}-\d{4}$");

        Regex verificarEmail = new(@"^\S+@(gmail|hotmail|icloud|yahoo|outlook)\.com$");

        public bool ValidarTelefone(string telefone)
        {
            return verificarTelefone.IsMatch(telefone);
        }
        public bool ValidarEmail(string email)
        {
            return verificarEmail.IsMatch(email);
        }

        public bool ValidarNome(string nome)
        {
            return !string.IsNullOrEmpty(nome);
        }

        public decimal ValidarDesconto()
        {
            var desconto = 0M;
            while (!decimal.TryParse(Console.ReadLine(), out desconto) || desconto < 0 || desconto > 50)
            {
                Console.Write("Formato de desconto inválido!" +
                              "\nInforme o desconto (0 - 50): ");
            }
            return desconto;
        }
    }
}
