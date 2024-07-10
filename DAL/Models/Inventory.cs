using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int PackagesInStock { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
