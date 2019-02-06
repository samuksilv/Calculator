using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Models
{
    public class Compra
    {

        public Compra(decimal valor)
        {
            this.ValorTotal = valor;
            if (!this.IsValid()) throw new ArgumentException("Valor da compra não pode ser null, ou zero");
        }
              
        [Required]
        public decimal ValorTotal { get; set; }

        public bool IsValid()
        {
            return this?.ValorTotal != null && this.ValorTotal > 0;
        }
    }
}
