using ExercicioLoja.Entidades;
using NHibernate;
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

        public void Adiciona(int valorTotal, int idCliente)
        {
            ITransaction transacao = session.BeginTransaction();

            Pedido pedido = new Pedido();
            ClienteDAO buscarCliente = new ClienteDAO(session);
            ProdutoDAO produtoDAO = new ProdutoDAO(session);

            pedido.DataDoPedido = DateTime.Now;
            pedido.Produtos = produtoDAO.BuscaProdutos("",0,"");
            pedido.ValorTotal = valorTotal;
            pedido.Cliente = buscarCliente.BuscaPorId(Convert.ToInt32(idCliente));

            session.Save(pedido);
            transacao.Commit();
        }

        public Pedido BuscaPorId(int id)
        {
            return session.Get<Pedido>(id);
        }
    }
}
