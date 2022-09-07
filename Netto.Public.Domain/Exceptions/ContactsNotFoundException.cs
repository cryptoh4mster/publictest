using Netto.Public.Domain.Exceptions.BusinessExceptions;

namespace Netto.Public.Domain.Exceptions
{
    public class ContactsNotFoundException : BusinessNettoException
    {
        public ContactsNotFoundException() : base("Can't found contacts for this country.")
        {
        }
    }
}
