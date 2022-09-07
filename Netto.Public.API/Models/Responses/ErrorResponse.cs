namespace Netto.Public.API.Models.Responses
{
    public class ErrorResponse : BaseResponse
    {
        public ErrorResponse()
        {
            IsSuccess = false;
        }

        public string ErrorMessage { get; set; }
        public int Code { get; set; }
    }
}
