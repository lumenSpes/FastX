using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        [Required]
        public string SenderName { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int AssignedRiderId { get; set; }
        [Required]
        public int BranchId { get; set; }
    }
}
