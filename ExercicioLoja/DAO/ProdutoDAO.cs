using ExercicioLoja.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.DAO
{
    public class ProdutoDAO
    {
       private ISession session;

        static public ProdutoDAO(ISession session)
        {
            this.session = session;
        }


        //Adicionar Produto no BD
        public void Adiciona(string nome, decimal preco, Categoria categoria, DateTime dataDeFabricacao, DateTime dataDeValidade, Fornecedor fornecedor)
        {

            ITransaction transacao = session.BeginTransaction();

            Produto produto = new Produto();
            produto.Nome = nome;
            produto.Preco = preco;
            produto.Categoria = categoria;
            produto.DataDeFabricacao = dataDeFabricacao;
            produto.DataDeValidade = dataDeValidade;
            produto.Fornecedor = fornecedor;

            session.Save(produto);
            transacao.Commit();
        }

        //Buscar Produto no BD
        public IList<Produto> BuscaProdutos(string nome, decimal precoMinimo, string nomeCategoria)
        {
            ICriteria criteria = session.CreateCriteria<Produto>();
            if (!String.IsNullOrEmpty(nome))
            {
                criteria.Add(Restrictions.Eq("Nome", nome));
            }
            if(precoMinimo > 0)
            {
                criteria.Add(Restrictions.Ge("Preco", precoMinimo));
            }
            if (!String.IsNullOrEmpty(nomeCategoria))
            {
                ICriteria criteriaCategoria = criteria.CreateCriteria("Categoria");
                criteriaCategoria.Add(Restrictions.Eq(nome, nomeCategoria));
            }

            return criteria.List<Produto>();
        }

        //Listar Todos os Produtos Cadastrados
        public IList<Produto> TodosOsProdutos()
        {
            Console.WriteLine("-------------------ESCOLHA OS PRODUTOS QUE DESEJA ----------------------");
            var ListaDeProdutos = this.BuscaProdutos("", 0, "");
            foreach (var produtos in ListaDeProdutos)
            {
                Console.WriteLine("ID: {0}\t Nome: {1}\t Peço: {2}", produtos.Id, produtos.Nome.PadRight(20), produtos.Preco);
            }
            return ListaDeProdutos;
        }

        public Produto BuscaPorId(int id)
        {
            return session.Get<Produto>(id);
        }
    }
}
