using System;

namespace MYOB.EmployeeMonthlyPayslip.Contract
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int AnnualSalary { get; set; }

        public double SuperRate { get; set; }

        public string PaymentStartDate { get; set; }
    }
}
