using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    /// <summary>
    /// Purpose: To create a simple calculator.  
    /// Input: None
    /// Output: Displays a calculator
    /// Author: George Lee and Steven Ma
    /// Date: 21/01/2017
    /// Updated by:George Lee and Steven Ma
    /// Date: 21/01/2017
    /// Based on: https://goo.gl/cMiPAE
    /// </summary>
    public partial class SimpleCalculator : Form
    {
        private List<double> _operands;
        private List<string> _operators;
        private double _total;
        private Boolean power = false;

        /// <summary>
        /// Constructor for the Simple Calculator
        /// </summary>
        public SimpleCalculator()
        {
            InitializeComponent();
            _operands = new List<double>();
            _operators = new List<string>();
            _total = 0;
            this.KeyPreview = true;
            memoryGroup.Visible = false;
            numGroup.Visible = false;
            opertGroup.Visible = false;
            clearGroup.Visible = false;
            bracketGroup.Visible = false;
            picture.Visible = false;
            Display.Visible = false;
        }

        /// <summary>
        /// Checks the type of number button clicked to display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Entered numButton_Click");
            try
            {
                if(sender is Button)
                {
                    Button button = (Button)sender;
                    if (button.Text == "+/-")
                    {
                        if(Display.Text.StartsWith("-"))
                        {
                            Display.Text = Display.Text.Remove(0, 1);
                        }
                        else
                        {
                            Display.Text = Display.Text.Insert(0, "-");
                        }
                    }
                    else
                    {
                        if (Display.Text.StartsWith("0"))
                        {
                            Display.Text = Display.Text.Remove(0, 1);
                        }
                        Display.Text += button.Text;
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            finally
            {
                System.Diagnostics.Debug.Print("Exiting numButton_Click");
            }
        }

        /// <summary>
        /// Checks the type of operator clicked to use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void operatorButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Entered operatorButton_Click");
            try
            {
                if (sender is Button)
                {
                    Button button = (Button)sender;

                    if (!String.IsNullOrWhiteSpace(Display.Text))
                    {
                        _operands.Add(double.Parse(Display.Text));
                    }
                    _operators.Add(button.Text);
                    Display.Text += button.Text;
                    EquationDisplay.Text += Display.Text;
                    Display.Text = "0";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            finally
            {
                System.Diagnostics.Debug.Print("Exiting operatorButton_Click");
            }
        }

        /// <summary>
        /// Checks whether the user wishes to clear all, clear screen, backspace or evaluate the expression
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Entered calculateButton_Click");
            try
            {
                if (sender is Button)
                {
                    Button button = (Button)sender;

                    switch (button.Text)
                    {
                        case "CE":
                            Display.Text = "0";
                            break;
                        case "C":
                            _total = 0;
                            _operators.Clear();
                            _operands.Clear();
                            EquationDisplay.Text = "";
                            Display.Text = "0";
                            break;
                        case "<-":
                            if(!string.IsNullOrWhiteSpace(Display.Text))
                            {
                                Display.Text = Display.Text.Remove(Display.Text.Length - 1, 1);
                            }                            
                            break;
                        case "=":
                            _operands.Add(double.Parse(Display.Text));
                            EquationDisplay.Text += Display.Text;
                            calculate();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            finally
            {
                System.Diagnostics.Debug.Print("Exiting calculateButton_Click");
            }
        }

        /// <summary>
        /// Calculates the numbers added depending which operand was clicked
        /// </summary>
        private void calculate()
        {
            System.Diagnostics.Debug.Print("Entered calculate");
            try
            {
                _total = _operands[0];
                for (int i = 0; i < _operands.Count - 1; i++)
                {
                    if (_operators[i] != null)
                    {
                        switch (_operators[i])
                        {
                            case "+":
                                _total += _operands[i + 1];
                                break;
                            case "-":
                                _total -= _operands[i + 1];
                                break;
                            case "/":
                                _total /= _operands[i + 1];
                                break;
                            case "*":
                                _total *= _operands[i + 1];
                                break;
                        }
                    }
                }
                Display.Text = _total.ToString();
                _total = 0;
                _operators.Clear();
                _operands.Clear();
                EquationDisplay.Text = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            finally
            {
                System.Diagnostics.Debug.Print("Exiting calculate");
            }
        }

        /// <summary>
        /// Displays text change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Display_TextChanged(object sender, EventArgs e)
        {

        }

        private void SimpleCalculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.Print("Entered calculate");
            try
            {
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    if (Display.Text.StartsWith("0"))
                    {
                        Display.Text = Display.Text.Remove(0, 1);
                    }
                    Display.Text += e.KeyChar;
                }
                switch (e.KeyChar)
                {
                    case '\b':
                        if (!string.IsNullOrWhiteSpace(Display.Text))
                        {
                            Display.Text = Display.Text.Remove(Display.Text.Length - 1, 1);
                        }
                        break;
                    case '-':
                    case '/':
                    case '+':
                    case '*':
                        if (!String.IsNullOrWhiteSpace(Display.Text))
                        {
                            _operands.Add(double.Parse(Display.Text));
                        }
                        _operators.Add(e.KeyChar.ToString());
                        Display.Text += e.KeyChar;
                        EquationDisplay.Text += Display.Text;
                        Display.Text = "0";
                        break;
                    case '=':
                    case '\r':
                        calculate();
                        break;
                    case '\u001b':
                        _total = 0;
                        _operators.Clear();
                        _operands.Clear();
                        EquationDisplay.Text = "";
                        Display.Text = "0";
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            finally
            {
                System.Diagnostics.Debug.Print("Exiting calculate");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOn_Click(object sender, EventArgs e)
        {
            if (power == false)
            {
                memoryGroup.Visible = true;
                numGroup.Visible = true;
                opertGroup.Visible = true;
                clearGroup.Visible = true;
                bracketGroup.Visible = true;
                picture.Visible = true;
                Display.Visible = true;
                power = true;
            }else
            {
                memoryGroup.Visible = false;
                numGroup.Visible = false;
                opertGroup.Visible = false;
                clearGroup.Visible = false;
                bracketGroup.Visible = false;
                picture.Visible = false;
                Display.Visible = false;
                power = false;
            }
        }
    }
}
