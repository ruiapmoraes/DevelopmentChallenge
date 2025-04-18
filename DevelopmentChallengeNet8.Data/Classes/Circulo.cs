﻿using DevelopmentChallengeNet8.Data.Helpers;
using DevelopmentChallengeNet8.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallengeNet8.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        private decimal _diametro;
        public Circulo(decimal diametro) => _diametro = diametro;
        public decimal CalcularArea() => (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        public decimal CalcularPerimetro() => (decimal)Math.PI * _diametro;
        public string Nome(int idioma, int quantidade)
        {
            var cultura = IdiomaHelper.ObterCulture(idioma);
            var chave = quantidade == 1 ? "Circle_Singular" : "Circle_Plural";
            return Resource.Strings.ResourceManager.GetString(chave, cultura);
        }
    }
}
