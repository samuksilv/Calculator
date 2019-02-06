using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Models
{
    public class Dinheiro : FormaPagamento
    {
        public Dinheiro(decimal valor) : base(valor)
        {
        }
       
    }
}
