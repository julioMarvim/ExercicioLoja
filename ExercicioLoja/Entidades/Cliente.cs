using ExercicioLoja.DAO;
using ExercicioLoja.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.Entidades
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Filiacao { get; set; }
        public virtual string Status { get; set; }
        public virtual decimal LimiteDeCredito { get; set; }
        public virtual string Documento { get; set; }

        static ProdutoDAO produtoDAO = new ProdutoDAO();

        private Pedido Pedido = null;

        public virtual IList<Produto> SelecionarProduto(Cliente cliente)
        {
            produtoDAO.TodosOsProdutos();
            Console.WriteLine("Informe o ID do produto Escolhido: ");
            var produtoEscolhido = produtoDAO.BuscaPorId(Convert.ToInt16(Console.ReadLine()));
            List<Produto> listaDeProdutos = new List<Produto>();
            listaDeProdutos.Add(produtoEscolhido);
            foreach (var item in listaDeProdutos)
            {
                Console.WriteLine("{0}\t{1}", item.Nome, item.Preco);
            }
            return listaDeProdutos;
        }

        //public virtual Cliente ReconhecerCliente()
        //{
        //    ISession session = NHibernateHelper.AbreSession();
        //    ClienteDAO clienteDAO = new ClienteDAO(session);
        //    //Cliente cliente = new Cliente();

        //    Console.WriteLine("Se ja for cadastrado digite 1, se não for digite 2 para se cadastrar: ");
        //    var opcao = Console.ReadLine();

        //    if (opcao == "1")
        //    {
        //        Console.WriteLine("Informe Seu Nome:");
        //        var nome = Console.ReadLine();
        //        var clienteCadastrardo = clienteDAO.BuscaPorNome(nome);
        //        foreach (var item in clienteCadastrardo)
        //        {
        //            Console.WriteLine("Bem Vindo! {0}", item.Nome); 
        //        }
        //    }
        //    else if (opcao == "2")
        //    {
        //        Console.WriteLine("Informe Seu Nome:");
        //        var nome = Console.ReadLine();
        //        Console.WriteLine("Informe Seu Telefone:");
        //        var telefone = Console.ReadLine();
        //        Console.WriteLine("Informe Seu Endereço:");
        //        var endereco = Console.ReadLine();
        //        Console.WriteLine("Informe o nome da Sua Mãe:");
        //        var mae = Console.ReadLine();
        //        Console.WriteLine("Informe o nome do Seu Pai:");
        //        var pai = Console.ReadLine();
        //        var filiacao = pai + "|" + mae;
        //        Console.WriteLine("Informe Seu CPF ou CNPJ:");
        //        var documento = Console.ReadLine(); ;
        //        clienteDAO.Adiciona(nome, telefone, endereco, filiacao, documento);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Favor Informar um valor valido!");
        //    }
        //    return null;
        //}

        //public virtual IList<Produto> ConsultaProdutoPorNome()
        //{
        //    ISession session = NHibernateHelper.AbreSession();
        //    ProdutoDAO produtoDAO = new ProdutoDAO(session);

        //    Console.WriteLine("Pesquise o Produto Desejado: ");
        //    var textoBusca = Console.ReadLine();
        //    //Consulta 
        //    var produtos = from a in produtoDAO.TodosOsProdutos()
        //                   where a.Nome.Contains(textoBusca)
        //                   select a;
        //    //Impressão
        //    foreach (var produto in produtos)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}", produto.Nome, produto.Preco, produto.Categoria.Nome);
        //    }
        //    Console.ReadKey();

        //    return null;
        //}

        //public virtual IList<Produto> IncluirProdutoPedido()
        //{
        //    ISession session = NHibernateHelper.AbreSession();
        //    ProdutoDAO produtoDAO = new ProdutoDAO(session);

        //    var todosOsProdutos = produtoDAO.TodosOsProdutos();
        //    do
        //    {
        //        Console.WriteLine("Para Incluir produtos no carrinho digite digite 1, para Fechar Pedido digite 2:");
        //        var opcao = Convert.ToInt16(Console.ReadLine());

        //        if (opcao == 1)
        //        {
        //            Console.WriteLine("Escolha os Produtos Desejados Informando seu ID: ");
        //            var produtoEscolhido = Console.ReadLine();
        //            var itemPedido = produtoDAO.BuscaPorId(Convert.ToInt16(produtoEscolhido));
        //            List<Produto> listaDeProdutos = new List<Produto>();
        //            listaDeProdutos.Add(itemPedido);
        //            foreach (var item in listaDeProdutos)
        //            {
        //                Console.WriteLine("{0}\t{1}", item.Nome, item.Preco);
        //            }
        //            return listaDeProdutos;
        //        }
        //        else if (opcao == 2)
        //        {
        //            break;
        //        }
        //    }
        //    while (true);

        //    return null;
        //}

    }
}
