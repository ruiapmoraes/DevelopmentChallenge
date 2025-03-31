using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class NewDataTests
    {
        [TestCase]
        public void TestResumenTrapecioEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
    {
        new Trapezio(baseMaior: 8, baseMenor: 4, altura: 5, lado1: 4, lado2: 3),
        new Trapezio(baseMaior: 10, baseMenor: 6, altura: 3, lado1: 4, lado2: 4)
    };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Italiano);

            // Área: ((8+4)*5)/2 = 30, ((10+6)*3)/2 = 24
            // Perímetro: 8+4+4+3 = 19, 10+6+4+4 = 24

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>2 Trapezi | Area 54 | Perimetro 43 <br/>TOTAL:<br/>2 forme Perimetro 43 Area 54",
                resultado);
        }

        [TestCase]
        public void TestResumenConTodasFormasEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
    {
        new Quadrado(3),                             // Área 9, Perímetro 12
        new Circulo(4),                              // Área ~12.57, Perímetro ~12.57
        new TrianguloEquilatero(6),                  // Área ~15.59, Perímetro 18
        new Trapezio(8, 4, 5, 4, 3)                  // Área 30, Perímetro 19
    };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Italiano);

            // Área total: 9 + 12.57 + 15.59 + 30 = ~67.16
            // Perímetro total: 12 + 12.57 + 18 + 19 = ~61.57

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>1 Quadrato | Area 9 | Perimetro 12 <br/>1 Cerchio | Area 12,57 | Perimetro 12,57 <br/>1 Triangolo | Area 15,59 | Perimetro 18 <br/>1 Trapezio | Area 30 | Perimetro 19 <br/>TOTAL:<br/>4 forme Perimetro 61,57 Area 67,16",
                resultado);
        }

    }
}
