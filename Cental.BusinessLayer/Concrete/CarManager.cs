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
    public class CarManager : IGenericManager<Car>, ICarService
    {
        private readonly ICarDal carDal;
        public CarManager(IGenericDal<Car> genericDal, ICarDal carDal) : base(genericDal)
        {
            this.carDal = carDal;
        }

        public List<Car> TGetCarsWithBrands()
        {
          return  carDal.GetCarsWithBrands();
        }
    }
}
