using ExercicioLoja.Entidades;
using ExercicioLoja.Infra;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.DAO
{
    public class ClienteDAO
    {
        private ISession session;

        public ClienteDAO(ISession session)
        {
            this.session = session;
        }


        //Adicionar Novo Cliente
        public void Adiciona(string nome, string telefone, string endereco, string filiacao, string documento)
        {
            ITransaction transacao = session.BeginTransaction();

            Cliente cliente = new Cliente();
            cliente.Nome = nome;
            cliente.Telefone = telefone;
            cliente.Endereco = endereco;
            cliente.Filiacao = filiacao;
            cliente.Documento = documento;
            cliente.Status = "Bom";
            cliente.LimiteDeCredito = 3000;

            session.Save(cliente);
            transacao.Commit();
        }
       
        //Buscar Cliente por Nome
        public List<Cliente> BuscaPorNome(string nome)
        {
            ICriteria criteria = session.CreateCriteria<Cliente>();
            if (!String.IsNullOrEmpty(nome))
                criteria.Add(Restrictions.Eq("Nome", nome));
            else
                return null;
            var listaDeClientes = criteria.List<Cliente>();
            if (listaDeClientes.Count() > 0)
                return listaDeClientes.ToList();
            else
                return null;
        }
    }

}
