using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure
{
    [Table("MovieActor")]
    public partial class MovieActor
    {
        [Key]
        public int ActorId { get; set; }
        [Key]
        public int MovieId { get; set; }

        [ForeignKey(nameof(ActorId))]
        [InverseProperty("MovieActors")]
        public virtual Actor Actor { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieActors")]
        public virtual Movie Movie { get; set; }
    }
}
