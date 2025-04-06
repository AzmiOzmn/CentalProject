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
    public class IGenericManager<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericDal<T> _genericDal;

        public IGenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void TDelete(int id)
        {
          _genericDal.Delete(id);
        }

        public List<T> TGetAll()
        {
            return _genericDal.GetAll();
        }

        public T TGetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public void TInsert(T entity)
        {
         _genericDal.Insert(entity);
        }

        public void TUpdate(T entity)
        {
          _genericDal.Update(entity);
        }
    }
}
