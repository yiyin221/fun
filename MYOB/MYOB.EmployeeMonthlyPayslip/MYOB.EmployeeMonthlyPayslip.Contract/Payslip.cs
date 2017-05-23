namespace MYOB.EmployeeMonthlyPayslip.Contract
{
    public class Payslip
    {
        public string Name { get; set; }

        public string PayPeriod { get; set; }

        public int GrossIncome { get; set; }

        public int IncomeTax { get; set; }

        public int NetIncome { get { return GrossIncome - IncomeTax; } }

        public int Super { get; set; }
    }
}
