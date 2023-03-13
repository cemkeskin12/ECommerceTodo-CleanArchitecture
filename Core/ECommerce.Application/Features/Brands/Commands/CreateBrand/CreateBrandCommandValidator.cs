using ECommerce.Domain.Entities;
using FluentValidation;

namespace ECommerce.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommandRequest>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.Picture.Length).NotNull()
                .LessThanOrEqualTo(1000000);
        }
    }
}
