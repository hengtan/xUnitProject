using System;
using NerdStore.Core.DomainObject;
using Xunit;

namespace NerdStore.Vendas.Domain.Tests
{
    public class PedidoItemTest
    {
        [Fact(DisplayName = "Novo item pedido com unidades abaixo do permitido")]
        [Trait("Categoria", "Vendas - Pedido Item")]
        public void AdicionarItemPedido_UnidadesItemAbaixoDoPermitido_DeveRetornarException()
        {
            // Arrange & Act & Assert 
            Assert.Throws<DomainException>(() => new PedidoItem(Guid.NewGuid(), "Produto Teste", Pedido.Pedido.MIN_UNIDADES_ITEM - 1, 100));
        }
    }
}