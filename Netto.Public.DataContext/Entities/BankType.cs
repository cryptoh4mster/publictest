using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netto.Public.DataContext.Entities
{
    public class BankType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bank> Bank { get; set; }
    }
}
