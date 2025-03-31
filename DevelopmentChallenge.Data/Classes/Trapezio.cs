using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapezio : IFormaGeometrica
    {
        private decimal _baseMaior, _baseMenor, _altura, _lado1, _lado2;
        public Trapezio(decimal baseMaior, decimal baseMenor, decimal altura, decimal lado1, decimal lado2)
        {
            _baseMaior = baseMaior;
            _baseMenor = baseMenor;
            _altura = altura;
            _lado1 = lado1;
            _lado2 = lado2;
        }
        public decimal CalcularArea() => ((_baseMaior + _baseMenor) * _altura) / 2;
        public decimal CalcularPerimetro() => _baseMaior + _baseMenor + _lado1 + _lado2;
        public string Nome(int idioma, int quantidade) => Localizacao.ObterNomeForma(Forma.Trapezio, idioma, quantidade);
    }
}
