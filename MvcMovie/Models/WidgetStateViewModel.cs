using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class WidgetStateViewModel
    {

        public WidgetStateViewModel()
        {
            this.States = new List<State>();
            this.Widgets = new List<Widget>();
        }

        public List<State> States { get; set; }    // Dropdown
        public List<Widget> Widgets { get; set; }   // Dropdown
        public decimal BasePrice { get; set; }    //  From Widget
        public double DiscountAmount { get; set; }   // Calculate : 10% of BasePrice when DiscountIndicator is true
        public double SalesTax { get; set; }          // StateTtaxPercentage : TX/FL = 0%, else 5%
        public double TotalPrice { get; set; }   // TotalPrice = BasePrice - DiscountAmount + SalesTax  
    }
}