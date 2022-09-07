using AutoMapper;
using Netto.Public.API.Models.Requests;
using Netto.Public.Domain.Models;

namespace Netto.Public.API.MappingProfiles
{
    public class RequirementsMapping : Profile
    {
        public RequirementsMapping()
        {
            CreateMap<AllBankRequirementsRequest, AllBankRequirementsModel>();
        }
    }
}
