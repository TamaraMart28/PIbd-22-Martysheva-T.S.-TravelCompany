using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BindingModels
{
    public class TravelBindingModel
    {
        public int? Id { get; set; }
        public string TravelName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> TravelConditions { get; set; }
    }
}
