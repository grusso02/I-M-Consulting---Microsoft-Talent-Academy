using Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserDAL
    {
        private readonly string _url = "https://jsonplaceholder.typicode.com/users";

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            User giovanni = new User();
            IEnumerable<User> users = null;
            HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync(_url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonSerializer.Deserialize<IEnumerable<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return users;
        }
    }
}
