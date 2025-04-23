using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _employeeStorage;
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            _employeeController.DeleteEmployee(1);

            _employeeStorage.Verify(s => s.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnARedirectResultObject()
        {
            var result = _employeeController.DeleteEmployee(1);

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}
