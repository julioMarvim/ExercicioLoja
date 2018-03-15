﻿using ExercicioLoja.Entidades;
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

        public ProdutoDAO(ISession session)
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
            var ListaDeProdutos = this.BuscaProdutos("", 0, "");

            foreach (var buscarProduto in ListaDeProdutos)
            {
                Console.WriteLine("Nome: {0} Preco: R${1} Categoria: {2}",
                    buscarProduto.Nome.PadRight(20),
                    buscarProduto.Preco.ToString().PadRight(20),
                    buscarProduto.Categoria.Nome);                   
            }
            return ListaDeProdutos;
        }

        public Produto BuscaPorId(int id)
        {
            return session.Get<Produto>(id);
        }
    }
}
