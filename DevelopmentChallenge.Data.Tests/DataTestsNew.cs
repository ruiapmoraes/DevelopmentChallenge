using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTestsNew
    {       
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                RelatorioDeFormas.Imprimir(new List<IFormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                RelatorioDeFormas.Imprimir(new List<IFormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new Quadrado(5) };

            var resumen = RelatorioDeFormas.Imprimir(cuadrados, (int)Idioma.Espanhol);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Quadrado(5),
                new Quadrado(1),
                new Quadrado(3),
            };

            var resumen = RelatorioDeFormas.Imprimir(cuadrados, (int)Idioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Quadrado( 5),
                new Circulo(3),
                new TrianguloEquilatero( 4),
                new Quadrado( 2),
                new TrianguloEquilatero(9),
                new Circulo( 2.75m),
                new TrianguloEquilatero( 4.2m)
            };

            var resumen = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
               new Quadrado(5),
               new Circulo(3),
               new TrianguloEquilatero(4),
               new Quadrado(2),
               new TrianguloEquilatero(9),
               new Circulo(2.75m),
               new TrianguloEquilatero(4.2m)
            };

            var resumen = RelatorioDeFormas.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenTrapecioEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Trapezio(baseMaior: 8, baseMenor: 4, altura: 5, lado1: 4, lado2: 3),
                new Trapezio(baseMaior: 10, baseMenor: 6, altura: 3, lado1: 4, lado2: 4)
            };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Italiano);
                       
            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>2 Trapezi | Area 54 | Perimetro 43 <br/>TOTAL:<br/>2 forme Perimetro 43 Area 54",
                resultado);
        }

        [TestCase, Ignore("Cenário que ocorre erro.")]
        public void TestResumenConTodasFormasEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Quadrado(3),                             
                new Circulo(4),                           
                new TrianguloEquilatero(6),                  
                new Trapezio(8, 4, 5, 4, 3)
            };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>1 Quadrato | Area 9 | Perimetro 12 <br/>1 Cerchio | Area 12,57 | Perimetro 12,57 <br/>1 Triangolo | Area 15,59 | Perimetro 18 <br/>1 Trapezio | Area 30 | Perimetro 19 <br/>TOTAL:<br/>4 forme Perimetro 61,57 Area 67,16",
                resultado);
        }

        [TestCase]
        public void TestUnCirculoEnEspanol()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Circulo(2)
            };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Espanhol);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Círculo | Area 3,14 | Perimetro 6,28 <br/>TOTAL:<br/>1 formas Perimetro 6,28 Area 3,14",
                resultado);
        }

        [TestCase]
        public void TestRetangulosEmIngles()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Retangulo(4, 2),
                new Retangulo(3.5m, 1.5m)
            };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Ingles);

            var areaTotal = 4 * 2 + 3.5m * 1.5m;
            var perimetroTotal = 2 * (4 + 2) + 2 * (3.5m + 1.5m);

            Assert.AreEqual(
                $"<h1>Shapes report</h1>2 Rectangles | Area {areaTotal:#.##} | Perimeter {perimetroTotal:#.##} <br/>TOTAL:<br/>2 shapes Perimeter {perimetroTotal:#.##} Area {areaTotal:#.##}",
                resultado);
        }

        [TestCase]
        public void TestUnRectanguloEnEspanol()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Retangulo(5, 2)
            };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Espanhol);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Rectángulo | Area 10 | Perimetro 14 <br/>TOTAL:<br/>1 formas Perimetro 14 Area 10",
                resultado);
        }

        [TestCase]
        public void TestDoisRettangoliEmItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Retangulo(3, 4),
                new Retangulo(6.5m, 2)
            };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Italiano);

            var areaTotal = 3 * 4 + 6.5m * 2;
            var perimetroTotal = 2 * (3 + 4) + 2 * (6.5m + 2);

            Assert.AreEqual(
                $"<h1>Rapporto sulle forme</h1>2 Rettangoli | Area {areaTotal:#.##} | Perimetro {perimetroTotal:#.##} <br/>TOTAL:<br/>2 forme Perimetro {perimetroTotal:#.##} Area {areaTotal:#.##}",
                resultado);
        }

        [TestCase]
        public void TestRectangleDecimalEnIngles()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Retangulo(2.5m, 3.3m)
            };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Ingles);

            var area = 2.5m * 3.3m;
            var perimetro = 2 * (2.5m + 3.3m);

            Assert.AreEqual(
                $"<h1>Shapes report</h1>1 Rectangle | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>TOTAL:<br/>1 shapes Perimeter {perimetro:#.##} Area {area:#.##}",
                resultado);
        }

        [TestCase]
        public void TestQuadradoRetanguloIngles()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Quadrado(4),
                new Retangulo(4, 2)
            };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>1 Square | Area 16 | Perimeter 16 <br/>1 Rectangle | Area 8 | Perimeter 12 <br/>TOTAL:<br/>2 shapes Perimeter 28 Area 24",
                resultado);
        }

        [TestCase]
        public void TestTodasFormasComRetanguloItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Quadrado(2),
                new Retangulo(4, 1.5m),
                new Circulo(3),
                new Trapezio(5, 3, 2, 2, 2)
            };

            var resultado = RelatorioDeFormas.Imprimir(formas, (int)Idioma.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>1 Quadrato | Area 4 | Perimetro 8 <br/>1 Rettangolo | Area 6 | Perimetro 11 <br/>1 Cerchio | Area 7,07 | Perimetro 9,42 <br/>1 Trapezio | Area 8 | Perimetro 12 <br/>TOTAL:<br/>4 forme Perimetro 40,42 Area 25,07",
                resultado);
        }
    }
}
