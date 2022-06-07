﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// DTO: data transfer object
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
    }
}
