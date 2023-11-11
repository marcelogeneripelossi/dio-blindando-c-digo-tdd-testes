using Projeto;

namespace ProjetoTest
{
    public class CalculadoraTest
    {

        ICalculadora divis�o = new Dividir();
        ICalculadora multiplica��o = new Multiplicar();
        ICalculadora soma = new Somar();
        ICalculadora subtra��o = new Subtrair();
        CalculadoraGerenciador gerenciadorCalculadora = new CalculadoraGerenciador();

        [Theory]
        [InlineData(10, 2, 12)]
        [InlineData(12, 6, 18)]
        public void Somar(int n�mero1, int n�mero2, int resultado)
        {
            int resultadoCalculadora = soma.C�lculo(primeiroN�mero: n�mero1, segundoN�mero: n�mero2);

            Assert.Equal(resultadoCalculadora, resultado);
        }


        [Theory]
        [InlineData(10, 2, 8)]
        [InlineData(12, 6, 6)]
        public void Subtrair(int n�mero1, int n�mero2, int resultado)
        {
            int resultadoCalculadora = subtra��o.C�lculo(primeiroN�mero: n�mero1, segundoN�mero: n�mero2);

            Assert.Equal(resultadoCalculadora, resultado);
        }


        [Theory]
        [InlineData(10, 2, 20)]
        [InlineData(12, 6, 72)]
        public void Multiplicar(int n�mero1, int n�mero2, int resultado)
        {
            int resultadoCalculadora = multiplica��o.C�lculo(primeiroN�mero: n�mero1, segundoN�mero: n�mero2);

            Assert.Equal(resultadoCalculadora, resultado);
        }


        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(12, 6, 2)]
        public void Dividir(int n�mero1, int n�mero2, int resultado)
        {
            int resultadoCalculadora = divis�o.C�lculo(primeiroN�mero: n�mero1, segundoN�mero: n�mero2);

            Assert.Equal(resultadoCalculadora, resultado);
        }


        [Fact]
        public void DividirPorZero()
        {
            Assert.Throws<DivideByZeroException>(() => divis�o.C�lculo(primeiroN�mero: 3, segundoN�mero: 0));
        }


        [Fact]
        public void Hist�rico()
        {

            soma.C�lculo(primeiroN�mero: 10, segundoN�mero: 2);
            soma.C�lculo(primeiroN�mero: 12, segundoN�mero: 6);
            soma.C�lculo(primeiroN�mero: 30, segundoN�mero: 3);
            soma.C�lculo(primeiroN�mero: 36, segundoN�mero: 7);

            var hist�rico = gerenciadorCalculadora.Hist�rico();

            Assert.NotEmpty(hist�rico);
            Assert.Equal(3, hist�rico.Count());
        }
    }
}