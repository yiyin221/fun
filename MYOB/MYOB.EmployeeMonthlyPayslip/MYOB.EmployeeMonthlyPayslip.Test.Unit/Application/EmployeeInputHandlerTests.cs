using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoRhinoMock;
using MYOB.EmployeeMonthlyPayslip.Application;
using Rhino.Mocks;
using System.Collections.Generic;
using MYOB.EmployeeMonthlyPayslip.Contract;

namespace MYOB.EmployeeMonthlyPayslip.Test.Unit.Application
{
    [TestFixture]
    public class EmployeeInputHandlerTests
    {
        private TestContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new TestContext();
        }

        [Test]
        public void Create_payslips_success()
        {
            _context.Arrange();

            _context.Act();

            _context.AssertAllExpectations();
        }

        private class TestContext
        {
            private readonly IFixture _fixture;

            private EmployeeInputHandler _sut;

            private IEmployeeReader _employeeReader;
            private IPayslipWriter _payslipWriter;

            private ICollection<Employee> _employees;

            public TestContext()
            {
                _fixture = new Fixture().Customize(new AutoRhinoMockCustomization());
            }

            public void Arrange()
            {
                _employees = _fixture.Create<ICollection<Employee>>();

                _employeeReader = _fixture.Freeze<IEmployeeReader>();

                _employeeReader.Stub(r => r.ReadFromFile(Arg<string>.Is.Anything))
                    .Return(_employees)
                    .Repeat
                    .Once();

                _payslipWriter = _fixture.Freeze<IPayslipWriter>();

                _payslipWriter.Expect(p => p.WritePayslip(Arg<ICollection<Payslip>>.Is.Anything))
                    .Repeat
                    .Once();

                _sut = _fixture.Create<EmployeeInputHandler>();
            }

            public void Act()
            {
                _sut.CreatePayslips();
            }

            public void AssertAllExpectations()
            {
                _employeeReader.VerifyAllExpectations();
                _payslipWriter.VerifyAllExpectations();
            }
        }
    }
}
