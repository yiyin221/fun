namespace MYOB.EmployeeMonthlyPayslip.Domain.Calculators
{
    public interface ITaxCalculator
    {
        int Calculate(int salary);
    }
}
