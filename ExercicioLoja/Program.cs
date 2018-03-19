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
    public class Program
    {
        public static void Main(string[] args)
        {
            ISession session = NHibernateHelper.AbreSession();
            ClienteDAO clienteDAO = new ClienteDAO(session);
			
            CategoriaDAO categoriaDAO = new CategoriaDAO(session);
            ProdutoDAO produtoDAO = new ProdutoDAO(session);
            FornecedorDAO fornecedorDAO = new FornecedorDAO(session);
            PedidoDAO pedidoDAO = new PedidoDAO(session);
            Cliente cliente = new Cliente();


            ReconhecerCliente();
            CriarPedido();

            //NHibernateHelper.GeraSchema();
            //fornecedorDAO.Adiciona("Ibanez Guitar", "(31)99876-5432", "Rua da Guitarra - 1000", "99.999.999/9999-99");
            //clienteDAO.Adiciona("Julio Marvim", "(31)97335-9094", "Rua São Gotardo - 129", "Delmira Pego|Venceslau Aparecido", "114.377.886-37");
            //categoriaDAO.Adiciona("Instrumentos Musicais");
            //produtoDAO.Adiciona("Guitarra Ibanez", 2050, categoriaDAO.BuscaPorId(1), new DateTime(2018, 01, 23), new DateTime(2035, 01, 01), fornecedorDAO.BuscaPorId(1));
            //produtoDAO.Adiciona("Guitarra Fender", 3500, categoriaDAO.BuscaPorId(1), new DateTime(2018, 01, 23), new DateTime(2035, 01, 01), fornecedorDAO.BuscaPorId(1));
            //produtoDAO.Adiciona("Violão Tagima", 500, categoriaDAO.BuscaPorId(1), new DateTime(2018, 01, 23), new DateTime(2035, 01, 01), fornecedorDAO.BuscaPorId(1));
            //pedidoDAO.Adiciona(1000, 1);
            //pedidoDAO.Adiciona(5500, 1);

            // Listar Todos Os Produtos. 
            //var todosOsProdutos = produtoDAO.TodosOsProdutos();
            //foreach (var produtos in todosOsProdutos)
            //{
            //    Console.WriteLine("ID: {0}\t Nome: {1}\t Peço: {2}", produtos.Id, produtos.Nome.PadRight(20), produtos.Preco);
            //}

            //Escolhendo os Produtos.


            //Console.WriteLine("Para Incluir produtos no carrinho digite digite 1, para Fechar Pedido digite 2: ");
            //var produtoEscolhido = Convert.ToInt16(Console.ReadLine());

            //while (produtoEscolhido ==1 )
            //{
            //Console.WriteLine("Escolha os Produtos Desejados Informando seu ID: ");
            //var item = Console.ReadLine();
            //var itemPedido = produtoDAO.BuscaPorId(Convert.ToInt16(item));
            //    List<Produto> listaDeProdutos = new List<Produto>();
            //    listaDeProdutos.Add(itemPedido);

            //    foreach (var itemEscolhido in listaDeProdutos)
            //    {
            //        Console.WriteLine("{0}\t{1}", itemEscolhido.Nome, itemEscolhido.Preco);
            //    }


            //    //var itemPedido = produtoDAO.BuscaPorId(Convert.ToInt16(produtoEscolhido));
            //}

            //Console.WriteLine();




            //Console.WriteLine("-------------------------PRODUTOS DO PEDIDO-----------------------------");


            //Console.WriteLine("{0}\t{1}\t{2}", itemPedido.Id, itemPedido.Nome, itemPedido.Preco);


            //Console.WriteLine("Para Incluir mais produtos digite 1, para Fechar Pedido digite 2: ");
            //var opção = Console.ReadLine();
            //if (opção == "1")
            //{
            //    Console.WriteLine("Escolha os Produtos Desejados Informando seu ID: ");
            //    var maisItensDoPedido = Console.ReadLine();
            //    var novaOpcao = produtoDAO.BuscaPorId(Convert.ToInt16(maisItensDoPedido));
            //    List<Produto> listaDeProdutos = new List<Produto>();
            //    listaDeProdutos.Add(itemPedido);
            //    listaDeProdutos.Add(novaOpcao);

            //    foreach (var produto in listaDeProdutos)
            //    {
            //        Console.WriteLine("ID: {0}\t Nome: {1}\t Peço: {2}", produto.Id, produto.Nome.PadRight(20), produto.Preco);
            //    }
            //    Console.WriteLine(listaDeProdutos);
            //}
            //else if (opção == "2")
            //{
            //    List<Produto> listaDeProdutos = new List<Produto>();
            //    listaDeProdutos.Add(itemPedido);
            //    pedidoDAO.Adiciona(itemPedido.Preco, listaDeProdutos, 1);
            //    Console.WriteLine("--------------------COMPRA REALIZADA COM SUCESSO--------------------------");
            //}
            //else
            //{

            //    Console.WriteLine("Digite um valor Valido");
            //}

            Console.WriteLine("-----------------OLÁ É UM PRAZER TE-LO EM NOSSA LOJA --------------------");
            Console.WriteLine("Se ja for cadastrado digite 1, se não for digite 2 para se cadastrar: ");
            var opcao = Console.ReadLine();

            Console.WriteLine("Informe Seu Nome:");
            var nome = Console.ReadLine();
            Console.WriteLine("Informe Seu Telefone:");
            var telefone = Console.ReadLine();
            Console.WriteLine("Informe Seu Endereço:");
            var endereco = Console.ReadLine();
            Console.WriteLine("Informe o nome da Sua Mãe:");
            var mae = Console.ReadLine();
            Console.WriteLine("Informe o nome do Seu Pai:");
            var pai = Console.ReadLine();
            
            Console.WriteLine("Informe Seu CPF ou CNPJ:");
            var documento = Console.ReadLine();

            //Console.ReadKey();

        }

        public static Cliente ReconhecerCliente(string nome, string telefone, string endereco, string mae, string pai, string documento, string opcao)
        {
            ISession session = NHibernateHelper.AbreSession();
            ClienteDAO clienteDAO = new ClienteDAO(session);
            Cliente cliente = new Cliente();

            if(opcao == "1")
            {
                clienteDAO.BuscaPorNome(nome);
            }else if (opcao == "2")
            {
                cliente.Nome = nome;
                cliente.Telefone = telefone;
                cliente.Endereco = endereco;
                var filiacao = pai + "|" + mae;
                cliente.Documento = documento;
                clienteDAO.Adiciona(nome, telefone, endereco, filiacao, documento);
            }
            else
            {
                Console.WriteLine("Favor Informar um valor valido!");
            }
        }

        public static void CriarPedido()
        {
            ISession session = NHibernateHelper.AbreSession();
            ProdutoDAO produtoDAO = new ProdutoDAO(session);
            PedidoDAO pedidoDAO = new PedidoDAO(session);

            Console.WriteLine("Para Incluir produtos no carrinho digite digite 1, para Fechar Pedido digite 2: ");
            var produtoEscolhido = Convert.ToInt16(Console.ReadLine());

            while (produtoEscolhido == 1)
            {
                Console.WriteLine("Escolha os Produtos Desejados Informando seu ID: ");
                var item = Console.ReadLine();
                var itemPedido = produtoDAO.BuscaPorId(Convert.ToInt16(item));
                List<Produto> listaDeProdutos = new List<Produto>();
                listaDeProdutos.Add(itemPedido);

                foreach (var itemEscolhido in listaDeProdutos)
                {
                    Console.WriteLine("{0}\t{1}", itemEscolhido.Nome, itemEscolhido.Preco);
                   
                }
            }

           

        }
    }
}
