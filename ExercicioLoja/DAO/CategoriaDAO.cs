using ExercicioLoja.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.DAO
{
    public class CategoriaDAO
    {
        private ISession session;

        public CategoriaDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(string nome)
        {

            ITransaction transacao = session.BeginTransaction();

            Categoria categoria = new Categoria();
            categoria.Nome = nome;

            session.Save(categoria);
            transacao.Commit();
        }

        public Categoria BuscaPorId(int id)
        {
            return session.Get<Categoria>(id);
        }
    }
}
