using System;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Business.ViewModels
{
    public class PagamentoContaViewModel
    {
        public PagamentoContaViewModel(decimal valorCompra,decimal valorPago)
        {
            this.ValorCompra = valorCompra;
            this.ValorPago = valorPago;
            if (!this.IsValid()) throw new ArgumentException("Valor pago inferior ao valor da compra");
        }

        [Required]
        public decimal ValorCompra { get; set; }

        [Required]
        public decimal ValorPago { get; set; }

        public bool IsValid()
        {
            return ValorCompra <= ValorPago ;
        }
    }
}
