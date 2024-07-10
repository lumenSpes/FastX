using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReturnOrderRepo : Repo, IRepo<ReturnOder, int, ReturnOder>
    {
        public ReturnOder Create(ReturnOder obj)
        {
            db.ReturnOrders.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.ReturnOrders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<ReturnOder> Read()
        {
            return db.ReturnOrders
                .Include(r => r.Order)
                .ToList();
        }

        public ReturnOder Read(int id)
        {
            return db.ReturnOrders
                .Include(r => r.Order)
                .FirstOrDefault(r => r.ReturnId == id);
        }

        public ReturnOder Update(ReturnOder obj)
        {
            var ex = Read(obj.ReturnId);

            if(ex == null) return null;

            ex.OrderId = obj.OrderId;
            ex.ReturnReason = obj.ReturnReason;
            ex.ReturnDate = obj.ReturnDate;
            ex.ReturnStatus = obj.ReturnStatus;
            ex.RefundAmount = ex.Order.Amount;

            db.ReturnOrders.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }

    }
}
