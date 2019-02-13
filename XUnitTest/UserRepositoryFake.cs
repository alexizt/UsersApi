using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationEntityFramework.Data;

namespace XUnitTest
{
    class UserRepositoryFake : IUserRepository
    {
        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetEldest()
        {
            return new User() { IdValue="1" };
        }

        public User GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
