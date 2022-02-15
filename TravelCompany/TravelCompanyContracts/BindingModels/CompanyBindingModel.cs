using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BindingModels
{
    public class CompanyBindingModel
    {
        public int? Id { get; set; }
        public string CompanyName { get; set; }
        public string NameResponsible { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> CompanyConditions { get; set; }
    }
}
