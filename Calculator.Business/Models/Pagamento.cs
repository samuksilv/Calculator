using System.ComponentModel.DataAnnotations;

namespace Calculator.Business.Models
{
    public class FormaPagamento
    {        
       
        public FormaPagamento(decimal valor)
        {
            this.Valor= valor;
        }
       
        [Required(ErrorMessage = @"Por favor, informe um valor válido.")]
        public  decimal Valor { get;  protected set; }       
    }
}
