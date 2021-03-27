using EntityHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Price : Entity
    {
        [Column(TypeName = "smallmoney")]
        public decimal PriceValue { get; set; }
        [DefaultValue("PLN")]
        [MaxLength(3)]
        [Column(TypeName = "char(3)")]
        public string Currency { get; set; }
    }
}
