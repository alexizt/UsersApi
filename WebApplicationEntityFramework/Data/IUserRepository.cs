using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEntityFramework.Data
{
    public interface IUserRepository
    {
        User GetUser(string id);
        void UpdateUser(User user);
        IEnumerable<User> GetAllUsers();        
        void DeleteUser(string id);
        //User GetEldest();
    }
}
