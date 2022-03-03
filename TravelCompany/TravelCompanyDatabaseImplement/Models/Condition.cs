using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TravelCompanyDatabaseImplement.Models
{
    public class Condition
    {
        public int Id { get; set; }

        [Required]
        public string ConditionName { get; set; }

        [ForeignKey("ConditionId")]
        public virtual List<TravelCondition> TravelConditions { get; set; }
    }
}
