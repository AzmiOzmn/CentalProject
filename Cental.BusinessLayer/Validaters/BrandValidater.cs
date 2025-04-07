using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validaters
{
    public class BrandValidater : AbstractValidator<Brand>
    {
        public BrandValidater()
        {
            RuleFor(a => a.BrandName)
                .NotEmpty().WithMessage("Marka ismi boş bırakılamaz")
                .MinimumLength(3).WithMessage("Marka ismi en az üç karakter olmalıdır.");

        }
    }
}