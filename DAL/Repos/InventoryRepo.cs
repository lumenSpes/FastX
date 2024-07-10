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
    internal class InventoryRepo : Repo, IRepo<Inventory, int, Inventory>
    {
        public Inventory Create(Inventory obj)
        {
            db.Inventories.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Inventories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Inventory> Read()
        {
            return db.Inventories
                .Include(i => i.Branch)
                .ToList();
        }

        public Inventory Read(int id)
        {
            return db.Inventories
                .Include(i => i.Branch)
                .FirstOrDefault(i => i.InventoryId == id);
        }

        public Inventory Update(Inventory obj)
        {
            var ex = Read(obj.InventoryId);
            
            if(ex == null) return null;

            ex.BranchId = obj.BranchId;
            ex.Address = obj.Address;
            ex.Capacity = obj.Capacity;
            ex.PackagesInStock = obj.PackagesInStock;

            db.Inventories.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
