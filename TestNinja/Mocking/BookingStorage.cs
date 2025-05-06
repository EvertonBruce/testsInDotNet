using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookingStorage
    {
        Booking GetOverlapingBooking(Booking booking);
    }

    public class BookingStorage : IBookingStorage
    {
        public Booking GetOverlapingBooking(Booking booking)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Id != booking.Id && b.Status != "Cancelled");

            var overlappingBooking =
                bookings.FirstOrDefault(
                    b =>
                        booking.ArrivalDate >= b.ArrivalDate
                        && booking.ArrivalDate < b.DepartureDate
                        || booking.DepartureDate > b.ArrivalDate
                        && booking.DepartureDate <= b.DepartureDate);

            return overlappingBooking;
        }
    }
}
