﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
  public  class Review : BaseEntity
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }

        #region Navigation Properties Car
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        #endregion
    }
}
