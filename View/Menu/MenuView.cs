using AppCliente_R.Repositorios.ClienteRepositorio;

namespace AppCliente_R.View.Menu
{
    public class MenuView
    {
        private readonly ClienteRepositorio _repositorio;
        public MenuView(ClienteRepositorio repositorio) => _repositorio = repositorio;
        public void ExibirMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("*****CADASTRO DE CLIENTES*****");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1 - Cadastrar Cliente" +
                                  "\n2 - Exibir Clientes" +
                                  "\n3 - Editar Cliente" +
                                  "\n4 - Excluir cliente" +
                                  "\n5 - Sair");
                EscolherOpcao();

            } while (true);
        }
        public void EscolherOpcao()
        {
            var opcao = 0;

            Console.Write("Escolha uma opção (1-5): ");
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 5)
            {
                Console.Write("Formato da opção inválida!" +
                                  "Escolha uma opção (1-5): ");
            }

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    _repositorio.CadastrarCliente();
                    break;

                case 2:
                    Console.Clear();
                    _repositorio.ExibirTodosClientes();
                    break;

                case 3:
                    Console.Clear();
                    _repositorio.EditarCliente();
                    break;

                case 4:
                    Console.Clear();
                    _repositorio.ExcluirCliente();
                    break;

                case 5:
                    _repositorio.GravarJson();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        }
    }
}
