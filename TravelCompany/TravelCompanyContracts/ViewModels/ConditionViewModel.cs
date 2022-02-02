using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace TravelCompanyContracts.ViewModels
{
    public class ConditionViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название условия")]
        public string ConditionName { get; set; }

    }
}
