using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class HtmlFormatterTests
	{
		[Test]
		public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithTheStrongElement()
		{
			var formater = new HtmlFormatter();

			var result = formater.FormatAsBold("Test");

			// Specific
			Assert.That(result, Is.EqualTo("<strong>Test</strong>"));

			// More general
			Assert.That(result, Does.StartWith("<strong>"));
			Assert.That(result, Does.EndWith("</strong>"));
			Assert.That(result, Does.Contain("Test"));
		}
	}
}
