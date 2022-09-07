using AutoMapper;
using Netto.Public.DataContext.Entities;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.MappingProfiles
{
    public class ContactPhonesMapping : Profile
    {
        public ContactPhonesMapping()
        {
            CreateMap<ContactPhones, ContactPhonesModel>().ReverseMap();
        }
    }
}
