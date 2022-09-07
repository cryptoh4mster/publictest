using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Netto.Public.API.Controllers.Base;
using Netto.Public.API.Models.Requests;
using Netto.Public.Core.Interfaces;
using Netto.Public.DataContext.Repositories.Interfaces;
using Netto.Public.Domain.Models;

namespace Netto.Public.API.Controllers.BankControllerVersions.v1
{
    [ApiVersion("1.0")]
    public class BankController : BaseController
    {
        private readonly IPublicService _publicService;

        public BankController(IMapper mapper, IPublicService publicService) : base(mapper)
        {
            _publicService = publicService;
        }

        [HttpGet("branches-and-atm/by-requirements")]
        public async Task<IActionResult> GetBranchesAndATMbyAllRequirements([FromQuery] AllBankRequirementsRequest request)
        {
            var requirements = _mapper.Map<AllBankRequirementsModel>(request);
            var result = await _publicService.GetBranchesAndATMByRequirements(requirements);

            return Ok(result);
        }
    }
}
