using System;
using System.Collections.Generic;
using WebApplicationEntityFramework.Data;
using Xunit;

namespace XUnitTest
{
    public class UnitTest
    {
        [Fact]
        public void TestGetEldest()
        {


            List<User> users = new List<User>();

            users.AddRange(new User[] {
                new User() { IdValue="12", BirthDate = new DateTime(1975,1,21) },
                new User() { IdValue="ABB",BirthDate = new DateTime(2008,11,1) },
                new User() { IdValue="33",BirthDate = new DateTime(1972,8,5) },
                new User() { IdValue="A-232-2",BirthDate = new DateTime(2002,4,25) },
                new User() { IdValue="ZZZ",BirthDate = new DateTime(1972,8,5) },
            });            

            Assert.Equal("33", BusinessLogic.GetEldest(users).IdValue);
        }
    }
}
