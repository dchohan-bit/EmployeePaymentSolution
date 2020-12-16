using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePaymentService.Models;
using EmployeePaymentService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EmployeePaymentService.Controller
{
    [Route("api/")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ITaxService _service;

        public PaymentController(ITaxService svc)
        {
            _service = svc;
        }
        [HttpPost]
        [Route("calculateTax")]
        public ActionResult<Double> calculateTax(double salary)
        {
            double _tax = _service.calculateTax(salary);
            return _tax;
        }
        [HttpGet]
        [Route("getCalculatedTax")]
        public ActionResult<Double> getCalculatedTax()
        {
            double tax = _service.getCalculatedTax();
            return tax;
        }
    }
}