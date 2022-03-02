using Xunit;

namespace Features.Tests._08___Skip
{
    public class TesteNaoPassouPorAlgumMotivo
    {
        [Fact(DisplayName = "Novo método 2.0", Skip = "Novo metodo precisa de tratamento")]
        [Trait("Categoria", "Skipando o teste")]
        public void SomaService_Calcular_RetornarSoma()
        {
            Assert.True(false);
        }
    }
}