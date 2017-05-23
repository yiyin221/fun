using Autofac;
using MYOB.EmployeeMonthlyPayslip.Domain.Calculators;
using MYOB.EmployeeMonthlyPayslip.Application;
using System;

namespace MYOB.EmployeeMonthlyPayslip.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new ContainerBuilder();

            container.RegisterType<TaxCalculator>()
                .As<ITaxCalculator>();

            container.RegisterType<EmployeeReader>()
                .As<IEmployeeReader>();

            container.RegisterType<PayslipWriter>()
                .As<IPayslipWriter>();

            container.RegisterType<EmployeeInputHandler>()
                .As<IEmployeeInputHandler>();

            container.Build().Resolve<IEmployeeInputHandler>()
                .CreatePayslips(@"..\..\..\..\Input\employees.txt");

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
