using System;
using System.Collections.Generic;
using System.Globalization;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Resources;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTestsNew
    {
        private string Traduzir(string chave, int idioma)
        {
            var cultura = ObterCultura(idioma);
            return Strings.ResourceManager.GetString(chave, cultura);
        }

        private CultureInfo ObterCultura(int idioma)
        {
            return IdiomaHelper.ObterCulture(idioma);
        }

        private string FormatarDecimal(decimal valor, int idioma)
        {
            return valor.ToString("N2", ObterCultura(idioma));
        }

        private string FormatarRodape(string template, int total, decimal perimetro, decimal area, int idioma)
        {
            var cultura = ObterCultura(idioma);
            return string.Format(cultura, template, total, perimetro.ToString("N2", cultura), area.ToString("N2", cultura));
        }

        private List<IFormaGeometrica> CriarLista(params IFormaGeometrica[] formas)
        {
            return new List<IFormaGeometrica>(formas);
        }

        [Test]
        public void QuadradoERetangulo_Iguais_Ingles()
        {
            var idioma = (int)Idioma.Ingles;
            var formas = CriarLista(new Quadrado(4), new Retangulo(2, 8));
            var resultado = RelatorioDeFormas.Imprimir(formas, idioma);

            var areaQuad = 4 * 4;
            var perQuad = 4 * 4;

            var areaRet = 2 * 8;
            var perRet = 2 * (2 + 8);

            var esperado = $"<h1>{Traduzir("ReportTitle", idioma)}</h1>" +
                           $"1 {Traduzir("Square_Singular", idioma)} | Area {FormatarDecimal(areaQuad, idioma)} | Perimeter {FormatarDecimal(perQuad, idioma)} <br/>" +
                           $"1 {Traduzir("Rectangle_Singular", idioma)} | Area {FormatarDecimal(areaRet, idioma)} | Perimeter {FormatarDecimal(perRet, idioma)} <br/>" +
                           $"{FormatarRodape(Traduzir("Total", idioma), 2, perQuad + perRet, areaQuad + areaRet, idioma)}";

            Assert.That(resultado, Is.EqualTo(esperado));
            TestContext.WriteLine("QuadradoERetangulo_Iguais_Ingles passou.");
            TestContext.WriteLine(resultado);
        }

        [Test]
        public void Retangulo_Zerado_Ingles()
        {
            var idioma = (int)Idioma.Ingles;
            var formas = CriarLista(new Retangulo(0, 0));
            var resultado = RelatorioDeFormas.Imprimir(formas, idioma);

            var area = 0m;
            var perimetro = 0m;

            var esperado = $"<h1>{Traduzir("ReportTitle", idioma)}</h1>" +
                           $"1 {Traduzir("Rectangle_Singular", idioma)} | Area {FormatarDecimal(area, idioma)} | Perimeter {FormatarDecimal(perimetro, idioma)} <br/>" +
                           $"{FormatarRodape(Traduzir("Total", idioma), 1, perimetro, area, idioma)}";

            Assert.That(resultado, Is.EqualTo(esperado));
            TestContext.WriteLine("Retangulo_Zerado_Ingles passou.");
            TestContext.WriteLine(resultado);
        }

        [Test]
        public void Retangulo_Zerado_Italiano()
        {
            var idioma = (int)Idioma.Italiano;
            var formas = CriarLista(new Retangulo(0, 0));
            var resultado = RelatorioDeFormas.Imprimir(formas, idioma);

            var area = 0m;
            var perimetro = 0m;

            var esperado = $"<h1>{Traduzir("ReportTitle", idioma)}</h1>" +
                           $"1 {Traduzir("Rectangle_Singular", idioma)} | Area {FormatarDecimal(area, idioma)} | Perimetro {FormatarDecimal(perimetro, idioma)} <br/>" +
                           $"{FormatarRodape(Traduzir("Total", idioma), 1, perimetro, area, idioma)}";

            Assert.That(resultado, Is.EqualTo(esperado));
            TestContext.WriteLine("Retangulo_Zerado_Italiano passou.");
            TestContext.WriteLine(resultado);
        }

        [Test]
        public void UmTriangulo_Ingles()
        {
            var idioma = (int)Idioma.Ingles;
            var formas = CriarLista(new TrianguloEquilatero(6));

            var area = ((decimal)Math.Sqrt(3) / 4) * 6 * 6;
            var perimetro = 6 * 3;

            var resultado = RelatorioDeFormas.Imprimir(formas, idioma);

            var esperado = $"<h1>{Traduzir("ReportTitle", idioma)}</h1>" +
                           $"1 {Traduzir("Triangle_Singular", idioma)} | Area {FormatarDecimal(area, idioma)} | Perimeter {FormatarDecimal(perimetro, idioma)} <br/>" +
                           $"{FormatarRodape(Traduzir("Total", idioma), 1, perimetro, area, idioma)}";

            Assert.That(resultado, Is.EqualTo(esperado));
            TestContext.WriteLine("✅ UmTriangulo_Ingles passou.");
            TestContext.WriteLine(resultado);
        }

        [Test]
        public void DoisCirculos_Espanhol()
        {
            var idioma = (int)Idioma.Espanhol;
            var formas = CriarLista(new Circulo(4), new Circulo(2));

            var area = (decimal)Math.PI * 2 * 2 + (decimal)Math.PI * 1 * 1;
            var perimetro = (decimal)Math.PI * 4 + (decimal)Math.PI * 2;

            var resultado = RelatorioDeFormas.Imprimir(formas, idioma);

            var esperado = $"<h1>{Traduzir("ReportTitle", idioma)}</h1>" +
                           $"2 {Traduzir("Circle_Plural", idioma)} | Area {FormatarDecimal(area, idioma)} | Perimetro {FormatarDecimal(perimetro, idioma)} <br/>" +
                           $"{FormatarRodape(Traduzir("Total", idioma), 2, perimetro, area, idioma)}";

            Assert.That(resultado, Is.EqualTo(esperado));
            TestContext.WriteLine("✅ DoisCirculos_Espanhol passou.");
            TestContext.WriteLine(resultado);
        }

        [Test]
        public void MixFormas_Italiano()
        {
            var idioma = (int)Idioma.Italiano;
            var formas = CriarLista(
                new Quadrado(3),
                new Retangulo(2, 6),
                new Circulo(4),
                new Trapezio(6, 4, 3, 2, 2)
            );

            var areaQ = 9m;
            var perQ = 12m;

            var areaR = 12m;
            var perR = 16m;

            var areaC = (decimal)Math.PI * 2 * 2;
            var perC = (decimal)Math.PI * 4;

            var areaT = (6 + 4) * 3 / 2m;
            var perT = 6 + 4 + 2 + 2;

            var totalArea = areaQ + areaR + areaC + areaT;
            var totalPer = perQ + perR + perC + perT;

            var resultado = RelatorioDeFormas.Imprimir(formas, idioma);

            var esperado = $"<h1>{Traduzir("ReportTitle", idioma)}</h1>" +
                           $"1 {Traduzir("Square_Singular", idioma)} | Area {FormatarDecimal(areaQ, idioma)} | Perimetro {FormatarDecimal(perQ, idioma)} <br/>" +
                           $"1 {Traduzir("Rectangle_Singular", idioma)} | Area {FormatarDecimal(areaR, idioma)} | Perimetro {FormatarDecimal(perR, idioma)} <br/>" +
                           $"1 {Traduzir("Circle_Singular", idioma)} | Area {FormatarDecimal(areaC, idioma)} | Perimetro {FormatarDecimal(perC, idioma)} <br/>" +
                           $"1 {Traduzir("Trapezoid_Singular", idioma)} | Area {FormatarDecimal(areaT, idioma)} | Perimetro {FormatarDecimal(perT, idioma)} <br/>" +
                           $"{FormatarRodape(Traduzir("Total", idioma), 4, totalPer, totalArea, idioma)}";

            Assert.That(resultado, Is.EqualTo(esperado));
            TestContext.WriteLine("MixFormas_Italiano passou.");
            TestContext.WriteLine(resultado);
        }

        [TestCase(5, 2, (int)Idioma.Espanhol)]
        [TestCase(3.5, 1.5, (int)Idioma.Ingles)]
        [TestCase(6, 4, (int)Idioma.Italiano)]
        public void TesteRetangulo_Parametrizado(decimal largura, decimal altura, int idioma)
        {
            var formas = new List<IFormaGeometrica> { new Retangulo(largura, altura) };
            var resultado = RelatorioDeFormas.Imprimir(formas, idioma);

            var area = largura * altura;
            var perimetro = 2 * (largura + altura);

            var esperado = $"<h1>{Traduzir("ReportTitle", idioma)}</h1>" +
                           $"1 {Traduzir("Rectangle_Singular", idioma)} | Area {FormatarDecimal(area, idioma)} | " +
                           $"{(idioma == (int)Idioma.Ingles ? "Perimeter" : "Perimetro")} {FormatarDecimal(perimetro, idioma)} <br/>" +
                           $"{FormatarRodape(Traduzir("Total", idioma), 1, perimetro, area, idioma)}";

            Assert.That(resultado, Is.EqualTo(esperado));
            TestContext.WriteLine($"Retângulo: {largura}x{altura} em idioma {idioma} passou.");
        }
    }
}
