using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MYOB.EmployeeMonthlyPayslip.Contract;

namespace MYOB.EmployeeMonthlyPayslip.Application
{
    public class EmployeeReader : IEmployeeReader
    {
        public ICollection<Employee> ReadFromFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new NullReferenceException(nameof(path));

            return File.ReadLines(path)
               .Select(e => Map(e.Split(',')))
               .ToList();
        }

        private Employee Map(string[] strs)
        {
            return new Employee
            {
                FirstName = strs[0],
                LastName = strs[1],
                AnnualSalary = int.Parse(strs[2]),
                SuperRate = int.Parse(strs[3].Split('%').First()) / 100d,
                PaymentStartDate = strs[4]
            };
        }
    }
}
