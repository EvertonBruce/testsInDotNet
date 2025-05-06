using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingStorage> _bookingStorage;
        private BookingHelper _bookingHelper;

        [SetUp]
        public void SetUp()
        {
            _bookingStorage = new Mock<IBookingStorage>();
            _bookingHelper = new BookingHelper(_bookingStorage.Object);
        }

        [Test]
        public void OverlappingBookingsExist_StatusIsCancelled_ReturnEmptyString()
        {
            var booking = new Booking() { Status = "Cancelled" };

            var result = _bookingHelper.OverlappingBookingsExist(booking);

            Assert.That(result, Is.EqualTo(""));
        }
    }
}
