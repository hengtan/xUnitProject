using Xunit;

namespace Demo.Tests
{
    public class AssertNullBoolTests
    {
        [Fact(DisplayName = "Nome Nao Deve Ser Nulo Ou Vazio")]
        public void Funcionario_Nome_NaoDeveSerNuloOuVazio()
        {
            // Assert & Act
            var funcionario = new Funcionario("", 1000);

            // Assert 
            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
        }

        [Fact(DisplayName = "Apelido Nao Deve Ser Nulo Ou Vazio")]
        public void Funcionario_Apelido_NaoDeveSerNuloOuVazio()
        {
            // Arrange & Act
            var funcionario = new Funcionario("", 1000);

            //Act
            Assert.Null(funcionario.Apelido);

            // Assert Bool
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
            Assert.False(funcionario.Apelido?.Length > 0);
        }
    }
}