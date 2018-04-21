using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace dz2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dateString = this.textBox1.Text;
            string format, resDate = "";
           CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime result = new DateTime();
            DateTime now = DateTime.Now;
            format = "dd-MM-yyyy";

            try
            {
                if (DateTime.TryParseExact(dateString, format, provider, DateTimeStyles.None, out result))
                {

                    TimeSpan difference = result - now;
                    if (radioButton1.Checked)
                    {
                        resDate = Convert.ToString(difference.TotalDays / 365.25);
                    }
                    else if(radioButton2.Checked)
                    {
                        resDate = Convert.ToString(difference.TotalDays / 30);
                    }
                    else if (radioButton3.Checked)
                    {
                        
                        resDate = Convert.ToString(difference.Days);
                    }
                    else if (radioButton4.Checked)
                    {
                        resDate = Convert.ToString((int)difference.TotalMinutes);
                    }
                    else if (radioButton5.Checked)
                    {
                        resDate = Convert.ToString((int)difference.TotalSeconds);
                    }
                }
                else
                {
                    resDate = "error";
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", dateString);
            }

            this.textBox2.Text = resDate;
        }
    }
}
