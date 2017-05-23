using System;

namespace MYOB.EmployeeMonthlyPayslip.Domain.Calculators
{
    public class TaxCalculator : ITaxCalculator
    {
        public int Calculate(int salary)
        {
            if(salary < 0)
            {
                throw new ArgumentException(nameof(salary));
            }

            if (salary < 18201)
            {
                return 0;
            }
            else if (salary < 37001)
            {
                return Round(salary - 18200, 0.19);
            }
            else if(salary < 80001)
            {
                return 3572 + Round(salary - 37000, 0.325);
            }
            else if(salary < 180001)
            {
                return 17547 + Round(salary - 80000, 0.37);
            }
            else
            {
                return 54547 + Round(salary - 180000, 0.45);
            }
        }

        private int Round(int salary, double rate)
        {
            return (int)Math.Round(salary * rate, 0);
        }
    }
}
