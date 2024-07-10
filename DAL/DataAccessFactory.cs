using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Branch, int, Branch> BranchData()
        {
            return new BranchRepo();
        }
        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }
        public static IRepo<ReturnOder, int, ReturnOder> ReturnOrderData()
        {
            return new ReturnOrderRepo();
        }
        public static IRepo<User, int, User> UsersData()
        {
            return new UsersRepo();
        }
        public static IRepo<Manager, int, Manager> ManagerData()
        {
            return new ManagerRepo();
        }
        public static IRepo<Inventory, int, Inventory> InventoryData()
        {
            return new InventoryRepo();
        }
    }
}
