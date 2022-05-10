using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BindingModels
{
    public class AddConditionBindingModel
    {
        public int Id { get; set; }
        public int ConditionId { get; set; }
        public int Count { get; set; }
    }
}
