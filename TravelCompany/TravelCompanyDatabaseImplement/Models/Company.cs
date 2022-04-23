using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanyDatabaseImplement.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string NameResponsible { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("CompanyId")]
        public virtual List<CompanyCondition> CompanyConditions { get; set; }
    }
}
