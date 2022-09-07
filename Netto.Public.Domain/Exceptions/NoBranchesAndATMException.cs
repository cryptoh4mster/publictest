using Netto.Public.Domain.Exceptions.BusinessExceptions;

namespace Netto.Public.Domain.Exceptions
{
    public class NoBranchesAndATMException : BusinessNettoException
    {
        public NoBranchesAndATMException() : base("No banks are suitable for the requirements.")
        {
        }
    }
}
