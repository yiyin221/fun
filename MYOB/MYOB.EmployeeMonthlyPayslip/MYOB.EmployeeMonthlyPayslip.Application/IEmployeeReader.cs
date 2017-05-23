using System.Collections.Generic;
using MYOB.EmployeeMonthlyPayslip.Contract;

namespace MYOB.EmployeeMonthlyPayslip.Application
{
    public interface IEmployeeReader
    {
        ICollection<Employee> ReadFromFile(string path);
    }
}
