using DevelopmentChallengeNet8.Data.Helpers;
using DevelopmentChallengeNet8.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallengeNet8.Data.Classes
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private decimal _lado;
        public TrianguloEquilatero(decimal lado) => _lado = lado;
        public decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        public decimal CalcularPerimetro() => _lado * 3;
        public string Nome(int idioma, int quantidade)
        {
            var cultura = IdiomaHelper.ObterCulture(idioma);
            var chave = quantidade == 1 ? "Triangle_Singular" : "Triangle_Plural";
            return Resource.Strings.ResourceManager.GetString(chave, cultura);
        }
    }
}
