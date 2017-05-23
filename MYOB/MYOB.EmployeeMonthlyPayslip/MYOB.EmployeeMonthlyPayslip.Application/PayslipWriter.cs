using System.IO;
using System.Collections.Generic;
using MYOB.EmployeeMonthlyPayslip.Contract;

namespace MYOB.EmployeeMonthlyPayslip.Application
{
    public class PayslipWriter : IPayslipWriter
    {
        public void WritePayslip(ICollection<Payslip> payslips)
        {
            var outputPath = @"..\..\..\..\Output\payslips.txt";

            using (StreamWriter outputFile = new StreamWriter(outputPath))
            {
                foreach (var p in payslips)
                {
                    outputFile.WriteLine($"{p.Name},{p.PayPeriod},{p.GrossIncome},{p.IncomeTax},{p.NetIncome},{p.Super}");
                }
            }
        }
    }
}
