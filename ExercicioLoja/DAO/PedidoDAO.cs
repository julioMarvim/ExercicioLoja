using ExercicioLoja.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.DAO
{
    public class PedidoDAO
    {
        private ISession session;

        public PedidoDAO(ISession session)
        {
            this.session = session;
        }

        //INCLUIR LISTA DE PRODUTOS NO METODO - 

        public void Adiciona(DateTime datadoPedido, int quantidadeDeProdutos, decimal valorTotal, IList<Produto> produtos, Cliente clienteId)
        {
            ITransaction transacao = session.BeginTransaction();

            Pedido pedido = new Pedido();
            ClienteDAO buscarCliente = new ClienteDAO(session);
            ProdutoDAO produtoDAO = new ProdutoDAO(session);

            pedido.DataDoPedido = datadoPedido;
            pedido.QuantidadeDeProdutos = quantidadeDeProdutos;
            pedido.Produtos = produtos;
            pedido.ValorTotal = valorTotal;
            pedido.Cliente = clienteId;

            session.Save(pedido);
            transacao.Commit();
        }

        public Pedido BuscaPorId(int id)
        {
            return session.Get<Pedido>(id);
        }

    }
}
