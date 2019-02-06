using Calculator.Business.Models;
using System.Collections.Generic;

namespace Calculator.Business.ViewModels
{
    public class TrocoViewModel 
    {
        public IEnumerable<Cedula> Cedulas { get;  private set; }

        public IEnumerable<Moeda> Moedas { get; private set; }

        public decimal Valor { get; private set; }

        public TrocoViewModel(decimal valor, IEnumerable<Cedula> cedulas, IEnumerable<Moeda> moedas ) 
        {
            this.Cedulas = cedulas;
            this.Moedas = moedas;
            this.Valor = valor;
        }

    }
}
