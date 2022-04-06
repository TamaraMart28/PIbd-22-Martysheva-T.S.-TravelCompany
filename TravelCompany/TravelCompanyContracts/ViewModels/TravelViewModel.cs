using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TravelCompanyContracts.ViewModels
{
    public class TravelViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название путевки")]
        public string TravelName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> TravelConditions { get; set; }
    }
}
