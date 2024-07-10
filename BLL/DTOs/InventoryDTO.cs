using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class InventoryDTO
    {
        public int InventoryId { get; set; }
        public int BranchId { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int PackagesInStock { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
