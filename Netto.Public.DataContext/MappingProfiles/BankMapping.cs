using AutoMapper;
using Netto.Public.DataContext.Entities;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.MappingProfiles
{
    public class BankMapping : Profile
    {
        public BankMapping()
        {
            CreateMap<Bank, BankModel>().ReverseMap();
        }
    }
}
