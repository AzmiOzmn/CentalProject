﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
   public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }


        #region Navigation Properties UserSocial
        public virtual List<UserSocial> UserSocials { get; set; }


        #endregion

        public virtual List<Booking>? Bookings { get; set; }

    }
}
