using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Contants
{
    public static class ValoresNotas
    {
        public  static IEnumerable<decimal> RetornaValoresCedulas()
        {
            yield return 100;
            yield return 50;
            yield return 5;
            yield return 1;
        }

        public static IEnumerable<decimal> RetornaValoresMoedas()
        {
            yield return 0.50M;
            yield return 0.10M;
            yield return 0.05M;
            yield return 0.01M;
        }
    }
}
