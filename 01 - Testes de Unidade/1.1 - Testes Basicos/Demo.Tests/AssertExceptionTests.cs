using System;
using Xunit;

namespace Demo.Tests
{
    public class AssertExceptionTests
    {
        [Fact(DisplayName = "Calculadora Dividir Deve Retornar Erro Divisao Por Zero")]
        public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero()
        {
            // Arrange
            var calculadora = new Calculadora();
            
            // Act & Assert 
            Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));
        }

        [Fact(DisplayName = "Funcionario Salario Deve Retornar Erro Slario Inferior Permitido")]
        public void Funcionario_Salario_DeveRetornarErroSalarioInferiorPermitido()
        {
            // Arrange & Act & Act
            var exception =
                Assert.Throws<Exception>(() => FuncionarioFactory.Criar("Joao da Silva", 250));

            Assert.Equal("Salario inferior ao permitido", exception.Message);
        }
    }
}