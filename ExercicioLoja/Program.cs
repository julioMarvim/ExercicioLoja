using ExercicioLoja.DAO;
using ExercicioLoja.Entidades;
using ExercicioLoja.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernateHelper.GeraSchema();
            ISession session = NHibernateHelper.AbreSession();
            ClienteDAO clienteDAO = new ClienteDAO(session);
            CategoriaDAO categoriaDAO = new CategoriaDAO(session);
            ProdutoDAO produtoDAO = new ProdutoDAO(session);
            FornecedorDAO fornecedorDAO = new FornecedorDAO(session);
            Categoria categoria = new Categoria();
            Produto produto = new Produto();


            fornecedorDAO.Adiciona("Ibanez", "3194444-4444", "Rua da Guitarra 1999", "99.999.999/9999-99");
    

            Console.ReadKey();
        }
    }
}
