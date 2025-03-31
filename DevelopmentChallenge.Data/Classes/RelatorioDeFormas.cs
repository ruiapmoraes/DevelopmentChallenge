using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class RelatorioDeFormas
    {
        public static string Imprimir(List<IFormaGeometrica> formas, int idioma)
        {
            if (formas == null || !formas.Any())
                return Localizacao.ListaVazia(idioma);

            var sb = new StringBuilder();
            sb.Append(Localizacao.Cabecalho(idioma));

            var agrupado = formas.GroupBy(f => f.GetType()).Select(g => new
            {
                Forma = g.First(),
                Quantidade = g.Count(),
                Area = g.Sum(f => f.CalcularArea()),
                Perimetro = g.Sum(f => f.CalcularPerimetro())
            });

            foreach (var grupo in agrupado)
            {
                sb.Append(grupo.Quantidade + " " + grupo.Forma.Nome(idioma, grupo.Quantidade) + " | Area " + grupo.Area.ToString("#.##") + " | ");
                sb.Append((idioma == (int)Idioma.Espanhol || idioma == (int)Idioma.Italiano ? "Perimetro" : "Perimeter"));
                sb.Append(" " + grupo.Perimetro.ToString("#.##") + " <br/>");
            }

            var total = formas.Count;
            var totalArea = formas.Sum(f => f.CalcularArea());
            var totalPerimetro = formas.Sum(f => f.CalcularPerimetro());

            sb.Append(Localizacao.Rodape(idioma, total, totalPerimetro, totalArea));

            return sb.ToString();
        }
    }
}
