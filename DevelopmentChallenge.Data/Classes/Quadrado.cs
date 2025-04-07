using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Quadrado : IFormaGeometrica
    {
        private decimal _lado;
        public Quadrado(decimal lado) => _lado = lado;
        public decimal CalcularArea() => _lado * _lado;
        public decimal CalcularPerimetro() => _lado * 4;

        public string Nome(int idioma, int quantidade)
        {
            var cultura = IdiomaHelper.ObterCulture(idioma);
            var chave = quantidade == 1 ? "Square_Singular" : "Square_Plural";
            return Resources.Strings.ResourceManager.GetString(chave, cultura);
        }
    }
}
