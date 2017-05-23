using System.Collections.Generic;
using MYOB.EmployeeMonthlyPayslip.Contract;

namespace MYOB.EmployeeMonthlyPayslip.Application
{
    public interface IPayslipWriter
    {
        void WritePayslip(ICollection<Payslip> payslips);
    }
}
