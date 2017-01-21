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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Entered numButton_Click");
            try
            {
                if(sender is Button)
                {
                    Button button = (Button)sender;
                    Display.Text += button.Text;
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
