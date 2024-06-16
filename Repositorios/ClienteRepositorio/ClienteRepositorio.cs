using AppCliente_R.Entidades;
using AppCliente_R.Repositorios.DataBase_Context;
using AppCliente_R.Util;
using System.Text.Json;
namespace AppCliente_R.Repositorios.ClienteRepositorio
{
    public class ClienteRepositorio
    {
        private readonly ClienteDbContext _context;
        private readonly Validacoes _validar;
        public ClienteRepositorio(ClienteDbContext context, Validacoes validar)
        {
            _context = context;
            _validar = validar;
        }

        public void CadastrarCliente()
        {
            Console.Write("\nInforme o nome do cliente: ");
            var nome = Console.ReadLine();
            while (!_validar.ValidarNome(nome))
            {
                Console.Write("O nome não pode ser nulo!" +
                              "Informe o nome do cliente: ");
                nome = Console.ReadLine();
            }
            Console.Write(Environment.NewLine);

            Console.Write("Informe a data de nascimento (dd/mm/yyyy): ");
            DateTime dataNasc;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNasc))
            {
                Console.Write("Formato de data inválida!" +
                              "\nInforme a data de nascimento (dd/mm/yyyy): ");
            }
            Console.Write(Environment.NewLine);

            Console.Write("Informe o telefone (xx) 12345-6789: ");
            var telefone = Console.ReadLine();
            while (!_validar.ValidarTelefone(telefone))
            {
                Console.Write("Formato de telefone inválido!" +
                                  "\nInforme o telefone (xx) 12345-6789: ");
                telefone = Console.ReadLine();
            }
            Console.Write(Environment.NewLine);

            Console.Write("Informe o E-mail (seu.email@gmail.com): ");
            var email = Console.ReadLine();
            while (!_validar.ValidarEmail(email))
            {
                Console.Write("Formato de email inválido!" +
                                  "\nInforme o E-mail (seu.email@gmail.com): ");
                email = Console.ReadLine();
            }
            Console.Write(Environment.NewLine);

            Console.Write("Informe o desconto (0 - 50): ");
            var desconto = _validar.ValidarDesconto();
            Console.Write(Environment.NewLine);

            var novoCliente = new Clientes()
            {
                NOME = nome,
                DATANASCIMENTO = dataNasc,
                TELEFONE = telefone,
                EMAIL = email,
                DESCONTO = desconto,
                DATACADASTRO = DateTime.Now
            };

            _context.CLIENTE.Add(novoCliente);
            _context.SaveChanges();
            Console.WriteLine("Cliente cadastrado com sucesso [Enter]");
            ExibirCliente(novoCliente);
            Console.ReadKey();
        }
        public void ExibirCliente(Clientes cliente)
        {
            Console.WriteLine($"\nID................: {cliente.ID}");
            Console.WriteLine($"Nome..............: {cliente.NOME}");
            Console.WriteLine($"Desconto..........: {cliente.DESCONTO}%");
            Console.WriteLine($"Telefone..........: {cliente.TELEFONE}");
            Console.WriteLine($"E-mail............: {cliente.EMAIL}");
            Console.WriteLine($"Data de nascimento: {cliente.DATANASCIMENTO.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de cadastro..: {cliente.DATACADASTRO.ToString("dd/MM/yyyy HH:mm")}");
            Console.WriteLine($"..........................................");
        }
        public void ExibirTodosClientes()
        {
            Console.WriteLine();
            foreach (var cliente in _context.CLIENTE.ToList().OrderBy(c => c.ID))
            {
                ExibirCliente(cliente);
            }
            Console.ReadKey();
        }
        public void EditarCliente()
        {
            var cliente = BuscarClientePorID();
            var continuar = "n";
            int opcao = 0;
            do
            {
                Console.WriteLine("1 - Nome" +
                              "\n2 - Desconto" +
                              "\n3 - Telefone" +
                              "\n4 - E-mail" +
                              "\n5 - Data de Nascimento" +
                              "\n6 - Cancelar Operação");
                Console.Write("Informe a opção que deseja atualizar (1-5): ");

                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 6)
                {
                    Console.Write("Opção Inválida!" +
                                  "Informe a opção que deseja atualizar (1-5): ");
                }
                switch (opcao)
                {
                    case 1:
                        Console.Write("Informe o nome: ");
                        var nome = Console.ReadLine();
                        while (!_validar.ValidarNome(nome))
                        {
                            Console.Write("O nome não pode ser nulo!" +
                                          "Informe o nome: ");
                            nome = Console.ReadLine();
                        }
                        cliente.NOME = nome;
                        break;

                    case 2:
                        Console.Write("Informe o desconto: ");
                        var desc = _validar.ValidarDesconto();
                        cliente.DESCONTO = desc;
                        break;

                    case 3:
                        Console.Write("Informe o telefone: ");
                        var tel = Console.ReadLine();
                        while (!_validar.ValidarTelefone(tel))
                        {
                            Console.Write("Formato de telefone inválido!" +
                                              "\nInforme o telefone (xx) 12345-6789: ");
                            tel = Console.ReadLine();
                        }
                        cliente.TELEFONE = tel;
                        break;

                    case 4:
                        Console.Write("Informe o E-mail: ");
                        var email = Console.ReadLine();
                        while (!_validar.ValidarEmail(email))
                        {
                            Console.Write("Formato de email inválido!" +
                                              "\nInforme o E-mail (seu.email@gmail.com): ");
                            email = Console.ReadLine();
                        }
                        cliente.EMAIL = email;
                        break;

                    case 5:
                        Console.Write("Informe a data de nascimento: ");
                        DateTime dataNasc;
                        while (!DateTime.TryParse(Console.ReadLine(), out dataNasc))
                        {
                            Console.Write("Formato de data inválida!" +
                                          "\nInforme a data de nascimento (dd/mm/yyyy): ");
                        }
                        cliente.DATANASCIMENTO = dataNasc;
                        break;

                    case 6:
                        Console.WriteLine("Operação cancelada!");
                        return;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
                _context.SaveChanges();
                Console.WriteLine("Cliente atualizado com sucesso!");

                Console.WriteLine("\nDeseja atualizar outro dado do cliente ? (S/N)");
                continuar = Console.ReadLine();

                if (!continuar.Equals("S", StringComparison.OrdinalIgnoreCase) && !continuar.Equals("sim", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Cliente Atualizado [Enter]:");
                    ExibirCliente(cliente);
                    Console.ReadKey();
                }

            } while (continuar == "S" || continuar == "s");

        }

        public void ExcluirCliente()
        {
            var cliente = BuscarClientePorID();
            var opcao = "n";

            ExibirCliente(cliente);
            Console.WriteLine("DESEJA REALMENTE EXCLUIR O CLIENTE A CIMA ? (S/N)");
            opcao = Console.ReadLine();

            if (!opcao.Equals("s", StringComparison.OrdinalIgnoreCase) && !opcao.Equals("sim", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Operação cancelada! [Enter]");
                Console.ReadKey();
                return;
            }
            _context.CLIENTE.Remove(cliente);
            _context.SaveChanges();

            Console.WriteLine("Cliente excluido com sucesso! [Enter]");
            Console.ReadKey();
        }

        public void GravarJson()
        {
            var clientes = _context.CLIENTE.ToList();
            var jsonOptions = new JsonSerializerOptions() { WriteIndented = true };

            var json = System.Text.Json.JsonSerializer.Serialize(clientes, jsonOptions);

            File.WriteAllText("C:\\Users\\willi\\OneDrive\\Ambiente de Trabalho\\Mentoria NET\\AppCliente-R\\Json\\Cliente.txt", json);
        }

        public Clientes BuscarClientePorID()
        {
            Console.Write("\nInforme o ID do cliente:  ");
            var id = 0;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Formato do id inválido! o ID deve ser um número inteiro" +
                                  "\nInforme o Id do cliente: ");
            }

            var cliente = _context.CLIENTE.FirstOrDefault(c => c.ID == id);

            if (cliente == null)
            {
                Console.WriteLine("Não foi localizado nenhum cliente com o ID informado! [Enter]");
                Console.ReadKey();
                return null;
            }
            return cliente;
        }
    }
}
