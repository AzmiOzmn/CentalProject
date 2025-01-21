using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validaters
{
    public class CarValidater : AbstractValidator<Car>
    {
        public CarValidater()
        {
            RuleFor(x=>x.ModelName).NotEmpty().WithMessage("Araba Modeli Boş Bırakılamaz");
            RuleFor(x=>x.Transmission).NotEmpty().WithMessage("Vites Türü Boş Bırakılamaz");
            RuleFor(x=>x.GasType).NotEmpty().WithMessage("Yakıt türü Boş Bırakılamaz");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat Boş Bırakılamaz");
            RuleFor(x=>x.Year).NotEmpty().WithMessage("Yıl boş bırakılamaz");
            RuleFor(x=>x.Km).NotEmpty().WithMessage("Km değeri boş bırakılamaz");
            RuleFor(x=>x.Gear).NotEmpty().WithMessage("Vites boş bırakılamaz");
            RuleFor(x=>x.SeatCount).NotEmpty().WithMessage("Koltuk Sayısı boş bırakılamaz");
        }
    }
}
