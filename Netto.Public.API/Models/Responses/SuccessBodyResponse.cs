﻿namespace Netto.Public.API.Models.Responses
{
    public class SuccessBodyResponse<T> : SuccessResponse
    {
        public SuccessBodyResponse(T body)
        {
            Body = body;
            IsSuccess = true;
        }

        public T Body { get; set; }
    }
}
