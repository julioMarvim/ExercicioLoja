using ExercicioLoja.Entidades;
using NHibernate;
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

        public ProdutoDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(string nome, decimal preco, Categoria categoria, DateTime dataDeFabricacao, DateTime dataDeValidade)
        {

            ITransaction transacao = session.BeginTransaction();

            Produto produto = new Produto();
            produto.Nome = nome;
            produto.Preco = preco;
            produto.Categoria = categoria;
            produto.DataDeFabricacao = dataDeFabricacao;
            produto.DataDeValidade = dataDeValidade;

            session.Save(produto);
            transacao.Commit();
        }

        public Produto BuscaPorId(int id)
        {
            return session.Get<Produto>(id);
        }
    }
}
