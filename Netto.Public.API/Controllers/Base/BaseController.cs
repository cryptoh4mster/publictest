using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Netto.Public.API.Controllers.Base
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/")]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
