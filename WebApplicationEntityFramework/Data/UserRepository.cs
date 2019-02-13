using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEntityFramework.Data
{
    public class UserRepository : IUserRepository
    {

        private DbContext context;
        private DbSet<User> userEntity;


        public UserRepository(DbContext context)
        {
            this.context = context;
            userEntity = context.Set<User>();
        }

        public void DeleteUser(string id)
        {
            User user = GetUser(id);
            userEntity.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = userEntity.Include(i => i.Location).AsEnumerable();
            return result;
        }

        public User GetUser(string id)
        {
            return userEntity.Include(i => i.Location).Where(x=>x.IdValue==id).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            context.Update(user);
            context.SaveChanges();
        }

    }
}
