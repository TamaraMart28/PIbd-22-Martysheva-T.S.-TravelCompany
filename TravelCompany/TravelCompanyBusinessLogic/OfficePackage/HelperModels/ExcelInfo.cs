using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportTravelConditionViewModel> TravelConditions { get; set; }
        public List<ReportCompanyConditionViewModel> CompanyConditions { get; set; }
    }
}
