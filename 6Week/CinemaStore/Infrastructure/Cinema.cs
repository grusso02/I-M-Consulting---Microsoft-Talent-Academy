using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure
{
    public partial class Cinema
    {
        public Cinema()
        {
            Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [InverseProperty(nameof(Movie.Ciname))]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
