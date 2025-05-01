using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class BookingManager : IGenericManager<Booking> , IBookingService
    {
        private readonly IBookingDal bookingDal;
        public BookingManager(IGenericDal<Booking> genericDal, IBookingDal bookingDal) : base(genericDal)
        {
            this.bookingDal = bookingDal;
        }

        public List<Booking> TUsersBookings(int id)
        {
            return bookingDal.UsersBookings(id);
        }
    }
}
