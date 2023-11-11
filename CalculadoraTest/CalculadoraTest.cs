using Projeto;

namespace ProjetoTest
{
    public class CalculadoraTest
    {

        ICalculadora divisão = new Dividir();
        ICalculadora multiplicação = new Multiplicar();
        ICalculadora soma = new Somar();
        ICalculadora subtração = new Subtrair();
        CalculadoraGerenciador gerenciadorCalculadora = new CalculadoraGerenciador();

        [Theory]
        [InlineData(10, 2, 12)]
        [InlineData(12, 6, 18)]
        public void Somar(int número1, int número2, int resultado)
        {
            int resultadoCalculadora = soma.Cálculo(primeiroNúmero: número1, segundoNúmero: número2);

            Assert.Equal(resultadoCalculadora, resultado);
        }


        [Theory]
        [InlineData(10, 2, 8)]
        [InlineData(12, 6, 6)]
        public void Subtrair(int número1, int número2, int resultado)
        {
            int resultadoCalculadora = subtração.Cálculo(primeiroNúmero: número1, segundoNúmero: número2);

            Assert.Equal(resultadoCalculadora, resultado);
        }


        [Theory]
        [InlineData(10, 2, 20)]
        [InlineData(12, 6, 72)]
        public void Multiplicar(int número1, int número2, int resultado)
        {
            int resultadoCalculadora = multiplicação.Cálculo(primeiroNúmero: número1, segundoNúmero: número2);

            Assert.Equal(resultadoCalculadora, resultado);
        }


        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(12, 6, 2)]
        public void Dividir(int número1, int número2, int resultado)
        {
            int resultadoCalculadora = divisão.Cálculo(primeiroNúmero: número1, segundoNúmero: número2);

            Assert.Equal(resultadoCalculadora, resultado);
        }


        [Fact]
        public void DividirPorZero()
        {
            Assert.Throws<DivideByZeroException>(() => divisão.Cálculo(primeiroNúmero: 3, segundoNúmero: 0));
        }


        [Fact]
        public void Histórico()
        {

            soma.Cálculo(primeiroNúmero: 10, segundoNúmero: 2);
            soma.Cálculo(primeiroNúmero: 12, segundoNúmero: 6);
            soma.Cálculo(primeiroNúmero: 30, segundoNúmero: 3);
            soma.Cálculo(primeiroNúmero: 36, segundoNúmero: 7);

            var histórico = gerenciadorCalculadora.Histórico();

            Assert.NotEmpty(histórico);
            Assert.Equal(3, histórico.Count());
        }
    }
}