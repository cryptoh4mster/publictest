using AutoMapper;
using Netto.Public.DataContext.Entities;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.MappingProfiles
{
    public class ExtrasMapping : Profile
    {
        public ExtrasMapping()
        {
            CreateMap<Extras, ExtrasModel>().ReverseMap();
        }
    }
}
