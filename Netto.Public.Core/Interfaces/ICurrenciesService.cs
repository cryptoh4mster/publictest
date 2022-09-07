using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netto.Public.Domain.Models;

namespace Netto.Public.Core.Interfaces
{
    public interface ICurrenciesService
    {
        Task<IEnumerable<CurrencyModel>> GetCurrencies();
    }
}
