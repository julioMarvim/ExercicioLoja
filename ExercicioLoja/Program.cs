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
    public class Program
    {
        public static void Main(string[] args)
        {
            ISession session = NHibernateHelper.AbreSession();

            FornecedorDAO fornecedorDAO = new FornecedorDAO(session);
            ClienteDAO clienteDAO = new ClienteDAO(session);
            CategoriaDAO categoriaDAO = new CategoriaDAO(session);
            ProdutoDAO produtoDAO = new ProdutoDAO(session);

            //NHibernateHelper.GeraSchema();
            //fornecedorDAO.Adiciona("Ibanez Guitar", "(31)99876-5432", "Rua da Guitarra - 1000", "99.999.999/9999-99");
            //clienteDAO.Adiciona("Julio Marvim", "(31)97335-9094", "Rua São Gotardo - 129", "Delmira Pego|Venceslau Aparecido", "114.377.886-37");
            //categoriaDAO.Adiciona("Instrumentos Musicais");
            //produtoDAO.Adiciona("Guitarra Ibanez", 2050, categoriaDAO.BuscaPorId(1), new DateTime(2018, 01, 23), new DateTime(2035, 01, 01), fornecedorDAO.BuscaPorId(1));
            //produtoDAO.Adiciona("Guitarra Fender", 3500, categoriaDAO.BuscaPorId(1), new DateTime(2018, 01, 23), new DateTime(2035, 01, 01), fornecedorDAO.BuscaPorId(1));
            //produtoDAO.Adiciona("Violão Tagima", 500, categoriaDAO.BuscaPorId(1), new DateTime(2018, 01, 23), new DateTime(2035, 01, 01), fornecedorDAO.BuscaPorId(1));
            InterfaceCliente.MenuInicial();
            Console.ReadKey();
        }
    }       
}
