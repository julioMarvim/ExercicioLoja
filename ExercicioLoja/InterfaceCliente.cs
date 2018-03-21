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
    public static class InterfaceCliente
    {
        static ISession session = NHibernateHelper.AbreSession();

        // Verificação de usuário
        public static void MenuInicial()
        {
            Console.WriteLine("--------------------------------OLA USUÁRIO!-----------------------------------");
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
            Console.WriteLine("         ****OLÁ "+ cliente.Nome +"!!****           ");
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
                RemoverProdutoPedido(cliente);
            else if (opcao == "3")
                ValorTotalDoPedido(cliente);
            else if (opcao == "4")
                FecharPedido(cliente);
            //else if (opcao == "5")
            //    ConsultaPedido(cliente);
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
            Console.WriteLine("------------CADASTRO REALIZADO COM SUCESSO!!--------------------");
            Console.WriteLine("Informe seu nome para Login");
            Login();
        }

        static void AdicionarProdutoPedido(Cliente cliente)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO(session);

            Console.WriteLine("------------------------------PRODUTOS DA LOJA!--------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            var listaDeProdutos = produtoDAO.BuscaProdutos("", 0, "");
            
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Escolha os Produtos Desejados Informando seu ID: ");
            try
            { 
                var produtosPedido = Convert.ToInt16(Console.ReadLine());
                if (produtosPedido <= listaDeProdutos.Count())
                {
                    Produto produtoEscolhido = listaDeProdutos[produtosPedido - 1];
                    cliente.AdicionarProdutoPedido(produtoEscolhido);
                }
                else
                {
                    Console.WriteLine("Produto Não Encontratdo...");
                }
            }
            catch
            {
                Console.WriteLine("Informe um valor Valido!");
            }

            MenuCliente(cliente);
        }

        static void RemoverProdutoPedido(Cliente cliente)
        {
            if (cliente.PegarPedido() != null && cliente.PegarPedido().QuantidadeDeProdutos > 0)
            {
                ListaProdutosPedido(cliente.PegarPedido());
                Console.WriteLine("Remova produtos do pedido informando seu ID: ");
                var produtoId = Convert.ToInt16(Console.ReadLine());
                cliente.RemoverProdutoPedido(produtoId);
                ListaProdutosPedido(cliente.PegarPedido());
            }
            else
            {
                Console.WriteLine("Não há produtos no seu Carrinho");
                Console.WriteLine("------------------------------------------------------------------------------");
            }

            MenuCliente(cliente);
        }
        
        public static void ListaProdutosPedido(Pedido pedido)
        {
            var listaProdutos = pedido.Produtos;
            if (listaProdutos.Count > 0 )
            {
                Console.WriteLine("---------------------------PRODUTOS DO PEDIDO--------------------------------");
                foreach (var produto in listaProdutos)
                    {
                        Console.WriteLine("ID:\t{0}\t{1}\t{2}\t{3}", produto.Id, produto.Nome, produto.Preco, produto.Categoria.Nome);
                    }
                Console.WriteLine("-----------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Não há produtos no carrinho!");
                Console.WriteLine("-----------------------------------------------------------------------------");
            }
        }

        public static void ValorTotalDoPedido(Cliente cliente)
        {
            ListaProdutosPedido(cliente.PegarPedido());
            Console.WriteLine("O Valor todal do seu pedido é: {0}", cliente.PegarValorTotalPedido());
            Console.WriteLine("-----------------------------------------------------------------------------");
            MenuCliente(cliente);
        }

        static void FecharPedido(Cliente cliente)
        {
            cliente.FecharPedido();
                           

            MenuCliente(cliente);
            
        }
    }
}
