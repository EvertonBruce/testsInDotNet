using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class CustomerControllerTests
	{
		private CustomerController _customer;

        [SetUp]
        public void SetUp()
        {
            _customer = new CustomerController();
        }

        [Test]
		public void GetCustomer_IdIsZero_ReturnNotFound()
		{
			var result = _customer.GetCustomer(0);

			//NotFound
			Assert.That(result, Is.TypeOf<ActionResult>());

			//NotFound or one of its derivatives 
			Assert.That(result, Is.InstanceOf<ActionResult>());
		}
	}
}
