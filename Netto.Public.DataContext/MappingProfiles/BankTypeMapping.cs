using AutoMapper;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.MappingProfiles
{
    public class BankTypeMapping : Profile
    {
        public BankTypeMapping()
        {
            CreateMap<BankTypeMapping, BankTypeModel>().ReverseMap();
        }
    }
}
