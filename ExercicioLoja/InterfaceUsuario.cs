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
    static class InterfaceUsuario
    {
        static ISession session = NHibernateHelper.AbreSession();
        static ProdutoDAO produtoDAO = new ProdutoDAO();
        static Cliente cliente = new Cliente();

        static Cliente MenuInicial()
        {
            Console.WriteLine("---------------- - OLÁ É UM PRAZER TE - LO EM NOSSA LOJA--------------------");
            Console.WriteLine("Se ja for cadastrado digite 1, se não for digite 2 para se cadastrar: ");
            var opcao = Console.ReadLine();
        }

        static Cliente Menu(Cliente clienteId)
        {
            cliente.Id = clienteId;

            Console.WriteLine("-----------------------BEM VINDO A NOSSA LOJA---------------------------");
            Console.WriteLine(
                "Para Criar um fazer um novo Pedido Digite 1: \n " +
                "Para retirar um Produto do Pedido digite 2 \n " +
                "Para consultar Valor do Pedido digite 3");
            var opcao = Console.ReadLine();
            // incluir produto no pedido
            if (opcao == "1")
            {
                //Metodo IncluirProduto()
                cliente.SelecionarProduto();
            }
            
        }
    }
}
