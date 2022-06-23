using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure
{
    public partial class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public int? Amount { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("ShoppingCartItems")]
        public virtual Movie Movie { get; set; }
    }
}
