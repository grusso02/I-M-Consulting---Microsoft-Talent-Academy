using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure
{
    public class Post
    {
        [Display(Name = "User")]
        public int userId { get; set; }
        public int id { get; set; }
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Body")]
        public string body { get; set; }
    }
}
