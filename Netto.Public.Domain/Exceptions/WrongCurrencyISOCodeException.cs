using Netto.Public.Domain.Exceptions.BusinessExceptions;

namespace Netto.Public.Domain.Exceptions
{
    public class WrongCurrencyISOCodeException : BusinessNettoException
    {
        public WrongCurrencyISOCodeException() : base("Wrong currency ISO code entered")
        {

        }
    }
}
