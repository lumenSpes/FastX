using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderRepo : Repo, IRepo<Order, int, Order>
    {
        public Order Create(Order obj)
        {
            db.Orders.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Orders.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

       
        public List<Order> Read()
        {
            return db.Orders.ToList();  
        }

        public Order Read(int id)
        {
            return db.Orders.Find(id);
        }

       
        public Order Update(Order obj)  
        {
            var ex = Read(obj.OrderId);
            
            if(ex == null) return null;

            ex.CustomerId = obj.CustomerId;
            ex.InventoryId = obj.InventoryId;
            ex.Quantity = obj.Quantity;
            ex.OrderDate = obj.OrderDate;
            ex.OrderStatus = obj.OrderStatus;
            ex.DeliveryAddress = obj.DeliveryAddress;

            db.Orders.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }

        
    }
}
