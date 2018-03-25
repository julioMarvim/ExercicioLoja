using ExercicioLoja.DAO;
using ExercicioLoja.Infra;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.Entidades
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Filiacao { get; set; }
        public virtual string Status { get; set; }
        public virtual decimal LimiteDeCredito { get; set; }
        public virtual string Documento { get; set; }

        private Pedido Pedido = null;

        public virtual Pedido CriarPedido()
        {
            this.Pedido = new Pedido();
            Pedido.Produtos = new List<Produto>();
            Pedido.DataDoPedido = DateTime.Now;
            return this.Pedido;
        }

        public virtual void AdicionarProdutoPedido(Produto produtoId)
        {
            if (this.Pedido != null)
            {
                this.Pedido.Produtos.Add(produtoId);
                Pedido.ValorTotal += produtoId.Preco;
                Pedido.QuantidadeDeProdutos++;
            }
            else
            {
                CriarPedido();
                this.Pedido.Produtos.Add(produtoId);
                Pedido.ValorTotal += produtoId.Preco;
                Pedido.QuantidadeDeProdutos++;                
            }
            Console.WriteLine(produtoId.Nome+", foi incluido no Carrinho!");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        public virtual void  RemoverProdutoPedido(int produtoId)
        {
            Produto produto = null;

            if (this.Pedido != null)
            {
                IList<Produto> listaProdutosPedido = Pedido.Produtos;
                foreach (var item in listaProdutosPedido)
                {
                    if (item.Id.Equals(produtoId))
                    {
                        produto = item;
                        break;
                    }
                }
                
                if (produto != null)
                {
                    Pedido.ValorTotal -= produto.Preco;
                    listaProdutosPedido.Remove(produto);
                    Console.WriteLine("O Produto foi removido do Pedido!");
                    Console.WriteLine("-----------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado!");
                    Console.WriteLine("------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Não há produtos no seu Carrinho");
                Console.WriteLine("------------------------------------------------------------------------------");
            }
        }

        public virtual Pedido PegarPedido()
        {
            if(this.Pedido != null)
            {
                return this.Pedido;
            }
            else
            {
                return null;
            }
        }

        public virtual decimal PegarValorTotalPedido()
        {
            if (Pedido != null)
            {
               return this.Pedido.ValorTotal;
            }
            return 0;
        }

        public virtual void FecharPedido()
        {
            if (this.Pedido != null && Pedido.QuantidadeDeProdutos > 0)
            {
                ISession session = NHibernateHelper.AbreSession();
                PedidoDAO pedidoDAO = new PedidoDAO(session);  
                pedidoDAO.Adiciona(Pedido.DataDoPedido, this.Pedido.QuantidadeDeProdutos, this.Pedido.ValorTotal, (List<Produto>)Pedido.Produtos, this);

                session.Close();                
                this.Pedido.Produtos.Clear();
                Console.WriteLine("VENDA REALIZADA COM SUCESSO!!");
            }
            else
            {
                Console.WriteLine("Seu carrinho não possui nenhum produto!");
            }
                    
        }
    }
}
