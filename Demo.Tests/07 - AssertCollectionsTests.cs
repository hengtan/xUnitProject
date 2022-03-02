using Xunit;

namespace Demo.Tests
{
    public class AssertCollectionsTests
    {
        [Fact(DisplayName = "Funcionario Habilidades Nao Deve Possuir Habilidades Vazias")]
        public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Joao", 100000);

            // Assert 
            Assert.All(funcionario.Habilidades, habilidade => Assert.False(string.IsNullOrWhiteSpace(habilidade)));
        }

        [Fact(DisplayName = "Funcionario Junior Deve Possuir Habilidade Basica")]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadeBasica()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Joao", 1000);

            // Assert 
            Assert.Contains("OOP", funcionario.Habilidades);
        }

        [Fact(DisplayName = "Funcionario Junior Nao Deve Possuir Habilidade Basica")]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadeBasica()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Joao", 1000);

            // Assert 
            Assert.DoesNotContain("Microservices", funcionario.Habilidades);
        }

        [Fact(DisplayName = "Funcionario Senior Deve Possuir Habilidade Basica")]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidade()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Joao", 15000);

            var habilidadesBasicas = new[]
            {
                "Logica de Programacao",
                "OOP",
                "Testes",
                "Microservices"
            };

            // Assert 
            Assert.Equal(habilidadesBasicas, funcionario.Habilidades);
        }
    }
}