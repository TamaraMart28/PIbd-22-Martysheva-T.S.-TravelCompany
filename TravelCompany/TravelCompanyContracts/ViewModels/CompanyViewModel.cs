using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TravelCompanyContracts.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string CompanyName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string NameResponsible { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> CompanyConditions { get; set; }
    }
}
