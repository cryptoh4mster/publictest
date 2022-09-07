using Netto.Public.API.Models.Responses;

namespace Netto.Public.API.Models.Responses
{
    public class ErrorBodyResponse<T> : ErrorResponse
    {
        public ErrorBodyResponse()
        {
            IsSuccess = false;
        }

        public T Body { get; set; }
    }
}
