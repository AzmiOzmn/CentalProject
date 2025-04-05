﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
   public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        #region List of Cars
        public List<Car> Cars { get; set; }
        #endregion
    }
}
