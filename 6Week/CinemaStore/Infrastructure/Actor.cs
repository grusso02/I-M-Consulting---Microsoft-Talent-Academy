using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActors = new HashSet<MovieActor>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Bio { get; set; }

        [InverseProperty(nameof(MovieActor.Actor))]
        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }
}
