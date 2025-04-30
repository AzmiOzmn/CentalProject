using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
   public class Booking : BaseEntity
    {
        public int BookingId { get; set; }
        public string PickupLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public bool? IsApproved { get; set; }
        public string Status { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public virtual AppUser? User { get; set; }
        public int? UserId { get; set; }
    }
}
