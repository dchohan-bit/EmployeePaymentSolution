using EmployeePaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePaymentService.Services
{
    public interface ITaxService
    {
         double calculateTax(double salary);
         double getCalculatedTax();
    }
}
