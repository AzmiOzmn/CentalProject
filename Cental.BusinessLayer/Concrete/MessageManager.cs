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
    public class MessageManager : IGenericManager<Message>, IMessageService
    {
        public MessageManager(IGenericDal<Message> genericDal) : base(genericDal)
        {
        }
    }
}
