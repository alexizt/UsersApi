using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplicationEntityFramework.Data
{
    public class UsersRemoteRepository
    {
        HttpClient client = new HttpClient();

        public UsersRemoteRepository(string UsersSeedingEndpoint)
        {
            //client.BaseAddress = new Uri("https://randomuser.me/");
            client.BaseAddress = new Uri(UsersSeedingEndpoint);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<User>> GetAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            HttpResponseMessage response = await client.GetAsync("api/?results=50", cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                List<User> users = new List<User>();
                var stringResult = await response.Content.ReadAsStringAsync();
                JObject s = JObject.Parse(stringResult);

                foreach (var user in s["results"])
                {
                    users.Add(
                        new User {
                            IdValue = (string)user["id"]["value"],
                            Name = (string)user["name"]["title"] +" "+ (string)user["name"]["first"] +" "+ (string)user["name"]["last"],
                            Uuid = (string)user["login"]["uuid"],
                            Gender = (string)user["gender"],
                            Email = (string)user["email"],
                            BirthDate = (DateTime)user["dob"]["date"],
                            UserName = (string)user["login"]["username"],
                            Location = new Location() {
                                UserLocationId = (string)user["id"]["value"],
                                City = (string)user["location"]["city"],
                                PostCode = (string)user["location"]["postcode"],
                                State = (string)user["location"]["state"],
                                Street = (string)user["location"]["street"]
                            }
                        }
                    );
                }
                return users;
            }
            return new List<User>();
        }
    }
}
