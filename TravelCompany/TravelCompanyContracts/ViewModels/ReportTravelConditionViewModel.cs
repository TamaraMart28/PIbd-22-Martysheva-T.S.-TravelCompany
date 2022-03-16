using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.ViewModels
{
    public class ReportTravelConditionViewModel
    {
        public string TravelName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Conditions { get; set; }
    }
}
