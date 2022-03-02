using Xunit;

namespace Demo.Tests
{
    public class AssertObjectTypesTests
    {
        [Fact(DisplayName = "Criar Deve Retornar Tipo Funcionario")]
        public void FuncionarioFactory_Criar_Deve_RetornarTipoFuncionario()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Joao", 10000);

            // Assert 
            Assert.IsType<Funcionario>(funcionario);
        }

        [Fact(DisplayName = "Criar Deve Retornar Tipo Derivado Pessoa")]
        public void funcionarioFactory_Criar_DeveRetornarTipoDerivadoPessoa()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Joao", 10000);

            // Assert 
            Assert.IsAssignableFrom<Pessoa>(funcionario);
        }
    }
}