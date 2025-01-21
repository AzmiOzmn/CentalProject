using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrate
{
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal _abouDal;

		public AboutManager(IAboutDal abouDal)
		{
			_abouDal = abouDal;
		}

		public void TCreate(About entity)                            
		{
			_abouDal.Create(entity);
		}

		public void TDelete(int id)
		{
			_abouDal.Delete(id);
		}

		public List<About> TGetAll()
		{
			return _abouDal.GetAll();
		}

		public About TGetById(int id)
		{
			return _abouDal.GetById(id);
		}

		public void TUpdate(About entity)
		{
			_abouDal.Update(entity);
		}
	}

}
