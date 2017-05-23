using System;

namespace MYOB.EmployeeMonthlyPayslip.Application.Utils
{
    public static class IncomeEx
    {
        public static int ToMonthly(this int annual)
        {
            return (int)Math.Round(annual / 12d, 0);
        }
    }
}
