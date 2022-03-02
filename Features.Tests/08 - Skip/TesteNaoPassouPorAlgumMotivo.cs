using Xunit;
using Xunit.Abstractions;

namespace Features.Tests._08___Skip
{
    public class TesteNaoPassouPorAlgumMotivo
    {
        private readonly ITestOutputHelper _outputHelper;

        public TesteNaoPassouPorAlgumMotivo(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact(DisplayName = "Novo método 2.0", Skip = "Novo metodo precisa de tratamento")]
        [Trait("Categoria", "Skipando o teste")]
        public void SomaService_Calcular_RetornarSoma()
        {
            _outputHelper.WriteLine($"Deu ruim");
            Assert.True(false);
        }
    }
}