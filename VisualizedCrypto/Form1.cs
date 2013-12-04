using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace VisualizedCrypto
{
    public partial class Form1 : Form
    {
        private SimpleCrypto.ICryptoService PBKDF2 = new SimpleCrypto.PBKDF2();
        public Form1()
        {
            InitializeComponent();
            InitializeTips();
        }

        private void InitializeTips()
        {
            ToolTip tips = new ToolTip();
            // Set up the delays for the ToolTip.
            tips.AutoPopDelay = 5000;
            tips.InitialDelay = 1000;
            tips.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tips.ShowAlways = true;
            //set em up
            tips.SetToolTip(label3, "The longer the salt the safer (until around 128 characters)");
            tips.SetToolTip(label2, "The more iterations, the longer it takes to hash");
            tips.SetToolTip(label4, "The password hash, which we store");
            tips.SetToolTip(label5, "The salt in the form of <length>.<salt>, which we store");
            tips.SetToolTip(label6, "This is how long it took to hash");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Stopwatch t = new Stopwatch();
                t.Start();
                textBox3.Text = PBKDF2.Compute(textBox1.Text, trackBar1.Value, trackBar2.Value);
                t.Stop();
                textBox2.Text = PBKDF2.Salt;
                textBox4.Text = t.ElapsedMilliseconds.ToString() + "ms";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                String result = PBKDF2.Compute(textBox6.Text, textBox5.Text);
                if (textBox8.Text == result)
                {
                    textBox6.BackColor = Color.Green;
                }
                else
                {
                    textBox6.BackColor = Color.Red;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox3.Text;
            textBox5.Text = textBox2.Text;
        }

    }
}
