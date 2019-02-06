using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Models
{
    public class Cedula: Dinheiro
    {
        public Cedula(decimal valor) : base(valor)
        {
        }        
    }
}
