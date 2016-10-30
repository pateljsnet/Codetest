using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMovie.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Service.Tests
{
    [TestClass()]
    public class CalculatorServiceTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            // This test shows Hard Dependency that is not mock, so it will throw exception for SQL provider for Entity Framework
            // Solution is Inject provider to MovieDBContext
            CalculatorService calc = new CalculatorService();

            double expected = 9;
            double actual = calc.Calculate("Widget1", "FL");
            Assert.AreEqual(expected, actual);

            expected = 10;
            Assert.AreNotEqual(expected, actual);
            
        }
    }
}