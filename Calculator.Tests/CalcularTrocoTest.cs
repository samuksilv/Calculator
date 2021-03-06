﻿using Calculator.Business.Models;
using Calculator.Business.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcularTrocoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValoresInvalidos()
        {
            //arrange
            var pagamento = new PagamentoContaViewModel(0, 10);
            var calculador = new CalculaTrocoViewModel(pagamento);
        
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ValoresNullos()
        {
            //arrange 
            var calculador = new CalculaTrocoViewModel(null);
        }

        [TestMethod]
        public void CalcularTrocoSucesso()
        {
            //act
            var troco = CalcularTroco(100, 270);

            //asserts
            decimal somaCedulasMoedas = 0;
            foreach (Moeda moeda in troco.Moedas)
                somaCedulasMoedas += moeda.Valor;
            foreach (Cedula cedula in troco.Cedulas)
                somaCedulasMoedas += cedula.Valor;

            Assert.AreEqual(troco.Valor, somaCedulasMoedas);    
        }

        [TestMethod]
        public void CalcularTrocoComValoresDecimaisSucesso()
        {
            //act
            var troco = CalcularTroco(100.50m, 222.80m);

            //asserts
            decimal somaCedulasMoedas = 0;
            foreach (Moeda moeda in troco.Moedas)
                somaCedulasMoedas += moeda.Valor;
            foreach (Cedula cedula in troco.Cedulas)
                somaCedulasMoedas += cedula.Valor;

            Assert.AreEqual(troco.Valor, somaCedulasMoedas);
        }
       
        private TrocoViewModel CalcularTroco(decimal valorCompra, decimal ValoPago)
        {
            //arrange
            var pagamento = new PagamentoContaViewModel(valorCompra, ValoPago);
            var calculador = new CalculaTrocoViewModel(pagamento);

            //act
            return calculador.CalcularTroco();
        }
        

    }
}
