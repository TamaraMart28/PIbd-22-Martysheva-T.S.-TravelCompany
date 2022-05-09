using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TravelCompanyContracts.Attributes;

namespace TravelCompanyContracts.ViewModels
{
    public class ConditionViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [Column(title: "Название условия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ConditionName { get; set; }
    }
}
