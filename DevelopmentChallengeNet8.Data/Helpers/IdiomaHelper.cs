using DevelopmentChallengeNet8.Data.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallengeNet8.Data.Helpers
{
    public static class IdiomaHelper
    {
        public static CultureInfo ObterCulture(int idioma)
        {
            switch (idioma)
            {
                case (int)Idioma.Espanhol: return new CultureInfo("es");
                case (int)Idioma.Italiano: return new CultureInfo("it");
                default: return new CultureInfo("en");
            }
        }
    }
}
