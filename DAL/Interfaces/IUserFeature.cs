using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserFeature
    {
        List<User> GetByRole(string role);
        bool ChangeRole(int userId, string newRole);

        Dictionary<string, int> GetUserCountByRole();
        List<User> SearchByNameOrEmail(string keyword);
    }
}
