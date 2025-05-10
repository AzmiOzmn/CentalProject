using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
   public class FooterContact : BaseEntity
    {
        public int FooterContactId { get; set; }

        public string Description { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int FaxNumber { get; set; }






    }
}
