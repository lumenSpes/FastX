using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ReturnOder
    {
        [Key]
        public int ReturnId { get; set; }

        // Foreign key relation
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public string ReturnReason { get; set; }

        public DateTime ReturnDate { get; set; }

        public string ReturnStatus { get; set; }

        public decimal RefundAmount { get; set; }
    }
}
