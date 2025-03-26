using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]

    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            var result = _math.Add(1, 3);

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            ////Generical aproach
            //Assert.That(result, Is.Not.Empty);

            ////Less General Aproach
            //Assert.That(result.Count(), Is.EqualTo(3));

            ////Especific aproach
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            //Compact Especific aproach
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //Usefull assertions
            //Assert.That(result, Is.Ordered); //Garantee that your collection is ordered
            //Assert.That(result, Is.Unique); // Gatantee that your collection has no duplicates in it
        }

        [Test]
        public void GetOddNumbers_LimitIsEqualToZero_ReturnAnEmptyArray()
        {
            var result = _math.GetOddNumbers(0);

            Assert.That(result, Is.Empty);
        }
        
        [Test]
        public void GetOddNumbers_LimitIsMinorThenZero_ReturnAnEmptyArray()
        {
            var result = _math.GetOddNumbers(-3);

            Assert.That(result, Is.Empty);
        }
    }
}
