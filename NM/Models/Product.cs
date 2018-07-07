using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NM.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("amount")]
        public double Amount { get; set; }

        [Column("image")]
        public string Image { get; set; }


        [NotMapped]
        public bool Deleted { get; set; }
    }
}