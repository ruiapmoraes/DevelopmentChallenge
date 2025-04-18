﻿using DevelopmentChallengeNet8.Data.Helpers;
using DevelopmentChallengeNet8.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallengeNet8.Data.Classes
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
        public string Nome(int idioma, int quantidade)
        {
            var cultura = IdiomaHelper.ObterCulture(idioma);
            var chave = quantidade == 1 ? "Trapezoid_Singular" : "Trapezoid_Plural";
            return Resource.Strings.ResourceManager.GetString(chave, cultura);
        }
    }
}
