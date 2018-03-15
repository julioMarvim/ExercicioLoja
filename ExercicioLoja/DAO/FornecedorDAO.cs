using ExercicioLoja.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.DAO
{
    public class FornecedorDAO
    {
        private ISession session;

        public FornecedorDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(string nome, string telefone, string endereco, string cnpj)
        {

            ITransaction transacao = session.BeginTransaction();

            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = nome;
            fornecedor.Telefone = telefone;
            fornecedor.Endereco = endereco;
            fornecedor.CNPJ = cnpj;

            session.Save(fornecedor);
            transacao.Commit();
        }

        public Fornecedor BuscaPorId(int id)
        {
            return session.Get<Fornecedor>(id);
        }
    }
}
