using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class BranchContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<ReturnOder> ReturnOrders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
