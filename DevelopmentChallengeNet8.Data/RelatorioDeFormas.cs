using DevelopmentChallengeNet8.Data.Helpers;
using DevelopmentChallengeNet8.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallengeNet8.Data
{
    public class RelatorioDeFormas
    {
        public static string Imprimir(List<IFormaGeometrica> formas, int idioma)
        {
            var cultura = IdiomaHelper.ObterCulture(idioma);

            if (formas == null || !formas.Any())
                return $"<h1>{Resource.Strings.ResourceManager.GetString("EmptyList", cultura)}</h1>";

            var sb = new StringBuilder();
            sb.Append("<h1>" + Resource.Strings.ResourceManager.GetString("ReportTitle", cultura) + "</h1>");

            var agrupado = formas.GroupBy(f => f.GetType()).Select(g => new
            {
                Forma = g.First(),
                Quantidade = g.Count(),
                Area = g.Sum(f => f.CalcularArea()),
                Perimetro = g.Sum(f => f.CalcularPerimetro())
            });

            foreach (var grupo in agrupado)
            {
                sb.Append($"{grupo.Quantidade} {grupo.Forma.Nome(idioma, grupo.Quantidade)} | ");
                sb.Append($"Area {grupo.Area.ToString("N2", cultura)} | ");
                sb.Append($"{(cultura.TwoLetterISOLanguageName == "en" ? "Perimeter" : "Perimetro")} {grupo.Perimetro.ToString("N2", cultura)} <br/>");
            }

            var total = formas.Count;
            var totalArea = formas.Sum(f => f.CalcularArea());
            var totalPerimetro = formas.Sum(f => f.CalcularPerimetro());

            var rodape = string.Format(
                Resource.Strings.ResourceManager.GetString("Total", cultura),
                total,
                totalPerimetro.ToString("N2", cultura),
                totalArea.ToString("N2", cultura)
            );

            sb.Append(rodape);

            return sb.ToString();
        }
    }
}
