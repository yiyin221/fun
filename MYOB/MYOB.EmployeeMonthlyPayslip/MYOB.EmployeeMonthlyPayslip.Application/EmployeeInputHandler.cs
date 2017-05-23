using System;
using System.Collections.Generic;
using MYOB.EmployeeMonthlyPayslip.Contract;
using MYOB.EmployeeMonthlyPayslip.Domain.Calculators;
using MYOB.EmployeeMonthlyPayslip.Application.Utils;

namespace MYOB.EmployeeMonthlyPayslip.Application
{
    public class EmployeeInputHandler : IEmployeeInputHandler
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly IEmployeeReader _employeeReader;
        private readonly IPayslipWriter _payslipWriter;

        public EmployeeInputHandler(ITaxCalculator taxCalculator, IEmployeeReader employeeReader, IPayslipWriter payslipWriter)
        {
            _taxCalculator = taxCalculator;
            _employeeReader = employeeReader;
            _payslipWriter = payslipWriter;
        }

        public void CreatePayslips(string path = @"..\..\..\..\Input\employees.txt")
        {
            var employees = _employeeReader.ReadFromFile(path);

            Console.WriteLine($"Found {employees.Count} employees");

            List<Payslip> payslips = new List<Payslip>();

            foreach(var e in employees)
            {
                payslips.Add(new Payslip
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    PayPeriod = e.PaymentStartDate,
                    GrossIncome = e.AnnualSalary.ToMonthly(),
                    IncomeTax = _taxCalculator.Calculate(e.AnnualSalary).ToMonthly(),
                    Super = (int)Math.Round(e.AnnualSalary.ToMonthly() * e.SuperRate, 0)
                });
            }

            foreach(var p in payslips)
            {
                Console.WriteLine($"Creating payslip for {p.Name},{p.PayPeriod}, Gross Income: {p.GrossIncome}, Income Tax:{p.IncomeTax}, Net Income: {p.NetIncome}, Super:{p.Super}");
            }

            if (payslips.Count > 0)
                _payslipWriter.WritePayslip(payslips);
        }
    }
}
