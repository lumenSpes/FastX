using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ManagerDTO
    {
        public int ManagerId { get; set; }

        public int UserId { get; set; }

        public string Level { get; set; }

        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual User User { get; set; }
    }
}
