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
    public partial class SimpleCalculator : Form
    {
        private List<double> _operands;
        private List<string> _operators;
        private double _total;

        public SimpleCalculator()
        {
            InitializeComponent();
            _operands = new List<double>();
            _operators = new List<string>();
            _total = 0;
        }

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
                        
                    }
                    else
                    {
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
                    Display.Text = "";
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
                            Display.Text = "";
                            break;
                        case "C":
                            _total = 0;
                            _operators.Clear();
                            _operands.Clear();
                            EquationDisplay.Text = "";
                            Display.Text = "";
                            break;
                        case "<-":
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
    }
}
