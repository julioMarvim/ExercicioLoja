using ExercicioLoja.Entidades;
using ExercicioLoja.Infra;
using NHibernate;
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

        public void Adiciona(string nome, string telefone, string endereco, string filiacao,  string documento)
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

        public Cliente BuscaPorId(int id)
        {
            return session.Get<Cliente>(id);
        }
    }
}
