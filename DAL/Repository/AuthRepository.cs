using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System.Linq;

public class AuthRepository : IAuthFeature
{
    private readonly JobBdContext db;

    public AuthRepository(JobBdContext db)
    {
        this.db = db;
    }

    public User GetByEmail(string email)
    {
        return db.Users.FirstOrDefault(u => u.Email == email);
    }

    public bool Update(User user)
    {
        db.Users.Update(user);
        return db.SaveChanges() > 0;
    }
}
