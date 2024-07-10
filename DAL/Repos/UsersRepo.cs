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
    internal class UsersRepo : Repo, IRepo<User, int, User>
    {
        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0)return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Users.Remove(ex);
            return db.SaveChanges()>0;
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(int id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var ex = Read(obj.UserId);
            
            if(ex == null) return null;

            ex.FirstName = obj.FirstName;
            ex.LastName = obj.LastName;
            ex.Username = obj.Username;
            ex.Email = obj.Email;
            ex.Address = obj.Address;
            ex.Password = obj.Password;
            ex.ContactNumber = obj.ContactNumber;
            ex.Role = obj.Role;

            db.Users.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
