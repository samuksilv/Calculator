using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Business.ViewModels
{
    public class PagamentoContaViewModel
    {
        public PagamentoContaViewModel()
        {
            if (!this.IsValid()) throw new ArgumentException("Valor pago inferior ao valor da compra");
        }

        public PagamentoContaViewModel(decimal valorCompra,decimal valorPago)
        {
            this.ValorCompra = valorCompra;
            this.ValorPago = valorPago;
            if (!this.IsValid()) throw new ArgumentException("Valor pago inferior ao valor da compra");
        }

        [Required]
        [Display(Name ="Valor da compra")]        
        public decimal ValorCompra { get; set; }

        [Required]
        [Display(Name = "Valor pago")]        
        public decimal ValorPago { get; set; }

        public bool IsValid()
        {
            return ValorCompra <= ValorPago && ValorCompra >0 && ValorPago >0;
        }
    }
}
