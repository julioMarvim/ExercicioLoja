using ExercicioLoja.DAO;
using ExercicioLoja.Entidades;
using ExercicioLoja.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja
{
    public static class InterfaceUsuario
    {
        static ISession session = NHibernateHelper.AbreSession();

        // Verificação de usuário
        static void MenuInicial()
        {
            Console.WriteLine("--------------------OLÁ USUARIO!!---------------------");
            Console.WriteLine("Digite 1 para fazer login ou 2 para se cadastrar:");
            var opcao = Console.ReadLine();

            if (opcao == "1")
                Login();
            else if (opcao == "2")
                CadastrarCliente();
            
            else
            {
                Console.WriteLine("Operação Invalida! Digite um valor válido.");
                MenuInicial();
            }
        }

         public static void MenuCliente(Cliente cliente)
        {
            Console.WriteLine("         ****BEM VINDO "+ cliente.Nome +"****           ");
            Console.WriteLine("\nDigite 1 para incluir produto no carrino\n" +
                "Digite 2 para remover produto do carrinho\n" +
                "Digite 3 para mostrar o valor total dos produtos selecionados\n" +
                "Digite 4 para fechar o Pedido \n" +
                "Digite 5 para consultar o seu carrinho\n" +
                "Digite qualquer outro valor para encerrar");
            string opcao = Console.ReadLine();

            if (opcao == "1")
                AdicionarProdutoPedido(cliente);
            else if (opcao == "2")
                RemoverProdutoDoPedido(cliente);
            else if (opcao == "3")
                ImprimirValorTotalDoPedido(cliente);
            else if (opcao == "4")
                EncerrarPedido(cliente);
            else if (opcao == "5")
                ConsultaPedido(cliente);
            else
                Console.WriteLine("Obrigado por acessar a nossa loja virtual");
        }

        static void Login()
        {
            Console.WriteLine("Informe seu nome: ");
            var nome = Console.ReadLine();

            ClienteDAO clienteDAO = new ClienteDAO(session);
            var clientes = clienteDAO.BuscaPorNome(nome);

            if (clientes != null)
            {
                Cliente cliente = clientes.First();
                MenuCliente(cliente);
            }
            else
            {
                Console.WriteLine("Cliente ainda não cadastrado.");
                MenuInicial();
            }
        }

        static void CadastrarCliente()
        {
            Console.WriteLine("Informe seu Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe seu Telefone:");
            string telefone = Console.ReadLine();
            Console.WriteLine("Informe seu Endereço:");
            string endereco = Console.ReadLine();
            Console.WriteLine("Informe o nome da sua Mãe:");
            string mae = Console.ReadLine();
            Console.WriteLine("Informe o nome do seu Pai:");
            string pai = Console.ReadLine();
            string filiacao = pai + "|" + mae;
            Console.WriteLine("Informe seu CPF");
            string documento = Console.ReadLine();

            ClienteDAO clienteDAO = new ClienteDAO(session);
            clienteDAO.Adiciona(nome, telefone, endereco, filiacao, documento);
            Console.WriteLine("------------CADASTRO REALIZADO COM SUCESSO--------------------");
            Console.WriteLine("Informe seu nome para Login");
            Login();
        }

        static void AdicionarProdutoPedido(Cliente cliente)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO(session);
             var listaDeProdutos = produtoDAO.BuscaProdutos("", 0, "");

            Console.WriteLine("-----------------------PRODUTOS DA LOJA!----------------------------");
            Console.WriteLine();
            Console.WriteLine();

            foreach (var produto in listaDeProdutos)
            {
                Console.WriteLine("ID:\t{0}\t{1}\t{2}\t{3}", produto.Id, produto.Nome, produto.Preco, produto.Categoria);
                Console.WriteLine("Escolha os Produtos Desejados Informando seu ID: ");
            }
        }


    }
}
