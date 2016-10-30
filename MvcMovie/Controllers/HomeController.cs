using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: /Home/
        public ActionResult Index()
        {

            var StateList = from d in db.States
                           orderby d.Name
                           select d.Name;

            ViewBag.StateList = new SelectList(StateList);

            var WidgetList = from m in db.Widgets
                             select  m.Name;
            ViewBag.WidgetList = new SelectList(WidgetList);

            return View();
        }

        // POST: /Home/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string widgetlist, string statelist)
        {

            var StateList = from d in db.States
                            orderby d.Name
                            select d.Name;

            ViewBag.StateList = new SelectList(StateList);

            var WidgetList = from m in db.Widgets
                             select m.Name;
            ViewBag.WidgetList = new SelectList(WidgetList);


            var BasePrice = (from m in db.Widgets
                             where m.Name == widgetlist
                             select m.BasePrice).FirstOrDefault();

            ViewBag.BasePrice = BasePrice.ToString();
            string bp = BasePrice.ToString();

            var taxPercentage = (from d in db.States
                            where d.Name == statelist
                            select d.TaxPercentage).FirstOrDefault(); ;
            string tp = taxPercentage.ToString();

            var discountIndicator = (from m in db.Widgets
                             where m.Name == widgetlist && m.DiscountIndicator == true
                             select 0.10).FirstOrDefault(); 
            string di = discountIndicator.ToString();

            double total = Convert.ToDouble(bp)  + (Convert.ToDouble(bp)*Convert.ToDouble(tp)) - (Convert.ToDouble(bp) * Convert.ToDouble(di));
            ViewBag.TotalPrice = total.ToString();
            return View();
        }

    }
}