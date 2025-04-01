
using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class FizzBuzzTests
	{
		
		[Test]
		[TestCase(15)]
		[TestCase(3)]
		[TestCase(5)]
		[TestCase(null)]
		public void GetOtPut_WhenCalled_MustReturnAString(int number)
		{
			var result = FizzBuzz.GetOutput(number);

			Assert.That(result, Is.TypeOf<String>());
		}

		[Test]
		public void GetOutPut_InputIsDivisableBy3And5_ReturnFizzBuzz()
		{
			var result = FizzBuzz.GetOutput(15);

			Assert.That(result, Is.EqualTo("FizzBuzz"));
		}

		[Test]
		public void GetOutPut_InputIsDivisableBy3Only_ReturnFizz()
		{
			var result = FizzBuzz.GetOutput(3);

			Assert.That(result, Is.EqualTo("Fizz"));
		}

		[Test]
		public void GetOutPut_InputIsDivisableBy5Only_ReturnBuzz()
		{
			var result = FizzBuzz.GetOutput(5);

			Assert.That(result, Is.EqualTo("Buzz"));
		}

        [Test]
        public void GetOutPut_InputIsNotDivisableBy3Or5_ReturnTheSameNumber()
        {
            var result = FizzBuzz.GetOutput(4);

            Assert.That(result, Is.EqualTo("4"));
        }
    }
}
