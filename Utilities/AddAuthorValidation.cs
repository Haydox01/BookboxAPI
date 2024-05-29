using Bookbox.DTOs;

namespace Bookbox.Utilities
{
    public class AddAuthorValidation : AbstractValidator<AddAuthorDto>
    {
        public AddAuthorValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name has to be a minimum of 3 characters")
                .MaximumLength(30);


        }
    }
}
