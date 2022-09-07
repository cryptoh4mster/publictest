using AutoMapper;
using Netto.Public.DataContext.Entities;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.MappingProfiles
{
    public class PopularMapping : Profile
    {
        public PopularMapping()
        {
            CreateMap<Popular, PopularModel>().ReverseMap();
        }
    }
}
