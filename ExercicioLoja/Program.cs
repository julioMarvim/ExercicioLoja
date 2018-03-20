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

            Console.WriteLine("-----------------OLÁ É UM PRAZER TE-LO EM NOSSA LOJA --------------------");


            cliente.ReconhecerCliente();

            cliente.IncluirProdutoPedido();


            //pedidoDAO.Adiciona(2500, cliente.IncluirProdutoPedido(), clienteDAO.BuscaPorId(1));

            Console.ReadKey();

        }

        


        //public static void CriarPedido()
        //{
        //    ISession session = NHibernateHelper.AbreSession();
        //    ProdutoDAO produtoDAO = new ProdutoDAO(session);
        //    PedidoDAO pedidoDAO = new PedidoDAO(session);

        //    var todosOsProdutos = produtoDAO.TodosOsProdutos();
        //    foreach (var produtos in todosOsProdutos)
        //    {
        //        Console.WriteLine("ID: {0}\t Nome: {1}\t Peço: {2}", produtos.Id, produtos.Nome.PadRight(20), produtos.Preco);
        //    }

        //    Console.WriteLine("Para Incluir produtos no carrinho digite digite 1, para Fechar Pedido digite 2: ");
        //    var produtoEscolhido = Convert.ToInt16(Console.ReadLine());

        //    while (produtoEscolhido == 1)
        //    {
        //        Console.WriteLine("Escolha os Produtos Desejados Informando seu ID: ");
        //        var item = Console.ReadLine();
        //        var itemPedido = produtoDAO.BuscaPorId(Convert.ToInt16(item));
        //        List<Produto> listaDeProdutos = new List<Produto>();
        //        listaDeProdutos.Add(itemPedido);

        //        foreach (var itemEscolhido in listaDeProdutos)
        //        {
        //            Console.WriteLine("{0}\t{1}", itemEscolhido.Nome, itemEscolhido.Preco);

        //        }



    }
}
