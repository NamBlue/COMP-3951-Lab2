using System;
using System.Collections.Generic;
using System.Windows.Forms;

[assembly: CLSCompliant(false)]

namespace SimpleCalculator
{
    /// <summary>
    /// Purpose: The purpose of this class is to create a simple calculator
    /// on a Windows form.  The calculator is able to add, subtract, multiply
    /// and divide positive or negative numbers.  The calculator is also able
    /// to store calculations in memory and use either the keyboard or the
    /// form's buttons for input.
    /// Input: None
    /// Output: Displays a calculator to user
    /// Author: George Lee and Steven Ma
    /// Date: 21/01/2017
    /// Updated by:George Lee and Steven Ma
    /// Date: 21/01/2017
    /// Based on: n/a
    /// </summary>
    public partial class SimpleCalculator : Form
    {
        //Array of doubles to store the operands inputted
        public List<double> _operands;

        //Array to store the strings of the operators inputted
        public List<string> _operators;

        //Double used to store the calculated double before displaying to user
        public double _total;

        //String used for writting the calculator's memory function
        public string _memory;

        //Boolean value for flagging if the calculator is turned on/off
        public bool _power;

        public TextBox _display;

        /// <summary>
        /// Constructor for the Simple Calculator
        /// </summary>
        public SimpleCalculator()
        {
            InitializeComponent();
            _operands = new List<double>();
            _operators = new List<string>();
            _total = 0;
            _memory = "0";
            this.KeyPreview = true;
            memoryGroup.Visible = false;
            numGroup.Visible = false;
            opertGroup.Visible = false;
            clearGroup.Visible = false;
            picture.Visible = false;
            Display.Visible = false;
            _display = Display;
        }

        /// <summary>
        /// Calculates the final numbers and operands together and displays
        /// the calculation to the user in the display textbox
        /// </summary>
        public void calculate()
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
                                if(_operands[i+1] == 0)
                                {
                                    clear();
                                    MessageBox.Show("Error: Cannot Divide By Zero", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                _total /= _operands[i + 1];
                                break;

                            case "*":
                                _total *= _operands[i + 1];
                                break;
                        }
                    }
                }
                if(double.IsInfinity(_total))
                {
                    clear();
                    MessageBox.Show("Error: Buffer Overflow, The result is too large.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
        /// Method for adding operands and numbers to the private string using keystrokes
        /// </summary>
        /// <param name="sender">Sender object to represent the keyboard</param>
        /// <param name="e">Keypress event generated from a keypress</param>
        public void SimpleCalculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.Print("Entered SimpleCalculator_KeyPress");
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
                            if (Display.Text.Length == 1)
                            {
                                Display.Text = "0";
                            }
                            else
                            {
                                Display.Text = Display.Text.Remove(Display.Text.Length - 1, 1);
                            }
                        }
                        break;

                    case '-':
                    case '/':
                    case '+':
                    case '*':
                        _operands.Add(double.Parse(Display.Text));
                        _operators.Add(e.KeyChar.ToString());
                        Display.Text += e.KeyChar;
                        EquationDisplay.Text += Display.Text;
                        Display.Text = "0";
                        break;

                    case '=':
                    case '\r':
                        _operands.Add(double.Parse(Display.Text));
                        calculate();
                        break;

                    case '\u001b':
                        clear();
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            finally
            {
                System.Diagnostics.Debug.Print("Exiting SimpleCalculator_KeyPress");
            }
        }

        /// <summary>
        /// Resets the calculator and clears the display
        /// </summary>
        public void clear()
        {
            _total = 0;
            _operators.Clear();
            _operands.Clear();
            EquationDisplay.Text = "";
            Display.Text = "0";
        }

        #region ButtonEventHandlers

        /// <summary>
        /// Adds numbers to the display text box depending on which number
        /// button was clicked
        /// </summary>
        /// <param name="sender">Object created for the button on the form</param>
        /// <param name="e">Button event generated from a clicking on a nubmer button</param>
        private void numButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Entered numButton_Click");
            try
            {
                if (sender is Button)
                {
                    Button button = (Button)sender;
                    if (button.Text == "+/-")
                    {
                        if (Display.Text.StartsWith("-"))
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            finally
            {
                System.Diagnostics.Debug.Print("Exiting numButton_Click");
            }
        }

        /// <summary>
        /// Adds operands to the display text box depending on which
        /// operand button was clicked
        /// </summary>
        /// <param name="sender">Object generated for the operator buttons</param>
        /// <param name="e">Event generated from pressing an operator button</param>
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
        /// Checks which button was clicked in the "clearGroup"
        /// </summary>
        /// <param name="sender">Objects generated for the clearGroup buttons</param>
        /// <param name="e">Event generated from the clearGroup buttons</param>
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
                            clear();
                            break;

                        case "<-":
                            if (Display.Text.Length == 1)
                            {
                                Display.Text = "0";
                            }
                            else
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
        /// Checks which button was clicked in the Checks which button was clicked
        /// in the "memoryGroup"
        /// </summary>
        /// <param name="sender">Object generated for the memoryGroup</param>
        /// <param name="e">Event generated from the memoryGroup buttons</param>
        private void memoryButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Entered memoryButton_Click");
            try
            {
                if (sender is Button)
                {
                    Button button = (Button)sender;

                    switch (button.Text)
                    {
                        case "MS":
                            _memory = Display.Text;
                            break;

                        case "M+":
                            _memory = (double.Parse(_memory) + double.Parse(Display.Text)).ToString();
                            break;

                        case "MC":
                            _memory = "0";
                            break;

                        case "MR":
                            Display.Text = _memory;
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
                System.Diagnostics.Debug.Print("Exiting calculate");
            }
        }

        /// <summary>
        /// Method for revealing or hiding buttons depending if the power is on/off
        /// </summary>
        /// <param name="sender">Object generated for the On button</param>
        /// <param name="e">Event generated by the "on/off" button</param>
        private void buttonOn_Click(object sender, EventArgs e)
        {
            if (!_power)
            {
                memoryGroup.Visible = true;
                numGroup.Visible = true;
                opertGroup.Visible = true;
                clearGroup.Visible = true;
                picture.Visible = true;
                Display.Visible = true;
                _power = true;
            }
            else
            {
                memoryGroup.Visible = false;
                numGroup.Visible = false;
                opertGroup.Visible = false;
                clearGroup.Visible = false;
                picture.Visible = false;
                Display.Visible = false;
                _power = false;
                clear();
                _memory = "0";
            }
        }

        #endregion ButtonEventHandlers
    }
}