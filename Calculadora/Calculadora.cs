using Projeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class Calculadora
    {

        CalculadoraGerenciador gerenciador = new CalculadoraGerenciador();

        public void AdicionarHistórico(string historico)
        {
            gerenciador.AdicionarHistorico(historico);
        }
    }

    public interface ICalculadora
    {
        int Cálculo(int primeiroNúmero, int segundoNúmero);
    }

    public class Dividir : Calculadora, ICalculadora
    {
        public int Cálculo(int primeiroNúmero, int segundoNúmero)
        {
            int calculo = primeiroNúmero / segundoNúmero;
            base.AdicionarHistórico($"{primeiroNúmero} / {segundoNúmero}");

            return calculo;
        }

    }
    public class Multiplicar : Calculadora, ICalculadora
    {
        public int Cálculo(int primeiroNúmero, int segundoNúmero)
        {
            int calculo = primeiroNúmero * segundoNúmero;
            base.AdicionarHistórico($"{primeiroNúmero} * {segundoNúmero}");

            return calculo;
        }

    }
    public class Somar : Calculadora, ICalculadora
    {
        public int Cálculo(int primeiroNúmero, int segundoNúmero)
        {

            int calculo = primeiroNúmero + segundoNúmero;
            base.AdicionarHistórico($"{primeiroNúmero} + {segundoNúmero}");

            return calculo;
        }

    }
    public class Subtrair : Calculadora, ICalculadora
    {
        public int Cálculo(int primeiroNúmero, int segundoNúmero)
        {
            int calculo = primeiroNúmero - segundoNúmero;
            base.AdicionarHistórico($"{primeiroNúmero} - {segundoNúmero}");

            return calculo;
        }

    }

    public class CalculadoraGerenciador
    {
        const int qtdeDeItensNoHistórico = 3;

        public IDictionary<OperaçãoEnum, ICalculadora> tiposDeCálculo = new Dictionary<OperaçãoEnum, ICalculadora>();
        private static List<String> histórico = new List<String>();

        public void AdicionarHistorico(string operaçãoEfetuada)
        {
            histórico.Insert(0, operaçãoEfetuada);
        }

        public IList<String> Histórico()
        {
            if (histórico.Count > 3)
                histórico.RemoveRange(qtdeDeItensNoHistórico, histórico.Count - qtdeDeItensNoHistórico);
            
            return histórico;
        }

        public IDictionary<OperaçãoEnum, ICalculadora> TiposDeCálculo()
        {
            tiposDeCálculo.Add(OperaçãoEnum.Somar, new Somar());
            tiposDeCálculo.Add(OperaçãoEnum.Subtrair, new Subtrair());
            tiposDeCálculo.Add(OperaçãoEnum.Multiplicar, new Multiplicar());
            tiposDeCálculo.Add(OperaçãoEnum.Dividir, new Dividir());

            return tiposDeCálculo;
        }
    }
}
