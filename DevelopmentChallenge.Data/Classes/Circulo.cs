﻿using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        private decimal _diametro;
        public Circulo(decimal diametro) => _diametro = diametro;
        public decimal CalcularArea() => (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        public decimal CalcularPerimetro() => (decimal)Math.PI * _diametro;
        public string Nome(int idioma, int quantidade) => Localizacao.ObterNomeForma(Forma.Circulo, idioma, quantidade);
    }
}
