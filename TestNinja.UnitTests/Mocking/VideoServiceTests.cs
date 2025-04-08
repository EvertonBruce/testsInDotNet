

using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class VideoServiceTests
	{
		[Test]
		public void ReadVideoTitle_EmptyFile_ReturnsError()
		{
			var service = new VideoService(new MockFileReader());

			var result = service.ReadVideoTitle();

			Assert.That(result, Does.Contain("error").IgnoreCase);
		}
	}
}
