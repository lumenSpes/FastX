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
    internal class ManagerRepo : Repo, IRepo<Manager, int, Manager>
    {
        public Manager Create(Manager obj)
        {
            db.Managers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Managers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Manager> Read()
        {
            return db.Managers
                .Include(m => m.User)
                .Include(m => m.Branch)
                .ToList();
        }

        public Manager Read(int id)
        {
            return db.Managers
                .Include(m => m.User)
                .Include(m => m.Branch)
                .FirstOrDefault(m => m.ManagerId == id);
        }

        public Manager Update(Manager obj)
        {
            var ex = Read(obj.UserId);
            
            if(ex == null) return null;

            ex.UserId = obj.UserId;
            ex.Level = obj.Level;
            ex.BranchId = obj.BranchId;

            db.Managers.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
