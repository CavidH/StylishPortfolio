using FluentValidation;
using StylishPortfolio.Areas.AdminPortfolio.ViewModels;

namespace StylishPortfolio.Areas.AdminPortfolio.Validators
{
    public class ProjectEntityValidator : AbstractValidator<CreateVM>
    {
        public ProjectEntityValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(p => p.Summary)
               .NotNull()
               .NotEmpty();
            RuleFor(p => p.ImageFile)
                .NotNull()
                .NotEmpty();

        }
    }
}
