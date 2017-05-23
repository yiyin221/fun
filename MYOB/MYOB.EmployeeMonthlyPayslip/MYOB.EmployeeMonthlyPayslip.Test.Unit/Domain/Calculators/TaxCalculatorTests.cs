using NUnit.Framework;
using Ploeh.AutoFixture;
using MYOB.EmployeeMonthlyPayslip.Domain.Calculators;

namespace MYOB.EmployeeMonthlyPayslip.Test.Unit.Domain.Calculators
{
    [TestFixture]
    public class TaxCalculatorTests
    {
        private TestContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new TestContext();
        }

        [TestCase(18000, 0)]
        [TestCase(37000, 3572)]
        [TestCase(50000, 7797)]
        [TestCase(80000, 17547)]
        [TestCase(280000, 99547)]
        public void Calculate_tax_correct(int salary, int expectedTax)
        {
            _context.Arrange(salary);

            _context.ActCalculate();

            _context.AssertExpectaions(expectedTax);
        }

        private class TestContext
        {
            private readonly IFixture _fixture;

            private TaxCalculator _sut;
            private int _salary;
            private int _resultTax;

            public TestContext()
            {
                _fixture = new Fixture();
            }

            public void Arrange(int s)
            {
                _salary = s;

                _sut = _fixture.Create<TaxCalculator>();
            }

            public void ActCalculate()
            {
                _resultTax = _sut.Calculate(_salary);
            }

            public void AssertExpectaions(int expectedResult)
            {
                Assert.AreEqual(expectedResult, _resultTax);
            }
        }
    }
}
