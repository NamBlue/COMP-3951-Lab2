using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTests
{
    public partial class CalculationTests
    {
        [TestMethod]
        public void TestClearButton()
        {
            //Arrange
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();
            double operand1 = gen.NextDouble() * gen.Next();
            double operand2 = gen.NextDouble() * gen.Next();

            //Act
            calc._operands.Add(operand1);
            calc._operands.Add(operand2);
            calc._operators.Add("+");
            calc.clear();

            //Assert
            Assert.AreEqual(0, calc._total);
            Assert.IsTrue(calc._total == 0);
            Assert.IsTrue(calc._display.Text.ToString() == "0");
        }

        [TestMethod]
        public void TestCalculatorInitialSetup()
        {
            //Arrange
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();

            //Assert
            Assert.IsTrue(calc._memoryGroupbox.Visible == false);
            Assert.IsTrue(calc._clearGroupbox.Visible == false);
            Assert.IsTrue(calc._opertGroupbox.Visible == false);
            Assert.IsTrue(calc._memoryGroupbox.Visible == false);
        }

        [TestMethod]
        public void TestOverflow()
        {
            //Arrange
            SimpleCalculator.SimpleCalculator._disableMessageBox = true;
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();
            double operand1 = 10;
            double operand2 = 10;
            int i;

            //Act
            for (i = 0; i < 100; i++) {
                calc._operands.Add(operand1);
                calc._operands.Add(operand2);
                calc._operators.Add("*");
                calc.calculate();
            }

            //Assert
            //No Exception thrown
            //Check if calculator is still in good state after calculate
            Assert.IsTrue(calc._total == 0
                                && calc._operands.Count == 0
                                && calc._operators.Count == 0
                                && String.IsNullOrWhiteSpace(calc._equationDisplay.Text));
        }
    }
}
