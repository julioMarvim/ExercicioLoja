using System;
using ExercicioLoja.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes
{
    [TestClass]
    public class ClienteTeste
    {
        [TestMethod]
        public void DeveCriarUmPedido()
        {
            Cliente cliente = new Cliente();

            cliente.CriarPedido();

            Assert.IsNotNull(cliente.PegarPedido());

        }
        [TestMethod]
        public void DeveAdicionarUmProdutoNoPedido()
        {
            Cliente cliente = new Cliente();
            Produto produto = new Produto();
            Pedido pedido = new Pedido();

            cliente.AdicionarProdutoPedido(produto);
            Assert.AreEqual(produto ,cliente.PegarPedido().Produtos);

        }   
    }
}
