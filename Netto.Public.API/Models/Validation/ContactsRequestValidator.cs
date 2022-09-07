using FluentValidation;
using Netto.Public.API.Models.Requests;

namespace Netto.Public.API.Models.Validation
{
    public class ContactsRequestValidator : AbstractValidator<ContactsRequest>
    {
        public ContactsRequestValidator()
        {
            RuleFor(x => x.Country).NotEmpty();
        }
    }
}
