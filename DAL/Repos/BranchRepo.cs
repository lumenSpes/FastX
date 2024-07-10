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
    internal class BranchRepo : Repo, IRepo<Branch, int, Branch>
    {
        public Branch Create(Branch obj)
        {
            db.Branches.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Branches.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Branch> Read()
        {
            return db.Branches.ToList();
        }

        public Branch Read(int id)
        {
            return db.Branches.Find(id);
        }

        public Branch Update(Branch obj)
        {
            var ex = Read(obj.BranchId);

            if (ex == null)
            {
                return null;
            }

            ex.BranchName = obj.BranchName;
            ex.Location = obj.Location;
            ex.ContactNumber = obj.ContactNumber;
            ex.OpeningTime = obj.OpeningTime;
            ex.ClosingTime = obj.ClosingTime;
            ex.Is24HourBranch = obj.Is24HourBranch;

            db.Branches.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
