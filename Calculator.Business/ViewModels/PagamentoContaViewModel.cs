using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Business.ViewModels
{
    public class PagamentoContaViewModel
    {
        public PagamentoContaViewModel()
        {            
        }

        public PagamentoContaViewModel(decimal valorCompra, decimal valorPago)
        {
            this.ValorCompra = valorCompra;
            this.ValorPago = valorPago;
            this.IsValid();
        }

        [Required]
        //[Display(Name ="Valor da compra")]        
        public decimal ValorCompra { get; set; }

        [Required]
        //[Display(Name = "Valor pago")]            
        public decimal ValorPago { get; set; }

        public bool IsValid()
        {
            if( ValorPago <= ValorCompra)
                throw new ArgumentException("Valor pago inferior ao valor da compra");
            if(ValorCompra <=0)
                throw new ArgumentException("Valor de compra não pode ser zero");
            if (ValorPago <= 0)
                throw new ArgumentException("Valor pago inferior ao valor da compra.");

            return true;
        }
    }
}
