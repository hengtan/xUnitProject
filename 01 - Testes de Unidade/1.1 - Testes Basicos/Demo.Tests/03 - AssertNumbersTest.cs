using Xunit;

namespace Demo.Tests
{
    public class AssertNumbersTest
    {
        [Fact(DisplayName = "Deve Ser Igual")]
        public void Calculadora_Somar_DeveSerIgual()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var result = calculadora.Somar(1, 2);

            // Assert 
            Assert.Equal(3, result);
        }

        [Fact(DisplayName = "Nao Deve Ser Igual")]
        public void Calculadora_Somar_NaoDeveSerIgual()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var result = calculadora.Somar(1.121213131212121, 2.1213121);

            // Assert 
            Assert.NotEqual(5, result, 1);
        }
    }
}