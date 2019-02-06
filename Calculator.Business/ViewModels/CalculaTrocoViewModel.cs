using Calculator.Business.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
using Calculator.Business.Contants;

namespace Calculator.Business.ViewModels
{
    /// <summary>
    /// Classe para calcular se é necessário troco
    /// </summary>
    public class CalculaTrocoViewModel
    {
        public CalculaTrocoViewModel()
        { }

        public CalculaTrocoViewModel(PagamentoContaViewModel pagamentoConta)
        {
            this.Compra = new Compra(pagamentoConta.ValorCompra);
            this.Pagamento = new FormaPagamento(pagamentoConta.ValorPago);
            this.Troco = this.Pagamento.Valor - this.Compra.ValorTotal;
            if (!this.IsValid()) throw new ArgumentException("Valor pago inferior ao valor da compra");
        }

        /// <summary>
        /// Pagamento 
        /// </summary>
        [Required]
        private FormaPagamento Pagamento { get; set; }

        /// <summary>
        /// Compras
        /// </summary>
        [Required]
        private Compra Compra { get; set; }

        /// <summary>
        /// valor de troco
        /// </summary>
        private decimal Troco { get; set; }

        /// <summary>
        /// precisa de troco?
        /// </summary>
        private bool NecessitaTroco => this.Pagamento.Valor > this.Compra.ValorTotal;

        private bool PagamentoIsValid()
        {
            return Pagamento?.Valor != null && Pagamento.Valor > 0 && Pagamento.Valor >= Compra.ValorTotal;
        }

        /// <summary>
        /// verifica se os dados são válidos
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return this.Compra.IsValid() && PagamentoIsValid();
        }

        /// <summary>
        /// Calcula o troco
        /// </summary>
        /// <returns></returns>
        public TrocoViewModel CalcularTroco()
        {
            if (NecessitaTroco)
            {
                var aux = Troco;
                var cedulas = CalculaCedulas();
                var moedas = CalculaMoedas();
                Troco = aux;
                return new TrocoViewModel(Troco, cedulas, moedas);
            }

            return null;
        }

        private IEnumerable<Moeda> CalculaMoedas()
        {
            var moedas = new List<Moeda>();            
            foreach (var valorMoeda in ValoresNotas.RetornaValoresMoedas())
            {
                if (Troco >= valorMoeda)
                {
                    //calcula numero de moedas com um valor x, ex: 2 moedas de 100
                    long quantMoedas = (long)(Troco / valorMoeda);

                    //loop para add na lista a quantidades de moedas com o valor x, ex: add na lista 2 moedas de 100 
                    Parallel.For(0, quantMoedas, (index) => moedas.Add(new Moeda(valorMoeda)));

                    //subtrai do valor do troco
                    Troco = Troco - quantMoedas * valorMoeda;
                }
            }

            return moedas;
        }

        private IEnumerable<Cedula> CalculaCedulas()
        {
            var cedulas = new List<Cedula>();            
            foreach (var valorCedula in ValoresNotas.RetornaValoresCedulas())
            {
                if (Troco >= valorCedula)
                {
                    //calcula numero de cedulas com um valor x, ex: 2 cédulas de 100
                    long quantCedulas = (long)(Troco / valorCedula);

                    //loop para add na lista a quantidades de cédulas com o valor x, ex: add na lista 2 cédulas de 100 
                    Parallel.For(0, quantCedulas, (index) => cedulas.Add(new Cedula(valorCedula)));

                    //subtrai do valor do troco
                    Troco = Troco - quantCedulas * valorCedula;
                }

            }

            return cedulas;
        }

    }
}
