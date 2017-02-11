using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();
            calc._operands.Add(3000.0);
            calc._operands.Add(6000.0);
            calc._operators.Add("+");
            calc.calculate();
            Assert.AreEqual("9000", calc._display.Text); 
        }
    }
}
