using Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PostDAL : IPostDAL
    {
        private readonly string _url = "https://jsonplaceholder.typicode.com/posts";

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            IEnumerable<Post> posts = null;
            HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync(_url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<IEnumerable<Post>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return posts;
        }
    }
}
