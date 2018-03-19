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



        //Buscar Cliente Por Id
        public Cliente BuscaPorId(int id)
        {
            return session.Get<Cliente>(id);
        }

        //public Cliente BuscaPorNome(string nome)
        //{
        //    return session.Get<Cliente>(nome);
        //}


        //public cliente buscapornome(string nome)
        //{
        //    return session.get<cliente>(nome);
        //}
        //public Cliente BuscaPorNome(string nome)
        //{
        //    Cliente cliente = new Cliente();
        //    var ClienteNome = from a in cliente.Nome
        //                   where a.Nome.Contains(nome)
        //                   select a;

        //}



        //public Cliente BuscaPorNome(string nome)
        //{
        //    ISession session = NHibernateHelper.AbreSession();
        //    ClienteDAO clienteDAO = new ClienteDAO(session);
        //    Console.WriteLine("Informe seu nome para que possamos identifica-lo");
        //    var encontrarCliente = Console.ReadLine();

        //    String hql = "from Cliente p where p.Nome = : nome";
        //    IQuery query = session.CreateQuery(hql);
        //    query.SetParameter("nome", encontrarCliente);
        //    IList<Cliente> clientes = query.List<Cliente>();
        //    foreach (Cliente cliente in clientes)
        //    {
        //        Console.WriteLine("Olá, {0}", cliente.Nome, "Bem vindo!");
        //    }
        //    return null;
        //}

        public List<Cliente> BuscaPorNome(string nome)
        {
            ICriteria criteria = session.CreateCriteria<Cliente>();
            if (!String.IsNullOrEmpty(nome))
                criteria.Add(Restrictions.Eq("NomeCliente", nome));
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
