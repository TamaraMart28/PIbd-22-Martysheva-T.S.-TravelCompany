using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.Attributes;

namespace TravelCompanyContracts.ViewModels
{
    public class TravelViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [Column(title: "Название путевки", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TravelName { get; set; }

        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> TravelConditions { get; set; }
    }
}
