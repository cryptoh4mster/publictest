using AutoMapper;
using Netto.Public.Core.Interfaces;
using Netto.Public.DataContext.Entities;
using Netto.Public.DataContext.Repositories.Interfaces;
using Netto.Public.Domain.Exceptions;
using Netto.Public.Domain.Models;
using System.Reflection;

namespace Netto.Public.Application.Services
{
    public class PublicService : IPublicService
    {
        private readonly IContactPhonesReadOnlyRepository _contactPhonesRepository;
        private readonly IBankReadOnlyRepository _bankRepository;

        public PublicService(IContactPhonesReadOnlyRepository contactPhonesRepository, 
            IBankReadOnlyRepository bankRepository)
        {
            _contactPhonesRepository = contactPhonesRepository;
            _bankRepository = bankRepository;
        }
        public async Task<ContactPhonesModel> GetContactsByCountry(string country)
        {
            var result = await _contactPhonesRepository
                .FindByPropertyOrDefault(
                    nameof(ContactPhonesModel.Country),
                    country);

            if (result == null)
            {
                throw new ContactsNotFoundException();
            }

            return result;
        }

        public async Task<List<BankModel>> GetBranchesAndATMByRequirements(AllBankRequirementsModel requirements)
        {
            var seperateRequirements = GetBankRequirements(requirements);
            var branches = await _bankRepository.FindAll(b => b.City == requirements.City & b.Address == requirements.Adress);

            if (!branches.Any())
            {
                throw new NoBranchesAndATMException();
            }

            var branchesId = branches.Select(b => b.Id).ToList();

            foreach (var requirement in seperateRequirements)
            {
                var intermidiateFilter = new List<Guid>();
                var properties = GetRequrementParameters(requirement);

                switch (requirement)
                {
                    case PopularBankRequirementsModel popularBankRequirementsModel:
                        intermidiateFilter.AddRange(await _bankRepository.GetAllFiltredBanksbyPopular(properties, branchesId));
                        break;
                    case WorkingHoursRequirementsModel workingHoursBankRequirementsModel:
                        intermidiateFilter.AddRange(await _bankRepository.GetAllFiltredBanksbyWorkingHours(properties, branchesId));
                        break;
                    case ExtrasRequirementsModel extrasBankRequirementsModel:
                        intermidiateFilter.AddRange(await _bankRepository.GetAllFiltredBanksbyExtras(properties, branchesId));
                        break;
                }

                branchesId = branchesId.Where(b => intermidiateFilter.Contains(b)).ToList();

                if (!branchesId.Any())
                {
                    throw new NoBranchesAndATMException();
                }
            }

            return branches.Where(b => branchesId.Contains(b.Id)).ToList();
        }

        private List<BankRequirementModel> GetBankRequirements(AllBankRequirementsModel bankRequirementModel)
        {
            List<BankRequirementModel> bankRequirements = new List<BankRequirementModel>();

            bankRequirements.Add((PopularBankRequirementsModel)bankRequirementModel);
            bankRequirements.Add((WorkingHoursRequirementsModel)bankRequirementModel);
            bankRequirements.Add((ExtrasRequirementsModel)bankRequirementModel);

            return bankRequirements;
        }   

        private List<string> GetRequrementParameters(BankRequirementModel bankRequirements)
        {
            var properties = new List<string>();

            if (bankRequirements == null)
            {
                return properties;
            }

            foreach (var pi in bankRequirements.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(bool))
                {
                    string value = pi.GetValue(bankRequirements).ToString();
                    if (value == "True")
                    {
                        properties.Add(pi.Name.ToString());
                    }
                }
            }

            return properties;
        }
    }
}
