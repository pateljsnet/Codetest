using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;
using MvcMovie.Service;
using Autofac;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {

        // GET: /Home/
        public ActionResult Index()
        {
            var builder = new ContainerBuilder();                                      // Autofac DI Container
            builder.RegisterType<CalculatorService>().As<ICalculator>();               // Register Dependency so that it can be resolve
            var container = builder.Build();

            var StateList = container.Resolve<ICalculator>().GetStates();              // Resolve DI of CalculatorService
            ViewBag.StateList = new SelectList(StateList);

            var WidgetList = container.Resolve<ICalculator>().GetWidgets();
            ViewBag.WidgetList = new SelectList(WidgetList);

            return View();
        }

        // POST: /Home/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string widgetlist, string statelist)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CalculatorService>().As<ICalculator>();
            var container = builder.Build();

            var StateList = container.Resolve<ICalculator>().GetStates();
            ViewBag.StateList = new SelectList(StateList);

            var WidgetList = container.Resolve<ICalculator>().GetWidgets();
            ViewBag.WidgetList = new SelectList(WidgetList);

            double total = container.Resolve<ICalculator>().Calculate(widgetlist, statelist);

            ViewBag.TotalPrice = total.ToString();

            return View();
        }

    }
}