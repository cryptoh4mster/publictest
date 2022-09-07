using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Netto.Public.API.Controllers.Base;
using Netto.Public.API.Models.Requests;
using Netto.Public.API.Models.Responses;
using Netto.Public.Core.Interfaces;
using Netto.Public.Domain.Models;

namespace Netto.Public.API.Controllers.PublicControllerVersions.v1
{
    [ApiVersion("1.0")]
    public class PublicController : BaseController
    {
        private readonly IPublicService _publicService;

        public PublicController(IMapper mapper, IPublicService publicService) : base(mapper)
        {
            _publicService = publicService;
        }

        [HttpGet("contacts")]
        [ProducesResponseType(typeof(SuccessBodyResponse<ContactPhonesModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetContacts([FromQuery] ContactsRequest request)
        {
            var result = await _publicService.GetContactsByCountry(request.Country);
            return Ok(result);
        }
    }
}
