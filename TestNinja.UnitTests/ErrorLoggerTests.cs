using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class ErrorLoggerTests
	{
        private ErrorLogger _errorLogger;

        [SetUp]
        public void SetUp()
        {
            _errorLogger = new ErrorLogger();
        }

        [Test]
		public void Log_WhenCalled_Set_TheLastErrorProperty()
		{
			_errorLogger.Log("b");

			Assert.That(_errorLogger.LastError, Is.EqualTo("b"));
		}

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            Assert.That(() => _errorLogger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;

            _errorLogger.ErrorLogged += (sender, args) => { id = args; };

            _errorLogger.Log("b");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
