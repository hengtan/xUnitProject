using System.Linq;
using System.Threading;
using Features.Clientes;
using MediatR;
using Moq;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteServiceAutomockerFixtureTests
    {
        private readonly ClienteTestsAutoMockerFixture _clienteTestesAutoMockerFixture;

        public ClienteServiceAutomockerFixtureTests(ClienteTestsAutoMockerFixture clienteTestsFixture)
        {
            _clienteTestesAutoMockerFixture = clienteTestsFixture;
            _clienteService = _clienteTestesAutoMockerFixture.ObterClienteService();
        }

        private readonly ClienteService _clienteService;

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service AutoMockFixture Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestesAutoMockerFixture.GerarClienteValido();

            // Act
            _clienteService.Adicionar(cliente);

            // Assert 
            Assert.True(cliente.EhValido());
            _clienteTestesAutoMockerFixture.Mocker.GetMock<IClienteRepository>()
                .Verify(r => r.Adicionar(cliente), Times.Once);
            _clienteTestesAutoMockerFixture.Mocker.GetMock<IMediator>()
                .Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Categoria", "Cliente Service AutoMockFixture Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestesAutoMockerFixture.GerarClienteInvalido();

            // Act
            _clienteService.Adicionar(cliente);

            // Assert 
            Assert.False(cliente.EhValido());
            _clienteTestesAutoMockerFixture.Mocker.GetMock<IClienteRepository>()
                .Verify(r => r.Adicionar(cliente), Times.Never);
            _clienteTestesAutoMockerFixture.Mocker
                .GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Obter Cliente Ativos")]
        [Trait("Categoria", "Cliente Service AutoMockFixture  Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            _clienteTestesAutoMockerFixture.Mocker.GetMock<IClienteRepository>()
                .Setup(c => c.ObterTodos())
                .Returns(_clienteTestesAutoMockerFixture.ObterClientesVariados());

            // Act
            var clientes = _clienteService.ObterTodosAtivos();

            // Assert 
            _clienteTestesAutoMockerFixture.Mocker.GetMock<IClienteRepository>()
                .Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(c => !c.Ativo) > 0);
        }
    }
}