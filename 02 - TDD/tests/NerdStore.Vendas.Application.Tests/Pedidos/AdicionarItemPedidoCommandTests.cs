using System;
using System.Linq;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Domain.Pedido;
using Xunit;

namespace NerdStore.Vendas.Application.Tests.Pedidos
{
    public class AdicionarItemPedidoCommandTests
    {
        [Fact(DisplayName = "Adicionar item Command valido")]
        [Trait("Categoria", "Vendas - Pedido Commands")]
        public void AdicionarItemPedidoCommand_CommandEstaValido_DevePassarNaValidacao()
        {
            // Arrange
            var pedidoCommand = new AdicionarItemPedidoCommand(
                Guid.NewGuid(), Guid.NewGuid(), "Produto 1", 2, 100);
            
            // Act
            var result = pedidoCommand.EhValido();

            // Assert 
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar item Command invalido")]
        [Trait("Categoria", "Vendas - Pedido Commands")]
        public void AdicionarItemPedidoCommand_CommandEstainvalido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var pedidoCommand = new AdicionarItemPedidoCommand(
                Guid.Empty, Guid.Empty, "", 0, 0);

            // Act
            var result = pedidoCommand.EhValido();

            // Assert 
            Assert.False(result);
            Assert.Contains(AdicionarItemPedidoValidation.IdClienteErroMsg, pedidoCommand.ValidationResult.Errors.Select(c=>c.ErrorMessage));
            Assert.Contains(AdicionarItemPedidoValidation.IdProdutoErroMsg, pedidoCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AdicionarItemPedidoValidation.NomeErroMsg, pedidoCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AdicionarItemPedidoValidation.QtdMinErroMsg, pedidoCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AdicionarItemPedidoValidation.ValorErroMsg, pedidoCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));

        }

        [Fact(DisplayName = "Adicionar item Command unidades acima do permitido")]
        [Trait("Categoria", "Vendas - Pedido Commands")]
        public void AdicionarItemPedidoCommand_QuantidadeUnidadesSuperiorAoPermitido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var pedidoCommand = new AdicionarItemPedidoCommand(
                Guid.NewGuid(), Guid.NewGuid(), "Produto 1", Pedido.MAX_UNIDADES_ITEM + 1 , 100);

            // Act
            var result = pedidoCommand.EhValido();

            // Assert 
            Assert.False(result);
            Assert.Contains(AdicionarItemPedidoValidation.QtdMaxErroMsg, pedidoCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
        }
    }
}