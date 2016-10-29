using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace MvcMovie.Models
{
    public class Widget
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal BasePrice { get; set; }

        [Required]
        public bool DiscountIndicator { get; set; }

    }

}