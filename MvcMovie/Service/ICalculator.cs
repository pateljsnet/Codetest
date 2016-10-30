using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
namespace MvcMovie.Service
{
    interface ICalculator
    {
        IQueryable<string> GetStates();
        IQueryable<string> GetWidgets();
        string GetBasePrice(string widgetlist);
        double Calculate(string widgetlist, string statelist);
    }
}
