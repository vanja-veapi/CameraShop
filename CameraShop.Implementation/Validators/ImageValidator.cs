using CameraShop.Application.Dto.CameraDto;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators
{
    public class ImageValidator : AbstractValidator<IFormFile>
    {
        public ImageValidator()
        {
            RuleFor(x => x.ContentType).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png")).WithMessage("Picture format is not good, supported file types: jpg, jpeg or png");
            RuleFor(x => x.Length).LessThanOrEqualTo(10500000).WithMessage("Image is too large, max 10mb");
        }
    }
}
