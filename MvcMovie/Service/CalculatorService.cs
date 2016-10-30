using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Service
{
    public class CalculatorService : ICalculator
    {
        private MovieDBContext db = new MovieDBContext();

        public IQueryable<string> GetStates()
        {
            var StateList = from d in db.States
                            orderby d.Name
                            select d.Name;
            return StateList;
        }


        public IQueryable<string> GetWidgets()
        {
            var WidgetList = from m in db.Widgets
                             select m.Name;
            return WidgetList;
        }

        public string GetBasePrice(string widgetlist)
        {
            var BasePrice = (from m in db.Widgets
                             where m.Name == widgetlist
                             select m.BasePrice).FirstOrDefault();

            return BasePrice.ToString();
        }

        public double Calculate(string widgetName, string stateName)
        {
            var BasePrice = (from m in db.Widgets
                             where m.Name == widgetName
                             select m.BasePrice).FirstOrDefault();

            string bp = BasePrice.ToString();

            var taxPercentage = (from d in db.States
                                 where d.Name == stateName
                                 select d.TaxPercentage).FirstOrDefault(); ;
            string tp = taxPercentage.ToString();

            var discountIndicator = (from m in db.Widgets
                                     where m.Name == widgetName && m.DiscountIndicator == true
                                     select 0.10).FirstOrDefault();
            string di = discountIndicator.ToString();

            double total = Convert.ToDouble(bp) + (Convert.ToDouble(bp) * Convert.ToDouble(tp)) - (Convert.ToDouble(bp) * Convert.ToDouble(di));
            return total;
        }

        
    }
}