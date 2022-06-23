using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure
{
    public partial class Movie
    {
        public Movie()
        {
            MovieActors = new HashSet<MovieActor>();
            OrderItems = new HashSet<OrderItem>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public string MovieCategory { get; set; }
        public int? CinameId { get; set; }
        public int? ProducerId { get; set; }

        [ForeignKey(nameof(CinameId))]
        [InverseProperty(nameof(Cinema.Movies))]
        public virtual Cinema Ciname { get; set; }
        [ForeignKey(nameof(ProducerId))]
        [InverseProperty("Movies")]
        public virtual Producer Producer { get; set; }
        [InverseProperty(nameof(MovieActor.Movie))]
        public virtual ICollection<MovieActor> MovieActors { get; set; }
        [InverseProperty(nameof(OrderItem.Movie))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [InverseProperty(nameof(ShoppingCartItem.Movie))]
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
