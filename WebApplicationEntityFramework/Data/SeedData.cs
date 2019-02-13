using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplicationEntityFramework.Data
{
    public class SeedData
    {
        private static CancellationTokenSource tokenSource;
        private UsersRemoteRepository _usersRemoteRepository;


        public SeedData(UsersRemoteRepository usersRemoteRepository) {
            tokenSource = new CancellationTokenSource();
            this._usersRemoteRepository = usersRemoteRepository;
        }

        public void Initialize(IServiceProvider serviceProvider)
        {
            DbContextOptions<MyDbContext> UsersContext = serviceProvider.GetRequiredService<DbContextOptions<MyDbContext>>();

            using (var dbContext = new MyDbContext(UsersContext))
            {
                //Ensure database is created                
                dbContext.Database.EnsureCreated();
                var users= _usersRemoteRepository.GetAsync(tokenSource.Token).Result;
                //GetRemoteData();


                if (users!=null &&  !dbContext.Users.Any())
                {
                    dbContext.Users.AddRange(users);
                    dbContext.SaveChanges();
                }
            }
        }

    }
}
