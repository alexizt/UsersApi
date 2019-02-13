using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationEntityFramework.Data;

namespace WebApplicationEntityFramework.BusinessLogic
{
    public class Business
    {
        public static User GetEldestUser(IEnumerable<User> users)
        {
            User oldestUser = users.First();

            foreach (User user in users)
            {
                if (user.BirthDate < oldestUser.BirthDate)
                {
                    oldestUser = user;
                }
            }

            return oldestUser;
        }

    }
}
