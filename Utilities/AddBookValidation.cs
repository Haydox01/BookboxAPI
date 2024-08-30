using Bookbox.DTOs.Request;
using FluentValidation;

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

            RuleFor(x => x.Price)
                .InclusiveBetween(0, 1000000)
                .WithMessage("Book Price cannot exceed 1000000");

            RuleFor(x => x.ISBN)
                .MaximumLength(13)
                .WithMessage("ISBN has to be a maximum of 13 characters");
                
        }
    }
}
