using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEntityFramework.Data
{
    public class BusinessLogic
    {
        public static User GetEldest(IEnumerable<User> users)
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
