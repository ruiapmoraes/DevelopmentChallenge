using DevelopmentChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public static class Localizacao
    {
        public static string ObterNomeForma(Forma forma, int idioma, int quantidade)
        {
            switch (idioma)
            {
                case (int)Idioma.Espanhol:
                    switch (forma)
                    {
                        case Forma.Quadrado: return quantidade == 1 ? "Cuadrado" : "Cuadrados";
                        case Forma.Circulo: return quantidade == 1 ? "Círculo" : "Círculos";
                        case Forma.Triangulo: return quantidade == 1 ? "Triángulo" : "Triángulos";
                        case Forma.Trapezio: return quantidade == 1 ? "Trapecio" : "Trapecios";
                        case Forma.Retangulo: return quantidade == 1 ? "Rectángulo" : "Rectángulos";
                    }
                    break;
                case (int)Idioma.Italiano:
                    switch (forma)
                    {
                        case Forma.Quadrado: return quantidade == 1 ? "Quadrato" : "Quadrati";
                        case Forma.Circulo: return quantidade == 1 ? "Cerchio" : "Cerchi";
                        case Forma.Triangulo: return quantidade == 1 ? "Triangolo" : "Triangoli";
                        case Forma.Trapezio: return quantidade == 1 ? "Trapezio" : "Trapezi";
                        case Forma.Retangulo: return quantidade == 1 ? "Rettangolo" : "Rettangoli";
                    }
                    break;
                default:
                    switch (forma)
                    {
                        case Forma.Quadrado: return quantidade == 1 ? "Square" : "Squares";
                        case Forma.Circulo: return quantidade == 1 ? "Circle" : "Circles";
                        case Forma.Triangulo: return quantidade == 1 ? "Triangle" : "Triangles";
                        case Forma.Trapezio: return quantidade == 1 ? "Trapezoid" : "Trapezoids";
                        case Forma.Retangulo: return quantidade == 1 ? "Rectangle" : "Rectangles";
                    }
                    break;
            }
            return string.Empty;
        }

        public static string Cabecalho(int idioma)
        {
            switch (idioma)
            {
                case (int)Idioma.Espanhol: return "<h1>Reporte de Formas</h1>";
                case (int)Idioma.Italiano: return "<h1>Rapporto sulle forme</h1>";
                default: return "<h1>Shapes report</h1>";
            }
        }

        public static string Rodape(int idioma, int total, decimal perimetro, decimal area)
        {
            string rotuloTotal = "TOTAL:<br/>" + total + " ";
            string rotuloFormas = idioma == (int)Idioma.Espanhol ? "formas" : idioma == (int)Idioma.Italiano ? "forme" : "shapes";
            string rotuloPerimetro = idioma == (int)Idioma.Espanhol || idioma == (int)Idioma.Italiano ? "Perimetro" : "Perimeter";
            return rotuloTotal + rotuloFormas + " " + rotuloPerimetro + " " + perimetro.ToString("#.##") + " Area " + area.ToString("#.##");
        }

        public static string ListaVazia(int idioma)
        {
            switch (idioma)
            {
                case (int)Idioma.Espanhol: return "<h1>Lista vacía de formas!</h1>";
                case (int)Idioma.Italiano: return "<h1>Lista vuota di forme!</h1>";
                default: return "<h1>Empty list of shapes!</h1>";
            }
        }
    }
}
