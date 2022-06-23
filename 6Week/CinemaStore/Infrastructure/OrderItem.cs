using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure
{
    public partial class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int? Amount { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public int? MovieId { get; set; }
        public int? OrderId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("OrderItems")]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderItems")]
        public virtual Order Order { get; set; }
    }
}
