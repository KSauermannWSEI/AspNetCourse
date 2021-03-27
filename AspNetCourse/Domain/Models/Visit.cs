using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Visit : EntityHelper.Entity
    {
        [Column(TypeName ="smalldatetime")]
        public DateTime VisitDate { get; set; }
        public bool IsPayd { get; set; }
        public bool IsDone { get; set; }
        public Person Employee { get; set; }
        [Required]
        public Person Customer { get; set; }
        public virtual ICollection<AvailableService> AvailableServices { get; set; }
    }
}
