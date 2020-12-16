using EmployeePaymentService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePaymentService
{

    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void calculateTaxTest1()
        {
            //Arrange
            TaxService tx = new TaxService();
            double amount = 500;
            double expected = 50;

            //Act
            double actual=tx.calculateTax(amount);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void calculateTaxTest2()
        {
            //Arrange
            TaxService tx = new TaxService();
            double amount = 1000;
            double expected = 100;

            //Act
            double actual = tx.calculateTax(amount);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void getTaxedAmountTest1()
        {
            //Arrange
            TaxService tx = new TaxService();
            double amount = 500;
            double expected = 450;

            //Act
            double actual = tx.getTaxedAmount(amount);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void getTaxedAmountTest2()
        {
            //Arrange
            TaxService tx = new TaxService();
            double amount = 1000;
            double expected = 900;

            //Act
            double actual = tx.getTaxedAmount(amount);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void getAmountFromTaxTest1()
        {
            //Arrange
            TaxService tx = new TaxService();
            double tax = 100;
            double expected = 1000;

            //Act
            double actual = tx.getAmountFromTax(tax);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void getAmountFromTaxTest2()
        {
            //Arrange
            TaxService tx = new TaxService();
            double tax = 50;
            double expected = 500;

            //Act
            double actual = tx.getAmountFromTax(tax);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getActualTaxRateTest1()
        {
            //Arrange
            TaxService tx = new TaxService();
            double amount = 1000;
            double tax = 100;
            double expected = 10;

            //Act
            double actual = tx.getActualTaxRate(amount,tax);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getActualTaxRateTest2()
        {
            //Arrange
            TaxService tx = new TaxService();
            double amount = 500;
            double tax = 50;
            double expected = 10;

            //Act
            double actual = tx.getActualTaxRate(amount, tax);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCalculatedTaxRateTest1()
        {
            //Arrange
            TaxService tx = new TaxService();
            double expected = 10;

            //Act
            double actual = tx.getCalculatedTax();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCalculatedTaxRateTest2()
        {
            //Arrange
            TaxService tx = new TaxService();
            double expected = 20;

            //Act
            double actual = tx.getCalculatedTax();

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
    }
}
