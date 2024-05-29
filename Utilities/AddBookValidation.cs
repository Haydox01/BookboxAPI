using Bookbox.Dto;

namespace Bookbox.Utilities
{
    public class AddBookValidation :  AbstractValidator<AddBookDto>
    {
        public AddBookValidation()
        {
            RuleFor(x => x.Title)
               .NotEmpty()
               .WithMessage("Title has to be a minimum of 1 characters")
               .MaximumLength(30);
        }
    }
}
