using EmployeePaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePaymentService.Services
{
    public class TaxService : ITaxService
    {
        double tax;

        public TaxService()
        {
            tax = 10;
        }
        public double calculateTax(double amount)
        {
            this.tax = amount * 0.1;
            return amount * 0.1;
        }
        public double getTaxedAmount(double amount)
        {
            return amount - (amount * 0.1);
        }
        public double getAmountFromTax(double tax)
        {
            return (100 * tax) / 10;
        }
        public double getActualTaxRate(double amount,double taxed)
        {
            return amount / taxed;
        }

        public double getCalculatedTax()
        {
            return this.tax;
        }
    }
}
