using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IRepository<User> , IUserFeature
    {
        JobBdContext db;

        public UserRepository(JobBdContext db)
        {
            this.db = db;
        }

        // CRUD Method
        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public bool Create(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(User entity)
        {
            db.Users.Update(entity);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var user = Get(id);
            if (user != null) db.Users.Remove(user);
            else return false;
            return db.SaveChanges() > 0;
        }

        //Feature Method

        public List<User> SearchByNameOrEmail(string keyword)
        {
            return db.Users
                     .Where(u => u.FullName.Contains(keyword)
                              || u.Email.Contains(keyword))
                     .ToList();
        }

        public List<User> GetByRole(string role)
        {
            return db.Users
                     .Where(u => u.Role == role)
                     .ToList();
        }

        public bool ChangeRole(int userId, string newRole)
        {
            var user = db.Users.Find(userId);
            if (user == null) return false;

            user.Role = newRole;
            db.SaveChanges();
            return true;
        }

        public Dictionary<string, int> GetUserCountByRole()
        {
            return db.Users
                     .GroupBy(u => u.Role)
                     .ToDictionary(g => g.Key, g => g.Count());
        }

    }
}
