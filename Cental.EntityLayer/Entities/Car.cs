using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
   public class Car : BaseEntity
    {
        public int CarId { get; set; }
        public string ModelName { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int SeatCount { get; set; }
        public string GearType { get; set; }
        public string GasType { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public int Kilometer { get; set; }

        #region Navigation Properties Brand

        public int BrandId { get; set; } // Foreign key property
        public virtual Brand Brand { get; set; } // Navigation property

        #endregion

        #region List of Reviews
        public virtual List<Review> Reviews { get; set; }
        #endregion

        public virtual List<Booking> Bookings { get; set; }
    }
}
