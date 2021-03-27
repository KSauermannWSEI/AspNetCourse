using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AvailableService : EntityHelper.Entity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public Price Price { get; set; }
        public ServiceType ServiceType { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
