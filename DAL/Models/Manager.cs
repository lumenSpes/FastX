using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Level { get; set; }

        // Foreign key relation
        [ForeignKey("Branch")]
        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual User User { get; set; }
    }
}
