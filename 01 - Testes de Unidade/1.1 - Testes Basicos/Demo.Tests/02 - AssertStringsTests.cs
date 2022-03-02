using Xunit;

namespace Demo.Tests
{
    public class AssertStringsTests
    {
        [Fact]
        public void StringsTools_UnirNomes_RetornarNomeCompleto()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Heng", "Tan");

            // Assert
            Assert.Equal("Heng Tan", nomeCompleto);
        }

        [Fact(DisplayName = "Ignorar Case")]
        public void StringsTools_UnirNomes_DeveIgnorarCase()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("heng", "tan");

            // Assert
            Assert.Equal(nomeCompleto, "heng tan", ignoreCase:true);
        }

        [Fact(DisplayName = "Deve Conter Um Trecho")]
        public void FactMethodName()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Heng", "Tan");

            // Assert 
            Assert.Contains("eng", nomeCompleto);
        }

        [Fact(DisplayName = "Deve Acabar Com")]
        public void StringsTools_UnirNomes_DeveAcabarCom()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Heng", "Tan");

            // Assert 
            Assert.EndsWith("an", nomeCompleto);
        }

        [Fact(DisplayName = "Validar Expressao Regular")]
        public void StringsTools_UnirNomes_ValidarExpressaoRegular()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var nomeCompleto = sut.Unir("Heng", "Tan");

            // Assert 
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);
        }
    }
}