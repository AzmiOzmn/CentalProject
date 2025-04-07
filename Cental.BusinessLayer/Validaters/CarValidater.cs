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
            RuleFor(a => a.ModelName).NotEmpty().WithMessage("Araba Modeli boş bırakılamaz");
            RuleFor(a => a.Transmission).NotEmpty().WithMessage("Vites Modeli boş bırakılamaz");
            RuleFor(a => a.GasType).NotEmpty().WithMessage("Yakıt Türü boş bırakılamaz");
            RuleFor(a => a.Price).NotEmpty().WithMessage("Fiyatı boş bırakılamaz");
            RuleFor(a => a.Year).NotEmpty().WithMessage("Yılı boş bırakılamaz");
            RuleFor(a => a.Kilometer).NotEmpty().WithMessage("Km değeri boş bırakılamaz");
            RuleFor(a => a.GearType).NotEmpty().WithMessage("Vites boş bırakılamaz");
            RuleFor(a => a.SeatCount).NotEmpty().WithMessage("Koltuk sayısı boş bırakılamaz");
        }
    }
}
