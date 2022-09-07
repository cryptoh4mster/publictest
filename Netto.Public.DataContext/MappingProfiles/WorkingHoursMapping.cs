using AutoMapper;
using Netto.Public.DataContext.Entities;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.MappingProfiles
{
    public class WorkingHoursMapping : Profile
    {
        public WorkingHoursMapping()
        {
            CreateMap<WorkingHours, WorkingHoursModel>().ReverseMap();
        }
    }
}
