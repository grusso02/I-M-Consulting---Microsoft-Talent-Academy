using Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApp.Models
{
    public class PostViewModel
    {
        public Post Item { get; set; }
        public SelectList Users { get; set; }
    }
}
