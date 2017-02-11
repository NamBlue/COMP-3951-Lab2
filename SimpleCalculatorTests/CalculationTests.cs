using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTests
{
    [TestClass]
    public partial class CalculationTests
    {
        private static readonly Random gen = new Random();
        [TestMethod]
        public void TestAddition()
        {
            //Arrange
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();
            double operand1 = gen.NextDouble() * gen.Next();
            double operand2 = gen.NextDouble() * gen.Next();

            //Act
            calc._operands.Add(operand1);
            calc._operands.Add(operand2);
            calc._operators.Add("+");
            calc.calculate();

            //Assert
            Assert.AreEqual((operand1 + operand2).ToString(), calc._display.Text);
            //Check if calculator is still in good state after calculate
            Assert.IsTrue(calc._total == 0 
                                && calc._operands.Count == 0 
                                && calc._operators.Count == 0
                                && String.IsNullOrWhiteSpace(calc._equationDisplay.Text));
        }

        [TestMethod]
        public void TestSubtraction()
        {
            //Arrange
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();
            double operand1 = gen.NextDouble() * gen.Next();
            double operand2 = gen.NextDouble() * gen.Next();

            //Act
            calc._operands.Add(operand1);
            calc._operands.Add(operand2);
            calc._operators.Add("-");
            calc.calculate();

            //Assert
            Assert.AreEqual((operand1 - operand2).ToString(), calc._display.Text);
            //Check if calculator is still in good state after calculate
            Assert.IsTrue(calc._total == 0
                                && calc._operands.Count == 0
                                && calc._operators.Count == 0
                                && String.IsNullOrWhiteSpace(calc._equationDisplay.Text));
        }

        [TestMethod]
        public void TestMultiplication()
        {
            //Arrange
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();
            double operand1 = gen.NextDouble() * gen.Next();
            double operand2 = gen.NextDouble() * gen.Next();

            //Act
            calc._operands.Add(operand1);
            calc._operands.Add(operand2);
            calc._operators.Add("*");
            calc.calculate();

            //Assert
            Assert.AreEqual((operand1 * operand2).ToString(), calc._display.Text);
            //Check if calculator is still in good state after calculate
            Assert.IsTrue(calc._total == 0
                                && calc._operands.Count == 0
                                && calc._operators.Count == 0
                                && String.IsNullOrWhiteSpace(calc._equationDisplay.Text));
        }

        [TestMethod]
        public void TestDivision()
        {
            //Arrange
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();
            double operand1 = gen.NextDouble() * gen.Next();
            double operand2 = gen.NextDouble() * (gen.Next() + 1);

            //Act
            calc._operands.Add(operand1);
            calc._operands.Add(operand2);
            calc._operators.Add("/");
            calc.calculate();

            //Assert
            Assert.AreEqual((operand1 / operand2).ToString(), calc._display.Text);
            //Check if calculator is still in good state after calculate
            Assert.IsTrue(calc._total == 0
                                && calc._operands.Count == 0
                                && calc._operators.Count == 0
                                && String.IsNullOrWhiteSpace(calc._equationDisplay.Text));
        }

        [TestMethod]
        public void TestCombinationCalculation()
        {
            //Arrange
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();
            double operand1 = gen.NextDouble() * gen.Next();
            double operand2 = gen.NextDouble() * (gen.Next() + 1);
            double operand3 = gen.NextDouble() * (gen.Next() + 1);
            double operand4 = gen.NextDouble() * (gen.Next() + 1);
            double operand5 = gen.NextDouble() * (gen.Next() + 1);
            double assumedresult = ((((operand1 + operand2) - operand3) * operand4) / operand5);

            //Act
            calc._operands.Add(operand1);
            calc._operands.Add(operand2);
            calc._operands.Add(operand3);
            calc._operands.Add(operand4);
            calc._operands.Add(operand5);
            calc._operators.Add("+");
            calc._operators.Add("-");
            calc._operators.Add("*");
            calc._operators.Add("/");
            calc.calculate();

            //Assert
            Assert.AreEqual(assumedresult.ToString(), calc._display.Text);
            //Check if calculator is still in good state after calculate
            Assert.IsTrue(calc._total == 0
                                && calc._operands.Count == 0
                                && calc._operators.Count == 0
                                && String.IsNullOrWhiteSpace(calc._equationDisplay.Text));
        }

        [TestMethod]
        public void TestDivideByZero()
        {
            //Arrange
            SimpleCalculator.SimpleCalculator._disableMessageBox = true;
            SimpleCalculator.SimpleCalculator calc = new SimpleCalculator.SimpleCalculator();
            double operand1 = gen.NextDouble() * gen.Next();
            double operand2 = 0;           

            //Act
            calc._operands.Add(operand1);
            calc._operands.Add(operand2);
            calc._operators.Add("/");
            calc.calculate();

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
