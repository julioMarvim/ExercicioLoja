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



        //public virtual IList<Produto> IncluirProdutoNoPedido(List<Produto> produtoEscolhido)
        //{
        //    ISession session = NHibernateHelper.AbreSession();
        //    ProdutoDAO produtoDAO = new ProdutoDAO(session);

        //    var produtoEscolhido = produtoDAO.BuscaProdutos(produto, 0, "");

        //    return produtoEscolhido;
        //}

        //definição de uma consulta
        public virtual IList<Produto> ConsultaProdutos()
        {
            ISession session = NHibernateHelper.AbreSession();
            ProdutoDAO produtoDAO = new ProdutoDAO(session);

            Console.WriteLine("Pesquise o Produto Desejado: ");
            var textoBusca = Console.ReadLine();
            //Consulta 
            var produtos = from a in produtoDAO.TodosOsProdutos()
                           where a.Nome.Contains(textoBusca)
                           select a;
            //Impressão
            foreach (var produto in produtos)
            {
                Console.WriteLine("{0}\t{1}\t{2}", produto.Nome, produto.Preco, produto.Categoria.Nome);
            }
            Console.ReadKey();

            return null;
        }
       
    }
}
