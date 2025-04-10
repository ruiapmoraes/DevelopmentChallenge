using DevelopmentChallengeNet8.Data.Helpers;
using DevelopmentChallengeNet8.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallengeNet8.Data.Classes
{
    public class Retangulo : IFormaGeometrica
    {
        private decimal _largura;
        private decimal _altura;

        public Retangulo(decimal largura, decimal altura)
        {
            _largura = largura;
            _altura = altura;
        }

        public decimal CalcularArea() => _largura * _altura;

        public decimal CalcularPerimetro() => 2 * (_largura + _altura);

        public string Nome(int idioma, int quantidade)
        {
            var cultura = IdiomaHelper.ObterCulture(idioma);
            var chave = quantidade == 1 ? "Rectangle_Singular" : "Rectangle_Plural";
            return Resource.Strings.ResourceManager.GetString(chave, cultura);
        }
    }
}
