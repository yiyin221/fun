using NUnit.Framework;
using MYOB.EmployeeMonthlyPayslip.Application.Utils;

namespace MYOB.EmployeeMonthlyPayslip.Test.Unit.Application.Utils
{
    [TestFixture]
    public class IncomeExTests
    {
        [TestCase(2000, 167)]
        [TestCase(1000, 83)]
        public void Convert_to_monthly_correct(int value, int expectedValue)
        {
            var result = value.ToMonthly();

            Assert.AreEqual(expectedValue, result);
        }
    }
}
